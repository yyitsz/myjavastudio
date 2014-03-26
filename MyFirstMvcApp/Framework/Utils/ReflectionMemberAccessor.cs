using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework.Utils
{
    public class ReflectionMemberAccessor : IMemberAccessor
    {
        private Dictionary<String, MethodInfo> methodCache = new Dictionary<String, MethodInfo>();

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

            MethodInfo method = null;
            if (methodCache.TryGetValue(key, out method) == false)
            {
                method = ReflectionHelper.GetMethod(target.GetType(), methodName, genericeTypes, parameterTypes);
                if (method == null)
                {
                    throw new Exception("Not found method " + methodName + " in " + target.GetType());
                }
               
                methodCache[key] = method;
            }

            return method.Invoke(target, parameters);
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
