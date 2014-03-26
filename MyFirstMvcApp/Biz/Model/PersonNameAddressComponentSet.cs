using System;

using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Biz.Model
{
    public class Employee2
    {
        private ISet<EmployeeAddress> addresses;
        public Employee2()
        {
            addresses = new HashedSet<EmployeeAddress>();
        }
        public virtual int Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual ISet<EmployeeAddress> Addresses
        {
            get { return addresses; }
           // set { addresses = value; }
        }
    }


}
