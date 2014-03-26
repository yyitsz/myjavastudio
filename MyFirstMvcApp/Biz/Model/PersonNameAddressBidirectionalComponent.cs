using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz.Model
{
    public class Employee3
    {
        public int Id { get; set; }
        public Name3 Name { get; set; }
        public EmployeeAddress3 Address { get; set; }
    }

    public class Name3
    {
        public virtual Employee3 Person { get; set; }
        public virtual String First { get; set; }
        public virtual String Last { get; set; }
    }
    public class EmployeeAddress3
    {
        public virtual String Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
