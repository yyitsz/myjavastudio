using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;

namespace SimpleCrm.Manager
{
    public class FollowUpRecordManager : BaseRepo<FollowUpRecord, long?>
    {

        public FollowUpRecordManager(IDbConnection conn)
        {
            Connection = conn;
        }

        internal IEnumerable<FollowUpRecord> GetFollowUpRecordByCustomer(long customerId)
        {
            return Connection.GetList<FollowUpRecord>(new { CustomerId = customerId });
        }
    }
}
