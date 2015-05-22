using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;

namespace Mouse.Main
{
    public static class Utils
    {
        public enum FileType { Image, SmallImage, Code, Other, NotExisted, ZERO }

        public const int RETRY_TIMES = 8;

        public static WebClient CreateWebClient(String cookie, String referer)
        {
            return CreateWebClient(null, cookie, referer);
        }

        public static WebClient CreateWebClient(Uri proxyAddr, String cookie, String referer)
        {
            //SocksWebClient client = new SocksWebClient();
            //client.Host = "127.0.0.1";
            //client.Port = 7070;
            WebClient client = new WebClient();
            InitWebClient(client, cookie, referer);
            if (proxyAddr != null)
            {
                WebProxy proxy = new WebProxy(proxyAddr);
                proxy.BypassProxyOnLocal = false;
                client.Proxy = proxy;
            }
            return client;
        }
        public static WebClient CreateWebClient(String host, int port, String cookie, String referer)
        {
            //SocksWebClient client = new SocksWebClient();
            //client.Host = "127.0.0.1";
            //client.Port = 7070;
            WebClient client = new WebClient();
            InitWebClient(client, cookie, referer);
            if (host != null)
            {
                WebProxy proxy = new WebProxy("127.0.0.1", 7070);
                proxy.BypassProxyOnLocal = false;
                client.Proxy = proxy;
            }
            return client;
        }
        public static void InitWebClient(WebClient webClient, String cookie, String referer)
        {
            webClient.Headers.Add("Cookie", cookie);
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
            webClient.Headers.Add("Accept", "image/webp,*/*;q=0.8");
            //webClient.Headers.Add("Accept-Language", "zh-cn");
            webClient.Headers.Add("Accept-Charset", "utf-8");
            if (referer != null)
            {
                webClient.Headers.Add("Referer", referer);
            }
            //webClient.Headers.Add("Accept-Encoding", "gzip, deflate");
            webClient.Encoding = Encoding.UTF8;


        }


        public static FileType CheckFileType(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                return FileType.NotExisted;
            }
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (stream.Length == 0)
                    {
                        return FileType.ZERO;
                    }
                    try
                    {
                        using (Image image = Image.FromStream(stream))
                        {
                            if (image.Width == 1)
                            {
                                return FileType.SmallImage;
                            }
                            if (stream.Length < 20000 && ImageHelper.compare(stream))
                            {
                                return FileType.SmallImage;
                            }
                            return FileType.Image;
                        }
                    }
                    catch
                    {
                    }
                    using (StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8))
                    {
                        if (reader.ReadToEnd().Contains("验证码"))
                        {
                            return FileType.Code;
                        }
                    }
                    return FileType.Other;
                }
            }
            catch
            {
                return FileType.Other;
            }
        }

        public static bool IsImage(String fileName, int picSize)
        {
            try
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(fileName))
                {
                    if (picSize == 2 && image.Width < 900
                        || picSize == 1 && image.Width < 800
                        || picSize == 0 && image.Width < 600)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsValidImage(Stream imageStream)
        {
            byte[] header = new byte[4]; // Change size if needed.
            string[] imageHeaders = new[]{
                "\xFF\xD8", // JPEG
                "BM",       // BMP
                "GIF",      // GIF
                Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71})}; // PNG

            imageStream.Read(header, 0, header.Length);

            bool isImageHeader = false;
            foreach (String imgheader in imageHeaders)
            {
                if (Encoding.ASCII.GetString(header).StartsWith(imgheader))
                {
                    isImageHeader = true;
                    break;
                }
            }

            if (isImageHeader == true)
            {
                imageStream.Seek(0, SeekOrigin.Begin);
                try
                {
                    Image.FromStream(imageStream).Dispose();
                    return true;
                }
                catch
                {

                }
            }

            return false;
        }
    }
}
