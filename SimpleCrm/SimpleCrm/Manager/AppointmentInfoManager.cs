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
             IEnumerable<AppointmentInfo> list = Connection.GetList<AppointmentInfo>("Owner = @Owner and ( StartTime >= date(@StartDate) And StartTime < date(@EndDate) or EndTime >= date(@StartDate) And EndTime < date(@EndDate) ) ",
                new {Owner = owner,  StartDate = startDate, EndDate = endDate.AddDays(1) });
             list.MarkAsPersisted();
             return list;
        }

    }

}
