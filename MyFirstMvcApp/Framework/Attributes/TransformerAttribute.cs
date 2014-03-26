using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using System.Reflection;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public abstract class TransformerAttribute : Attribute
    {

        public Type TransformerType { get; private set; }
        public Type ReturnType { get; set; }
       
        public TransformerAttribute(Type transformerType)
        {
            TransformerType = transformerType;
        }

        public abstract IResultTransformer CreateTransformer(MethodInfo calledmethod,Type returnType);

    }
}
