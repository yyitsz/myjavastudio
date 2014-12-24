using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.DTO
{
    public class CustomerSearchParamDto : PageSearchParamDto
    {
        public String CustomerName { get; set; }
        public String IdCardNo { get; set; }
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

        public String ContactType { get; set; }

        public String ContactMethod { get; set; }
    }
}
