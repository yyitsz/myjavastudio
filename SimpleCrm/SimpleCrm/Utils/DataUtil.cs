using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq.Expressions;
using SimpleCrm.Model;

namespace SimpleCrm.Utils
{
    public static class DataUtil
    {
        public static String FormatDate(DateTime date)
        {
            return date.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
        }

        public static String FormatDateTime(DateTime date)
        {
            return date.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static DateTime ParseDate(String str)
        {
            return DateTime.ParseExact(str, "yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
        }

        public static String FormatCurrency(decimal amt)
        {
            return String.Format("{0:###,##0.00}", amt);
        }

        public static String FormatTime(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        internal static string FormatDateNoSep(DateTime date)
        {
            return date.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
        }

        public static void AddRange<T>(this ISet<T> set, IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                set.Add(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}
