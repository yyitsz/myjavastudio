using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Validator;

namespace SimpleCrm.Utils
{
    public class ValidationHelper
    {
        public static bool ValidateRequiredField(DataGridViewRow row, params string[] columns)
        {
            bool valid = true;
            foreach (string columnName in columns)
            {
                var cell = row.Cells[columnName];
                if (String.IsNullOrEmpty(Convert.ToString(cell.Value)))
                {
                    cell.ErrorText = "必填项";
                    valid = false;
                }
                else
                {
                    cell.ErrorText = "";
                }
            }
            return valid;
        }

        public static bool ValidateRequiredField(ErrorProvider errorProvider, Highlighter highlighter, params Control[] controls)
        {
            bool valid = true;
            foreach (Control control in controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    valid = SetErrorText(control, errorProvider, highlighter,textBox.Text.Trim().Length > 0, "必填项") && valid;
                    continue;
                }
                ComboBox comboBox = control as ComboBox;
                if (comboBox != null)
                {
                    valid = SetErrorText(control, errorProvider, highlighter, ComboBoxUtil.Selected(comboBox), "必填项") && valid;
                    continue;
                }
                DateTimeInput dateTimeInput = control as DateTimeInput;
                if (dateTimeInput != null)
                {
                    valid = SetErrorText(control, errorProvider, highlighter, dateTimeInput.ValueObject != null, "必填项") && valid;
                    continue;
                }
            }

            return valid;
        }

        public static bool SetErrorText(Control control, ErrorProvider errorProvider,Highlighter highlighter, bool valid, String text)
        {
            if (valid)
            {
                errorProvider.SetError(control, null);
            }
            else
            {
                errorProvider.SetError(control, text);
            }
            if (highlighter != null)
            {
               // highlighter.SetHighlightOnFocus(control, !valid);
                highlighter.SetHighlightColor(control, eHighlightColor.Red);
            }
            return valid;
        }
    }
}
