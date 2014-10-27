using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Model;
using SimpleCrm.Utils;
using SimpleCrm.DTO;
using SimpleCrm.Common;
using SimpleCrm.Facade;

namespace SimpleCrm.PendingItemForm
{
    public partial class PendingItemHandlingForm : BaseForm
    {
        public PendingItemDto PendingItemDto { get; set; }

        public PendingItemHandlingForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (superValidator.Validate())
                {
                    dataBindingPendingItem.MapToObject(this.PendingItemDto);
                    this.PendingItemDto.HandleDate = DateTime.Today;
                    AppFacade.Facade.SavePendingItem(this.PendingItemDto);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                SimpleCrm.Utils.ExceptionHelper.HandleException(ex);
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            if (PendingItemDto == null)
            {
                throw new AppException("No data provided.");
            }

            ComboBoxUtil.BindEnumType(typeof(PendingItemHandleResult), cmbHandleResult,true);

            dataBindingPendingItem.MapToControl(this.PendingItemDto);

            if (FormMode == SimpleCrm.FormMode.View)
            {
                new ReadonlyHelper(this).SetReadonly();
                btnSave.Visible = false;

            }
            else if (FormMode == SimpleCrm.FormMode.Add)
            {
            }
            else if (FormMode == SimpleCrm.FormMode.Edit)
            {
            }
        }
    }
}
