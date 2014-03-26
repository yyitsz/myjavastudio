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
using System.Web.Profile;
using System.Web.Configuration;
using NHibernate;
using NHMembershipProvider.Entities;
using Framework;
using Common.Logging;
using NHMembershipProvider.Dao;
using Framework.Transaction;
using Framework.Context;
using Framework.Entity;


namespace NHMembershipProvider.Providers
{
    public sealed class NHProfileProvider : System.Web.Profile.ProfileProvider
    {
        private static ILog log = LogManager.GetLogger<NHProfileProvider>();
        #region private
        //private string eventSource = "NHProfileProvider";
        //private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionStringName;
        private string _applicationName;

        private TransactionTemplate txTemplate;
        private IRoleDao roleDao;
        private IUserDao userDao;
        private IProfileDao profileDao;
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

            //string message = exceptionMessage + "\n\n";
            //message += "Action: " + action + "\n\n";
            //message += "Exception: " + e.ToString();

            //log.WriteEntry(message);

            string message = exceptionMessage + "\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            //log.WriteEntry(message);

            log.Error(message, e);
        }
        #endregion

        #region Private Methods
        //get a role by name
        private Entities.Profile GetProfile(string username, bool isAuthenticated)
        {
            Entities.Profile profile = null;
            //Is authenticated and IsAnonmous are opposites,so flip sign,IsAuthenticated = true -> notAnonymous
            bool isAnonymous = !isAuthenticated;


            try
            {
                Entities.User usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                if (usr != null)
                {
                    profile = profileDao.GetProfile(usr.Id, isAnonymous);
                    //profile = session.CreateCriteria(typeof(Entities.Profile))
                    //                    .Add(NHibernate.Criterion.Restrictions.Eq("Users_Id", usr.Id))
                    //                    .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", isAnonymous))
                    //                    .UniqueResult<Entities.Profile>();
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "GetProfileWithIsAuthenticated");

                throw;
            }


            return profile;
        }

        private Entities.Profile GetProfile(string username)
        {
            Entities.Profile profile = null;

            try
            {
                Entities.User usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                if (usr != null)
                {
                    profile = profileDao.GetProfileByUserId(usr.Id);
                }
            }
            catch (Exception e)
            {
                WriteToEventLog(e, "GetProfile(username)");
                throw;
            }


            return profile;
        }

        private Entities.Profile GetProfile(int userId)
        {
            Entities.Profile profile = null;

            try
            {
                Entities.User usr = userDao.Load(userId);

                if (usr != null)
                {
                    profile = profileDao.GetProfileByUserId(usr.Id);
                }
                else
                {
                    throw new ProviderException("Membership User does not exist");
                }

            }
            catch (Exception e)
            {
                WriteToEventLog(e, "GetProfile(id)");
                throw;
            }


            return profile;
        }

        private Entities.Profile CreateProfile(string username, bool isAnonymous)
        {
            Profile p = new Profile();
            bool profileCreated = false;


            try
            {
                Entities.User usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                if (usr != null) //membership user exits so create a profile
                {
                    p.UserId = usr.Id;
                    p.IsAnonymous = isAnonymous;
                    p.LastUpdatedDate = System.DateTime.Now;
                    p.LastActivityDate = System.DateTime.Now;
                    p.ApplicationName = this.ApplicationName;
                    profileDao.Save(p);
                    profileCreated = true;
                }
                else
                {
                    throw new ProviderException("Membership User does not exist.Profile cannot be created.");
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "GetProfile");

                throw;
            }


            if (profileCreated)
            {
                return p;
            }
            else
            {
                return null;
            }

        }

        private bool IsMembershipUser(string username)
        {

            bool hasMembership = false;



            try
            {
                Entities.User usr = userDao.GetUserByUsernameAndAppName(username, this.ApplicationName);

                if (usr != null) //membership user exits so create a profile
                {
                    hasMembership = true;
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "GetProfile");

                throw;
            }



            return hasMembership;

        }

