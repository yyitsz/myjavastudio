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

        internal List<Customer> GetRelatedCustomerList(long primaryCustomerId)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                return customerMgr.GetByPrimaryCustomer(primaryCustomerId);
            });
        }

        internal DTO.PageSearchResultDto<DTO.CustomerSearchResultDto> SearchCustomer(DTO.CustomerSearchParamDto customerSearchParamDto)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                return customerMgr.SearchCustomer(customerSearchParamDto);
            });
        }

        public void SaveCustomer(Customer customer, IEnumerable<Customer> deletingList)
        {
            ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);
                if (deletingList != null)
                {
                    customerMgr.DeleteBatch(deletingList);
                }
                customerMgr.Save(customer);
                customer.FamilyMember.ForEach(c => c.PrimaryCustomerId = customer.CustomerId);
                customerMgr.SaveFamily(customer.FamilyMember);

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
                customerMgr.DeleteBatch(customer.FamilyMember);
                customerMgr.Delete(customer);
            });
        }
        public Customer GetCustomer(long customerId)
        {
            return ExecutedInTx(conn =>
            {
                CustomerManager customerMgr = new CustomerManager(conn);

                Customer customer = customerMgr.FindOne(customerId);

                customer.FamilyMember = customerMgr.GetFamily(customer.CustomerId.Value).ToList();
                return customer;
            });
        }

        public Customer GetCustomerBaseInfo(long customerId)
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
    }
}
