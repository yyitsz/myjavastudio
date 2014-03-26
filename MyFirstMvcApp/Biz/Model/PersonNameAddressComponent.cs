using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz.Model
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual EmployeeAddress Address { get; set; }
    }

    public class Name
    {
        public virtual String First { get; set; }
        public virtual String Last { get; set; }
    }
    public class EmployeeAddress
    {
        public virtual String Street { get; set; }
        public virtual int CivicNumber { get; set; }
    }
}