        private bool IsUserInCollection(MembershipUserCollection uc, string username)
        {
            bool isInColl = false;
            foreach (MembershipUser u in uc)
            {
                if (u.UserName.Equals(username))
                {
                    isInColl = true;
                    break;
                }
            }

            return isInColl;

        }

        // Updates the LastActivityDate and LastUpdatedDate values  when profile properties are accessed by the
        // GetPropertyValues and SetPropertyValues methods. Passing true as the activityOnly parameter will update only the LastActivityDate.

        private void UpdateActivityDates(string username, bool isAuthenticated, bool activityOnly)
        {
            //Is authenticated and IsAnonmous are opposites,so flip sign,IsAuthenticated = true -> notAnonymous
            bool isAnonymous = !isAuthenticated;
            DateTime activityDate = DateTime.Now;


            Entities.Profile pr = GetProfile(username, isAuthenticated);
            if (pr == null)
            {
                throw new ProviderException("User Profile not found");
            }
            try
            {
                if (activityOnly)
                {
                    pr.LastActivityDate = activityDate;
                    pr.IsAnonymous = isAnonymous;
                }
                else
                {
                    pr.LastActivityDate = activityDate;
                    pr.LastUpdatedDate = activityDate;
                    pr.IsAnonymous = isAnonymous;
                }


            }
            catch (Exception e)
            {

                WriteToEventLog(e, "UpdateActivityDates");
                throw;

            }
        }

        private bool DeleteProfile(string username)
        {
            // Check for valid user name.
            if (username == null)
                throw new ArgumentNullException("User name cannot be null.");
            if (username.Contains(","))
                throw new ArgumentException("User name cannot contain a comma (,).");

            Entities.Profile profile = GetProfile(username);
            if (profile == null)
                return false;


            try
            {
                profileDao.Delete(profile);

            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteProfile");

                throw;
            }


            return true;
        }

        private bool DeleteProfile(int id)
        {
            // Check for valid user name.
            Entities.Profile profile = GetProfile(id);
            if (profile == null)
                return false;


            try
            {
                profileDao.Delete(profile);

            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteProfile(id)");

                throw;
            }


            return true;
        }

        private int DeleteProfilesbyId(string[] ids)
        {
            int deleteCount = 0;
            try
            {
                foreach (string id in ids)
                {
                    if (DeleteProfile(id))
                    {
                        deleteCount++;
                    }
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteProfiles(Id())");

                throw;

            }
            return deleteCount;
        }

        private void CheckParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                throw new ArgumentException("Page index must 0 or greater.");
            if (pageSize < 1)
                throw new ArgumentException("Page size must be greater than 0.");
        }

        private ProfileInfo GetProfileInfoFromProfile(Entities.Profile p)
        {

            Entities.User usr = userDao.Load(p.UserId);


            if (usr == null)
            {
                throw new ProviderException("The userid not found in memebership tables.GetProfileInfoFromProfile(p)");
            }


            // ProfileInfo.Size not currently implemented.
            ProfileInfo pi = new ProfileInfo(usr.Username, p.IsAnonymous, p.LastActivityDate, p.LastUpdatedDate, 0);

            return pi;
        }
        #endregion

        #region Public Methods
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "FNHProfileProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample Fluent Nhibernate Profile provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            _applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            // Initialize Connection.

            connectionStringName = config["connectionStringName"];

            roleDao = AppContext.Container.Resolve<IRoleDao>();
            userDao = AppContext.Container.Resolve<IUserDao>();
            profileDao = AppContext.Container.Resolve<IProfileDao>();

