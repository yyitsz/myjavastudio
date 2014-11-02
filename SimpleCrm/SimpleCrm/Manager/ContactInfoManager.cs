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
    public class ContactInfoManager : BaseRepo<ContactInfo, long?>
    {

        public ContactInfoManager(IDbConnection conn)
        {
            Connection = conn;
        }


        internal IEnumerable<ContactInfo> GetListByCustomer(long customerId)
        {
            IEnumerable<ContactInfo> list = Connection.GetList<ContactInfo>(new { CustomerId = customerId });
            list.MarkAsPersisted();
            return list;
        }

        internal IEnumerable<ContactInfo> GetListByCustomer(IEnumerable<long> customerIds)
        {
            if (customerIds.Count() == 0)
            {
                return new List<ContactInfo>();
            }
            Tuple<String, Object> param = BuildCollectionSql("CustomerId", customerIds.Cast<object>());
            IEnumerable<ContactInfo> list = Connection.GetList<ContactInfo>(param.Item1, param.Item2);
            list.MarkAsPersisted();
            return list;
        }

        internal void DeleteByCustomer(long customerId)
        {
            Connection.Execute("Delete From ContactInfo where CustomerId = @CustomerId", new { CustomerId = customerId });
        }
    }

}
