using System;
using Iesi.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz.Model
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
        public virtual ISet<Role> Roles { get; set; }

    }

    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<User> Users { get; set; }
    }
}
