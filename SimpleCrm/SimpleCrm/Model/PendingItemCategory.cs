using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCrm.Utils;

namespace SimpleCrm.Model
{
    public enum PendingItemCategory
    {
        [Display("生日提醒")]
        Birthday,
        [Display("续期保费")]
        RenewalPremium,
    }
}
