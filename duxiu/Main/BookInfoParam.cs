using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    public class BookInfoParam
    {
        public string Path { get; set; }
        public string Html { get; set; }
        public Uri Uri { get; set; }
        public String Cookie { get; set; }
        public int PicSize { get; set; }
        public Boolean ParseAuxPage { get; set; }
        public override string ToString()
        {

            return "BookInfoParam{path=" + Path + ", html" + ("" + Html).Substring(100) + "}";
        }
    }
}
