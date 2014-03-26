using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHMembershipProvider.Entities;

namespace NHMembershipProvider.Services
{
    public interface IUserService
    {
        User GetUserByUsernameAndAppName(string username, string appName);

        IList<User> GetUsers(string appName);

        IList<User> GetUsersLikeUsername(string usernameToMatch, string appName);

        IList<User> GetUsersLikeEmail(string emailToMatch, string appName);

        int GetNumberOfUsersOnline(string appName, DateTime compareTime);

        int Count(string appName);

        IList<User> GetUsers(string appName, int pageIndex, int pageSize);

        IList<User> GetUsersLikeUsername(string appName, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);

        IList<User> GetUsersLikeEmail(string appName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        User GetUserByEmailAndAppName(string email);

        void UpdateFailureCount(string username, string failureType, string appName, int passwordAttemptWindow, int maxInvalidPasswordAttempts);

      

        User LoadUser(int id);

        int Save(User user);
    }
}
