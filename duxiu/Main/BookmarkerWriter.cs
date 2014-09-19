using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Mouse.Main
{
    public class BookmarkerWriter
    {
        private String FILE_SUM = "FreePic2Pdf.itf";
        private String FILE_BK = "FreePic2Pdf_bkmk.txt";

        public void Write(AuxPageParseResult result)
        {
            if (result == null || result.BookName == null)
            {
                return;
            }
            String folder = result.BookFolder;
            String title = result.BookName;
            int totalPages = result.PageParseResults.Count;
            int contentPages = result.MaxNum[AuxPageParseResult.PageType.con];
            String sumFilePath = Path.Combine(folder, FILE_SUM);
            String bkFilePath = Path.Combine(folder, FILE_BK);
            if (File.Exists(sumFilePath) == false)
            {
                using (StreamReader sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Mouse." + FILE_SUM), Encoding.GetEncoding("GBK")))
                {
                    String content = sr.ReadToEnd();
                    content = content.Replace("${BasePage}", (totalPages + 1).ToString())
                        .Replace("${Title}", title)
                        .Replace("${Subject}", title);

                    File.WriteAllText(sumFilePath, content);

                }
            }
            if (File.Exists(bkFilePath) == false)
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(bkFilePath, FileMode.Create, FileAccess.ReadWrite),Encoding.GetEncoding("GBK")))
                {
                    sw.WriteLine("封面\t" + (-totalPages).ToString());
                    if (result.MaxNum[AuxPageParseResult.PageType.cov] == 2)
                    {
                        sw.WriteLine("封底\t" + (-(totalPages - 1)).ToString());
                    }
                    if (result.MaxNum[AuxPageParseResult.PageType.bok] == 1)
                    {
                        sw.WriteLine("书名页\t" + (-(totalPages - 2)).ToString());
                    }
                    if (result.MaxNum[AuxPageParseResult.PageType.leg] == 1)
                    {
                        sw.WriteLine("版权页\t" +(-( totalPages - 3)).ToString());
                    }
                    if (result.MaxNum[AuxPageParseResult.PageType.fow]  > 0)
                    {
                        sw.WriteLine("前言\t" + (-(totalPages - 4)).ToString());
                    }
                    if (result.MaxNum[AuxPageParseResult.PageType.con]  > 0)
                    {
                        sw.WriteLine("目录\t" + (-result.MaxNum[AuxPageParseResult.PageType.con]).ToString());
                    }
                }
            }

        }

    }
}
