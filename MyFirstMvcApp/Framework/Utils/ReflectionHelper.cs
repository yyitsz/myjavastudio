using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework.Utils
{
    public class ReflectionHelper
    {
        public const BindingFlags MemberAccessFlags = BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

        public static object InvokeMethod(object target, string methodName, params object[] parameters)
        {
            // Pick up parameter types so we can match the method properly
            Type[] parameterTypes = GetParameterTypes(parameters);
            return InvokeMethod(target, methodName, parameterTypes, parameters);


        }

        public static object InvokeMethod(object target, string methodName, Type[] parameterTypes, params object[] parameters)
        {
            if (parameterTypes == null && parameters.Length > 0)
            {
                // Call without explicit parameter types - might cause problems with overloads    
                // occurs when null parameters were passed and we couldn't figure out the parm type
                return target.GetType().InvokeMember(methodName,
                    MemberAccessFlags | BindingFlags.InvokeMethod,
                    new DefaultBinder(), target, parameters);
            }
            else
            {
                // Call with parameter types - works only if no null values were passed
                MethodInfo mi = GetMethod(target.GetType(), methodName, null, parameterTypes);
                return mi.Invoke(target, parameters);
            }
        }


        public static object InvokeGenericeMethod(object target,
            string methodName, Type[] genericeTypes, Type[] parameterTypes, params object[] parameters)
        {
            if (parameterTypes == null && parameters.Length > 0)
            {
                // Call without explicit parameter types - might cause problems with overloads    
                // occurs when null parameters were passed and we couldn't figure out the parm type

                return target.GetType().InvokeMember(methodName,
                    MemberAccessFlags | BindingFlags.InvokeMethod,
                    new DefaultBinder(genericeTypes), target, parameters);
            }
            else
            {
                // Call with parameter types - works only if no null values were passed
                MethodInfo mi = GetMethod(target.GetType(), methodName, genericeTypes, parameterTypes);
                return mi.Invoke(target, parameters);
            }
        }

        public static object InvokeGenericeMethod(object target, string methodName, Type[] genericeTypes, params object[] parameters)
        {
            // Pick up parameter types so we can match the method properly
            Type[] parameterTypes = GetParameterTypes(parameters);
            return InvokeGenericeMethod(target, methodName, genericeTypes, parameterTypes, parameters);

        }

        public static Type[] GetParameterTypes(params object[] parameters)
        {
            Type[] parameterTypes = null;
            if (parameters != null)
            {
                parameterTypes = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    // if we have null parameters we can't determine parameter types - exit
                    if (parameters[i] == null)
                    {
                        parameterTypes = null;  // clear out - don't use types        
                        break;
                    }
                    parameterTypes[i] = parameters[i].GetType();
                }
            }
            return parameterTypes;
        }

        public static Type[] GetParameterTypes(MethodInfo method)
        {
            ParameterInfo[] pis = method.GetParameters();
            Type[] parameterTypes = new Type[pis.Length];
            for (int i = 0; i < pis.Length; i++)
            {
                parameterTypes[i] = pis[i].ParameterType;
            }
            return parameterTypes;
        }

        public static MethodInfo GetMethod(Type targetType, string methodName, Type[] genericeTypes, Type[] parameters)
        {
            MethodInfo mi = targetType.GetMethod(methodName, MemberAccessFlags,
                new DefaultBinder(genericeTypes), parameters, null);

            if (genericeTypes != null && genericeTypes.Length > 0 && mi != null && mi.IsGenericMethodDefinition)
            {
                mi = mi.MakeGenericMethod(genericeTypes);
            }
            return mi;
        }

        public static T GetAttribute<T>(MemberInfo mi) where T : Attribute
        {
            object[] objs = mi.GetCustomAttributes(typeof(T), true);
            if (objs.Length > 0)
            {
                return (T)objs[0];
            }
            return default(T);
        }

        public static T GetAttribute<T>(ParameterInfo pi) where T : Attribute
        {
            object[] objs = pi.GetCustomAttributes(typeof(T), true);
            if (objs.Length > 0)
            {
                return (T)objs[0];
            }
            return default(T);
        }

        public object ExtractValueIfNullable(object o)
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

        public static Type GetGenericParameterTypeBaseOn(Type baseType, Type subclass)
        {
            if (baseType.IsGenericType == false)
            {
                throw new ArgumentException("baseType should be a generic type.");
            }

            while (subclass != null && subclass != typeof(object))
            {
                if (subclass.IsGenericType && subclass.GetGenericTypeDefinition() == baseType)
                {
                    return subclass.GetGenericArguments()[0];
                }
                else
                {
                    subclass = subclass.BaseType;
                }
            }


            return null;
        }

        public static void SetValue(object target, string propertyName, object value)
        {
            target.GetType().GetProperty(propertyName).SetValue(target, value, null);
        }
    }
}
