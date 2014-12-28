using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.DTO
{
    [Serializable]
    public class BaseSearchParamDto
    {
        public int? StartPage { get; set; }
        public int? PageSize { get; set; }
    }
}
