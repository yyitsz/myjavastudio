using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.Model
{

    [Dapper.Table("SystemParamerer")]
    public class SystemParameter : BaseModel
    {
        [Dapper.Key(false)]
        public String Code { get; set; }
        public String Config { get; set; }
        public override object GetPK()
        {
            return Code;
        }
    }
}
