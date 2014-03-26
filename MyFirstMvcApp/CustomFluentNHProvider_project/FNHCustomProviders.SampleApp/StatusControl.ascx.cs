using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FNHCustomProviders.SampleApp
{
    public partial class StatusControl : System.Web.UI.UserControl
    {
         public string LoggedinName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblUserName.Text = this.LoggedinName;
        }
    }
}