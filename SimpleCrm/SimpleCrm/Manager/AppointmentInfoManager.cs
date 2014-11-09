using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using System.Linq;

namespace SimpleCrm.Manager
{
    public class AppointmentInfoManager : BaseRepo<AppointmentInfo, long?>
    {

        public AppointmentInfoManager(IDbConnection conn)
        {
            Connection = conn;
        }


        internal IEnumerable<AppointmentInfo> GetListByDateRange(String owner, DateTime startDate, DateTime endDate)
        {
            IEnumerable<AppointmentInfo> list = Connection.Query<AppointmentInfo>(@"SELECT AppointmentInfoId, CustomerId, Category, StartTime, EndTime, Subject, Content, CategoryColor, TimerMarker, Owner, VersionNo, CreateTime, UpdatedBy, UpdateTime
FROM AppointmentInfo
union all
SELECT FollowUpRecordId AppointmentInfoId, f.CustomerId, 'FollowUp' Category, NextFollowUpDate StartTime, date(NextFollowUpDate, '+1 day') EndTime, '预约再次跟进客户' || CustomerName Subject, Content Content, null CategoryColor, null TimerMarker, null Owner, f.VersionNo, f.CreateTime, f.UpdatedBy, f.UpdateTime
FROM FollowUpRecord f INNER JOIN Customer c on f.CustomerId = c.CustomerId
WHERE ( StartTime >= date(@StartDate) And StartTime < date(@EndDate) or EndTime >= date(@StartDate) And EndTime < date(@EndDate) ) ",
                new {  StartDate = startDate, EndDate = endDate.AddDays(1) });
             list.MarkAsPersisted();
             return list;
        }

    }

}
