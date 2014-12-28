using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using SimpleCrm.DTO;
using System.Linq;
using SimpleCrm.DynamicSql;

namespace SimpleCrm.Manager
{
    public class CustomerManager : BaseRepo<Customer, long?>
    {
        private readonly static String SQL_SEARCH_CUST = @"SELECT 
@count(*) {
  Customer.*,  mobileCi.ContactMethod Mobile, addressCi.ContactMethod HomeAddress
}
FROM Customer 
    LEFT JOIN ContactInfo mobileCi ON mobileCi.CustomerId = Customer.CustomerId AND mobileCi.ContactType = 'Mobile'
    LEFT JOIN ContactInfo addressCi ON addressCi.CustomerId = Customer.CustomerId AND addressCi.ContactType = 'HomeAddress'
WHERE 1=1
@if($IdCardNo){  AND IdCardNo = @IdCardNo }
@if($CustomerSource){    AND CustomerSource = @CustomerSource }
@if($CustomerClass){    AND CustomerClass = @CustomerClass }
@if($IntentPhase){    AND IntentPhase = @IntentPhase }
@if($Status){    AND Status = @Status }
@if($CustomerName){    AND CustomerName = @CustomerName }
@if($HasContact){    AND  EXISTS 
    ( SELECT 1 
      FROM ContactInfo 
      WHERE ContactInfo.CustomerId = Customer.CustomerId 
       @if($ContactMethod){ AND ContactInfo.ContactMethod like @ContactMethod }
       @if($ContactType){ AND ContactInfo.ContactType = @ContactType }
    )
  }  
";

        private ContactInfoManager contactInfoMgr;
        public CustomerManager(IDbConnection conn)
        {
            Connection = conn;
            contactInfoMgr = new ContactInfoManager(Connection);
        }


        internal DTO.BaseSearchResultDto<DTO.CustomerSearchResultDto> SearchCustomer(DTO.CustomerSearchParamDto customerSearchParamDto)
        {
            if (!String.IsNullOrWhiteSpace(customerSearchParamDto.ContactMethod))
            {
                customerSearchParamDto.ContactMethod = "%" + customerSearchParamDto.ContactMethod + "%";
            }

            //String sql = SqlParser.Eval(SQL_SEARCH_CUST, customerSearchParamDto).Item1;
           
            //var list = Connection.Query<CustomerSearchResultDto>(sql, customerSearchParamDto);
            //BaseSearchResultDto<CustomerSearchResultDto> result = new BaseSearchResultDto<CustomerSearchResultDto>();
            //result.Results = list.ToList();
            //return result;
            return base.Search<BaseSearchResultDto<CustomerSearchResultDto>,CustomerSearchParamDto, CustomerSearchResultDto>(SQL_SEARCH_CUST,customerSearchParamDto);
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
            SetContactInfo(customer);
            return customer;
        }

        private void SetContactInfo(Customer customer)
        {
            IEnumerable<ContactInfo> exists = contactInfoMgr.GetListByCustomer(customer.CustomerId.Value);
            customer.Contacts = exists.ToList();
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

        public override int Delete(long? customerId)
        {
            contactInfoMgr.DeleteByCustomer(customerId.Value);
            return base.Delete(customerId);
        }

        public bool CanDeleteCustomer(long customerId)
        {
            int count = Connection.ExecuteScalar<int>(@"select sum(c)
from 
(
	select count(*) c from FollowUpRecord where CustomerId = @CustomerId
	UNION ALL
	select count(*) c from InsurancePolicy where CustomerId = @CustomerId
	UNION ALL
	select count(*) c from InsurancePolicyCustomer where CustomerId = @CustomerId
)", new { CustomerId = customerId });

            return count == 0;
        }

        public List<Customer> GetCustomer(string customerName, DateTime birthday)
        {
            var list = Connection.GetList<Customer>(new { CustomerName = customerName, Birthday = birthday });
            //var result = list.Where(c => c.Birthday == birthday).ToList();
            //if (result.Count > 0)
            //{
            //    return result;
            //}
            return list.ToList();
        }

        public Customer GetUniqueCustomer(string customerName, DateTime birthday)
        {
            List<Customer> customers = GetCustomer(customerName, birthday);
            if (customers.Count > 1)
            {
                throw new AppException(String.Format("在系统中找到多个相同姓名的客户，无法区分，不能继续导入。姓名：{0},生日：{1}", customerName, birthday));
            }
            if (customers.Count == 1)
            {
                Customer c = customers[0];
                SetContactInfo(c);
                return c;
            }
            return null;
        }
    }
}
