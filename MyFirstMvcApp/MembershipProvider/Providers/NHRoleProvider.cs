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
using System.Collections;
using Framework.Transaction;
using NHMembershipProvider.Dao;
using Castle.Core.Logging;
using NHMembershipProvider.Entities;
using Common.Logging;
using Framework.Context;
using System.Linq;

namespace NHMembershipProvider.Providers
{
    public sealed class NHRoleProvider : RoleProvider
    {
        private static ILog logger = LogManager.GetLogger<NHRoleProvider>();

        #region private
        //private string eventSource = "FNHRoleProvider";
        //private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Log.";
        private string connectionStringName;
        private string _applicationName;

        private TransactionTemplate txTemplate;
        private IRoleDao roleDao;
        private IUserDao userDao;

        #endregion

        #region Properties

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public bool WriteExceptionsToEventLog { get; set; }
        #endregion

        #region Helper Functions
        // A helper function to retrieve config values from the configuration file
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        private void WriteToEventLog(Exception e, string action)
        {
            //EventLog log = new EventLog();
            //log.Source = eventSource;
            //log.Log = eventLog;

            string message = exceptionMessage + "\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            //log.WriteEntry(message);

            logger.Error(message, e);
        }
        #endregion

        #region Private Methods
        //get a role by name
        private Entities.Role GetRole(string rolename)
        {
            Entities.Role role = null;

            role = roleDao.GetRole(rolename, this.ApplicationName);
            IList<Entities.User> us = role.UsersInRole;

            return role;
        }

        #endregion

        #region Public Methods
        //initializes the FNH role provider
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "FNHRoleProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Role provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            // Initialize Connection.


            connectionStringName = config["connectionStringName"];


            roleDao = AppContext.Container.Resolve<IRoleDao>();
            userDao = AppContext.Container.Resolve<IUserDao>();
            txTemplate = AppContext.Container.Resolve<TransactionTemplate>();



        }

