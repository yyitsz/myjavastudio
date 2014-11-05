using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Validator;
using SimpleCrm.Model;

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
                    valid = SetErrorText(control, errorProvider, highlighter, textBox.Text.Trim().Length > 0, "必填项") && valid;
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

        public static bool SetErrorText(Control control, ErrorProvider errorProvider, Highlighter highlighter, bool valid, String text)
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

        public static bool FillBirthdayAndGenderWithIdCardNo(DataGridViewCell idCardNoControl, DataGridViewCell birthdayControl = null, DataGridViewCell genderControl = null)
        {
            String idCardNo = idCardNoControl.Value.ToString().Trim();
            if (idCardNo.Length == 0)
            {
                return true;
            }
            DateTime birthday = new DateTime();
            GenderType gender = GenderType.Male;
            bool isValid = ValidateIdCardNo(idCardNo, out birthday, out gender);
            if (isValid == false)
            {
                idCardNoControl.ErrorText = "无效身份证号码。";
                return false;
            }
            else
            {
                idCardNoControl.ErrorText = "";
            }

            if (birthdayControl != null)
            {
                birthdayControl.Value = birthday;
            }
            if (genderControl != null)
            {
                genderControl.Value = gender.ToString();
            }
            return true;
        }

        public static bool FillBirthdayAndGenderWithIdCardNo(Control idCardNoControl, ErrorProvider errorProvider, Control birthdayControl = null, Control genderControl = null)
        {
            String idCardNo = idCardNoControl.Text.Trim();
            if (idCardNo.Length == 0)
            {
                return true;
            }
            DateTime birthday = new DateTime();
            GenderType gender = GenderType.Male;
            bool isValid = ValidateIdCardNo(idCardNo, out birthday, out gender);
            if (isValid == false)
            {
                errorProvider.SetError(idCardNoControl, "无效身份证号码。");
                return false;
            }
            else
            {
                errorProvider.SetError(idCardNoControl, null);
            }
            if (birthdayControl != null)
            {
                if (birthdayControl is DateTimeInput)
                {
                    ((DateTimeInput)birthdayControl).Value = birthday;
                }
                else if (birthdayControl is DateTimePicker)
                {
                    ((DateTimePicker)birthdayControl).Value = birthday;
                }
            }
            if (genderControl != null)
            {
                if (genderControl is ComboBox)
                {
                    ((ComboBox)genderControl).SelectedValue = gender.ToString();
                }
            }
            return true;
        }

        public static bool ValidateIdCardNo(string idCardNo, out DateTime birthday, out GenderType gender)
        {
            birthday = new DateTime();
            gender = GenderType.Male;

            long n = 0;
            if (idCardNo.Length < 18
                || long.TryParse(idCardNo.Remove(17), out n) == false
                 || n < Math.Pow(10, 16)
                 || long.TryParse(idCardNo.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idCardNo.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = idCardNo.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            if (DateTime.TryParse(birth, out birthday) == false)
            {
                return false;//生日验证
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idCardNo.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idCardNo.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            int c = int.Parse(Ai[Ai.Length - 1].ToString());
            if (c % 2 == 0)
            {
                gender = GenderType.Female;
            }
            else
            {
                gender = GenderType.Male;
            }
            return true;//符合GB11643-1999标准
        }

        internal static bool ValidateIdCardNo(string idCardNo)
        {
            DateTime birthday = new DateTime();
            GenderType gender = GenderType.Male;
            return ValidateIdCardNo(idCardNo, out birthday, out gender);
        }
    }
}
