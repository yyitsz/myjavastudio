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
   
    public class RoleDao : NHibernateBaseDao<Role, int>, IRoleDao
    {
        public RoleDao(ISessionManager sessionManager)
            : base(sessionManager)
        {

        }

        public RoleDao(ISessionManager sessionManager, string sessionFactoryAlias)
            : base(sessionManager, sessionFactoryAlias)
        {
        }



        public Role GetRole(string rolename, string appName)
        {
            return GetSession().CreateCriteria(typeof(Entities.Role))
                           .Add(NHibernate.Criterion.Restrictions.Eq("RoleName", rolename))
                           .Add(NHibernate.Criterion.Restrictions.Eq("ApplicationName", appName))
                           .UniqueResult<Entities.Role>();
        }
    }
}