        //adds a user collection toa roles collection
        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            Entities.User usr = null;
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                    throw new ProviderException(String.Format("Role name {0} not found.", rolename));
            }

            foreach (string username in usernames)
            {
                if (username.Contains(","))
                    throw new ArgumentException(String.Format("User names {0} cannot contain commas.", username));
                //is user not exiting //throw exception

                foreach (string rolename in rolenames)
                {
                    if (IsUserInRole(username, rolename))
                        throw new ProviderException(String.Format("User {0} is already in role {1}.", username, rolename));
                }
            }


            try
            {
                foreach (string username in usernames)
                {
                    foreach (string rolename in rolenames)
                    {
                        //get the user
                        usr = userDao.GetUserByUsernameAndAppName(username, ApplicationName);

                        if (usr != null)
                        {
                            //get the role first from db
                            Entities.Role role = roleDao.GetRole(rolename, this.ApplicationName);

                            //Entities.Roles role = GetRole(rolename);
                            usr.AddRole(role);
                        }
                    }
                    userDao.SaveOrUpdate(usr);
                }

            }
            catch (Exception e)
            {

                WriteToEventLog(e, "AddUsersToRoles");

                throw;
            }


        }

        //create  a new role with a given name
        public override void CreateRole(string rolename)
        {
            if (rolename.Contains(","))
                throw new ArgumentException("Role names cannot contain commas.");

            if (RoleExists(rolename))
                throw new ProviderException("Role name already exists.");


            try
            {
                Entities.Role role = new Entities.Role();
                role.ApplicationName = this.ApplicationName;
                role.RoleName = rolename;
                roleDao.Save(role);
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "CreateRole");

                throw;
            }

        }

        //delete a role with given name
        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            bool deleted = false;
            if (!RoleExists(rolename))
                throw new ProviderException("Role does not exist.");

            if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0)
                throw new ProviderException("Cannot delete a populated role.");


            try
            {
                Entities.Role role = GetRole(rolename);
                roleDao.Delete(role);


            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteRole");

                throw;
            }


            return deleted;
        }

        //get an array of all the roles
        public override string[] GetAllRoles()
        {

            List<String> roles = new List<string>();
            try
            {
                IList<Entities.Role> allroles = roleDao.FindRolesByAppName(this.ApplicationName);
                //IList<Entities.Role> allroles = session.CreateCriteria(typeof(Entities.Role))
                //                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", this.ApplicationName))
                //                .List<Entities.Role>();

                foreach (Entities.Role r in allroles)
                {
                    roles.Add(r.RoleName);
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "GetAllRoles");

                throw;
            }

            return roles.ToArray();
        }

        //Get roles for a user by username
        public override string[] GetRolesForUser(string username)
        {
            Entities.User usr = null;
            List<String> usrroles = new List<String>();

            try
            {
                usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);
                //usr = session.CreateCriteria(typeof(Entities.User))
                //                .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                //                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", this.ApplicationName))
                //                .UniqueResult<Entities.User>();

                if (usr != null && usr.Roles != null)
                {
                    foreach (Entities.Role r in usr.Roles)
                    {
                        usrroles.Add(r.RoleName);
                    }
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "GetRolesForUser");

                throw;
            }

            return usrroles.ToArray();
        }
        //Get users in a givenrolename
        public override string[] GetUsersInRole(string rolename)
        {
            List<String> sb = new List<String>();

            try
            {
                txTemplate.Execute(tx =>
                {
                    Entities.Role role = roleDao.GetRole(rolename, this.ApplicationName);

                    IList<Entities.User> usrs = role.UsersInRole;

                    foreach (Entities.User u in usrs)
                    {
                        sb.Add(u.Username);
                    }

                }
                );
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                    WriteToEventLog(e, "GetUsersInRole");
                else
                    throw e;
            }



            return sb.ToArray();
        }

        //determine is a user has a given role
        public override bool IsUserInRole(string username, string rolename)
        {

            return txTemplate.Execute(tx =>
                {
                    bool userIsInRole = false;
                    Entities.User usr = null;
                    IList<Entities.Role> usrroles = null;
                    StringBuilder sb = new StringBuilder();

                    try
                    {
                        usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                        if (usr != null)
                        {
                            usrroles = usr.Roles;
                            foreach (Entities.Role r in usrroles)
                            {
                                if (r.RoleName.Equals(rolename))
                                {
                                    userIsInRole = true;
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (WriteExceptionsToEventLog)
                        {
                            WriteToEventLog(e, "IsUserInRole");
                        }
                        else
                        {
                            throw e;
                        }
                    }

                    return userIsInRole;
                });
        }

        //remeove users from roles
        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            Entities.User usr = null;
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                    throw new ProviderException(String.Format("Role name {0} not found.", rolename));
            }

            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (!IsUserInRole(username, rolename))
                        throw new ProviderException(String.Format("User {0} is not in role {1}.", username, rolename));
                }
            }

            //get user , get his roles , the remove the role and save   

            try
            {
                txTemplate.Execute<object>(tx =>
                    {
                        foreach (string username in usernames)
                        {
                            usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                            var rolestodelete = new List<Entities.Role>();
                            foreach (string rolename in rolenames)
                            {
                                IList<Entities.Role> roles = usr.Roles;
                                foreach (Entities.Role r in roles)
                                {
                                    if (r.RoleName.Equals(rolename))
                                        rolestodelete.Add(r);

                                }
                            }
                            foreach (Entities.Role rd in rolestodelete)
                            {
                                usr.RemoveRole(rd);
                            }

                        }
                        return null;
                    });

            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                    WriteToEventLog(e, "RemoveUsersFromRoles");
                else
                    throw;
            }


        }

        //boolen to check if a role exists given a role name
        public override bool RoleExists(string rolename)
        {
            return txTemplate.Execute(tx =>
                   {
                       bool exists = false;
                       try
                       {
                           Entities.Role role = roleDao.GetRole(rolename, this.ApplicationName);
                           if (role != null)
                           {
                               exists = true;
                           }

                       }
                       catch (Exception e)
                       {
                           if (WriteExceptionsToEventLog)
                               WriteToEventLog(e, "RoleExists");
                           else
                               throw;
                       }
                       return exists;
                   });
        }

        //find users that beloeng to a particular role , given a username, Note : does not do a LIke search
        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            List<String> sb = new List<String>();

            try
            {

                txTemplate.Execute<object>(tx =>
                    {
                        Role role = roleDao.GetRole(rolename, this.ApplicationName);

                        IList<Entities.User> users = role.UsersInRole;
                        if (users != null)
                        {
                            foreach (Entities.User u in users)
                            {
                                if (String.Compare(u.Username, usernameToMatch, true) == 0)
                                {
                                    sb.Add(u.Username);
                                }
                            }
                        }
                        return null;
                    });
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                    WriteToEventLog(e, "FindUsersInRole");
                else
                    throw e;
            }
            return sb.ToArray();

        }

        #endregion
    }
}
