using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;
using System.Text.RegularExpressions;
using SimpleCrm.Utils;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SimpleCrm.Manager
{
    public static class ConnectionProvider
    {
        private static DbProviderFactory dbProviderfactory;
        private static String pwd;
        private static String connectionStr;
        // private static Regex pwdRegex = new Regex("Password=(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex dataSourceRegex = new Regex("(?<=Data Source=)[^;]*(?=;)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static DbConnection GetConnection()
        {

            CreateFactory();

            DbConnection cnn = dbProviderfactory.CreateConnection();

            cnn.ConnectionString = connectionStr;
            if (String.IsNullOrEmpty(pwd) == false)
            {
                ((SQLiteConnection)cnn).SetPassword(pwd);
            }
            cnn.Open();
            return cnn;

        }

        private static void CreateFactory()
        {

            if (dbProviderfactory == null)
            {
                connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["simplecrm"].ConnectionString;
                Match match = dataSourceRegex.Match(connectionStr);
                if (match.Success)
                {
                    String ds = match.Value;
                    if (String.IsNullOrEmpty(ds) == false)
                    {
                        String newds = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ds);
                        newds = Path.GetFullPath(newds);
                        connectionStr = dataSourceRegex.Replace(connectionStr, newds);
                    }
                }

                String providerName = System.Configuration.ConfigurationManager.ConnectionStrings["simplecrm"].ProviderName;
                dbProviderfactory = DbProviderFactories.GetFactory(providerName);
                pwd = ConfigurationManager.AppSettings["appkey"];
                if (String.IsNullOrEmpty(pwd) == false)
                {
                    pwd = PasswordUtil.Decrypt(pwd);
                }

            }
        }
    }


}
