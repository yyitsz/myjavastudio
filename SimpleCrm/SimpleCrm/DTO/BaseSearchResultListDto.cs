using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.DTO
{
    [Serializable]
    public class BaseSearchResultDto<T>
    {
        public int? TotalRecord { get; set; }
        public List<T> Results { get; set; }
    }
}
