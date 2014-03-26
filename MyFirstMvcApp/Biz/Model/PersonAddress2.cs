using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz.Model
{
    public class Person2
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Address2 Address { get; set; }
    }

    public class Address2
    {
        public virtual int Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
        public virtual Person2 Person { get; set; }
    }
}
