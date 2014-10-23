using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.DTO
{
    [Serializable]
    public class PageSearchParamDto : IPagination
    {
        public EnquiryParam EnquiryParam { get; set; }

    }
}
