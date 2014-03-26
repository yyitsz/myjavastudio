using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Dao;
using NHMembershipProvider.Entities;
using Framework.Attributes;

namespace NHMembershipProvider.Dao
{
    public interface IRoleDao : IBaseDao<Role, int>
    {
        [Hql("from Role r where r.RoleName=:rolename AND r.ApplicationName=:appName")]
        Role GetRole(string rolename, string appName);

        [Hql("from Role r where r.ApplicationName=:appName")]
        IList<Role> FindRolesByAppName(string appName);
    }
}
