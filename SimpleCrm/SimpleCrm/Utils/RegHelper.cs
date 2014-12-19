using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using Microsoft.Win32;
using System.Globalization;
using System.Diagnostics;

namespace SimpleCrm.Utils
{
    public class RegHelper
    {
        public static readonly string SOFTWARE_NAME = "SimpleCRM";
        public static string GetCpuInfo()
        {
            string cpuInfo = " ";
            using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
            {
                ManagementObjectCollection moc = cimobject.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    //mo.Dispose();
                }
            }
            return cpuInfo.ToString();
        }

        public static void SaveValueToRegister(String name, String value)
        {
            RegistryKey retkey = Registry.LocalMachine
                .OpenSubKey("Software", true)
                .CreateSubKey(SOFTWARE_NAME);
            retkey.SetValue(name, value, RegistryValueKind.String);
        }

        public static string GetValueFromRegister(String name)
        {
            String value = null;
            RegistryKey retkey = Registry.LocalMachine
                .OpenSubKey("Software", true)
                .CreateSubKey(SOFTWARE_NAME);
            value = Convert.ToString(retkey.GetValue(name));
            return value;
        }

        public static LicenseInfo CheckLicenseFromRegister()
        {
            String key = GetValueFromRegister("license");
            string startdate = GetValueFromRegister("ksrq");
            DateTime result = DateTime.Now.Date;
            if (startdate != null)
            {
                if (!DateTime.TryParseExact(startdate, "MMddyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    result = DateTime.MinValue;
                }
            }
            else 
            {
                SaveValueToRegister("ksrq",DateTime.Now.ToString("MMddyy",CultureInfo.InvariantCulture));
            }
            LicenseInfo info = CheckLicense(key, result);
            return info;
        }

        public static LicenseInfo CheckLicense(string license)
        {
            return CheckLicense(license, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// -1 no license
        /// 0 trial
        /// 1 registered,normal
        /// 2 registered, expired
        /// 3 registered, wrong machine.
        /// </returns>
        public static LicenseInfo CheckLicense(String license, DateTime? startDate)
        {
            if (license == null || String.IsNullOrWhiteSpace(license))
            {
                if (startDate != null)
                {
                    if (startDate.value > DateTime.Now.Date || startDate.Value.AddDays(15) <= DateTime.Now.Date)
                    {
                        return new LicenseInfo(-1);
                    }
                    else
                    {
                        return new LicenseInfo(0, "试用用户", startDate.Value.AddDays(15));
                    }
                }
                else
                {
                    return new LicenseInfo(0, "试用用户", DateTime.Now.Date.AddDays(15)); ;
                }
            }
            else
            {
                try
                {
                    String regInfo = SimpleRsaHelper.RSADecrypWithPublicKey(SimpleRsaHelper.PUB_KEY, license);
                    String[] regInfoItems = regInfo.Split('\n');
                    String machineInfo = regInfoItems[1];
                    String username = regInfoItems[0];
                    String expireDateStr = regInfoItems[2];
                    string functionslist = regInfoItems[3];

                    DateTime expireDate;
                    if (!DateTime.TryParseExact(expireDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expireDate))
                    {
                        expireDate = DateTime.MaxValue;
                    }
                    if (expireDate < DateTime.Now)
                    {
                        LicenseInfo info = new LicenseInfo(2, username, expireDate);
                        return info;
                    }

                    if (!string.IsNullOrWhiteSpace(machineInfo))
                    {
                        String localMachineCode = GetCpuInfo();
                        if (machineInfo != localMachineCode)
                        {
                            LicenseInfo info = new LicenseInfo(3, username, expireDate);
                            return info;
                        }
                    }
                    return new LicenseInfo(1, username, expireDate);

                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached)
                    {
                        Debug.Write(ex);
                    }
                    return new LicenseInfo(-1);
                }

            }
        }
    }
    public class LicenseInfo
    {
        /// <summary>
        /// -1 no license
        /// 0 trial
        /// 1 registered,normal
        /// 2 registered, expired
        /// 3 registered, wrong machine.
        /// </summary>
        public int Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public String CustomerName { get; set; }
        public String FunctionList { get; set; }

        public LicenseInfo(int status)
            : this(status, "未注册用户")
        {
        }
        public LicenseInfo(int status, String customerName)
            : this(status, customerName, new DateTime(2014, 1, 1))
        {
        }
        public LicenseInfo(int status, String customerName, DateTime expireDate)
        {
            Status = status;
            CustomerName = customerName;
            ExpireDate = expireDate;
        }
    }
}
