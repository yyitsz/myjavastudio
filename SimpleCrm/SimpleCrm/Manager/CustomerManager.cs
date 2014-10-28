using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using SimpleCrm.DTO;
using System.Linq;

namespace SimpleCrm.Manager
{
    public class CustomerManager : BaseRepo<Customer, long?>
    {
        private ContactInfoManager contactInfoMgr;

        public CustomerManager(IDbConnection conn)
        {
            Connection = conn;
            contactInfoMgr = new ContactInfoManager(Connection);
        }


        internal DTO.PageSearchResultDto<DTO.CustomerSearchResultDto> SearchCustomer(DTO.CustomerSearchParamDto customerSearchParamDto)
        {
            var list = Connection.SearchByCriteria<CustomerSearchResultDto>("select * from Customer", customerSearchParamDto);
            PageSearchResultDto<CustomerSearchResultDto> result = new PageSearchResultDto<CustomerSearchResultDto>();
            result.Results = list.ToList();
            return result;
        }

        public override int Save(Customer customer)
        {
            int count = base.Save(customer);
            customer.Contacts.ForEach(c => c.CustomerId = customer.CustomerId);

            IEnumerable<ContactInfo> exists = contactInfoMgr.GetListByCustomer(customer.CustomerId.Value);
            contactInfoMgr.SaveBatch(exists, customer.Contacts);
            return count;
        }

        public override int Delete(Customer customer)
        {
            contactInfoMgr.DeleteBatch(customer.Contacts);
            return base.Delete(customer);
        }
        public void SaveFamily(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                int count = base.Save(customer);
                customer.Contacts.ForEach(c => c.CustomerId = customer.CustomerId);

                IEnumerable<ContactInfo> exists = contactInfoMgr.GetListByCustomer(customer.CustomerId.Value);
                contactInfoMgr.SaveBatch(exists, customer.Contacts);
            }
        }

        public IEnumerable<Customer> GetFamily(long customerId)
        {
            IEnumerable<Customer> customers = Connection.GetList<Customer>(new { PrimaryCustomerId = customerId });

            PopulateContactInfo(customers);
            customers.MarkAsPersisted();
            return customers;
        }

        private void PopulateContactInfo(IEnumerable<Customer> customers)
        {
            IEnumerable<ContactInfo> all = contactInfoMgr.GetListByCustomer(customers.Select(c => c.CustomerId.Value));
            foreach (var customer in customers)
            {
                IEnumerable<ContactInfo> exists = all.Where(c => c.CustomerId == customer.CustomerId);
                customer.Contacts = exists.ToList();
            }
        }

        public override Customer FindOne(long? id)
        {
            Customer customer = base.FindOne(id);
            IEnumerable<ContactInfo> exists = contactInfoMgr.GetListByCustomer(customer.CustomerId.Value);
            customer.Contacts = exists.ToList();
            return customer;
        }

        internal void UpdateIntentPhase(long customerId, string intentPhase)
        {
            Customer customer = base.FindOne(customerId);
            if (intentPhase != customer.IntentPhase)
            {
                customer.IntentPhase = intentPhase;
                base.Update(customer);
            }
        }

        internal List<Customer> GetByIdList(IEnumerable<long> idList)
        {
            if (idList.Count() == 0)
            {
                return new List<Customer>();
            }
            Tuple<String, Object> param = BuildCollectionSql("CustomerId", idList.Cast<object>());
            List<Customer> customerList = Connection.GetList<Customer>(param.Item1, param.Item2).ToList();
            PopulateContactInfo(customerList);
            customerList.MarkAsPersisted();
            return customerList;
        }

        internal List<Customer> GetCustomerByRelation(long customerId)
        {
            List<Customer> customerList = Connection.Query<Customer>(
               @"Select r.relation, c.*
    from CustomerRelation r 
		INNER JOIN Customer c on r.AgainstCustomerId = c.CustomerId 
where r.BaseCustomerId = @CustomerId "
               , new { CustomerId = customerId }).ToList();
            PopulateContactInfo(customerList);
            customerList.MarkAsPersisted();
            return customerList;
        }
    }
}
