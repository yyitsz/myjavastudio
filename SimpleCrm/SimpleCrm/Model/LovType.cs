using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCrm.Utils;

namespace SimpleCrm.Model
{
    public enum LovType
    {
        [Display("联系方式类别")]
        ContactType,
        [Display("跟进阶段")]
        IntentPhase,
        [Display("客户来源")]
        CustomerSource,

        [Display("客户级别")]
        CustomerClass,
        [Display("证件类别")]
        IdCardType,
        [Display("关系")]
        Relation,
        [Display("客户状态")]
        CustomerStatus,

        [Display("保单状态")]
        InsurancePolicyStatus,
        [Display("保单分类")]
        InsurancePolicyCategory,
    }
}
