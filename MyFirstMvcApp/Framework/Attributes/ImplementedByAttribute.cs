using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class ImplementedByAttribute : BaseDaoAttribute
    {

        private readonly Type implementedType;
 

        public ImplementedByAttribute(Type implementedType)
        {
            this.implementedType = implementedType;
        }

        public Type ImplementedType
        {
            get { return implementedType; }
        }

        public String MethodName { get; set; }

      
    }

}
