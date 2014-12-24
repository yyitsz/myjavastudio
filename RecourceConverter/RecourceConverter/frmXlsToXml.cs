using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace RecourceConverter
{
    public partial class frmXlsToXml : Form
    {
        public frmXlsToXml()
        {
            InitializeComponent();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConvertInfo()
        {
            if (txtFilename.Text.Trim() == "")
            {
                return;
            }

            if (File.Exists(txtFilename.Text.Trim()) == false)
            {
                return;
            }

            int firstLineNo;
            if (int.TryParse(txtFirstLineNo.Text, out firstLineNo) == false)
            {
                MessageBox.Show("Please input correct first line no. in excel sheet.");
                return;
            }

            ExcelImportUtil util = new ExcelImportUtil();
            IDictionary<int, string> map = new Dictionary<int, string>();
            //Parse parameter
            string template = this.txtTemplate.Text;
            List<string> parameterMap = new List<string>();
            String keyPropertyName = "";
            // int index = 0;
            int loc = 0;
            // int startIndex = 0;
            while (true)
            {
                loc = template.IndexOf("{", loc);
                if (loc < 0)
                {
                    break;
                }
                int rightLoc = template.IndexOf("}", loc + 1);
                if (rightLoc < 0 || rightLoc == loc + 1)
                {
                    throw new Exception("Template format is wrong. Position is " + loc.ToString());
                }

                string column = template.Substring(loc + 1, rightLoc - loc - 1);
                if (parameterMap.IndexOf(column) < 0)
                {
                    parameterMap.Add(column);
                }
                loc = rightLoc + 1;
                if (loc >= template.Length - 1)
                {
                    break;
                }
            }

            for (int i = 0; i < parameterMap.Count; i++)
            {
                //  string[] s = map.Split(":");
                template = template.Replace("{" + parameterMap[i] + "}", "{" + i.ToString() + "}");
                map[ExcelImportUtil.ConvertToNumberIndex(parameterMap[i])] = "S" + i.ToString();
                if (parameterMap[i] == this.txtKey.Text)
                {
                    keyPropertyName = "S" + i.ToString();
                }
            }

            if (txtDeletedFlagColumn.Text.Trim().Length > 0)
            {
                map[ExcelImportUtil.ConvertToNumberIndex(txtDeletedFlagColumn.Text)] = "DeletedColumn";
            }

            int totalColumns = int.Parse(txtTotalColumns.Text);

            List<TempClass> list = null;

            list = util.ExcelToList<TempClass>(txtFilename.Text, firstLineNo, txtSheetName.Text, totalColumns, map,
                delegate(object t, int columnIndex, string cellValue)
                {

                }
                );


            PropertyInfo[] properties = new PropertyInfo[parameterMap.Count];
            for (int i = 0; i < parameterMap.Count; i++)
            {
                properties[i] = typeof(TempClass).GetProperty("S" + i.ToString());
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(txtHeader.Text);
            sb.Append(Environment.NewLine);


            foreach (TempClass tempObj in list)
            {
                if (tempObj.DeletedColumn != null && tempObj.DeletedColumn.ToUpper() == "Y")
                {
                    continue;
                }
                object[] parmeters = new object[parameterMap.Count];
                bool validObject = true;
                for (int i = 0; i < properties.Length; i++)
                {
                    string x = Convert.ToString(properties[i].GetValue(tempObj, null));
                    if (x != null)
                    {
                        if (rdbXml.Checked)
                        {
                            //&amp;&lt;&gt;
                            x = x.Replace("&", "&amp;")
                                 .Replace("<", "&lt;")
                                 .Replace(">", "&gt;")
                                 .Replace("\n", ";");
                        }
                        else if (rdbSQL.Checked)
                        {
                            x = x.Replace("'", "''");
                        }

                    }
                    //if key property is empty or null, ignore it.
                    if (properties[i].Name == keyPropertyName && string.IsNullOrEmpty(x))
                    {
                        validObject = false;
                        break;
                    }
                    parmeters[i] = x;
                }
                if (validObject)
                {
                    string tempS = string.Format(template, parmeters);
                    sb.Append(tempS);
                    sb.Append(Environment.NewLine);
                }
            }
            sb.Append(txtFooter.Text);
            String s = sb.ToString();
            if (s.StartsWith("<xml"))
            {
                s = XmlUtils.FormatXml(sb.ToString());
            }
            txtResult.Text = s;

            MessageBox.Show("Successful.");
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel File(*.xls)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = dialog.FileName;
            }
        }
        Templates template;
        private void frmXlsToXml_Load(object sender, EventArgs e)
        {
            template = ConfigHelper.LoadConfig<Templates>(
               Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TemplateDef.xml"));
            if (template != null && template.Template != null)
            {
                this.cmbTemplate.DataSource = template.Template;
                this.cmbTemplate.Value = template.Default;
                //BindTemplate(template.Default);
            }
        }

        private void BindTemplate(string templateName)
        {
            if (template != null && template.Template != null && template.Template.Count > 0)
            {

                Template temp = template.Template.Find(delegate(Template t) { return t.Name == templateName; });
                Bind(temp);
            }
        }

        private void Bind(Template temp)
        {
            if (temp != null)
            {
                this.txtFilename.Text = temp.SourceFile;
                this.txtFirstLineNo.Text = temp.StartRow;
                this.txtFooter.Text = temp.Tail.Replace("\n", Environment.NewLine);
                this.txtHeader.Text = temp.Header.Replace("\n", Environment.NewLine);
                this.txtTemplate.Text = temp.Body.Replace("\n", Environment.NewLine);
                this.txtSheetName.Text = temp.SheetName;
                this.txtKey.Text = temp.KeyColumn;
                this.txtResult.Text = "";
                this.txtTotalColumns.Text = temp.TotalColumns.ToString();
                txtDeletedFlagColumn.Text = temp.DeletedColumn;
            }
        }

        private void cmbTemplate_ValueChanged(object sender, EventArgs e)
        {
            if (this.cmbTemplate.SelectedItem != null && this.cmbTemplate.SelectedItem.ListObject != null)
            {
                Bind((Template)this.cmbTemplate.SelectedItem.ListObject);
            }
        }
    }

    public class TempClass
    {
        private string s0;

        public string S0
        {
            get { return s0; }
            set { s0 = value; }
        }

        private string s1;

        public string S1
        {
            get { return s1; }
            set { s1 = value; }
        }

        private string s2;

        public string S2
        {
            get { return s2; }
            set { s2 = value; }
        }

        private string s3;

        public string S3
        {
            get { return s3; }
            set { s3 = value; }
        }

        private string s4;

        public string S4
        {
            get { return s4; }
            set { s4 = value; }
        }

        private string s5;

        public string S5
        {
            get { return s5; }
            set { s5 = value; }
        }

        private string s6;

        public string S6
        {
            get { return s6; }
            set { s6 = value; }
        }

        private String s7;

        public String S7
        {
            get { return s7; }
            set { s7 = value; }
        }

        private String s8;

        public String S8
        {
            get { return s8; }
            set { s8 = value; }
        }

        private String s9;

        public String S9
        {
            get { return s9; }
            set { s9 = value; }
        }

        private String s10;

        public String S10
        {
            get { return s10; }
            set { s10 = value; }
        }

        public string deletedColumn;
        public string DeletedColumn
        {
            get { return deletedColumn; }
            set { deletedColumn = value; }
        }
    }
}