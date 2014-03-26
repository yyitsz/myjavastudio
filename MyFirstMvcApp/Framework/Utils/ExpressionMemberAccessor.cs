using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework.Utils
{
    public class ExpressionMemberAccessor : IMemberAccessor
    {
        private Dictionary<string, LateBoundMethod> methodCache = new Dictionary<string, LateBoundMethod>();

        public object InvokeMethod(object target, string methodName, Type[] parameterTypes, params object[] parameters)
        {
            return this.InvokeMethod(target, methodName, null, parameterTypes, parameters);
        }

        public object InvokeMethod(object target, string methodName, Type[] genericeTypes, Type[] parameterTypes, params object[] parameters)
        {
            if (parameterTypes == null)
            {
                parameterTypes = ReflectionHelper.GetParameterTypes(parameters);
            }
            if (parameters.Length > 0 
                && (parameterTypes == null || parameterTypes.Length == 0))
            {
                throw new Exception("Not infer parameter types in " + methodName + " of " + target.GetType());
            }
            string key = GenKey(target.GetType(), methodName, genericeTypes, parameterTypes);

            LateBoundMethod dele = null;
            if (methodCache.TryGetValue(key, out dele) == false)
            {
                MethodInfo mi = ReflectionHelper.GetMethod(target.GetType(), methodName, genericeTypes, parameterTypes);
                if (mi == null)
                {
                    throw new Exception("Not found method " + methodName + " in " + target.GetType());
                }
                dele = DelegateFactory.Create(mi);
                methodCache[key] = dele;
            }

            return dele(target, parameters);
        }

        private string GenKey(Type type, string methodName, Type[] genericeTypes, Type[] parameterTypes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}-{1}", type.FullName, methodName));

            if (genericeTypes != null)
            {
                foreach (var item in genericeTypes)
                {
                    sb.Append("-").Append(item.FullName);
                }
            }

            if (parameterTypes != null)
            {
                foreach (var item in parameterTypes)
                {
                    sb.Append("-").Append(item.FullName);
                }
            }
            return sb.ToString();
        }
    }
}
