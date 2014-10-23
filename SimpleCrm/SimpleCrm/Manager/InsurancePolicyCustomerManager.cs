using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;

namespace SimpleCrm.Manager
{
    public class InsurancePolicyCustomerManager : BaseRepo<InsurancePolicyCustomer,long?>
    {

        public InsurancePolicyCustomerManager(IDbConnection conn)
        {
            Connection = conn;
        }

        internal void DeleteByPolicyId(long policyId)
        {
            Connection.Execute("delete from InsurancePolicyCustomer where IPId = @PolicyId", new { PolicyId = policyId });
        }

        internal IEnumerable<InsurancePolicyCustomer> GetByPolicyId(long policyId)
        {
            return Connection.GetList<InsurancePolicyCustomer>(new { IPId = policyId });
        }
    }
}
