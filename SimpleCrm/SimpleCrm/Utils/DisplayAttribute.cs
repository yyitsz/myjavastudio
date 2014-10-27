using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SimpleCrm.Utils
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DisplayAttribute : Attribute
    {
        readonly string text;

        // This is a positional argument
        public DisplayAttribute(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }

    }

    public static class EnumEx
    {
        public static String GetDisplayName(this Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            MemberInfo[] memberInfos = enumType.GetMembers();
            Array array = Enum.GetValues(enumType);
            foreach (MemberInfo member in memberInfos)
            {
                if (member.DeclaringType == enumType && member.Name == enumValue.ToString())
                {
                    DisplayAttribute dispay = member.GetCustomAttributes(typeof(DisplayAttribute), true).ElementAtOrDefault(0) as DisplayAttribute;

                    if (dispay != null)
                    {
                        return dispay.Text;
                    }
                    return member.Name;
                }
            }
            return "";
        }
    }
}
