using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using System.Data;
using SimpleCrm.Common;
using SimpleCrm.Config;
using SimpleCrm.Utils;
using System.IO;
using System.Linq;
using SimpleCrm.Manager;
using SimpleCrm.DTO;
using Dapper;
using System.Collections;

namespace SimpleCrm.Facade
{
    public class AppFacade
    {
        private static AppFacade facade = new AppFacade();

        public static AppFacade Facade { get { return facade; } }
        public MainForm MainForm { get; set; }

        public void InitSystem()
        {
            new AppConfigManager().Init();
            SqlMapper.AddTypeHandler(typeof(DateTime?), new DateTimeHandler());

            ExecutedInTx(conn => new SystemParameterManager(conn).Init());
        }

        public static void ExecutedInTx(Action<IDbConnection> action)
        {
            using (IDbConnection conn = ConnectionProvider.GetConnection())
            {
                IDbTransaction tx = conn.BeginTransaction();
                try
                {
                    action(conn);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public static T ExecutedInTx<T>(Func<IDbConnection, T> action)
        {
            using (IDbConnection conn = ConnectionProvider.GetConnection())
            {
                IDbTransaction tx = conn.BeginTransaction();
                try
                {
                    T result = action(conn);
                    tx.Commit();
                    return result;
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public static void ExecutedInTx(Action<IDbConnection, IDbTransaction> action)
        {
            using (IDbConnection conn = ConnectionProvider.GetConnection())
            {
                IDbTransaction tx = conn.BeginTransaction();
                try
                {
                    action(conn, tx);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public static T ExecutedInTx<T>(Func<IDbConnection, IDbTransaction, T> action)
        {
            using (IDbConnection conn = ConnectionProvider.GetConnection())
            {
                IDbTransaction tx = conn.BeginTransaction();
                try
                {
                    T result = action(conn, tx);
                    tx.Commit();
                    return result;
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }


        #region User
        internal void CreateUser(User user)
        {
            ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                usrMgr.Create(user);
            });
        }

        internal void UpdateUser(User user)
        {
            ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                usrMgr.Update(user);
            });
        }

        internal void DeleteUser(User user)
        {
            ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                usrMgr.Delete(user);
            });
        }

        internal IList<User> SearchUserByExample(User user)
        {
            return ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                return usrMgr.SearchUserByExample(user).ToList();
            });
        }

        public UserProfile Authenticate(String userId, String pwd)
        {
            UserProfile profile = new UserProfile();
            String encryptedPwd = PasswordUtil.Encrypt(pwd);
            ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                User user = usrMgr.FindOne(userId);
                if (user == null || user.Password != encryptedPwd)
                {
                    throw new AppException("UserId or Password may be wrong.");
                }
                if (user.Status == User.DISABLED)
                {
                    throw new AppException("User has been disabled.");
                }
                profile.UserId = user.UserId;
                profile.UserName = user.UserName;
                profile.RoleList = new List<String>(user.Roles);
            });
            return profile;
        }

        internal void ChangePassword(string userId, string oldPwd, string newPwd)
        {
            String encryptedOldPwd = PasswordUtil.Encrypt(oldPwd);
            String encryptednewPwd = PasswordUtil.Encrypt(newPwd);
            ExecutedInTx(conn =>
            {
                UserManager usrMgr = new UserManager(conn);
                User user = usrMgr.FindOne(userId);
                if (user == null || user.Password != encryptedOldPwd)
                {
                    throw new AppException("UserId or Password may be wrong.");
                }
                user.Password = encryptednewPwd;
                usrMgr.Update(user);
            });
        }
        #endregion



        #region System Config
        public SystemConfig GetSystemConfig()
        {
            return ExecutedInTx(conn =>
            {
                return new SystemParameterManager(conn).GetSystemConfig();
            });
        }

        public void SaveSystemConfig(SystemConfig systemConfig)
        {
            ExecutedInTx(conn =>
            {
                new SystemParameterManager(conn).SaveSystemConfig(systemConfig);
            });
        }
        #endregion

        #region app config
        public AppConfig GetAppConfig()
        {
            return new AppConfigManager().GetAppConfig();
        }

        public void SaveAppConfig(AppConfig config)
        {
            new AppConfigManager().SaveAppConfig(config);
        }
        #endregion

        #region ref no
        public string GenerateTxRefNo()
        {
            return ExecutedInTx(conn =>
            {
                return new RefNoManager(conn).GenerateRefNo("IFILE", "IF", 8);
            });
        }
        #endregion


        #region Customer

        //internal List<Customer> GetRelatedCustomerList(long customerId)
        //{
        //    return ExecutedInTx(conn =>
        //    {
        //        CustomerManager customerMgr = new CustomerManager(conn);
        //        return customerMgr.GetCustomerByRelation(customerId);
        //    });
        //}

        internal DTO.PageSearchResultDto<DTO.CustomerSearchResultDto> SearchCustomer(DTO.CustomerSearchParamDto customerSearchParamDto)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                return customerMgr.SearchCustomer(customerSearchParamDto);
            });
        }

        public void SaveCustomer(Customer customer, List<Customer> relatedCustomerList)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                customerMgr.Save(customer);
                customerMgr.SaveBatch(relatedCustomerList);
                CustomerRelationManager customerRelationMgr = new CustomerRelationManager(conn);
                customerRelationMgr.SaveRelation(customer, relatedCustomerList);
            });
        }
        public void SaveCustomerBaseInfo(Customer customer)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                customerMgr.Save(customer);
            });
        }

        public void DeleteCustomer(Customer customer)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                customerMgr.Delete(customer);
            });
        }
        public Customer GetCustomer(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);

                Customer customer = customerMgr.FindOne(customerId);
                return customer;
            });
        }

        public void UpdateIntentPhase(long customerId, String phase)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);

                customerMgr.UpdateIntentPhase(customerId, phase);
            });
        }
        #endregion

        #region LOV
        public List<Lov> GetLovByType(String lovType)
        {
            return ExecutedInTx(conn =>
            {
                LovManager lovMgr = new LovManager(conn);
                return lovMgr.GetLovByType(lovType).ToList();
            });
        }

        public void SaveLov(IEnumerable<Lov> lovs)
        {
            ExecutedInTx(conn =>
            {
                LovManager lovMgr = new LovManager(conn);
                lovMgr.SaveBatch(lovs);
            });
        }

        public void DeleteLov(Lov lov)
        {
            ExecutedInTx(conn =>
            {
                LovManager lovMgr = new LovManager(conn);
                lovMgr.Delete(lov);
            });
        }
        #endregion

        internal void SaveFollowUpRecord(FollowUpRecord record)
        {
            ExecutedInTx(conn =>
            {
                FollowUpRecordManager mgr = new FollowUpRecordManager(conn);
                mgr.Save(record);
            });
        }

        internal List<FollowUpRecord> GetFollowUpRecordByCustomer(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                FollowUpRecordManager mgr = new FollowUpRecordManager(conn);
                return mgr.GetFollowUpRecordByCustomer(customerId).ToList();
            });
        }

        internal void DeleteFollowUpRecord(FollowUpRecord record)
        {
            ExecutedInTx(conn =>
            {
                FollowUpRecordManager mgr = new FollowUpRecordManager(conn);
                mgr.Delete(record);
            });
        }
        #region Appointment
        internal void SaveAppointmentInfo(AppointmentInfo appointmentInfo)
        {
            ExecutedInTx(conn =>
            {
                AppointmentInfoManager mgr = new AppointmentInfoManager(conn);
                mgr.Save(appointmentInfo);
            });
        }

        internal void DeleteAppointmentInfo(AppointmentInfo appointmentInfo)
        {
            ExecutedInTx(conn =>
            {
                AppointmentInfoManager mgr = new AppointmentInfoManager(conn);
                mgr.Delete(appointmentInfo);
            });
        }

        internal List<AppointmentInfo> GetListByDateRange(String owner, DateTime startDate, DateTime endDate)
        {
            return ExecutedInTx(conn =>
            {
                AppointmentInfoManager mgr = new AppointmentInfoManager(conn);
                return mgr.GetListByDateRange(owner, startDate, endDate).ToList();
            });
        }
        #endregion

        internal List<DTO.InsurancePolicyResultDto> GetInsurancePolicyByCustomer(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                InsurancePolicyManager mgr = new InsurancePolicyManager(conn);
                return mgr.GetInsurancePolicyByCustomer(customerId).ToList();
            });
        }



        internal InsurancePolicy GetInsurancePolicy(long policyId)
        {
            return ExecutedInTx(conn =>
            {
                InsurancePolicyManager mgr = new InsurancePolicyManager(conn);
                return mgr.FindOne(policyId);
            });
        }

        internal void SaveInsurancePolicy(InsurancePolicy policy)
        {
            ExecutedInTx(conn =>
            {
                InsurancePolicyManager mgr = new InsurancePolicyManager(conn);
                mgr.Save(policy);
            });
        }

        internal void DeleteInsurancePolicy(long insurancePolicyId)
        {
            ExecutedInTx(conn =>
            {
                InsurancePolicyManager mgr = new InsurancePolicyManager(conn);
                mgr.Delete(insurancePolicyId);
            });
        }

        internal List<DTO.PendingItemDto> SearchPendingItems(PendingItemCategory pendingItemCategory, DateTime fromDate, DateTime toDate)
        {
            return ExecutedInTx(conn =>
            {
                PendingItemManager mgr = new PendingItemManager(conn);
                SearchPendingItemParamDto param = new SearchPendingItemParamDto();
                param.FromDate = fromDate;
                param.ToDate = toDate;
                List<PendingItemDto> result = new List<PendingItemDto>();
                DateTime today = DateTime.Today;

                if (pendingItemCategory == PendingItemCategory.Birthday)
                {
                    var list = mgr.SearchBirthdayPendingItems(param);
                    foreach (var dto in list)
                    {
                        int days = (dto.ActionDate.Value - today).Days;
                        if (days == 0)
                        {
                            dto.Content = "今天过生日";
                        }
                        else if (days > 0)
                        {
                            dto.Content = "还有" + days + "天过生日.";
                        }
                        else
                        {
                            dto.Content = "今年的生日已经过了，等明年吧.";
                        }
                        result.Add(dto);
                    }
                }
                else if (pendingItemCategory == PendingItemCategory.RenewalPremium)
                {
                    var list = mgr.SearchRenewalPremiumPendingItems(param).ToList();
                    foreach (var dto in list)
                    {
                        int days = (dto.ActionDate.Value - today).Days;
                        if (days == 0)
                        {
                            dto.Content = "今天续期保费";
                        }
                        else if (days > 0)
                        {
                            dto.Content = "还有" + days + "天续期保费.";
                        }
                        else
                        {
                            dto.Content = "今年的续期保费已经过了，等明年吧.";
                        }
                        result.Add(dto);
                    }
                }
                return result;
            });

        }

        internal void SavePendingItem(PendingItemDto pendingItemDto)
        {
            ExecutedInTx(conn =>
           {
               PendingItemManager mgr = new PendingItemManager(conn);
               mgr.Save(pendingItemDto);
           });
        }

        internal List<Customer> GetCustomerByRelation(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager mgr = new CustomerManager(conn);
                return mgr.GetCustomerByRelation(customerId);
            });
        }

        internal void DeleteCustomer(long customerId)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager mgr = new CustomerManager(conn);
                CustomerRelationManager customerRelationMgr = new CustomerRelationManager(conn);
                customerRelationMgr.DeleteByCustomer(customerId);
                mgr.Delete(customerId);
            });
        }

        public bool CanDeleteCustomer(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager mgr = new CustomerManager(conn);
                return mgr.CanDeleteCustomer(customerId);
            });
        }

        internal bool ExistAnyUser()
        {
            return ExecutedInTx(conn =>
            {
                UserManager mgr = new UserManager(conn);
                return mgr.ExistAnyUser();
            });
        }

        internal List<CustomerImportDto> ImportCustomers(string filename)
        {
            CSV.CsvImporter importer = new CSV.CsvImporter(filename, true);
            importer.Converter = new CSV.CsvObjectConverter(typeof(CustomerImportDto));
            IList cusotmerImportDtoList = importer.Parse();
            List<CustomerImportDto> lists = new List<CustomerImportDto>();
            ExecutedInTx(conn =>
            {

                CustomerManager custMgr = new CustomerManager(conn);
                CustomerRelationManager custRMgr = new CustomerRelationManager(conn);
                ContactInfoManager contactInfoMgr = new ContactInfoManager(conn);
                InsurancePolicyManager ipMgr = new InsurancePolicyManager(conn);
                InsurancePolicyCustomerManager ipcMgr = new InsurancePolicyCustomerManager(conn);
                LovManager lovMgr = new LovManager(conn);
                List<Lov> statusLovList = lovMgr.GetLovByType(LovType.InsurancePolicyStatus.ToString()).ToList();
                //check status exists in lov
                cusotmerImportDtoList.Cast<CustomerImportDto>().ForEach(c => ConvertToCode(statusLovList, c.IPStatus));

                foreach (CustomerImportDto dto in cusotmerImportDtoList)
                {
                    lists.Add(dto);

                    InsurancePolicy ip = ipMgr.GetInsurancePolicyByNo(dto.InsurancePolicyNo);
                    if (ip != null)
                    {
                        dto.ImportStatus = CustomerImportDto.SKIPPED;
                        continue;
                    }
                    Customer policyHolder = custMgr.GetUniqueCustomer(dto.PolicyHolder, dto.PolicyHolderBirthday.Value);
                    Customer insured = custMgr.GetUniqueCustomer(dto.Insured, dto.InsuredBirthday.Value);

                    if (policyHolder == null)
                    {
                        policyHolder = new Customer();
                        policyHolder.CustomerName = dto.PolicyHolder;
                        policyHolder.Birthday = dto.PolicyHolderBirthday;
                        policyHolder.CustomerClass = "Normal";
                        policyHolder.CustomerSource = "120";//服务单
                        policyHolder.Status = CustomerStatus.Purchased.ToString();
                        policyHolder.Contacts = new List<ContactInfo>();
                       
                        if (dto.Telephone.Trim().Length > 0)
                        {
                            ContactInfo ci = new ContactInfo();
                            policyHolder.Contacts.Add(ci);
                            ci.ContactMethod = dto.Telephone.Replace("-", "");
                            if (ci.ContactMethod.Length == 11)
                            {
                                ci.ContactType = "Mobile";
                            }
                            else
                            {
                                ci.ContactType = "HomePhone";
                            }
                        }
                        if (dto.Address.Trim().Length > 0)
                        {
                            ContactInfo ci = new ContactInfo();
                            ci = new ContactInfo();
                            policyHolder.Contacts.Add(ci);
                            ci.ContactMethod = dto.Address;
                            ci.ContactType = "HomeAddress";
                        }
                        custMgr.Save(policyHolder);

                    }
                    if (dto.PolicyHolder == dto.Insured)
                    {
                        insured = policyHolder;
                    }

                    if (insured == null)
                    {
                        insured = new Customer();
                        insured.CustomerName = dto.Insured;
                        insured.Birthday = dto.InsuredBirthday;
                        insured.CustomerClass = "Normal";
                        insured.CustomerSource = "120";//服务单
                        insured.Status = CustomerStatus.Purchased.ToString();
                        insured.Contacts = new List<ContactInfo>();
                        if (dto.Telephone.Trim().Length > 0)
                        {
                            ContactInfo ci = new ContactInfo();
                            insured.Contacts.Add(ci);
                            ci.ContactMethod = dto.Telephone.Replace("-", "");
                            if (ci.ContactMethod.Length == 13)
                            {
                                ci.ContactType = "Mobile";
                            }
                            else
                            {
                                ci.ContactType = "HomePhone";
                            }
                        }
                        if (dto.Address.Trim().Length > 0)
                        {
                            ContactInfo ci = new ContactInfo();
                            insured.Contacts.Add(ci);
                            ci.ContactMethod = dto.Address;
                            ci.ContactType = "HomeAddress";
                        }
                        custMgr.Save(insured);
                    }


                    custRMgr.CreateIfNotExistsOrUpdateRelationIfExists(policyHolder, insured, "Other");
                    ip = new InsurancePolicy();
                    ip.Category = "Life";
                    ip.EffectiveDate = dto.IPEffectiveDate;
                    ip.Premium = dto.Premium;
                    ip.PrimaryIPName = dto.PrimaryIPName;
                    ip.Remark = dto.Remark;
                    ip.CustomerId = policyHolder.CustomerId;
                    ip.InsurancePolicyNo = dto.InsurancePolicyNo;
                    ip.Insured = insured;
                    ip.PolicyHolder = policyHolder;
                    ip.Status = ConvertToCode(statusLovList, dto.IPStatus);

                    ipMgr.Save(ip);
                    dto.ImportStatus = CustomerImportDto.SUCCESS;
                }
            });
            return lists;
        }

        private string ConvertToCode(List<Lov> statusLovList, string statusName)
        {
            var lov = statusLovList.SingleOrDefault(l => l.Name == statusName);
            if (lov == null)
            {
                throw new AppException(String.Format("保单状态数据字典中不存在{0}, 请增加之。", statusName));
            }
            return lov.Code;
        }

        private static Customer GetUniqueCustomer(CustomerManager custMgr, string customerName, DateTime birthday)
        {
            List<Customer> policyHolders = custMgr.GetCustomer(customerName, birthday);
            if (policyHolders.Count > 1)
            {
                throw new AppException(String.Format("在系统中找到多个相同姓名的客户，无法区分，不能继续导入。姓名：{0},生日", customerName, birthday));
            }
            if (policyHolders.Count == 1)
            {
                return policyHolders[0];
            }
            return null;
        }
    }
}
