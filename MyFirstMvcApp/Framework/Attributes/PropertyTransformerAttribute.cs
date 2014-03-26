using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using System.Reflection;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class PropertyTransformerAttribute : TransformerAttribute
    {


        public PropertyTransformerAttribute()
            : base(typeof(AliasToBeanResultTransformer))
        {

        }



        public override NHibernate.Transform.IResultTransformer CreateTransformer(MethodInfo calledmethod, Type returnType)
        {
            return new AliasToBeanResultTransformer(returnType);
        }
    }
}
