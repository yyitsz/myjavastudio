using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;

namespace SimpleCrm.Manager
{
    public class CustomerRelationManager : BaseRepo<CustomerRelation, long?>
    {

        public CustomerRelationManager(IDbConnection conn)
        {
            Connection = conn;
        }

        internal void DeleteRelation(long customerAId, long customerBId)
        {
            Connection.Execute(@"delete from 
CustomerRelation 
where BaseCustomerId = @CustomerAId and AgainstCustomerId = @CustomerBId
    or BaseCustomerId = @CustomerBId and AgainstCustomerId = @CustomerAId"
                , new { CustomerAId = customerAId, CustomerBId = customerBId });
        }

     
    }
}
