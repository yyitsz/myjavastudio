using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mouse.Main
{
    public class AuxPageParseResult : IParseResult
    {
        public enum PageType { cov = 1, bok, leg, fow, con };

        public BookInfoParam BookInfoParam { get; set; }
        public String HostUrl { get; set; }
        public String BookFolder { get; set; }
        public String BookName { get; set; }
        public String PreUrl { get; set; }
        public String PostUrl { get; set; }
        public Dictionary<String, PageParseResult> EffectivePages { get; private set; }
        public Dictionary<PageType, int> MaxNum { get; private set; }
        public bool Finished { get; set; }


        public AuxPageParseResult()
        {
            EffectivePages = new Dictionary<string, PageParseResult>();
            MaxNum = new Dictionary<PageType, int>();
            MaxNum[PageType.cov] = 2;
            MaxNum[PageType.bok] = 1;
            MaxNum[PageType.leg] = 1;
            MaxNum[PageType.fow] = 50;
            MaxNum[PageType.con] = 50;
        }


        public void AddEffectivePageResult(PageParseResult pageResult)
        {
            if (EffectivePages.ContainsKey(pageResult.PageName))
            {
                EffectivePages.Remove(pageResult.PageName);
            }
            EffectivePages.Add(pageResult.PageName, pageResult);
        }
        //cov001
        //cov002
        //bok001
        //leg001
        //fow025
        //!00001

        public PageParseResult GetPage(PageType pageType, int index)
        {
            if (index > MaxNum[pageType])
            {
                return null;
            }
            String prefix = pageType.ToString();
            if (pageType == PageType.con)
            {
                prefix = "!00";
            }
            String pageName = prefix + index.ToString().PadLeft(3, '0');
            String fileName = "!0" + (int)pageType + index.ToString().PadLeft(3, '0');
            PageParseResult result = CreatePageParseResult(pageName, fileName);
            return result;
        }

        private PageParseResult CreatePageParseResult(String pageName, string fileName)
        {
            if (EffectivePages.ContainsKey(pageName))
            {
                return EffectivePages[pageName];
            }
            PageParseResult result = new PageParseResult();
            result.PageName = pageName;
            result.PageUrl = PreUrl + pageName + PostUrl;
            result.FullFileName = Path.Combine(BookFolder, fileName + ".png");
            return result;
        }



        public List<PageParseResult> PageParseResults
        {
            get
            {
                var list = new List<PageParseResult>();
                list.AddRange(this.EffectivePages.Values);
                return list;
            }
        }


    }
}
