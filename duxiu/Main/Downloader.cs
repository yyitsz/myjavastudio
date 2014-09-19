using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using NLog;

namespace Mouse.Main
{
    public class Downloader
    {

        private Logger logger = LogManager.GetLogger(typeof(Downloader).Name);
        public MainForm MainForm { get; set; }
        private Random random = new Random(DateTime.Now.Millisecond);
        private volatile int minSleepSec = 0;
        private volatile int maxSleepSc = 0;

        public int MinSleepSec { get { return minSleepSec; } set {minSleepSec = value;} }
        public int MaxSleepSec { get { return maxSleepSc; } set { maxSleepSc = value; } }

        public void Download(BookParseResult result)
        {
            ThreadPool.QueueUserWorkItem(p => DoWork(result));
        }

        public void Download(AuxPageParseResult result)
        {
            ThreadPool.QueueUserWorkItem(p => DoWork(result));
        }

        private void DoWork(BookParseResult result)
        {
            try
            {

                foreach (PageParseResult param in result.PageParseResults)
                {
                    DownloadPage(result, param);
                }
                result.Finished = true;
                MainForm.SyncContext.Post(state => MainForm.Finished(result), null);
            }
            catch (AbortException)
            { }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
        }

        private bool DownloadPage(IParseResult result, PageParseResult param)
        {
            if (File.Exists(param.FullFileName))
            {
                if (Utils.IsImage(param.FullFileName))
                {
                    param.Exsit = true;
                    param.Success = true;
                    return true;
                }
                else
                {
                    File.Delete(param.FullFileName);
                }
            }

            int count = 0;
            do
            {
                param.Error = null;
                if (File.Exists(param.FullFileName))
                {
                    File.Delete(param.FullFileName);
                }
                try
                {
                    count++;

                    using (WebClient webClient = Utils.CreateWebClient(MainForm.GetProxy(), result.BookInfoParam.Cookie, result.BookInfoParam.Uri.ToString()))
                    {
                        //Utils.InitWebClient(webClient, result.BookInfoParam.Cookie);
                        webClient.DownloadFile(new Uri(param.PageUrl), param.FullFileName);
                        //result.BookInfoParam.Cookie = webClient.Headers.Get("Cookie");
                    }


                    Utils.FileType fileType = Utils.CheckFileType(param.FullFileName);

                    if (fileType == Utils.FileType.Code)
                    {
                        MainForm.SyncContext.Send(state => MainForm.InputCode(result, param), null);
                    }
                    else if (fileType == Utils.FileType.Image)
                    {
                        param.Success = true;
                        if (MaxSleepSec > MinSleepSec)
                        {
                            Thread.Sleep(random.Next(MinSleepSec, MaxSleepSec) * 1000);
                        }
                    }
                    else
                    {
                        if (fileType != Utils.FileType.NotExisted)
                        {
                            File.Delete(param.FullFileName);
                        }
                        return false;
                    }
                }
                catch (WebException webEx)
                {
                    logger.ErrorException("Error when download " + param.PageUrl + ", caused by: " + webEx.Message, webEx);
                    param.Error = webEx;
                }

            } while (count < Utils.RETRY_TIMES && param.Success == false);
            if (count >= Utils.RETRY_TIMES)
            {
                param.Success = false;
            }

            PageParseResult tmpParam = param;
            MainForm.SyncContext.Post(state => MainForm.Finished(result, tmpParam), null);
            return true;
        }

        private void DoWork(AuxPageParseResult result)
        {
            try
            {
                var keys = new List<AuxPageParseResult.PageType>();
                keys.AddRange(result.MaxNum.Keys);
                foreach (var key in keys)
                {
                    var count = result.MaxNum[key];
                    for (int i = 1; i <= count; i++)
                    {
                        PageParseResult param = result.GetPage(key, i);
                        if (param == null)
                        {
                            break;
                        }
                        bool success = DownloadPage(result, param);
                        if (success && param.Success)
                        {
                            result.AddEffectivePageResult(param);
                        }
                        else
                        {
                            //result.MaxNum[key] = (i - 1);
                            break;
                        }
                    }
                }
                result.Finished = true;
                MainForm.SyncContext.Post(state => MainForm.Finished(result), null);
            }
            catch (AbortException)
            { }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
        }

    }
}
