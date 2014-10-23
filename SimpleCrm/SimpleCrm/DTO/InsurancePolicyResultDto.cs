using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.DTO
{
    public class InsurancePolicyResultDto 
    {
        public long? InsurancePolicyId { get; set; }
        public long? CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String InsurancePolicyNo { get; set; }
        public String PrimaryIPName { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int? InsuredYear { get; set; }
        public Decimal? Premium { get; set; }
        public String PolicyHolderName { get; set; }
        public String InsuredName { get; set; }

        /// <summary>
        /// 保险类别，Car, Life
        /// </summary>
        public String Category { get; set; }
        public String Status { get; set; }

    }
}
