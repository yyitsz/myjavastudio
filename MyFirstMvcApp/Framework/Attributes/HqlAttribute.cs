using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class HqlAttribute : SqlBaseDaoAttribute
    {
       
        public HqlAttribute(string hql):base(hql)
        {
           
        }
    }
}
