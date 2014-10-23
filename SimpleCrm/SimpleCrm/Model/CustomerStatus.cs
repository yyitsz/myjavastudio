using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCrm.Utils;

namespace SimpleCrm.Model
{
    public enum CustomerStatus
    {
        [Display("潜在客户")]
        Implicit,
        [Display("意向客户")]
        Intent,
        [Display("正式客户")]
        Purchased,
        [Display("无效客户")]
        Closed,
    }
}
