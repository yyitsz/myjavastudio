using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;
using SimpleCrm.Utils;

namespace SimpleCrm.Config
{
    public partial class AppConfigForm : BaseForm
    {
        private Boolean changed;

        public AppConfigForm()
        {
            InitializeComponent();
        }
        
        private void AppConfigForm_Load(object sender, EventArgs e)
        {
            AppConfig appconfig = AppFacade.Facade.GetAppConfig();
            if (appconfig == null)
            {
                appconfig = new AppConfig();
            }
            else 
            {
                appconfig = ObjectUtil.ShallowCopy(appconfig);
            }
            appconfig.PropertyChanged += new PropertyChangedEventHandler(appconfig_PropertyChanged);
            pgAppConfig.SelectedObject = appconfig;
            ControlButton(false);
        }

        private void ControlButton(bool achanged)
        {
            this.changed = achanged;
            btnSave.Enabled = achanged;
        }

        void appconfig_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ControlButton(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfig appconfig = (AppConfig)pgAppConfig.SelectedObject;
                appconfig = ObjectUtil.ShallowCopy(appconfig);
                AppFacade.Facade.SaveAppConfig(appconfig);
                MessageBoxHelper.ShowPrompt(ErrorCode.SAVE_SUCCESS);
                ControlButton(false);
            }
            catch (System.Exception ex)
            {
                SimpleCrm.Utils.ExceptionHelper.HandleException(ex);
            }
          

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                if (MessageBoxHelper.ShowYesNo("设置已经改变，是否退出?") != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
