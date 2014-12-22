using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Utils;
using System.Globalization;
using SimpleCrm.Facade;
using SimpleCrm.Model;

namespace SimpleCrm.SecurityForm
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string tmp = @"<div style='text-align:center'><h1>{0}</h1></div>
<br />
<div>版本号: {1} </div>
<div>数据库版本号：{2}</div>
<div>授权给:{3}</div>
<div>过期日:{4}</div>
版权所有。
";
            String dbversion = "";
            SystemConfig config = AppFacade.Facade.GetSystemConfig();
            if (config != null)
            {
                dbversion = config.DbVersion;
            }
            LicenseInfo licenseInfo = RegHelper.CheckLicenseFromRegister();
            lblMsg.Text = string.Format(tmp
                ,"Simple客户关系管理系统"
              , Application.ProductVersion
              ,dbversion
              ,licenseInfo.CustomerName
              ,licenseInfo.ExpireDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
              );

        }
    }
}
