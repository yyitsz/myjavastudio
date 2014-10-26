using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace SimpleCrm.DTO
{
    [Serializable]
    public abstract class BaseDto
    {
        public DateTime? CreateTime { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public long? VersionNo { get; set; }
        public abstract Object GetPK();
    }
}
