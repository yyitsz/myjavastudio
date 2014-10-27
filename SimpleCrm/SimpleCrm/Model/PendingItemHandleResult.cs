using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCrm.Utils;

namespace SimpleCrm.Model
{
    public enum PendingItemHandleResult
    {
        [Display("未处理")]
        Unhandled,
        [Display("已处理")]
        Handled,
    }
}
