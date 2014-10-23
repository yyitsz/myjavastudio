using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;

namespace SimpleCrm.Manager
{
    public class UserManager : BaseRepo<User,String>
    {
        private static UserProfile userProfile = new UserProfile();
        public static UserProfile UserProfile { get { return userProfile; } }

        public UserManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public override int Create(User user)
        {
            int count = Connection.Count<User>(new { UserId = user.UserId });
            if (count > 0)
            {
                throw new AppException("用户 " + user.UserId + " 已经存在.");
            }
            return Connection.Insert(user);
        }

        internal IEnumerable<User> SearchUserByExample(User user)
        {
            return Connection.GetListByExample<User>(user);
        }
    }
}
