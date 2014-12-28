using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SimpleCrm.Utils
{
    public sealed class ObjectUtil
    {
        /// <summary>
        /// Copy Simply properties from sourceObject to toObject .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="toObject">To object.</param>
        public static void ShallowCopy<T>(T sourceObject, T toObject)
        {
            ShallowCopy<T>(sourceObject, toObject, null);
        }

        public static T ShallowCopy<T>(T sourceObject) where T : new()
        {
            T toObject = new T();
            ShallowCopy<T>(sourceObject, toObject, null);
            return toObject;
        }

        /// <summary>
        /// Shallows the copy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="toObject">To object.</param>
        /// <param name="excludedProperties">The excluded properties.</param>
        public static void ShallowCopy<T>(T sourceObject, T toObject, params string[] excludedProperties)
        {
            if (sourceObject == null)
            {
                throw new ArgumentNullException("sourceObject");
            }
            if (toObject == null)
            {
                throw new ArgumentNullException("toObject");
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (excludedProperties != null && Array.IndexOf<String>(excludedProperties, pi.Name) >= 0)
                {
                    continue;
                }
                if (pi.CanRead && pi.CanWrite && pi.Name != "Item")
                {
                    object value = pi.GetValue(sourceObject, null);
                    try
                    {
                        pi.SetValue(toObject, value, null);
                    }
                    catch { }
                }
            }
        }

        public static void Copy<T1, T2>(T1 sourceObject, T2 toObject, params string[] excludedProperties)
        {
            if (sourceObject == null)
            {
                throw new ArgumentNullException("sourceObject");
            }
            if (toObject == null)
            {
                throw new ArgumentNullException("toObject");
            }

            PropertyInfo[] properties1 = typeof(T1).GetProperties();
            PropertyInfo[] properties2 = typeof(T2).GetProperties();
            foreach (PropertyInfo pi1 in properties1)
            {
                if (pi1.CanRead == false
                    || pi1.Name == "Item"
                    || excludedProperties != null && Array.IndexOf<String>(excludedProperties, pi1.Name) >= 0)
                {
                    continue;
                }
                PropertyInfo pi2 = null;
                foreach (PropertyInfo tmp in properties2)
                {
                    if (tmp.PropertyType == pi1.PropertyType && tmp.Name == pi1.Name && tmp.CanWrite)
                    {
                        pi2 = tmp;
                        break;
                    }
                }
                if (pi2 == null)
                {
                    continue;
                }

                object value = pi1.GetValue(sourceObject, null);
                try
                {
                    pi2.SetValue(toObject, value, null);
                }
                catch { }

            }
        }


        #region Deep Clone
        /// <summary>
        /// Clones the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static object Clone(object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memStream, obj);
                memStream.Position = 0;
                return (formatter.Deserialize(memStream));
            }
        }

        /// <summary>
        ///  Clone Deeply.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static T DeepClone<T>(T obj)
        {
            if (obj == null)
            {
                return obj;
            }
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memStream, obj);
                memStream.Position = 0;
                return (T)(formatter.Deserialize(memStream));
            }
        }
        #endregion
    }
}
