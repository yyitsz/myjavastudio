using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    public class BookParseResult : IParseResult
    {
        public BookInfoParam BookInfoParam { get; set; }
        public String HostUrl { get; set; }
        public String BaseFolder { get; set; }
        public string BookName { get; set; }
        public string BookFolder { get; set; }
        public int AllPageNum { get; set; }
        public int TotalPage { get; set; }
        public bool Finished { get; set; }
        //page info
        public String PageInfo { get; set; }

        public List<PageParseResult> PageParseResults { get; set; }
    }
}
