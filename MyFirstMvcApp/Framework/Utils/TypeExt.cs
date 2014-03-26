using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Utils
{
    public static class TypeExt
    {
        public static bool IsBoolOrNullableBool(this Type type)
        {
            if (type == null)
            {
                return false;
            }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var typeOfNullable = type.GetGenericArguments()[0];
                return typeOfNullable == typeof(bool);
            }
            return typeof(bool) == type;
        }

        public static T TryParseEnum<T>(this String value, T @default)
        {
            if (string.IsNullOrEmpty(value))
            {
                return @default;
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        public static bool TryParseBool(this String value, bool @default)
        {
            if (string.IsNullOrEmpty(value))
            {
                return @default;
            }
           string tmpValue = value.ToLower();
            if ("true" == tmpValue)
            {
                return true;
            }
            else if ("false" == tmpValue)
            {
                return false;
            }

            throw new Exception(String.Format("{0} can not be converted to boolean type.",value));
        }
    }
}
