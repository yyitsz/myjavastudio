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

namespace SimpleCrm.ScheduleForm
{
    public partial class AppointmentForm : BaseForm
    {
        public AppointmentInfo Appointment { get; set; }

        public AppointmentForm()
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
            if (superValidator.Validate())
            {
                dataBindingAppointment.MapToObject(this.Appointment);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            if (Appointment == null)
            {
                this.Appointment = new AppointmentInfo();
            }

            dataBindingAppointment.MapToControl(this.Appointment);

            if (FormMode == SimpleCrm.FormMode.View)
            {
            //    txtDesc.ReadOnly = true;
            //    txtSubject.ReadOnly = true;
            //    dtEndTime.Enabled = false;
            //    dtStartTime.Enabled = false;
                new ReadonlyHelper(this).SetReadonly();
                btnSave.Visible = false;

                this.Text = "查看日程";
            }
            else if (FormMode == SimpleCrm.FormMode.Add)
            {
                this.Text = "新建日程";
            }
            else if (FormMode == SimpleCrm.FormMode.Edit)
            {
                this.Text = "修改日程";
            }
        }
    }
}
