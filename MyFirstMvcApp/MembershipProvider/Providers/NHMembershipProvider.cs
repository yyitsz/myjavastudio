/*
//Software usage License : Fluent Nhibernate membership and role provider
//--------------------------------------------------
//Copyright (c) 2010, Suhel Shah (suhel.shah@gmail.com)
//All rights reserved.

//Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

//1.  Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//2.  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//3.  The name of the Author may not be used to endorse or promote products derived from this software without specific prior written permission.

//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, 
//BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
//OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
//OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
//POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using NHibernate;
using Framework;
using Castle.Facilities.NHibernateIntegration;
using NHMembershipProvider.Dao;
using NHibernate.Criterion;
using System.Collections;
using Castle.Core.Logging;
using NHMembershipProvider.Services;
using Framework.Transaction;
using Common.Logging;
using Framework.Context;

namespace NHMembershipProvider.Providers
{
    public sealed class NHMembershipProvider : MembershipProvider
    {
        private static ILog logger = LogManager.GetLogger<NHMembershipProvider>();

        #region Private
        // Global connection string, generated password length, generic exception message, event log info.
        private int newPasswordLength = 8;
        //private string eventSource = "FNHMembershipProvider";
        //private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionStringName;


        private string _applicationName;
        private bool _enablePasswordReset;
        private bool _enablePasswordRetrieval;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private int _maxInvalidPasswordAttempts;
        private int _passwordAttemptWindow;
        private MembershipPasswordFormat _passwordFormat;
        // Used when determining encryption key values.
        private MachineKeySection _machineKey;
        private int _minRequiredNonAlphanumericCharacters;
        private int _minRequiredPasswordLength;
        private string _passwordStrengthRegularExpression;

        private TransactionTemplate txTemplate;
        private IUserDao userDao;
        #endregion

        #region Public Propeties
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
        }


        public override bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
        }


        public override bool RequiresQuestionAndAnswer
        {
            get { return _requiresQuestionAndAnswer; }
        }


        public override bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
        }


        public override int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
        }


        public override int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
        }


        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _passwordFormat; }
        }


        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _minRequiredPasswordLength; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _passwordStrengthRegularExpression; }
        }

        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        public bool WriteExceptionsToEventLog { get; set; }

        /// <summary>Gets the session factory.</summary>


        #endregion

        #region Helper functions
        // A Function to retrieve config values from the configuration file
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }

            return configValue;
        }

        //Fn to create a Membership user from a Entities.Users class
        private MembershipUser ConvertToMembershipUserFromUser(Entities.User usr)
        {
            MembershipUser u = new MembershipUser(this.Name,
                                                  usr.Username,
                                                  usr.Id,
                                                  usr.Email,
                                                  usr.PasswordQuestion,
                                                  usr.Comment,
                                                  usr.IsApproved,
                                                  usr.IsLockedOut,
                                                  usr.CreationDate,
                                                  usr.LastLoginDate,
                                                  usr.LastActivityDate,
                                                  usr.LastPasswordChangedDate,
                                                  usr.LastLockedOutDate);

            return u;
        }

        //Fn that performs the checks and updates associated with password failure tracking
        private void UpdateFailureCount(string username, string failureType)
        {

            try
            {
                DateTime windowStart = new DateTime();
                int failureCount = 0;
                Entities.User usr = null;

                usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                if (!(usr == null))
                {
                    if (failureType == "password")
                    {
                        failureCount = usr.FailedPasswordAttemptCount;
                        windowStart = usr.FailedPasswordAttemptWindowStart;
                    }

                    if (failureType == "passwordAnswer")
                    {
                        failureCount = usr.FailedPasswordAnswerAttemptCount;
                        windowStart = usr.FailedPasswordAnswerAttemptWindowStart;
                    }
                }

                DateTime windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

                if (failureCount == 0 || DateTime.Now > windowEnd)
                {
                    // First password failure or outside of PasswordAttemptWindow. 
                    // Start a new password failure count from 1 and a new window starting now.

                    if (failureType == "password")
                    {
                        usr.FailedPasswordAttemptCount = 1;
                        usr.FailedPasswordAttemptWindowStart = DateTime.Now; ;
                    }

                    if (failureType == "passwordAnswer")
                    {
                        usr.FailedPasswordAnswerAttemptCount = 1;
                        usr.FailedPasswordAnswerAttemptWindowStart = DateTime.Now; ;
                    }

                }
                else
                {
                    if (failureCount++ >= MaxInvalidPasswordAttempts)
                    {
                        // Password attempts have exceeded the failure threshold. Lock out
                        // the user.
                        usr.IsLockedOut = true;
                        usr.LastLockedOutDate = DateTime.Now;

                    }
                    else
                    {
                        // Password attempts have not exceeded the failure threshold. Update
                        // the failure counts. Leave the window the same.

                        if (failureType == "password")
                        {
                            usr.FailedPasswordAttemptCount = failureCount;
                        }

                        if (failureType == "passwordAnswer")
                        {
                            usr.FailedPasswordAnswerAttemptCount = failureCount;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateFailureCount");
                    throw new ProviderException("Unable to update failure count and window start." + exceptionMessage, e);
                }
                else
                {
                    throw;
                }
            }

        }

        //CheckPassword: Compares password values based on the MembershipPasswordFormat.
        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }

        //EncodePassword:Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        private string EncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return password;
            }

            string encodedPassword = password;


            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(_machineKey.ValidationKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }
            return encodedPassword;
        }

        // UnEncodePassword :Decrypts or leaves the password clear based on the PasswordFormat.
        private string UnEncodePassword(string encodedPassword)
        {
            if (string.IsNullOrEmpty(encodedPassword))
            {
                return encodedPassword;
            }
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //   Converts a hexadecimal string to a byte array. Used to convert encryption key values from the configuration.    
        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        // WriteToEventLog
        // A helper function that writes exception detail to the event log. Exceptions
        // are written to the event log as a security measure to avoid private database
        // details from being returned to the browser. If a method does not return a status
        // or boolean indicating the action succeeded or failed, a generic exception is also 
        // thrown by the caller.

        private void WriteToEventLog(Exception e, string action)
        {
            //EventLog log = new EventLog();
            //log.Source = eventSource;
            //log.Log = eventLog;

            string message = "An exception occurred communicating with the data source.\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            //log.WriteEntry(message);

            logger.Error(message, e);
        }

        #endregion

        #region Private Methods

        //single fn to get a membership user by key or username
        private MembershipUser GetMembershipUserByKeyOrUser(bool isKeySupplied, string username, object providerUserKey, bool userIsOnline)
        {
            Entities.User usr = null;
            MembershipUser u = null;



            try
            {
                if (isKeySupplied)
                {
                    usr = userDao.Load((int)providerUserKey);
                }
                else
                {
                    usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);
                }

                if (usr != null)
                {
                    u = ConvertToMembershipUserFromUser(usr);

                    if (userIsOnline)
                    {
                        usr.LastActivityDate = System.DateTime.Now;
                        //userService.Update(usr);
                    }
                }
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUser(Object, Boolean)");
                }
                throw new ProviderException(exceptionMessage, e);
            }


            return u;
        }

        private Entities.User GetUserByUsername(string username)
        {
            Entities.User usr = null;

            try
            {
                usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UnlockUser");
                }
                throw new ProviderException(exceptionMessage, e);
            }


            return usr;

        }

        private IList<Entities.User> GetUsers()
        {
            IList<Entities.User> usrs = null;

            try
            {
                usrs = userDao.GetUsers(this.ApplicationName);
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUsers");
                }
                throw new ProviderException(exceptionMessage, e);
            }


            return usrs;

        }

        private IList<Entities.User> GetUsersLikeUsername(string usernameToMatch)
        {
            IList<Entities.User> usrs = null;

            try
            {
                usrs = userDao.GetUsersLikeUsername(usernameToMatch, this.ApplicationName);

            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUsersMatchByUsername");
                }
                throw new ProviderException(exceptionMessage, e);
            }


            return usrs;

        }

        private IList<Entities.User> GetUsersLikeEmail(string emailToMatch)
        {
            IList<Entities.User> usrs = null;

            try
            {
                usrs = userDao.GetUsersLikeEmail(emailToMatch, this._applicationName);
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUsersMatchByEmail");
                }
                throw new ProviderException(exceptionMessage, e);
            }


            return usrs;

        }
        #endregion

        #region Public methods

        // Initilaize the provider 
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "NHMemebershipProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Membership provider");
            }
            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            _maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            _passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            _minRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
            _minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            _passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            _enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            _enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
            _requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            _requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));


            string temp_format = config["passwordFormat"];
            if (temp_format == null)
            {
                temp_format = "Hashed";
            }

            switch (temp_format)
            {
                case "Hashed":
                    _passwordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    _passwordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    _passwordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }


            //
            // Initialize Connection.
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            connectionStringName = config["connectionStringName"];
            // Get encryption and decryption key information from the configuration.

            //Encryption skipped
            Configuration cfg =
                            WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            _machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

            if (_machineKey.ValidationKey.Contains("AutoGenerate"))
            {
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                {
                    throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");
                }
            }
         
            userDao = AppContext.Container.Resolve<IUserDao>();
            txTemplate = AppContext.Container.Resolve<TransactionTemplate>();
           

        }

        // Change password for a user
        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            int rowsAffected = 0;
            Entities.User usr = null;
            if (!ValidateUser(username, oldPwd))
            {
                return false;
            }

            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPwd, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                if (args.FailureInformation != null)
                {
                    throw args.FailureInformation;
                }
                else
                {
                    throw new MembershipPasswordException("Change password canceled due to new password validation failure.");
                }
            }
            return txTemplate.Execute(x =>
            {

                try
                {
                    usr = GetUserByUsername(username);

                    if (usr != null)
                    {
                        usr.Password = EncodePassword(newPwd);
                        usr.LastPasswordChangedDate = System.DateTime.Now;
                        // userService.Update(usr);
                        rowsAffected = 1;
                    }
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                    {
                        WriteToEventLog(e, "ChangePassword");
                    }
                    throw new ProviderException(exceptionMessage, e);
                }


                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            );

        }

        // Change Password Question And Answer for a user
        public override bool ChangePasswordQuestionAndAnswer(string username,
                      string password,
                      string newPwdQuestion,
                      string newPwdAnswer)
        {
            return txTemplate.Execute(tx =>
                {
                    Entities.User usr = null;
                    int rowsAffected = 0;
                    if (!ValidateUser(username, password))
                    {
                        return false;
                    }


                    try
                    {
                        usr = GetUserByUsername(username);
                        if (usr != null)
                        {
                            usr.PasswordQuestion = newPwdQuestion;
                            usr.PasswordAnswer = newPwdAnswer;
                            //userService.Update(usr);
                            rowsAffected = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                            WriteToEventLog(e, "ChangePasswordQuestionAndAnswer");
                        throw new ProviderException(exceptionMessage, e);
                    }



                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                });
        }

        // Create a new Membership user 
        public override MembershipUser CreateUser(string username,
                 string password,
                 string email,
                 string passwordQuestion,
                 string passwordAnswer,
                 bool isApproved,
                 object providerUserKey,
                 out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);
            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            MembershipUser usr = null;
            status = txTemplate.Execute(tx =>
               {
                   MembershipCreateStatus tmpStatus = MembershipCreateStatus.Success;

                   MembershipUser u = GetUser(username, false);

                   if (u == null)
                   {
                       DateTime createDate = DateTime.Now;

                       //provider user key in our case is auto int

                       Entities.User user = new Entities.User();
                       user.Username = username;
                       user.Password = EncodePassword(password);
                       user.Email = email;
                       user.PasswordQuestion = passwordQuestion;
                       user.PasswordAnswer = EncodePassword(passwordAnswer);
                       user.IsApproved = isApproved;
                       user.Comment = "";
                       user.CreationDate = createDate;
                       user.LastPasswordChangedDate = createDate;
                       user.LastActivityDate = createDate;
                       user.ApplicationName = _applicationName;
                       user.IsLockedOut = false;
                       user.LastLockedOutDate = createDate;
                       user.FailedPasswordAttemptCount = 0;
                       user.FailedPasswordAttemptWindowStart = createDate;
                       user.FailedPasswordAnswerAttemptCount = 0;
                       user.FailedPasswordAnswerAttemptWindowStart = createDate;

                       try
                       {
                           int retId = (int)userDao.Save(user);

                         

                           if ((retId < 1))
                           {
                               tmpStatus = MembershipCreateStatus.UserRejected;
                           }
                           else
                           {
                               tmpStatus = MembershipCreateStatus.Success;
                               //retrive and return user by user name
                               usr = GetUser(username, false);
                           }

                       }
                       catch (Exception e)
                       {
                           tx.SetRollbackOnly();
                           tmpStatus = MembershipCreateStatus.ProviderError;
                           if (WriteExceptionsToEventLog)
                           {
                               WriteToEventLog(e, "CreateUser");
                           }
                       }


                   }
                   else
                   {
                       tmpStatus = MembershipCreateStatus.DuplicateUserName;
                   }
                   return tmpStatus;


               });

            return usr;
        }

        // Delete a user 
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return txTemplate.Execute(tx =>
               {
                   int rowsAffected = 0;
                   Entities.User usr = null;



                   try
                   {
                       usr = GetUserByUsername(username);
                       if (usr != null)
                       {
                           userDao.Delete(usr);
                           rowsAffected = 1;
                       }
                   }
                   catch (Exception e)
                   {
                       if (WriteExceptionsToEventLog)
                           WriteToEventLog(e, "DeleteUser");
                       throw new ProviderException(exceptionMessage, e);
                   }

                   if (rowsAffected > 0)
                       return true;
                   return false;
               });
        }

        // Get all users in db
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();
            totalRecords = 0;
            totalRecords = txTemplate.Execute(tx =>
               {

                   int tmpTotalRecords;
                   IList<Entities.User> allusers = null;


                   try
                   {
                       tmpTotalRecords = userDao.Count(ApplicationName);

                       if (tmpTotalRecords > 0)
                       {
                           allusers = userDao.GetUsers(this.ApplicationName, pageIndex, pageSize);
                           foreach (Entities.User u in allusers)
                           {
                               MembershipUser mu = ConvertToMembershipUserFromUser(u);
                               users.Add(mu);
                           }
                       }
                   }
                   catch (Exception e)
                   {
                       if (WriteExceptionsToEventLog)
                       {
                           WriteToEventLog(e, "GetAllUsers");
                       }
                       throw new ProviderException(exceptionMessage, e);
                   }


                   return tmpTotalRecords;

               });

            return users;
        }

        // Gets a number of online users
        public override int GetNumberOfUsersOnline()
        {
            return txTemplate.Execute(tx =>
                {
                    TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
                    DateTime compareTime = DateTime.Now.Subtract(onlineSpan);
                    int numOnline = 0;



                    try
                    {
                        numOnline = userDao.GetNumberOfUsersOnline(this.ApplicationName, compareTime);
                        //numOnline = (Int32)session.CreateCriteria(typeof(Entities.User))
                        //                   .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", this.ApplicationName))
                        //                   .Add(NHibernate.Criterion.Restrictions.Gt("LastActivityDate", compareTime))
                        //                   .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "GetNumberOfUsersOnline");
                        }
                        throw new ProviderException(exceptionMessage, e);
                    }



                    return numOnline;
                });
        }

        // Get a password fo a user
        public override string GetPassword(string username, string answer)
        {
            return txTemplate.Execute(tx =>
                {
                    string password = string.Empty;
                    string passwordAnswer = string.Empty;

                    if (!EnablePasswordRetrieval)
                    {
                        throw new ProviderException("Password Retrieval Not Enabled.");
                    }
                    if (PasswordFormat == MembershipPasswordFormat.Hashed)
                    {
                        throw new ProviderException("Cannot retrieve Hashed passwords.");
                    }
                    try
                    {
                        Entities.User usr = GetUserByUsername(username);

                        if (usr == null)
                        {
                            throw new MembershipPasswordException("The supplied user name is not found.");
                        }
                        else
                        {
                            if (usr.IsLockedOut)
                            {
                                throw new MembershipPasswordException("The supplied user is locked out.");
                            }

                            password = usr.Password;
                            passwordAnswer = usr.PasswordAnswer;

                        }
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                            WriteToEventLog(e, "GetPassword");
                        throw new ProviderException(exceptionMessage, e);
                    }

                    if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                    {
                        UpdateFailureCount(username, "passwordAnswer");
                        throw new MembershipPasswordException("Incorrect password answer.");
                    }

                    if (PasswordFormat == MembershipPasswordFormat.Encrypted)
                        password = UnEncodePassword(password);

                    return password;
                });
        }

        // Get a membership user by username
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return txTemplate.Execute(tx => GetMembershipUserByKeyOrUser(false, username, 0, userIsOnline));
        }

        //  // Get a membership user by key ( in our case key is int)
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return txTemplate.Execute(tx => GetMembershipUserByKeyOrUser(true, string.Empty, providerUserKey, userIsOnline));
        }

        //Unlock a user given a username 
        public override bool UnlockUser(string username)
        {
            return txTemplate.Execute<bool>(tx =>
               {
                   Entities.User usr = null;
                   bool unlocked = false;

                   try
                   {
                       usr = GetUserByUsername(username);

                       if (usr != null)
                       {
                           usr.LastLockedOutDate = System.DateTime.Now;
                           usr.IsLockedOut = false;
                           //userService.Update(usr);
                           unlocked = true;
                       }
                   }
                   catch (Exception e)
                   {
                       WriteToEventLog(e, "UnlockUser");
                       throw new ProviderException(exceptionMessage, e);
                   }

                   return unlocked;
               });
        }

        //Gets a membehsip user by email
        public override string GetUserNameByEmail(string email)
        {
            return txTemplate.Execute<string>(tx =>
                {
                    Entities.User usr = null;

                    try
                    {
                        usr = userDao.GetUserByEmailAndAppName(email);
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                            WriteToEventLog(e, "GetUserNameByEmail");
                        throw new ProviderException(exceptionMessage, e);
                    }


                    if (usr == null)
                        return string.Empty;
                    else
                        return usr.Username;
                });
        }

        // Reset password for a user
        public override string ResetPassword(string username, string answer)
        {
            int rowsAffected = 0;
            string newPassword = null;
            txTemplate.Execute<object>(tx =>
                {


                    Entities.User usr = null;

                    if (!EnablePasswordReset)
                    {
                        throw new NotSupportedException("Password reset is not enabled.");
                    }

                    if (answer == null && RequiresQuestionAndAnswer)
                    {
                        UpdateFailureCount(username, "passwordAnswer");
                        throw new ProviderException("Password answer required for password reset.");
                    }

                    newPassword = System.Web.Security.Membership.GeneratePassword(newPasswordLength,
                       MinRequiredNonAlphanumericCharacters);


                    ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPassword, true);

                    OnValidatingPassword(args);

                    if (args.Cancel)
                    {
                        if (args.FailureInformation != null)
                        {
                            throw args.FailureInformation;
                        }
                        else
                        {
                            throw new MembershipPasswordException("Reset password canceled due to password validation failure.");
                        }
                    }

                    string passwordAnswer = "";

                    try
                    {
                        usr = GetUserByUsername(username);
                        if (usr == null)
                        {
                            throw new MembershipPasswordException("The supplied user name is not found.");
                        }

                        if (usr.IsLockedOut)
                        {
                            throw new MembershipPasswordException("The supplied user is locked out.");
                        }

                        if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                        {
                            UpdateFailureCount(username, "passwordAnswer");
                            throw new MembershipPasswordException("Incorrect password answer.");
                        }

                        usr.Password = EncodePassword(newPassword);
                        usr.LastPasswordChangedDate = System.DateTime.Now;
                        usr.Username = username;
                        usr.ApplicationName = this.ApplicationName;
                        //session.Update(usr);

                        rowsAffected = 1;
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                            WriteToEventLog(e, "ResetPassword");
                        throw new ProviderException(exceptionMessage, e);
                    }


                    return null;
                });
            if (rowsAffected > 0)
            {
                return newPassword;
            }
            else
            {
                throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
            }
        }

        // Update a user information 
        public override void UpdateUser(MembershipUser user)
        {
            txTemplate.Execute<Object>(tx =>
                {
                    Entities.User usr = null;


                    try
                    {
                        usr = GetUserByUsername(user.UserName);
                        if (usr != null)
                        {
                            usr.Email = user.Email;
                            usr.Comment = user.Comment;
                            usr.IsApproved = user.IsApproved;
                            // userService.Update(usr);
                        }
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "UpdateUser");
                            throw new ProviderException(exceptionMessage, e);
                        }
                    }


                    return null;
                });
        }

        // Validates as user
        public override bool ValidateUser(string username, string password)
        {

            return txTemplate.Execute<bool>(tx =>
                 {
                     bool isValid = false;
                     Entities.User usr = null;


                     try
                     {
                         usr = GetUserByUsername(username);
                         if (usr == null)
                         {
                             isValid = false;
                         }
                         else if (usr.IsLockedOut)
                         {
                             isValid = false;
                         }
                         else if (CheckPassword(password, usr.Password))
                         {
                             if (usr.IsApproved)
                             {
                                 isValid = true;
                                 usr.LastLoginDate = DateTime.Now;
                                 //userService.Update(usr);
                             }
                         }
                         else
                         {
                             UpdateFailureCount(username, "password");
                         }
                     }
                     catch (Exception e)
                     {
                         if (WriteExceptionsToEventLog)
                         {
                             WriteToEventLog(e, "ValidateUser");
                             throw new ProviderException(exceptionMessage, e);
                         }
                         else
                         {
                             throw;
                         }
                     }


                     return isValid;
                 });

        }

        // Find users by a name, note : does not do a like search
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection tmpusers = new MembershipUserCollection();
            totalRecords = 0;
            totalRecords = txTemplate.Execute<int>(tx =>
                {
                    int tmpTotalRecords = 0;


                    try
                    {

                        IList<Entities.User> allusers = userDao.GetUsersLikeUsername(this.ApplicationName,
                            usernameToMatch, pageIndex, pageSize, out  tmpTotalRecords);

                        if (allusers != null)
                        {
                            foreach (Entities.User u in allusers)
                            {
                                MembershipUser mu = ConvertToMembershipUserFromUser(u);
                                tmpusers.Add(mu);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "FindUsersByName");
                            throw new ProviderException(exceptionMessage, e);
                        }
                        else
                        {
                            throw;
                        }
                    }



                    return tmpTotalRecords;
                });

            return tmpusers;
        }



        // Search users by email , NOT a Like match
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            IList<Entities.User> allusers = null;
            MembershipUserCollection users = new MembershipUserCollection();

            totalRecords = 0;
            totalRecords = txTemplate.Execute(delegate
                 {
                     int tmpTotalRecords = 0;


                     try
                     {
                         allusers = userDao.GetUsersLikeEmail(this.ApplicationName, emailToMatch, pageIndex, pageSize, out tmpTotalRecords);
                         if (allusers != null)
                         {
                             foreach (Entities.User u in allusers)
                             {

                                 MembershipUser mu = ConvertToMembershipUserFromUser(u);
                                 users.Add(mu);

                             }
                         }
                     }
                     catch (Exception e)
                     {
                         if (WriteExceptionsToEventLog)
                         {
                             WriteToEventLog(e, "FindUsersByEmail");
                             throw new ProviderException(exceptionMessage, e);
                         }
                         else
                         {
                             throw e;
                         }
                     }


                     return tmpTotalRecords;
                 });
            return users;
        }

        #endregion
    }
}
