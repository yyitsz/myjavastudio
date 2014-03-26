using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Biz.Model
{
    public class Person6
    {
        private IDictionary<String,Address6> addresses;
        public Person6()
        {
            addresses = new Dictionary<String,Address6>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IDictionary<String, Address6> Addresses { get { return addresses; } }
    }

    public class Address6
    {
        public virtual Guid Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
