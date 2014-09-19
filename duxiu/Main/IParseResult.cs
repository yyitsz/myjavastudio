using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    public interface IParseResult
    {
        BookInfoParam BookInfoParam { get;  }
        String HostUrl { get; }
        List<PageParseResult> PageParseResults { get;  }
        bool Finished { get; set; }
    }
}
