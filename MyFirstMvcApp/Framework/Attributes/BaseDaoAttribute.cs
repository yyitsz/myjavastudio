using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public abstract class BaseDaoAttribute : Attribute
    {
        public bool IsStateless { get; set; }
        public BaseDaoAttribute()
        {
            IsStateless = false;
        }
    }
}
