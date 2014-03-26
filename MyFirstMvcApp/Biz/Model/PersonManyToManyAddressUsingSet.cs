using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Biz.Model
{
    public class Person3
    {
        private Iesi.Collections.Generic.ISet<Address3> addresses;
        public Person3()
        {
            addresses = new HashedSet<Address3>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Iesi.Collections.Generic.ISet<Address3> Addresses { get { return addresses; } }
    }

    public class Address3
    {
        public virtual Guid Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
