using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;
using SimpleCrm.Utils;

namespace SimpleCrm
{
    public partial class BaseForm : DevComponents.DotNetBar.Office2007Form
    {

        private Boolean forceClose = false;

        public FormMode FormMode { get; set; }
        public BaseForm()
        {
            FormMode = SimpleCrm.FormMode.Add;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
                WindowsFormsSynchronizationContext.Current.Post(d =>
                    {
                        forceClose = true;
                        ((Form)d).Close();
                    }, this);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            foreach (var form in this.OwnedForms)
            {
                try
                {
                    form.Close();
                }
                catch
                { }
            }

            if (forceClose)
            {
                return;
            }
            base.OnClosing(e);
        }

     
    }

    public enum FormMode
    {
        Add,
        Edit,
        Delete,
        View,
    }
}