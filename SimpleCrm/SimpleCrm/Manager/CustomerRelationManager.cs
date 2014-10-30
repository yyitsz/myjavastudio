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
        /// <summary>
        /// create or update relation between cutomer with relatedCustomerList
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="relatedCustomerList"></param>
        internal void CreateOrUpdateRelation(Customer customer, IEnumerable<Customer> relatedCustomerList)
        {
            var customerRelations = GetByCustomer(customer.CustomerId.Value);
            var updateRelations = new List<CustomerRelation>();

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

                var foundList = customerRelations.TakeWhile(c => c.BaseCustomerId == customer.CustomerId && c.AgainstCustomerId == relatedCustomer.CustomerId
                                        || c.AgainstCustomerId == customer.CustomerId && c.BaseCustomerId == relatedCustomer.CustomerId);
                updateRelations.AddRange(foundList);
            }
            SaveBatch(updateRelations, saving
                , (t1, t2) =>
                {
                    t1.Relation = t2.Relation;
                }
                , (t1, t2) => t1.BaseCustomerId.Value == t2.BaseCustomerId.Value && t1.AgainstCustomerId.Value == t2.AgainstCustomerId.Value);
        }

        /// <summary>
        /// save all relation for this customer. 
        /// this means system will delete all relations of this customer, and create relation with relatedCustomeList
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="relatedCustomerList"></param>
        internal void SaveRelation(Customer customer, IEnumerable<Customer> relatedCustomerList)
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

        private string GetReverseRelation(IEnumerable<Lov> lovList, string code)
        {
            Lov lov = lovList.FirstOrDefault(l => l.Code == code);
            if (lov == null)
            {
                throw new AppException("Not found LOV for " + code);
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

        internal IEnumerable<CustomerRelation> GetByCustomerIdList(IEnumerable<long> idList)
        {
             Tuple<string, object> tuple1 = BuildCollectionSql("BaseCustomerId", idList.Cast<Object>());
             Tuple<string, object> tuple2 = BuildCollectionSql("AgainstCustomerId", idList.Cast<Object>());

            return Connection.GetList<CustomerRelation>(tuple1.Item1 + " OR " + tuple2.Item1,tuple1.Item2);
   
        }
    }
}
