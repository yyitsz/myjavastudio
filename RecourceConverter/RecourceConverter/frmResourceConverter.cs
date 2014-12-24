using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RecourceConverter
{
    public partial class frmResourceConverter : Form
    {
        #region Header

        //private readonly string FiledLabelFileName = @"\\10.100.1.124\test\20080428HKFS\Field\MSS_FieldLabel_0.5.xls";
        //private readonly string MessageFileName = @"\\10.100.1.124\test\20080428HKFS\Field\MSS_Message_0.4.xls";
        //private readonly string ResourcePath = @"D:\MyWorkspace\MSS-D\MSS-D Client\Taifook.MSS.Resources\Properties\";
        //private readonly string ResourceName = "Resources.resx";

        private string header = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
<xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">
    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />
    <xsd:element name=""root"" msdata:IsDataSet=""true"">
      <xsd:complexType>
        <xsd:choice maxOccurs=""unbounded"">
          <xsd:element name=""metadata"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />
              <xsd:attribute name=""type"" type=""xsd:string"" />
              <xsd:attribute name=""mimetype"" type=""xsd:string"" />
              <xsd:attribute ref=""xml:space"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""assembly"">
            <xsd:complexType>
              <xsd:attribute name=""alias"" type=""xsd:string"" />
              <xsd:attribute name=""name"" type=""xsd:string"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""data"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />
              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />
              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />
              <xsd:attribute ref=""xml:space"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""resheader"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name=""resmimetype"">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name=""version"">
    <value>2.0</value>
  </resheader>
  <resheader name=""reader"">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name=""writer"">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <assembly alias=""System.Windows.Forms"" name=""System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" />


";

        #endregion

        AppConfigs configs;

        readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "SourceConfig.xml";

        public frmResourceConverter()
        {
            InitializeComponent();

        }

        private void InitializeConfigs()
        {
            cmbApp.Items.Clear();
            cmbApp.DisplayMember = "ApplicationName";
            cmbApp.ValueMember = "ApplicationName";

            if (File.Exists(fileName))
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(AppConfigs));
                    configs = (AppConfigs)s.Deserialize(fs);
                    if (configs.AppSetting != null)
                    {
                        cmbApp.DataSource = configs.AppSetting;
                        ApplicationSetting app = configs.AppSetting.Find(delegate(ApplicationSetting a) { return a.IsDefault; });
                        if (app != null)
                        {
                            cmbApp.SelectedValue = app.ApplicationName;
                        }
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Convert()
        {
            if (txtFilename.Text.Trim() == "")
            {
                return;
            }

            if (File.Exists(txtFilename.Text.Trim()) == false)
            {
                return;
            }


            ExcelImportUtil util = new ExcelImportUtil();
            IDictionary<int, string> map = new Dictionary<int, string>();
            map[ExcelImportUtil.ConvertToNumberIndex(txtKeyIndex.Text)] = "Key";
            map[ExcelImportUtil.ConvertToNumberIndex(txtValueIndex.Text)] = "Value";
            map[ExcelImportUtil.ConvertToNumberIndex(txtLabelType.Text)] = "LabelType";
            map[ExcelImportUtil.ConvertToNumberIndex(txtDeleted.Text)] = "IsDeleted";

            int rowIndex = int.Parse(txtRowStart.Text);
            int totalColumns = int.Parse(txtTotalColumns.Text);
            List<ResourceValue> list = null;

            list = util.ExcelToList<ResourceValue>(txtFilename.Text, rowIndex, txtSheetName.Text, totalColumns, map,
                delegate(object t, int columnIndex, string cellValue)
                {

                }
                );


            IDictionary<string, ResourceValue> old = GetOldResourceFile();

            IDictionary<string, ResourceValue> newResx = new Dictionary<string, ResourceValue>();


            //Merge 
            foreach (ResourceValue rv in list)
            {
                if (string.IsNullOrEmpty(rv.IsDeleted) == false &&
                    rv.IsDeleted.ToUpper() == "Y")
                {
                    if (string.IsNullOrEmpty(rv.Key) == false && old.ContainsKey(rv.Key))
                    {
                        old.Remove(rv.Key);
                    }
                    continue;
                }

                if (rv.LabelType == "Button" && string.IsNullOrEmpty(rv.Value) == false)
                {
                    rv.Value = rv.Value.Replace("&", "");
                }
                //replace blank string.
                if (string.IsNullOrEmpty(rv.Key) == false)
                {
                    rv.Key = rv.Key.Trim();
                    rv.Key = rv.Key.Replace("-", "_");
                    rv.Key = rv.Key.Replace("/", "");
                    rv.Key = rv.Key.Replace("&", "");
                    rv.Key = rv.Key.Replace(" ", "");
                }

                if (CheckKeyValid(rv.Key) == false)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(rv.Key) == false && string.IsNullOrEmpty(rv.Value) == false &&
                    rv.Key.Trim() != "" && rv.Value.Trim() != "")
                {

                    newResx[rv.Key] = rv;
                }



            }

            foreach (KeyValuePair<string, ResourceValue> kv in old)
            {
                if (newResx.ContainsKey(kv.Key.ToUpper()) == false)
                {
                    newResx[kv.Key] = kv.Value;
                }
            }


            using (StreamWriter writer = new System.IO.StreamWriter(GetGeneratedFilePath(), false, this.resourceFileCoding))
            {
                // writer.WriteLine("<root>");
                writer.WriteLine(this.header);
                foreach (ResourceValue rv in newResx.Values)
                {

                    if (string.IsNullOrEmpty(rv.Key) == false && string.IsNullOrEmpty(rv.Value) == false)
                    {

                        string v = rv.Value.Trim();
                        if ((rv.Value.Contains("&") || rv.Value.Contains("<") || rv.Value.Contains(">"))
                       && rv.Value.StartsWith("<![CDATA") == false)
                        {
                            v = "<![CDATA[" + rv.Value.Trim() + "]]>";
                        }

                        if (string.IsNullOrEmpty(rv.Type))
                        {
                            string result = String.Format(@"  <data name=""{0}"" xml:space=""preserve"">
    <value>{1}</value>
  </data>", rv.Key.Replace('-', '_'), v);
                            writer.Write(result);
                        }
                        else
                        {
                            string result = String.Format(@"  <data name=""{0}"" type=""{2}"">
    <value>{1}</value>
  </data>", rv.Key.Replace('-', '_'), v, rv.Type);
                            writer.Write(result);
                        }
                        writer.WriteLine();
                    }
                }
                writer.WriteLine("</root>");
            }

            MessageBox.Show("Successful.");
        }

        //Check 
        private bool CheckKeyValid(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] <= 'Z' && key[i] >= 'A' ||
                    key[i] <= '9' && key[i] >= '0' ||
                    key[i] == '_')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            key = key.ToUpper();
            if (key[0] > 'Z' || key[0] < 'A')
            {
                return false;
            }

            return true;

        }

        private string GetGeneratedFilePath()
        {
            int index = 1;
            string returnedFileName = this.txtResoucrFile.Text;
            string renamedFileName = this.txtResoucrFile.Text + "." + index.ToString();
            while (File.Exists(renamedFileName))
            {
                index++;
                renamedFileName = this.txtResoucrFile.Text + "." + index.ToString();
            }
            File.Move(returnedFileName, renamedFileName);
            return returnedFileName;
        }

        private Encoding resourceFileCoding = Encoding.ASCII;

        private IDictionary<string, ResourceValue> GetOldResourceFile()
        {
            Dictionary<string, ResourceValue> oldResource = new Dictionary<string, ResourceValue>();
            if (File.Exists(txtResoucrFile.Text))
            {
                using (System.IO.StreamReader sr = new StreamReader(txtResoucrFile.Text, true))
                {
                    resourceFileCoding = sr.CurrentEncoding;
                    XmlDocument resourceXml = new XmlDocument();
                    resourceXml.Load(sr);

                    XmlNodeList nodes = resourceXml.SelectNodes("//data");
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        ResourceValue rv = new ResourceValue();
                        rv.Key = nodes[i].Attributes["name"].Value.Trim();
                        if (nodes[i].Attributes.GetNamedItem("type") != null)
                        {
                            rv.Type = nodes[i].Attributes["type"].Value;
                        }

                        //  XmlNode valueNode = nodes[i].SelectSingleNode("/value");
                        rv.Value = nodes[i].InnerText.Trim();

                        //check if key contains lower letter.
                        bool isContain = true;
                        //foreach (char c in rv.Key)
                        //{
                        //    if (char.IsLower(c))
                        //    {
                        //        isContain = true;
                        //        break;
                        //    }
                        //}
                        if (isContain)
                        {
                            oldResource[rv.Key] = rv;
                        }

                    }
                }
            }

            return oldResource;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFileType.SelectedIndex = 0;
            cmbLanguage.SelectedIndex = 0;
            InitializeConfigs();
        }

        private void btnBrownResourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".resx";
            dialog.Filter = "Resource File(*.resx)|*.resx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtResoucrFile.Text = dialog.FileName;

                string s = Path.GetFileNameWithoutExtension(txtResoucrFile.Text);
                int loc = s.LastIndexOf('.');
                if (loc < 1)
                {
                    cmbLanguage.Text = "";
                }
                else
                {
                    string language = s.Substring(loc + 1, s.Length - loc - 1);
                    cmbLanguage.Text = language;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(ReferenceEquals(sender,cmbLanguage))
            //{
            //    txtResoucrFile.Text = "";
            //}

            //if (cmbFileType.Text == "Field")
            //{
            //    this.txtFilename.Text = this.FiledLabelFileName;
            //    this.txtSheetName.Text = "Field$";
            //    this.txtKeyIndex.Text = "P";
            //    if (cmbLanguage.Text.Trim() == "zh-cn")
            //    {
            //        this.txtValueIndex.Text = "S";
            //    }
            //    else if (cmbLanguage.Text.Trim() == "zh-tw")
            //    {
            //        this.txtValueIndex.Text = "R";
            //    }
            //    else
            //    {
            //        this.txtValueIndex.Text = "Q";
            //    }

            //    this.txtDeleted.Text = "D";
            //}
            //else if (cmbFileType.Text == "Message")
            //{
            //    this.txtFilename.Text = this.MessageFileName;
            //    this.txtSheetName.Text = "Message$";
            //    this.txtKeyIndex.Text = "R";
            //    if (cmbLanguage.Text.Trim() == "zh-cn")
            //    {
            //        this.txtValueIndex.Text = "X";
            //    }
            //    else if (cmbLanguage.Text.Trim() == "zh-tw")
            //    {
            //        this.txtValueIndex.Text = "W";
            //    }
            //    else
            //    {
            //        this.txtValueIndex.Text = "V";
            //    }


            //    this.txtDeleted.Text = "H";
            //}

            //if (cmbLanguage.Text.Trim() == "zh-cn")
            //{
            //    this.txtResoucrFile.Text = this.ResourcePath + Path.GetFileNameWithoutExtension(this.ResourceName) + ".zh-cn" + Path.GetExtension(this.ResourceName);
            //}
            //else if (cmbLanguage.Text.Trim() == "zh-tw")
            //{
            //    this.txtResoucrFile.Text = this.ResourcePath + Path.GetFileNameWithoutExtension(this.ResourceName) + ".zh-tw" + Path.GetExtension(this.ResourceName);
            //}
            //else
            //{
            //    this.txtResoucrFile.Text = this.ResourcePath + this.ResourceName;
            //}
            ApplicationSetting currentConfig = null;
            if (cmbApp.SelectedIndex == -1)
            {
                // currentConfig = null;
                return;

            }
            currentConfig = (cmbApp.SelectedItem as ApplicationSetting);

            if (currentConfig == null)
            {
                return;
            }

            if (cmbFileType.SelectedIndex == -1 || cmbLanguage.SelectedIndex == -1)
            {
                return;
            }

            Setting setting = currentConfig.Setting.Find(delegate(Setting s) { return s.Type == cmbFileType.Text; });
            if (setting == null)
            {
                MessageBox.Show("Can not find type " + cmbFileType.Text);
                return;
            }


            this.txtFilename.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, setting.SourceFilePath);
            this.txtSheetName.Text = setting.SheetName;// "Field$";
            this.txtKeyIndex.Text = setting.IdColumn;
            this.txtTotalColumns.Text = setting.TotalColumns.ToString();
            LanguageSetting langSetting = setting.LanguagetSetting.Find(delegate(LanguageSetting s) { return s.LanguageCode == cmbLanguage.Text; });
            if (langSetting == null)
            {
                MessageBox.Show("Can not find language setting " + cmbLanguage.Text);

                return;
            }

            this.txtDeleted.Text = setting.DeletedColumn;
            txtRowStart.Text = setting.RowStartIndex.ToString();
            txtLabelType.Text = setting.TypeColumn;
            this.txtValueIndex.Text = langSetting.Column;

            string resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentConfig.ResourcePath);
            if (langSetting.LanguageCode == "")
            {
                this.txtResoucrFile.Text = resourcePath + currentConfig.ResourceName;
            }
            else
            {
                this.txtResoucrFile.Text = resourcePath + Path.GetFileNameWithoutExtension(currentConfig.ResourceName)
                    + "." + langSetting.LanguageCode + Path.GetExtension(currentConfig.ResourceName);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (txtFieldFilePath.Text.Trim() == "")
            {
                return;
            }

            if (File.Exists(txtFieldFilePath.Text.Trim()) == false)
            {
                return;
            }


            ExcelImportUtil util = new ExcelImportUtil();
            IDictionary<int, string> map = new Dictionary<int, string>();

            map[ExcelImportUtil.ConvertToNumberIndex(txtFieldIdNo.Text)] = "FieldId";
            map[ExcelImportUtil.ConvertToNumberIndex(txtLengthColumnNo.Text)] = "Length";
            map[ExcelImportUtil.ConvertToNumberIndex(txtAllowNonEng.Text)] = "AllowNonEnglish";

            int totalColumns = int.Parse(txtTotalCoumnsForLen.Text);
            List<Field> list = null;

            list = util.ExcelToList<Field>(txtFieldFilePath.Text, 5, txtFieldSheetName.Text, totalColumns, map,
                delegate(object t, int columnIndex, string cellValue)
                {

                }
                );



            using (StreamWriter writer = new System.IO.StreamWriter(GetFieldLengthFilePath(), false, Encoding.UTF8))
            {
                writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>
<root>");

                foreach (Field field in list)
                {

                    if (string.IsNullOrEmpty(field.FieldId) == false
                       || string.IsNullOrEmpty(field.Length) == false)
                    {
                        field.FieldId = field.FieldId.Replace(" ", "");

                        bool allow = false;
                        int length;

                        if (int.TryParse(field.Length, out length) == false)
                        {
                            continue;
                        }

                        if (field.AllowNonEnglish.Trim().ToUpper() == "Y")
                        {
                            allow = true;
                        }
                        else if (field.AllowNonEnglish.Trim().ToUpper() == "N")
                        {
                            allow = false;
                        }

                        //<field name="MARKET_CODE" length="10" allowNonEnglish="false"></field>

                        writer.WriteLine(@"<field name=""{0}"" length=""{1}"" allowNonEnglish=""{2}"" />",
                            field.FieldId, length, allow);


                    }
                }
                writer.WriteLine("</root>");
            }

            MessageBox.Show("Sucessful.");
        }

        private void btnBrown2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel File(*.xls)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFieldFilePath.Text = dialog.FileName;
            }
        }

        private static string GetFieldLengthFilePath()
        {
            return @"D:\MyWorkspace\MSS-D\MSS-D Client\Taifook.MSS.Resources\Properties" + "\\FieldLength_new.xml";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckLov_Click(object sender, EventArgs e)
        {
            IDictionary<String, ResourceValue> dic = GetOldResourceFile();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Resource Key,Error,Enum Value,Field Id, Description,LOV Definition");
            foreach (KeyValuePair<String, ResourceValue> kv in dic)
            {

                if (kv.Key.StartsWith("LOV"))
                {
                    String value = kv.Value.Value;
                    string[] enumKeyDescList = value.Split('|');
                    if (enumKeyDescList.Length == 1)
                    {
                        continue;
                    }
                    bool error = false;
                    StringBuilder singleLovBuilder = new StringBuilder();
                    foreach (string enumKeyDesc in enumKeyDescList)
                    {
                        string[] strs = enumKeyDesc.Split(':');
                        if (strs.Length != 3)
                        {
                            sb.AppendLine(string.Format("{0},{1} is incorrect definition.,,,,{2} ", kv.Key, enumKeyDesc,kv.Value.Value));
                            continue;
                        }
                        else
                        {
                            if (dic.ContainsKey(strs[1]) == false)
                            {
                                error = true;
                                singleLovBuilder.AppendLine(string.Format("{0},Field id [{3}] cannot be found  in resources.,{2},{3},{4},{1}", kv.Key, kv.Value.Value, strs[0], strs[1], strs[2]));
                            }
                            else
                            {
                                singleLovBuilder.AppendLine(string.Format("{0},,{2},{3},{4},{1}", kv.Key, kv.Value.Value, strs[0], strs[1], strs[2]));
                            }
                        }
                    }
                    if (error)
                    {
                        sb.Append(singleLovBuilder.ToString());
                    }
                }
            }
            ResultForm form = new ResultForm();
            form.Content = sb.ToString();
            form.Owner = this;
            form.Show();
        }


    }

    public class ResourceValue
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string labelType;

        public string LabelType
        {
            get { return labelType; }
            set { labelType = value; }
        }

        private string isDeleted;

        public string IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

    }

    public class Field
    {
        public Field(string fieldId)
        {
            this.fieldId = fieldId;
        }

        public Field()
        {

        }

        private string fieldId;

        public string FieldId
        {
            get { return fieldId; }
            set { fieldId = value; }
        }

        private string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }

        private string allowNonEnglish;

        public string AllowNonEnglish
        {
            get { return allowNonEnglish; }
            set { allowNonEnglish = value; }
        }

    }
}