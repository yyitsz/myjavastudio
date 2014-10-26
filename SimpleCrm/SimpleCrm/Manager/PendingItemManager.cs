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

        internal IEnumerable<PendingItemDto> SearchBirthdayPendingItems(DTO.SearchPendingItemParamDto param)
        {
            return Connection.Query<PendingItemDto>(@"select  cust.CustomerName, cust.BirthdayThisYear ActionDate, cust.Birthday, pi.PendingItemId, 'Birthday' Category,pi.CreateTime
	,pi.HandleDate,pi.HandleResult,cust.CustomerId, pi.Remark, pi.UpdatedBy, pi.UpdateTime, pi.VersionNo
from (select c.*, date(c.Birthday, '+' || ( strftime('%Y', 'now') -  strftime('%Y', c.Birthday)) || ' years') BirthdayThisYear
     from Customer c 
     where c.Birthday is not null) cust
		LEFT JOIN PendingItem pi on cust.CustomerId = pi.RefId and pi.Category = 'Birthday' and cust.BirthdayThisYear = pi.ActionDate
	where cust.BirthdayThisYear >= @FromDate and cust.BirthdayThisYear <= @ToDate;
", param);
        }
    }
}
