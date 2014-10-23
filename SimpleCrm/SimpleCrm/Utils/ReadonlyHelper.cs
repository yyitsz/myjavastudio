using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.Editors;
using DevComponents.DotNetBar.Controls;

namespace SimpleCrm.Utils
{
    public class ReadonlyHelper
    {
        private Control rootControl;
        private ISet<Control> changedStatusControl = new HashSet<Control>();
        public ReadonlyHelper(Control rootControl)
        {
            this.rootControl = rootControl;
        }
        public void SetReadonly()
        {
            SetReadonly(this.rootControl);
        }

        private void SetReadonly(Control control)
        {
            bool changed = ChangeControlStatus(control, true);
            if (changed)
            {
                changedStatusControl.Add(control);
            }
            if (control.HasChildren)
            {
                foreach (Control childControl in control.Controls)
                {
                    SetReadonly(childControl);
                }
            }
        }

        public void Reset()
        {
            foreach (Control control in changedStatusControl)
            {
                ChangeControlStatus(control, false);
            }
        }
        private bool ChangeControlStatus(Control control, bool isReadonly)
        {
            TextBoxBase textBox = control as TextBoxBase;
            if (textBox != null)
            {
                if (textBox.ReadOnly != isReadonly)
                {
                    textBox.ReadOnly = isReadonly;
                    return true;
                }
                return false;
            }
            if (control is ComboBox 
                || control is DateTimeInput
                || control is CheckBox
                || control is CheckBoxX
                || control is DateTimePicker
                || control is IntegerInput
                || control is DoubleInput
                 )
            {
                if (control.Enabled == isReadonly)
                {
                    control.Enabled = !isReadonly;
                    return true;
                }
                return false;
            }

            DataGridView dgv = control as DataGridView;
            if (dgv != null)
            {
                if (dgv.ReadOnly != isReadonly)
                {
                    dgv.ReadOnly = isReadonly;
                    return true;
                }
                return false;
            }

            TextBoxDropDown textBoxDropDown = control as TextBoxDropDown;
            if (textBoxDropDown != null)
            {
                if (textBoxDropDown.ReadOnly != isReadonly)
                {
                    textBoxDropDown.ReadOnly = isReadonly;
                    return true;
                }
                return false;
            }

            RichTextBox richTextBox = control as RichTextBox;
            if (richTextBox != null)
            {
                if (richTextBox.ReadOnly != isReadonly)
                {
                    richTextBox.ReadOnly = isReadonly;
                    return true;
                }
                return false;
            }

            RichTextBoxEx richTextBoxEx = control as RichTextBoxEx;
            if (richTextBoxEx != null)
            {
                if (richTextBoxEx.ReadOnly != isReadonly)
                {
                    richTextBoxEx.ReadOnly = isReadonly;
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
