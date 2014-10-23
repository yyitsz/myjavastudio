using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace SQLiteTools.Utils
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
    }
}
