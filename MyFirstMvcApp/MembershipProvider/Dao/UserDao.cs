using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHMembershipProvider.Entities;
using Framework.Dao;
using Castle.Services.Transaction;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;


namespace NHMembershipProvider.Dao
{
   
    public class UserDao : NHibernateBaseDao<User, int>, IUserDao
    {
        public UserDao(ISessionManager sessionManager)
            : base(sessionManager)
        {

        }

        public UserDao(ISessionManager sessionManager, string sessionFactoryAlias)
            : base(sessionManager, sessionFactoryAlias)
        {
        }

        public User GetUserByUsernameAndAppName(string username, string appName)
        {
            return GetSession().CreateCriteria<Entities.User>()
                            .Add(NHibernate.Criterion.Restrictions.Eq("Username", username))
                            .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                            .UniqueResult<Entities.User>();
        }


        public IList<User> GetUsers(string appName)
        {
            return GetSession().CreateCriteria<Entities.User>()
                            .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                            .List<Entities.User>();
        }


        public IList<User> GetUsersLikeUsername(string usernameToMatch, string appName)
        {
            return GetSession().CreateCriteria<Entities.User>()
                                        .Add(NHibernate.Criterion.Restrictions.Like("Username", usernameToMatch))
                                        .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                                        .List<Entities.User>();
        }


        public IList<User> GetUsersLikeEmail(string emailToMatch, string appName)
        {
            return GetSession().CreateCriteria<Entities.User>()
                            .Add(NHibernate.Criterion.Restrictions.Like("Email", emailToMatch))
                            .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                            .List<Entities.User>();
        }


        public int GetNumberOfUsersOnline(string appName, DateTime compareTime)
        {
            return (Int32)GetSession().CreateCriteria<Entities.User>()
                               .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                               .Add(NHibernate.Criterion.Restrictions.Gt("LastActivityDate", compareTime))
                               .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
        }


        public int Count(string appName)
        {
            return (Int32)GetSession().CreateCriteria<Entities.User>()
                        .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                        .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
        }


        public IList<User> GetUsers(string appName, int pageIndex, int pageSize)
        {
            return GetSession().CreateCriteria<Entities.User>()
                            .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                            .SetFirstResult(pageIndex * pageSize)
                            .SetMaxResults(pageSize)
                            .List<Entities.User>();
        }


        public IList<User> GetUsersLikeUsername(string appName, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = (Int32)GetSession().CreateCriteria<Entities.User>()
                        .Add(NHibernate.Criterion.Restrictions.Like("userName", usernameToMatch))
                         .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                         .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
            if (totalRecords == 0)
            {
                return new List<User>();
            }
            ICriteria c = GetSession().CreateCriteria<Entities.User>()
                           .Add(NHibernate.Criterion.Restrictions.Like("UserName", usernameToMatch))
                           .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName));
            if (pageIndex != int.MinValue && pageSize != int.MinValue)
            {
                c.SetMaxResults(pageSize);
                c.SetFirstResult(pageIndex * pageSize);
            }

            return c.List<Entities.User>();
        }


        public IList<User> GetUsersLikeEmail(string appName, string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = (Int32)GetSession().CreateCriteria<Entities.User>()
                        .Add(NHibernate.Criterion.Restrictions.Like("Email", emailToMatch))
                         .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                         .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
            if (totalRecords == 0)
            {
                return new List<User>();
            }
            ICriteria c = GetSession().CreateCriteria<Entities.User>()
                           .Add(NHibernate.Criterion.Restrictions.Like("Email", emailToMatch))
                           .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName));
            if (pageIndex != int.MinValue && pageSize != int.MinValue)
            {
                c.SetMaxResults(pageSize);
                c.SetFirstResult(pageIndex * pageSize);
            }

            return c.List<Entities.User>();
        }


        public User GetUserByEmailAndAppName(string email)
        {
            return  GetSession().CreateCriteria<Entities.User>()
                                .Add(NHibernate.Criterion.Restrictions.Eq("Email", email))
                                .UniqueResult<Entities.User>();
        }
    }
}
