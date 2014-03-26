using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using NHMembershipProvider.Dao;
using NHMembershipProvider.Entities;

namespace NHMembershipProvider.Services
{
    [Transactional]
    public class UserService : IUserService
    {
        IUserDao userDao;

        
        public UserService(IUserDao userDao)
        {
            this.userDao = userDao;
        }
        [Transaction]
        public Entities.User GetUserByUsernameAndAppName(string username, string appName)
        {
            return userDao.GetUserByUsernameAndAppName(username, appName);
        }
        [Transaction]
        public IList<Entities.User> GetUsers(string appName)
        {
            return userDao.GetUsers(appName);
        }
        [Transaction]
        public IList<Entities.User> GetUsersLikeUsername(string usernameToMatch, string appName)
        {
            return userDao.GetUsersLikeUsername(usernameToMatch, appName);
        }
        [Transaction]
        public IList<Entities.User> GetUsersLikeEmail(string emailToMatch, string appName)
        {
            return userDao.GetUsersLikeEmail(emailToMatch, appName);
        }
        [Transaction]
        public int GetNumberOfUsersOnline(string appName, DateTime compareTime)
        {
            return userDao.GetNumberOfUsersOnline(appName, compareTime);
        }
        [Transaction]
        public int Count(string appName)
        {
            return userDao.Count(appName);
        }
        [Transaction]
        public IList<Entities.User> GetUsers(string appName, int pageIndex, int pageSize)
        {
            return userDao.GetUsers(appName, pageIndex, pageSize);
        }
        [Transaction]
        public IList<Entities.User> GetUsersLikeUsername(string appName, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return userDao.GetUsersLikeUsername(appName, usernameToMatch, pageIndex, pageSize, out  totalRecords);
        }
        [Transaction]
        public IList<Entities.User> GetUsersLikeEmail(string appName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return userDao.GetUsersLikeEmail(appName, emailToMatch, pageIndex, pageSize, out  totalRecords);
        }
        [Transaction]
        public Entities.User GetUserByEmailAndAppName(string email)
        {
            return userDao.GetUserByEmailAndAppName(email);
        }


        public void UpdateFailureCount(string username, string failureType, string appName,
            int passwordAttemptWindow, int maxInvalidPasswordAttempts)
        {
            DateTime windowStart = new DateTime();
            int failureCount = 0;
            Entities.User usr = null;

            usr = GetUserByUsernameAndAppName(username,appName);

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

            DateTime windowEnd = windowStart.AddMinutes(passwordAttemptWindow);

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
                if (failureCount++ >= maxInvalidPasswordAttempts)
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
            //userDao.Update(usr);
        }





        public User LoadUser(int id)
        {
            return userDao.Load(id);
        }


        public int Save(User user)
        {
            return userDao.Save(user);
        }
    }
}
