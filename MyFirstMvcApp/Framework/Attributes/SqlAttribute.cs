using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SqlAttribute : SqlBaseDaoAttribute
    {
        public SqlAttribute(string sql)
            : base(sql)
        {

        }
    }
}
