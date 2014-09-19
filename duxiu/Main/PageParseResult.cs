using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    public class PageParseResult
    {

        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string FullFileName { get; set; }
        public bool Exsit { get; set; }
        public bool Success { get; set; }
        public Exception Error { get; set; }
        public override string ToString()
        {
            return "PageParseResult{FullFileName=" + FullFileName + ", PageUrl=" + PageUrl + ", PageName=" + PageName + "}";
        }
    }
}
