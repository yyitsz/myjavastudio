using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INCT.FNHProviders.Entities
{
    public class Roles
    {
        public virtual int Id { get; private set; }
        public virtual string RoleName { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<Users> UsersInRole { get; set; }

        public Roles()
        {
            UsersInRole = new List<Users>();
        }
       
    }
}
