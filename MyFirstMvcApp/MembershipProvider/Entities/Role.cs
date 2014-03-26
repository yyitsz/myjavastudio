    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Entity;

namespace NHMembershipProvider.Entities
{
    public class Role : AuditableBaseEntity<int>
    {
       // public virtual int Id { get; private set; }
        public virtual string RoleName { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<User> UsersInRole { get; set; }

        public Role()
        {
            UsersInRole = new List<User>();
        }
       
    }
}
