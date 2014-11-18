using System;
using System.Data;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace Mouse.Main
{
    public partial class MainForm : Form
    {
        private Logger logger = LogManager.GetLogger(typeof(MainForm).Name);
        //private List<String> urls = new List<string>();
        //private int urlIndex = 0;
        //private BookParseResult result;
        //private Dictionary<String, BookParseResult> results = new Dictionary<String, BookParseResult>();
        private ParseContext parseContext;
        private Downloader downloader;
        private String baseFolder;
        public SynchronizationContext SyncContext { get; private set; }

        public MainForm()
        {
            downloader = new Downloader();

            downloader.MainForm = this;
            InitializeComponent();
            downloader.MaxSleepSec = (int)txtMax.Value;
            downloader.MinSleepSec = (int)txtMin.Value;
        }

        private void LogMsg(String msg)
        {
            txtLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            txtLog.AppendText(" ");
            txtLog.AppendText(msg);
            txtLog.AppendText("\n");
        }

        private void ParseImageUrl(BookParseResult result)
        {
            BookInfoParam paramPath = result.BookInfoParam;
            result.HostUrl = paramPath.Uri.Scheme + "://" + paramPath.Uri.Host + ":" + paramPath.Uri.Port.ToString() + "/";
            //Regex regex = new Regex("(?<=<INPUT id=title value=)([^>]+)(?=type=hidden)");
            //Match match = regex.Match(paramPath.html);
            //if (match.Success)
            //{
            //    result.bookName = match.Value.Trim();
            //}
            //else
            //{
            //    result.bookName = "读秀图书";
            //}

            result.BaseFolder = paramPath.Path;
            result.BookFolder = Path.Combine(result.BaseFolder, createFileName(result.BookName));


            //Regex regex2 = new Regex("scr=(.*) rotate");
            Regex regex2 = new Regex(@"var str = ""([^""]*)"";");
            Match match2 = regex2.Match(paramPath.Html);
            if (match2.Success == false)
            {
                regex2 = new Regex(@"jpgPath\:""([^""]*)"",");
                match2 = regex2.Match(paramPath.Html);
            }
            string str = "&uf=ssr&zoom=" + paramPath.PicSize.ToString();
            //&pi=2
            AuxPageParseResult auxResult = null;
            if (result.BookInfoParam.ParseAuxPage)
            {
                if (parseContext.GetAuxPage(result.BookName) == null)
                {
                    auxResult = new AuxPageParseResult();
                    auxResult.BookName = result.BookName;
                    auxResult.BookFolder = result.BookFolder;
                    auxResult.BookInfoParam = result.BookInfoParam;
                    auxResult.HostUrl = result.HostUrl;
                    //auxResult.PreUrl = result.HostUrl + "n/";
                    auxResult.PostUrl = "?." + str;
                    parseContext.AddAuxPage(auxResult);
                }
            }


            List<PageParseResult> urlParams = new List<PageParseResult>();
            result.PageParseResults = urlParams;
            if (match2.Success)
            {
                String trueUrl = match2.Groups[1].Value;

                Regex regPageNum = new Regex(@"var spage = (\d+)\, epage = (\d+);");
                Match pageNumMatch = regPageNum.Match(paramPath.Html);
                int beginPage = 0;
                int endPage = 0;
                if (pageNumMatch.Success)
                {
                    beginPage = int.Parse(pageNumMatch.Groups[1].Value);
                    endPage = int.Parse(pageNumMatch.Groups[2].Value);
                }
                else
                {
                    regPageNum = new Regex(@"ps\:'(\d+)\-(\d+)',");
                    pageNumMatch = regPageNum.Match(paramPath.Html);
                    if (pageNumMatch.Success)
                    {
                        beginPage = int.Parse(pageNumMatch.Groups[1].Value);
                        endPage = int.Parse(pageNumMatch.Groups[2].Value);
                    }
                }
                for (int i = beginPage; i <= endPage; i++)
                {
                    PageParseResult param = new PageParseResult();
                    param.PageName = i.ToString().PadLeft(6, '0');
                    param.PageUrl = result.HostUrl + trueUrl.TrimStart('/') + param.PageName + "?." + str;
                    if (auxResult != null && auxResult.PreUrl == null)
                    {
                        auxResult.PreUrl = result.HostUrl + trueUrl.TrimStart('/');
                    }
                    param.FullFileName = Path.Combine(result.BookFolder, param.PageName + ".png");

                    urlParams.Add(param);

                }
                result.TotalPage = endPage - beginPage + 1;

            }

            //            int num = 0; 
            //while (match2.Success)
            //{
            //    PageParseResult param = new PageParseResult();
            //    String trueUrl = match2.Groups[1].Value;
            //    param.PageUrl = result.HostUrl + "n/" + match2.Value.Substring(5, match2.Value.Length - 13) + str;
            //    if (auxResult != null && auxResult.PreUrl == null)
            //    {
            //        auxResult.PreUrl = result.HostUrl + "n/" + match2.Value.Substring(5, match2.Value.Length - 21);
            //    }
            //    Regex regex3 = new Regex("/[^/]+?.&uf");
            //    Match match3 = regex3.Match(param.PageUrl);
            //    bool flag = true;
            //    char c = match3.Value[1];
            //    if (c != '!')
            //    {

            //        flag = true;
            //    }
            //    else
            //    {

            //    }

            //    param.PageName = match3.Value.Substring(1, match3.Value.Length - 6);

            //    param.FullFileName = Path.Combine(result.BookFolder, param.PageName.ToString() + ".png");

            //    if (flag)
            //    {
            //        urlParams.Add(param);
            //    }

            //    num++;
            //    match2 = match2.NextMatch();
            //}
            //result.TotalPage = num;
            logger.Debug(ListToString(urlParams));

        }



        private string ListToString<T>(List<T> urlParams)
        {
            StringBuilder sb = new StringBuilder();
            urlParams.ForEach(p => sb.AppendLine(p.ToString()));
            return sb.ToString();
        }


        public bool InputCode(IParseResult result, PageParseResult param)
        {
            string refUrl = result.HostUrl + "n/antispiderShowVerify.ac";
            InputCode2Form form = new InputCode2Form();
            form.Url = refUrl;
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else if (form.DialogResult == DialogResult.Abort)
            {
                throw new AbortException();
            }
            return false;
        }

        public bool InputCode2(IParseResult result, PageParseResult param)
        {
            bool ok = false;
            int count = 0;
            string refUrl = result.HostUrl + "n/antispiderShowVerify.ac";
            do
            {
                String code = null;
                Boolean abort = false;
                using (WebClient webClient = Utils.CreateWebClient(GetProxy(), result.BookInfoParam.Cookie, refUrl))
                {
                    // Utils.InitWebClient(webClient, result.BookInfoParam.Cookie);
                    InputCodeForm form = new InputCodeForm();
                    do
                    {
                        byte[] image = webClient.DownloadData(result.HostUrl + "n/n/processVerifyPng.ac?t=" + (2147483647L * new Random().Next()).ToString());// @"/n/n/64d08a1d97c044fef88adf6f6560c3fd/img0/096BD447CB578CCFCA66FC8E981C442ECBC58CC5BA9830DDF93199055649075EF3306C1847C2EC29107A897EADB35AA3F1874045743BB18B762C9CD94859F048A5BCDC6EEB0B431D2DF52EA5D241F9E96638425E134F3C8A5533F5BE9350B7499316D0711AACD7430D830A74F85707BA4C0E/b48/drs/processVerifyPng.ac");
                        form.Image = image;
                        form.ShowDialog(this);
                    } while (form.DialogResult != DialogResult.OK && form.DialogResult != DialogResult.Abort);
                    code = form.Code;
                    // result.BookInfoParam.Cookie = webClient.Headers.Get("Cookie");
                    abort = form.DialogResult == DialogResult.Abort;
                }
                if (abort)
                {
                    throw new AbortException();
                }
                count++;
                String changedCookie = CookieHelper.GetCookieInternal(new Uri(refUrl), false);
                try
                {
                    using (WebClient webClient = Utils.CreateWebClient(GetProxy(), changedCookie, refUrl))
                    {
                        //Utils.InitWebClient(webClient, result.BookInfoParam.Cookie);

                        String response = webClient.UploadString(result.HostUrl + "n/processVerify.ac?ucode=" + code, "");
                        // result.BookInfoParam.Cookie = webClient.Headers.Get("Cookie");
                        if (response.IndexOf("验证码") > 0)
                        {
                            ok = false;
                        }
                        else
                        {
                            ok = true;

                        }
                    }
                }
                catch (WebException webEx)
                {
                    logger.ErrorException("Error when send code. " + webEx.Message, webEx);
                }

            } while (!ok && count < 5);
            return ok;
        }




        private string CreateDir(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return path;
        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            if (this.txtUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show("URL is required");
                return;
            }
            this.InitForm();
            this.btnParse.Enabled = false;
            ParseNextUrl();

        }

        private void ParseNextUrl()
        {
            AuxPageParseResult auxResult = parseContext.GetUnfinishedAuxPage();
            if (chkAuxPage.Checked && auxResult != null)
            {
                this.Download(auxResult);
                return;
            }

            if (parseContext.HasNext())
            {
                String url = parseContext.NextUrl();

                BookParseResult result = parseContext.GetResult(url);
                if (result == null)
                {
                    LogMsg("Begin parse url " + url);
                    this.webBrowser.Navigate(url);
                    // DownloadPage(url);
                }
                else
                {
                    FillBookInfo(result);
                    this.Download(result);
                    return;
                }
            }
            else if (parseContext.Urls.Count > 0)
            {
                BookmarkerWriter bookWriter = new BookmarkerWriter();
                foreach (var var in parseContext.AuxPageParseResults.Values)
                {
                    bookWriter.Write(var);
                }
                this.btnDownload.Enabled = true;
            }
        }


        private void InitForm()
        {
            getBaseFolder();
            this.lblBookPageInfo.Text = "0-0页";
            this.lblBookInfo.Text = "图书信息暂无！";
            this.btnDownload.Enabled = false;
            parseContext = new ParseContext();
            this.txtLog.Clear();

            parseContext.AddRange(this.txtUrl.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
            logger.Info("URL: " + ListToString(parseContext.Urls));
        }

        private void ParseHtml(BookParseResult result)
        {
            BookInfoParam param = result.BookInfoParam;
            LogMsg("Parsing Book Url");
            String html = param.Html;
            Regex regex = new Regex("jpgRange =(.*);");
            Match match = regex.Match(html);
            if (match.Success)
            {
                result.PageInfo = match.Value.Substring(10, match.Value.Length - 11).Replace("\"", string.Empty) + "页";
            }
            else
            {
                Regex regex2 = new Regex("(?<=<OPTION selected value=5>)([^>]+)(?=</OPTION>)");
                Match match2 = regex2.Match(html);
                if (match2.Success)
                {
                    result.PageInfo = match2.Value;
                }
                else
                {
                    regex2 = new Regex(@"ps\:'(.+)',");
                    match2 = regex2.Match(html);
                    if (match2.Success)
                    {
                        result.PageInfo = match2.Groups[1].Value;
                    }
                }
            }
            //Regex regex3 = new Regex("(?<=id=bookinfo>)([^>]+)(?=</DIV>)");
            Regex regex3 = new Regex(@"<div id=""bookinfo"" [^>]*>([^<]*)</div>");
            Match match3 = regex3.Match(html);
            if (match3.Success)
            {
                //result.BookName = match3.Value.Trim();
                result.BookName = match3.Groups[1].Value.Trim();
            }
            else
            {
                Regex regBookInfo = new Regex("(?<=id=bookinfo[^>]*>)([^>]+)(?=</DIV>)");
                //Regex regBookInfo = new Regex("(?<=id=bookinfo>)([^>]+)(?=</DIV>)");
                Match matchBookInfo = regBookInfo.Match(html);
                if (matchBookInfo.Success)
                {
                    result.BookName = matchBookInfo.Value.Trim();

                }
                else
                {
                    Regex regex4 = new Regex("(?<=<INPUT id=title value=)([^>]+)(?=type=hidden)");
                    Match match4 = regex4.Match(html);
                    if (match4.Success)
                    {
                        result.BookName = match4.Value;
                    }
                }
            }

            LogMsg("Parsing Page Url");
            this.ParseImageUrl(result);

            if (Directory.Exists(result.BookFolder) == false)
            {
                Directory.CreateDirectory(result.BookFolder);
            }

            LogMsg(String.Format("Parsed [{0}]. TotalPage:{1}. Page Status: {2} ", result.BookName, result.TotalPage, result.PageInfo));
            LogMsg(String.Format("Save to [{0}]. ", result.BookFolder));

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.cmbPicSize.SelectedIndex = 2;
            SyncContext = SynchronizationContext.Current;
        }


        private static string createFileName(string fileName)
        {
            string pattern = @"\:|\;|\/|\\|\||\,|\*|\?|\""|\<|\>";
            Regex regex = new Regex(pattern);
            string text = regex.Replace(fileName, ".");
            if (text.Length == 0)
            {
                text = "book-" + fileName.GetHashCode();
            }
            return text;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }

        private void mnuSetting_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            if (setting.ShowDialog() == DialogResult.OK)
            {
                getBaseFolder();
            }
        }

        private void DownloadPage(String url)
        {
            Encoding gbk = Encoding.GetEncoding("GBK");
            BookParseResult result = parseContext.GetResult(parseContext.CurrentUrl);
            if (result == null)
            {
                String cookie = null;
                String html = null;
                using (WebClient webClient = Utils.CreateWebClient(GetProxy(), null, null))
                {
                    webClient.Encoding = gbk;
                    //Utils.InitWebClient(webClient, result.BookInfoParam.Cookie);
                    html = webClient.DownloadString(new Uri(url));
                    //html = Encoding.UTF8.GetString(htmlByte);
                    cookie = webClient.ResponseHeaders.Get("Set-Cookie");
                }
                //result.BookInfoParam.Cookie = webClient.Headers.Get("Cookie");

                try
                {
                    BookInfoParam param = new BookInfoParam();
                    param.PicSize = this.cmbPicSize.SelectedIndex;
                    param.Cookie = cookie;
                    param.Html = html;
                    param.Uri = new Uri(url);
                    param.Path = getBaseFolder();
                    param.ParseAuxPage = chkAuxPage.Checked;
                    result = new BookParseResult();
                    result.BookInfoParam = param;
                    ParseHtml(result);
                    bool success = parseContext.AddResult(parseContext.CurrentUrl, result);
                    if (success)
                    {
                        FillBookInfo(result);
                        Download(result);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.StackTrace);
                }
            }
        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowser.Document.Body.InnerHtml == null)
            {
                return;
            }
            BookParseResult result = parseContext.GetResult(parseContext.CurrentUrl);
            if (result == null)
            {
                try
                {
                    BookInfoParam param = new BookInfoParam();
                    param.PicSize = this.cmbPicSize.SelectedIndex;
                    param.Cookie = CookieHelper.GetCookieInternal(this.webBrowser.Url, true);
                    param.Html = this.webBrowser.Document.Body.InnerHtml;
                    param.Uri = this.webBrowser.Url;
                    param.Path = getBaseFolder();
                    param.ParseAuxPage = true;// chkAuxPage.Checked;
                    result = new BookParseResult();
                    result.BookInfoParam = param;
                    ParseHtml(result);
                    bool success = parseContext.AddResult(parseContext.CurrentUrl, result);
                    if (success)
                    {
                        FillBookInfo(result);
                        Download(result);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.StackTrace);
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (parseContext == null || parseContext.Urls.Count == 0)
            {
                MessageBox.Show("没有待解析的URL,");
                return;
            }

            parseContext.Reset();
            ParseNextUrl();

        }
        private String getBaseFolder()
        {
            if (baseFolder == null)
            {
                AppConfig config = Tools.Load();
                String path = config.BooksPath;
                bool exist = true;
                if (String.IsNullOrEmpty(path) == false && Directory.Exists(path) == false)
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        exist = true;
                    }
                    catch (Exception)
                    {
                        exist = false;
                    }
                }

                if (String.IsNullOrEmpty(path) == false && exist)
                {
                    baseFolder = path;
                }
                else
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    folderBrowserDialog.Description = "请选择存储位置";
                    while (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                    {

                    }
                    if (Directory.Exists(folderBrowserDialog.SelectedPath) == false)
                    {
                        Directory.CreateDirectory(folderBrowserDialog.SelectedPath);
                    }
                    baseFolder = folderBrowserDialog.SelectedPath;
                }
            }
            return baseFolder;
        }



        public void Finished(IParseResult result, PageParseResult param)
        {
            String errorMsg = "";
            if (param.Error != null)
            {
                errorMsg = "\nError Message: " + param.Error.Message + "\n" + param.Error.StackTrace;
            };
            LogMsg("Finished download Page: " + param.PageName + ", Success: " + param.Success + errorMsg);
        }

        public void Finished(IParseResult result)
        {
            int exist = 0;
            int success = 0;
            int fail = 0;
            result.PageParseResults.ForEach(p =>
            {
                if (p.Success)
                {
                    success++;
                }
                else
                {
                    fail++;
                }
                if (p.Exsit)
                {
                    exist++;
                };
            });

            LogMsg("Success download book: " + (success - exist) + ", Exist: " + exist + ", Failed: " + fail);
            ParseNextUrl();
        }
        public void Download(BookParseResult result)
        {
            LogMsg("Begin Download " + result.BookInfoParam.Uri.ToString());
            downloader.Download(result);
        }

        private void Download(AuxPageParseResult auxPageParseResult)
        {
            LogMsg("Begin Download Aux Page.");
            downloader.Download(auxPageParseResult);
        }

        private void FillBookInfo(BookParseResult result)
        {
            lblBookInfo.Text = result.BookName;
            lblBookPageInfo.Text = result.PageInfo;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (parseContext != null)
            {
                parseContext.Clear();
            }
            btnParse.Enabled = true;

        }
        private volatile String hostString;
        private volatile bool useProxy = false;
        public Uri GetProxy()
        {
            try
            {
                if (useProxy && String.IsNullOrEmpty(hostString) == false)
                {
                    return new Uri(hostString);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Error when create uri from " + hostString, ex);
            }
            return null;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            if (this.txtHost.Text.Trim().Length > 0 && this.txtPort.Text.Trim().Length > 0)
            {
                hostString = "http://" + this.txtHost.Text + ":" + this.txtPort.Text.ToString();
            }
            else
            {
                hostString = "";
            }
        }

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            useProxy = this.chkUseProxy.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuxPageParseResult result = new AuxPageParseResult();
            result.BookFolder = "d:\\";
            result.BookName = "test";
            PageParseResult pageParseResult = new PageParseResult();
            pageParseResult.PageName = "1";
            result.AddEffectivePageResult(pageParseResult);
            new BookmarkerWriter().Write(result);
        }

        private void txtMin_ValueChanged(object sender, EventArgs e)
        {
            if (downloader != null)
            {
                downloader.MinSleepSec = (int)txtMin.Value;
            }
        }

        private void txtMax_ValueChanged(object sender, EventArgs e)
        {
            if (downloader != null)
            {
                downloader.MaxSleepSec = (int)txtMax.Value;
            }
        }
    }
}
