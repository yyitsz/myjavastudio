using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Globalization;

namespace SQLiteTools.RegisterForm
{
    public partial class RegisterManagerForm : Form
    {
        public RegisterManagerForm()
        {
            InitializeComponent();
        }

        private void btnGetMachineCode_Click(object sender, EventArgs e)
        {
            txtMachineCode.Text = new MachineCode().GetCpuInfo();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(txtMachineCode.Text)
                .Append("\n")
                .Append(txtCustomerName.Text.Trim())
                .Append("\n")
                .Append(dtpExpireDate.Value.Date.ToString("yyyyMMdd",CultureInfo.InvariantCulture));
            txtKey.Text = RsaHelper.RSAEncryptWithPrivateKey(RsaHelper.PRI_KEY,sb.ToString());
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            txtContent.Text = RsaHelper.RSADecrypWithPublicKey(RsaHelper.PUB_KEY, txtKey.Text);
        }

        private void btnGenRsaKey_Click(object sender, EventArgs e)
        {
            Tuple<String, String> keys = RsaHelper.GenRSAKey();
            txtPrivateKey.Text = keys.Item1;
            txtPublicKey.Text = keys.Item2;

        }

      
    }

    /// <summary>/// 机器码
    /// </summary>
    public class MachineCode
    {
        ///<summary>
        ///   获取cpu序列号
        ///</summary>
        ///<returns> string </returns>
        public string GetCpuInfo()
        {
            string cpuInfo = " ";
            using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
            {
                ManagementObjectCollection moc = cimobject.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    mo.Dispose();
                }
            }
            return cpuInfo.ToString();
        }

        ///<summary>
        ///   获取硬盘ID
        ///</summary>
        ///<returns> string </returns>
        public string GetHDid()
        {
            string HDid = " ";
            using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive"))
            {
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                    mo.Dispose();
                }
            }
            return HDid.ToString();
        }

        ///<summary>
        ///   获取网卡硬件地址
        ///</summary>
        ///<returns> string </returns>
        public string GetMoAddress()
        {
            string MoAddress = " ";
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        MoAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }
            return MoAddress.ToString();
        }
    }
}