            txTemplate = AppContext.Container.Resolve<TransactionTemplate>();


        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection ppc)
        {
            return txTemplate.Execute(tx =>
                {
                    string username = (string)context["UserName"];
                    bool isAuthenticated = (bool)context["IsAuthenticated"];
                    Entities.Profile profile = null;

                    profile = GetProfile(username, isAuthenticated);
                    // The serializeAs attribute is ignored in this provider implementation.
                    SettingsPropertyValueCollection svc = new SettingsPropertyValueCollection();

                    if (profile == null)
                    {
                        if (IsMembershipUser(username))
                            profile = CreateProfile(username, false);
                        else
                            throw new ProviderException("Profile cannot be created. There is no membership user");
                    }


                    foreach (SettingsProperty prop in ppc)
                    {
                        SettingsPropertyValue pv = new SettingsPropertyValue(prop);
                        switch (prop.Name)
                        {
                            case "IsAnonymous":
                                pv.PropertyValue = profile.IsAnonymous;
                                break;
                            case "LastActivityDate":
                                pv.PropertyValue = profile.LastActivityDate;
                                break;
                            case "LastUpdatedDate":
                                pv.PropertyValue = profile.LastUpdatedDate;
                                break;
                            case "Subscription":
                                pv.PropertyValue = profile.Subscription;
                                break;
                            case "Language":
                                pv.PropertyValue = profile.Language;
                                break;
                            case "FirstName":
                                pv.PropertyValue = profile.FirstName;
                                break;
                            case "LastName":
                                pv.PropertyValue = profile.LastName;
                                break;
                            case "Gender":
                                pv.PropertyValue = profile.Gender;
                                break;
                            case "BirthDate":
                                pv.PropertyValue = profile.BirthDate;
                                break;
                            case "Occupation":
                                pv.PropertyValue = profile.Occupation;
                                break;
                            case "Website":
                                pv.PropertyValue = profile.Website;
                                break;
                            case "Street":
                                pv.PropertyValue = profile.Street;
                                break;
                            case "City":
                                pv.PropertyValue = profile.City;
                                break;
                            case "State":
                                pv.PropertyValue = profile.State;
                                break;
                            case "Zip":
                                pv.PropertyValue = profile.Zip;
                                break;
                            case "Country":
                                pv.PropertyValue = profile.Country;
                                break;

                            default:
                                throw new ProviderException("Unsupported property.");
                        }

                        svc.Add(pv);
                    }

                    UpdateActivityDates(username, isAuthenticated, true);
                    return svc;
                });
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection ppvc)
        {
            txTemplate.Execute<object>(tx =>
                {
                    Entities.Profile profile = null;
                    // The serializeAs attribute is ignored in this provider implementation.
                    string username = (string)context["UserName"];
                    bool isAuthenticated = (bool)context["IsAuthenticated"];



                    profile = GetProfile(username, isAuthenticated);

                    if (profile == null)
                    {
                        profile = CreateProfile(username, !isAuthenticated);
                    }
                    foreach (SettingsPropertyValue pv in ppvc)
                    {
                        switch (pv.Property.Name)
                        {
                            case "IsAnonymous":
                                profile.IsAnonymous = (bool)pv.PropertyValue;
                                break;
                            case "LastActivityDate":
                                profile.LastActivityDate = (DateTime)pv.PropertyValue;
                                break;
                            case "LastUpdatedDate":
                                profile.LastUpdatedDate = (DateTime)pv.PropertyValue;
                                break;
                            case "Subscription":
                                profile.Subscription = pv.PropertyValue.ToString();
                                break;
                            case "Language":
                                profile.Language = pv.PropertyValue.ToString();
                                break;
                            case "FirstName":
                                profile.FirstName = pv.PropertyValue.ToString();
                                break;
                            case "LastName":
                                profile.LastName = pv.PropertyValue.ToString();
                                break;
                            case "Gender":
                                profile.Gender = pv.PropertyValue.ToString();
                                break;
                            case "BirthDate":
                                profile.BirthDate = (DateTime)pv.PropertyValue;
                                break;
                            case "Occupation":
                                profile.Occupation = pv.PropertyValue.ToString();
                                break;
                            case "Website":
                                profile.Website = pv.PropertyValue.ToString();
                                break;
                            case "Street":
                                profile.Street = pv.PropertyValue.ToString();
                                break;
                            case "City":
                                profile.City = pv.PropertyValue.ToString();
                                break;
                            case "State":
                                profile.State = pv.PropertyValue.ToString();
                                break;
                            case "Zip":
                                profile.Zip = pv.PropertyValue.ToString();
                                break;
                            case "Country":
                                profile.Country = pv.PropertyValue.ToString();
                                break;
                            default:
                                throw new ProviderException("Unsupported property.");
                        }
                    }


                    UpdateActivityDates(username, isAuthenticated, false);
                    return null;
                });
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            int deleteCount = 0;
            try
            {
                foreach (ProfileInfo p in profiles)
                {
                    if (txTemplate.Execute(tx => DeleteProfile(p.UserName)))
                    {
                        deleteCount++;
                    }
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteProfiles(ProfileInfoCollection)");

                throw;
            }
            return deleteCount;
        }

        public override int DeleteProfiles(string[] usernames)
        {
            int deleteCount = 0;
            try
            {
                foreach (string user in usernames)
                {
                    if (txTemplate.Execute(tx => DeleteProfile(user)))
                        deleteCount++;
                }
            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteProfiles(String())");

                throw;

            }
            return deleteCount;
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            int count = 0;
            bool anaon = false;
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    anaon = true;
                    break;
                case ProfileAuthenticationOption.Authenticated:
                    anaon = false;
                    break;
                default:
                    break;
            }


            try
            {
                count = txTemplate.Execute(tx => profileDao.DeleteInactiveAndAnonymousProfile(this.ApplicationName, userInactiveSinceDate, anaon));
                //IList<Entities.Profile> profs = session.CreateCriteria(typeof(Entities.Profile))
                //                                .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", this.ApplicationName))
                //                                .Add(NHibernate.Criterion.Restrictions.Le("LastActivityDate", userInactiveSinceDate))
                //                                .Add(NHibernate.Criterion.Restrictions.Eq("IsAnonymous", anaon))
                //                                .List<Entities.Profile>();


            }
            catch (Exception e)
            {

                WriteToEventLog(e, "DeleteInactiveProfiles");

                throw e;
            }


            return count;
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                       int pageIndex,
                                                                       int pageSize,
                                                                       out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                              DateTime userInactiveSinceDate,
                                                                              int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex,
                                                                              int pageSize,
                                                                              out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, null, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate,
                                                                          int pageIndex,
                                                                          int pageSize,
                                                                          out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            int inactiveProfiles = 0;

            ProfileInfoCollection profiles =
              GetProfileInfo(authenticationOption, null, userInactiveSinceDate, 0, 0, out inactiveProfiles);

            return inactiveProfiles;
        }


        // GetProfileInfo
        // Retrieves a count of profiles and creates a 
        // ProfileInfoCollection from the profile data in the 
        // database. Called by GetAllProfiles, GetAllInactiveProfiles,
        // FindProfilesByUserName, FindInactiveProfilesByUserName, 
        // and GetNumberOfInactiveProfiles.
        // Specifying a pageIndex of 0 retrieves a count of the results only.
        //

        private ProfileInfoCollection GetProfileInfo(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
                                                                      DateTime? userInactiveSinceDate,
                                                                      int pageIndex,
                                                                      int pageSize,
                                                                      out int totalRecords)
        {

            bool isAnaon = false;
            ProfileInfoCollection profilesInfoColl = new ProfileInfoCollection();
            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.Anonymous:
                    isAnaon = true;
                    break;
                case ProfileAuthenticationOption.Authenticated:
                    isAnaon = false;
                    break;
                default:
                    break;
            }


            try
            {
                BaseSearchingResult<ProfileInfo> allProfiles = profileDao.SearchProfile(this.ApplicationName, userInactiveSinceDate, isAnaon);

                foreach (ProfileInfo p in allProfiles.Result)
                {
                    profilesInfoColl.Add(p);

                }
                unchecked
                {
                    totalRecords = (int)allProfiles.TotalRecords;
                }


            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetProfileInfo");
                    throw new ProviderException(exceptionMessage, e);
                }
                else
                    throw;

            }

            return profilesInfoColl;
        }



        #endregion
    }
}
