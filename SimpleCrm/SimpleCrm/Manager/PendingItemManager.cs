using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using System.Linq;
using SimpleCrm.DTO;

namespace SimpleCrm.Manager
{
    public class PendingItemManager : BaseRepo<PendingItem, long?>
    {

        public PendingItemManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public void Save(PendingItemDto dto)
        {
            PendingItem item = null;
            if (dto.PendingItemId != null)
            {
                item = base.FindOne(dto.PendingItemId);
                if (item == null)
                {
                    throw new AppException("Not found  pending item for id : " + dto.PendingItemId.Value);
                }
            }
            else 
            {
                item = new PendingItem();
            }
            item.ActionDate = dto.ActionDate;
            item.Category = dto.Category;
           // item.CreateTime = dto.CreateTime;
            item.HandleDate = dto.HandleDate;
            item.HandleResult = dto.HandleResult;
            item.PendingItemId = dto.PendingItemId;
            item.RefId = dto.RefId;
            item.Remark = dto.Remark;
           // item.UpdatedBy = dto.UpdatedBy;
           // item.UpdateTime = dto.UpdateTime;
            item.VersionNo = dto.VersionNo;

            base.Save(item);

            dto.PendingItemId = item.PendingItemId;
            dto.VersionNo = item.VersionNo;
            dto.CreateTime = item.CreateTime;
            dto.UpdateTime = item.UpdateTime;
            dto.UpdatedBy = item.UpdatedBy;            
        }

        internal IEnumerable<PendingItemDto> SearchBirthdayPendingItems(DTO.SearchPendingItemParamDto param)
        {
            return Connection.Query<PendingItemDto>(@"select  cust.CustomerName CustomerName, cust.CustomerId RefId
, date(cust.BirthdayThisYear) ActionDate, cust.Birthday, pi.PendingItemId PendingItemId, 'Birthday' Category,pi.CreateTime CreateTime
	,pi.HandleDate HandleDate,pi.HandleResult HandleResult,cust.CustomerId CustomerId, pi.Remark Remark, pi.UpdatedBy UpdatedBy, pi.UpdateTime UpdateTime, pi.VersionNo VersionNo
from (select c.*, datetime(c.Birthday, '+' || (((strftime('%Y', 'now') -  strftime('%Y', c.Birthday)) * 12 + (strftime('%m', 'now') -  strftime('%m', c.Birthday)) + 11) /12) || ' years') BirthdayThisYear
     from Customer c 
     where c.Birthday is not null) cust
		LEFT JOIN PendingItem pi on cust.CustomerId = pi.RefId and pi.Category = 'Birthday' and cust.BirthdayThisYear = datetime(pi.ActionDate)
	where cust.BirthdayThisYear >= datetime(@FromDate) and cust.BirthdayThisYear <= datetime(@ToDate)
    order by cust.BirthdayThisYear
", param);
        }

        internal IEnumerable<PendingItemDto> SearchRenewalPremiumPendingItems(DTO.SearchPendingItemParamDto param)
        {
            return Connection.Query<PendingItemDto>(@"select  cust.CustomerName CustomerName, policy.RenewalDate ActionDate, policy.EffectiveDate, policy.InsurancePolicyId refId, pi.PendingItemId PendingItemId, 'RenewalPremium' Category,pi.CreateTime CreateTime
	,pi.HandleDate HandleDate,pi.HandleResult HandleResult,cust.CustomerId CustomerId, pi.Remark Remark, pi.UpdatedBy UpdatedBy, pi.UpdateTime UpdateTime, pi.VersionNo VersionNo, policy.InsurancePolicyNo InsurancePolicyNo
from (select ip.*, datetime(ip.EffectiveDate, '+' || (((strftime('%Y', 'now') -  strftime('%Y', ip.EffectiveDate)) * 12 + (strftime('%m', 'now') -  strftime('%m', ip.EffectiveDate)) + 11) /12) || ' years') RenewalDate
     from InsurancePolicy ip 
     where ip.EffectiveDate is not null and ip.EffectiveDate <= date('now') and date(ip.EffectiveDate, '+' || ip.InsuredYear || ' years') >= date(@FromDate) ) policy
    INNER JOIN InsurancePolicyCustomer ipc on policy.InsurancePolicyId = ipc.IPId and ipc.Role = 'PolicyHolder'
    INNER JOIN Customer cust on ipc.CustomerId = cust.CustomerId
		LEFT JOIN PendingItem pi on policy.InsurancePolicyId = pi.RefId and pi.Category = 'RenewalPremium' and policy.RenewalDate = datetime(pi.ActionDate)
	where policy.RenewalDate >= datetime(@FromDate) and policy.RenewalDate <= datetime(@ToDate)
    order by policy.RenewalDate
", param);
        }
    }
}
