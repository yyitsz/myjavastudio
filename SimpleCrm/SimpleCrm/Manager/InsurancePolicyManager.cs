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
            List<InsurancePolicyCustomer> ipcList = ipcMgr.GetByPolicyId(id.Value).ToList();
            if (ipcList.Count > 0)
            {
                List<Customer> customerList = customerMgr.GetByIdList(ipcList.Select(ipc => ipc.CustomerId.Value));
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
    }
}
