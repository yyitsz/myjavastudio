using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Manager;
using SimpleCrm.Config;
using SimpleCrm.Utils;
using System.IO;
using SimpleCrm.Facade;

namespace SimpleCrm.MasterForm
{
    public partial class OptionsForm : SimpleCrm.BaseForm
    {
        private AppConfig appConfig;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            appConfig = AppFacade.Facade.GetAppConfig();
            if (appConfig == null)
            {
                appConfig = new AppConfig();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFormValue())
                {
                    AppFacade.Facade.SaveAppConfig(appConfig);
                    MessageBoxHelper.ShowPrompt("Saved Successful.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private bool ValidateFormValue()
        {
            //if 
            //    )
            //{
            //    MessageBoxHelper.ShowPrompt("All options must be inpuuted.");
            //    return false;
            //}


            return true;
        }

       
        private void btnCacnel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
