using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class InsurancePolicyCustomer : BaseModel
    {
        [Key(true)]
        public long? IPCId { get; set; }
        public long? IPId { get; set; }
        public long? CustomerId { get; set; }
        /// <summary>
        /// PolicyHolder, Insured, Beneficiary
        /// </summary>
        public String Role { get; set; }
        /// <summary>
        /// 与被保人关系. Children, Parent, Spouse, Employee
        /// </summary>
        public String Relation { get; set; }

        public override object GetPK()
        {
            return IPCId;
        }

    }
}
