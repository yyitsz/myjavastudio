using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Dao;
using NHMembershipProvider.Entities;

namespace NHMembershipProvider.Dao
{
    public interface IUserDao : IBaseDao<User, int>
    {
        User GetUserByUsernameAndAppName(string username, string appName);

        IList<User> GetUsers(string appName);

        IList<User> GetUsersLikeUsername(string usernameToMatch,string appName);

        IList<User> GetUsersLikeEmail(string emailToMatch, string appName);

        int GetNumberOfUsersOnline(string appName, DateTime compareTime);

        int Count(string appName);

        IList<User> GetUsers(string appName, int pageIndex, int pageSize);

        IList<User> GetUsersLikeUsername(string appName,string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);

        IList<User> GetUsersLikeEmail(string appName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        User GetUserByEmailAndAppName(string email);

      }
}
