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

            if (txtCustomerName.Text.Trim().Length < 3 && txtCustomerName.Text.Trim().Length <= 20)
            {
                MessageBox.Show("客户名必填, 3个字符以上20个字符以下。");
                return;
            }

            if (txtMachineCode.Text.Trim().Length > 30)
            {
                MessageBox.Show("机器码必须在30个字符以下。");
                return;
            }
            if (txtMachineCode.Text.Trim().Length == 0
                && MessageBox.Show("机器码未填表示可任意在任何机器上，是否继续？","提示",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(txtCustomerName.Text)
                .Append("\n")
                .Append(txtMachineCode.Text.Trim())
                .Append("\n")
                .Append(dtpExpireDate.Value.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture))
                .Append("\n")
                .Append(" ");
            txtKey.Text = RsaHelper.RSAEncryptWithPrivateKey(RsaHelper.PRI_KEY, sb.ToString());
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

        private void RegisterManagerForm_Load(object sender, EventArgs e)
        {
            dtpExpireDate.Value = DateTime.Now.Date.AddMonths(3);
        }


    }

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

    }
}
