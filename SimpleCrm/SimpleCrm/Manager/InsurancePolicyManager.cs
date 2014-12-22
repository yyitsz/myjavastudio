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
    public class InsurancePolicyManager : BaseRepo<InsurancePolicy, long?>
    {

        public InsurancePolicyManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public override int Save(InsurancePolicy ip)
        {
            CustomerManager customerMgr = new CustomerManager(Connection);
            InsurancePolicyCustomerManager ipcMgr = new InsurancePolicyCustomerManager(Connection);
            CustomerRelationManager relationMgr = new CustomerRelationManager(Connection);

            if (ip.InsurancePolicyId != null)
            {
                ipcMgr.DeleteByPolicyId(ip.InsurancePolicyId.Value);
            }
            int count = base.Save(ip);
            if (ip.PolicyHolder != null)
            {
                customerMgr.Save(ip.PolicyHolder);
                InsurancePolicyCustomer ipc = new InsurancePolicyCustomer();
                ipc.IPId = ip.InsurancePolicyId;
                ipc.CustomerId = ip.PolicyHolder.CustomerId;
                ipc.Role = CustomerRoleType.PolicyHolder.ToString();
                ipcMgr.Save(ipc);

            }

            if (ip.Insured != null)
            {
                customerMgr.Save(ip.Insured);
                InsurancePolicyCustomer ipc = new InsurancePolicyCustomer();
                ipc.IPId = ip.InsurancePolicyId;
                ipc.CustomerId = ip.Insured.CustomerId;
                ipc.Role = CustomerRoleType.Insured.ToString();
                ipcMgr.Save(ipc);
                relationMgr.CreateOrUpdateRelation(ip.PolicyHolder, new List<Customer> { ip.Insured });
            }

            if (ip.Beneficiaries != null && ip.Beneficiaries.Count > 0)
            {
                foreach (Customer c in ip.Beneficiaries)
                {
                    customerMgr.Save(c);
                    InsurancePolicyCustomer ipc = new InsurancePolicyCustomer();
                    ipc.IPId = ip.InsurancePolicyId;
                    ipc.CustomerId = c.CustomerId;
                    ipc.Role = CustomerRoleType.Beneficiary.ToString();
                    ipcMgr.Save(ipc);
                }
                if (ip.Insured != null)
                {
                    relationMgr.CreateOrUpdateRelation(ip.Insured, ip.Beneficiaries.Where(c => !String.IsNullOrEmpty(c.Relation)));
                }
            }

            return count;
        }

        public override int Delete(InsurancePolicy ip)
        {
            InsurancePolicyCustomerManager ipcMgr = new InsurancePolicyCustomerManager(Connection);
            ipcMgr.DeleteByPolicyId(ip.InsurancePolicyId.Value);
            int c = base.Delete(ip);
            return c;
        }

        public void Delete(long ipId)
        {
            InsurancePolicyCustomerManager ipcMgr = new InsurancePolicyCustomerManager(Connection);
            ipcMgr.DeleteByPolicyId(ipId);

            Connection.Execute("delete from InsurancePolicy where InsurancePolicyId = @IPId", new { IPId = ipId });
        }

        public override InsurancePolicy FindOne(long? id)
        {
            InsurancePolicy ip = base.FindOne(id);
            if (ip == null)
            {
                return null;
            }
            InsurancePolicyCustomerManager ipcMgr = new InsurancePolicyCustomerManager(Connection);
            CustomerManager customerMgr = new CustomerManager(Connection);
            CustomerRelationManager customerRelationMgr = new CustomerRelationManager(Connection);
            List<InsurancePolicyCustomer> ipcList = ipcMgr.GetByPolicyId(id.Value).ToList();
            if (ipcList.Count > 0)
            {
                var idList = ipcList.Select(ipc => ipc.CustomerId.Value);
                List<Customer> customerList = customerMgr.GetByIdList(idList);
                IEnumerable<CustomerRelation> customerRelationList = customerRelationMgr.GetByCustomerIdList(idList);
                if (customerList.Count > 0)
                {
                    foreach (InsurancePolicyCustomer ipc in ipcList)
                    {
                        Customer customer = customerList.Find(c => c.CustomerId == ipc.CustomerId);
                        if (customer != null)
                        {
                            if (ipc.Role == CustomerRoleType.PolicyHolder.ToString())
                            {
                                ip.PolicyHolder = customer;
                            }
                            else if (ipc.Role == CustomerRoleType.Insured.ToString())
                            {
                                ip.Insured = customer;
                            }
                            else if (ipc.Role == CustomerRoleType.Beneficiary.ToString())
                            {
                                ip.Beneficiaries.Add(customer);
                            }
                        }
                    }
                    if (ip.Insured != null)
                    {
                        var foundRelation = customerRelationList.FirstOrDefault(c => c.BaseCustomerId == ip.PolicyHolder.CustomerId && c.AgainstCustomerId == ip.Insured.CustomerId);
                        if (foundRelation != null)
                        {
                            ip.Insured.Relation = foundRelation.Relation;
                        }
                        foreach (var beneficiary in ip.Beneficiaries)
                        {
                            foundRelation = customerRelationList.FirstOrDefault(c => c.BaseCustomerId == ip.Insured.CustomerId && c.AgainstCustomerId == beneficiary.CustomerId);
                            if (foundRelation != null)
                            {
                                beneficiary.Relation = foundRelation.Relation;
                            }
                        }
                    }
                }
            }
            return ip;
        }

        internal IEnumerable<InsurancePolicyResultDto> GetInsurancePolicyByCustomer(long customerId)
        {
            return Connection.Query<InsurancePolicyResultDto>(@"
select ip.InsurancePolicyId,ip.CustomerId,ip.EffectiveDate,ip.InsurancePolicyNo
  ,ip.Category,ip.InsuredYear,ip.PrimaryIpName,ip.Status, ip.Category,
  primaryCust.CustomerName, holderCust.CustomerName PolicyHolderName, insuredCust.CustomerName InsuredName
 from InsurancePolicy ip 
   left join InsurancePolicyCustomer holder on holder.IPId = ip.InsurancePolicyId and holder.Role = 'PolicyHolder'
   left join InsurancePolicyCustomer insured on insured.IPId = ip.InsurancePolicyId and insured.Role = 'Insured'
   INNER JOIN Customer primaryCust on ip.CustomerId = primaryCust.CustomerId
   left JOIN Customer holderCust on holder.CustomerId = holderCust.CustomerId    
   left JOIN Customer insuredCust on insured.CustomerId = insuredCust.CustomerId
where ip.CustomerId = @CustomerId 
  or EXISTS (select 1 from InsurancePolicyCustomer ipc where ipc.CustomerId = @CustomerId and ip.InsurancePolicyId = ipc.IPId)
", new { CustomerId = customerId });
        }

        internal InsurancePolicy GetInsurancePolicyByNo(string insurancePolicyNo)
        {
            return Connection.GetList<InsurancePolicy>(new { InsurancePolicyNo = insurancePolicyNo }).FirstOrDefault();
        }
    }
}
