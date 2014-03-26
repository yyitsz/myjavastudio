using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public abstract class SqlBaseDaoAttribute : BaseDaoAttribute
    {
        public string Name { get; set; }
        public string Sql { get; private set; }
        public bool IsQuery { get; set; }
        public bool IsDynamic { get; set; }
        public string Count { get; set; }

        public SqlBaseDaoAttribute(string hql)
        {
            this.Sql = hql;
            IsQuery = true;
            IsDynamic = false;

        }
    }
}
