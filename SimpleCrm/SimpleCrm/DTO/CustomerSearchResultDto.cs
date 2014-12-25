using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.DTO
{
    [Serializable]
    public class CustomerSearchResultDto
    {
        public long? CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String IdCardNo { get; set; }
        public String Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public String Unit { get; set; }
        /// <summary>
        /// 接触约访，取得面谈，递送建议书，签投保书，收取保费
        /// </summary>
        public String IntentPhase { get; set; }
       
        /// <summary>
        /// Active, Closed
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String CustomerClass { get; set; }

        /// <summary>
        /// 客户来源。默拜，转介绍，原故。
        /// </summary>
        public String CustomerSource { get; set; }

        public String Mobile { get; set; }
        public String HomeAddress { get; set; }
    }
}
