using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Model;
using SimpleCrm.Facade;
using System.Reflection;
using DevComponents.DotNetBar.Controls;

namespace SimpleCrm.Utils
{
    public static class ComboBoxUtil
    {
        private static Dictionary<Type, List<Tuple<String, String>>> cache = new Dictionary<Type, List<Tuple<string, string>>>();

        public static bool Selected(ComboBox control)
        {
            if (control.SelectedItem == null)
            {
                return false;
            }

            if (control.SelectedValue == null || control.SelectedValue.Equals(""))
            {
                return false;
            }
            return true;
        }

        public static void BindLovType(Object comboBox, bool appendBlank = true)
        {
            List<Tuple<String, String>> list = GetListSource(typeof(LovType), appendBlank);
            BindToControl(comboBox, list, "Item2", "Item1");

        }

        public static void BindEnumType(Type enumType, Object comboBox, bool appendBlank = true)
        {
            List<Tuple<String, String>> list = GetListSource(enumType, appendBlank);
            BindToControl(comboBox, list, "Item2", "Item1");

        }

        private static List<Tuple<String, String>> GetListSource(Type enumType, bool appendBlank)
        {
            List<Tuple<String, String>> list;
            if (cache.TryGetValue(enumType, out list))
            {
                if (appendBlank)
                {
                    list = new List<Tuple<string, string>>(list);
                }
            }
            else
            {
                list = new List<Tuple<string, string>>();
                MemberInfo[] memberInfos = enumType.GetMembers();
                foreach (MemberInfo member in memberInfos)
                {
                    if (member.DeclaringType == enumType)
                    {
                        DisplayAttribute dispay = member.GetCustomAttributes(typeof(DisplayAttribute), true).ElementAtOrDefault(0) as DisplayAttribute;

                        if (dispay != null)
                        {
                            String name = dispay.Text;
                            list.Add(Tuple.Create(name, member.Name));
                        }

                    }
                }
                cache.Add(enumType, list);
                if (appendBlank)
                {
                    list = new List<Tuple<string, string>>(list);
                }
            }
            if (appendBlank)
            {
                Tuple<String, String> lov = Tuple.Create("", (String)"");
                list.Insert(0, lov);
            }
            return list;
        }

        private static void BindToControl(Object control, Object dataSource, String valueMember, String displayMember)
        {
            ComboBox comboBox = control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.DataSource = dataSource;
                comboBox.Leave += new EventHandler(comboBox_Leave);
                return;
            }

            DataGridViewComboBoxColumn column = control as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DisplayMember = displayMember;
                column.ValueMember = valueMember;
                column.DataSource = dataSource;
                
                return;
            }

            DataGridViewComboBoxExColumn columnEx = control as DataGridViewComboBoxExColumn;
            if (columnEx != null)
            {
                columnEx.DisplayMember = displayMember;
                columnEx.ValueMember = valueMember;
                columnEx.DataSource = dataSource;
                columnEx.DropDownStyle = ComboBoxStyle.DropDownList;
                return;
            }

        }

        static void comboBox_Leave(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (String.IsNullOrEmpty(comboBox.Text.Trim()) == false
                    && comboBox.SelectedItem == null)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public static void BindLov(LovType lovType, Object comboBox, bool appendBlank = true)
        {
            List<Lov> list = AppFacade.Facade.GetLovByType(lovType.ToString());

            if (appendBlank)
            {
                Lov lov = new Lov();
                lov.Code = "";
                lov.Name = "";
                list.Insert(0, lov);
            }
            BindToControl(comboBox, list, "Code", "Name");
        }

    }
}
