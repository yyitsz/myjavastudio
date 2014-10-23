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
    public class ContactInfoManager : BaseRepo<ContactInfo,long?>
    {

        public ContactInfoManager(IDbConnection conn)
        {
            Connection = conn;
        }


        internal IEnumerable<ContactInfo> GetListByCustomer(long customerId)
        {
            return Connection.GetList<ContactInfo>(new { CustomerId = customerId });
        }

        internal IEnumerable<ContactInfo> GetListByCustomer(IEnumerable<long> customerIds)
        {
            if (customerIds.Count() == 0) {
                return new List<ContactInfo>();
            }
            Tuple<String, Object> param = BuildCollectionSql("CustomerId", customerIds.Cast<object>());
            return Connection.GetList<ContactInfo>(param.Item1, param.Item2);
        }

       

    }
  
}
