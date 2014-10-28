using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using System.Linq;
using SimpleCrm.Utils;

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

        public IEnumerable<CustomerRelation> GetByCustomer(long customerId)
        {
            return Connection.GetList<CustomerRelation>("BaseCustomerId = @CustomerId OR AgainstCustomerId = @CustomerId", new { CustomerId = customerId });
        }

        internal void SaveRelation(Customer customer, List<Customer> relatedCustomerList)
        {
            var customerRelations = GetByCustomer(customer.CustomerId.Value);
            LovManager lovMgr = new LovManager(Connection);
            IEnumerable<Lov> lovList = lovMgr.GetLovByType(LovType.Relation.ToString());
            List<CustomerRelation> saving = new List<CustomerRelation>();
            foreach (Customer relatedCustomer in relatedCustomerList)
            {
                CustomerRelation cr = new CustomerRelation();
                cr.BaseCustomerId = customer.CustomerId.Value;
                cr.AgainstCustomerId = relatedCustomer.CustomerId.Value;
                cr.Relation = relatedCustomer.Relation;
                saving.Add(cr);

                CustomerRelation reverseCr = new CustomerRelation();
                reverseCr.AgainstCustomerId = customer.CustomerId.Value;
                reverseCr.BaseCustomerId = relatedCustomer.CustomerId.Value;
                reverseCr.Relation = GetReverseRelation(lovList, relatedCustomer.Relation);
                saving.Add(reverseCr);
            }
            SaveBatch(customerRelations, saving
                , (t1, t2) =>
                {
                    t1.Relation = t2.Relation;
                }
                , (t1, t2) => t1.BaseCustomerId.Value == t2.BaseCustomerId.Value && t1.AgainstCustomerId.Value == t2.AgainstCustomerId.Value);
        }

        private string GetReverseRelation(IEnumerable<Lov> lovList, string p)
        {
            Lov lov = lovList.FirstOrDefault(l => l.Code == p);
            if (lov == null)
            {
                throw new AppException("Not found LOV for " + p);
            }
            if (String.IsNullOrWhiteSpace(lov.Attribute1))
            {
                throw new AppException("没有配置反向关系：" + lov.Name);
            }

            lov = lovList.FirstOrDefault(l => l.Code == lov.Attribute1);
            if (lov == null)
            {
                throw new AppException("配置的反向关系找不到对应的关系：" + lov.Name);
            }
            return lov.Code;
        }
    }
}
