using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Biz.Model
{
    public class Person5
    {
        private IList<Address5> addresses;
        public Person5()
        {
            addresses = new List<Address5>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Address5> Addresses { get { return addresses; } }
    }

    public class Address5
    {
        public virtual Guid Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
