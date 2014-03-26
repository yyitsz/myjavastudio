using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Biz.Model
{
    public class Person4
    {
        private ICollection<Address4> addresses;
        public Person4()
        {
            addresses = new HashedSet<Address4>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Address4> Addresses { get { return addresses; } }
    }

    public class Address4
    {
        public virtual Guid Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
