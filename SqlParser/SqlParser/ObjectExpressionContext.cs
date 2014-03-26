using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace SqlParser
{
    public class ObjectExpressionContext : Dictionary<String, Object>, IExpressionContext
    {
        Object target;
        PropertyDescriptorCollection props;
        public ObjectExpressionContext(object target)
        {
            this.target = target;
            if (this.target != null)
            {
                props = System.ComponentModel.TypeDescriptor.GetProperties(target);
            }
        }
        public object GetValue(string propertyName)
        {
            object o = null;
            if (this.TryGetValue(propertyName, out o))
            {
               
            }
            else
            {
                if (this.target != null)
                {
                    PropertyDescriptor prop = props.Find(propertyName, true);
                    if (prop != null)
                    {
                        o = prop.GetValue(target);
                    }
                }
            }
            return ExtractValueIfNullable(o);

        }

        private object ExtractValueIfNullable(object o)
        {
            if (o == null)
            {
                return null;
            }

            if (o.GetType().IsGenericType && o.GetType().GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                PropertyInfo pi = o.GetType().GetProperty("Value");
                return pi.GetValue(o, null);

            }
            return o;
        }
    }
}
