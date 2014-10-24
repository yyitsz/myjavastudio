using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;
using System.Text.RegularExpressions;
using SimpleCrm.Utils;
using System.Data;

namespace SimpleCrm.Manager
{
    public static class ConnectionProvider
    {
        private static DbProviderFactory dbProviderfactory;
        private static String pwd;
        private static String connectionStr;
       // private static Regex pwdRegex = new Regex("Password=(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

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
                //Match match = pwdRegex.Match(connectionStr);
                //if (match.Success)
                //{
                //    String pwd = match.Groups[1].Value;
                //    if (String.IsNullOrEmpty(pwd) == false)
                //    {
                //        String npwd = PasswordUtil.Encrypt(pwd);
                //        connectionStr = connectionStr.Replace(pwd, npwd);
                //    }
                //}

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
