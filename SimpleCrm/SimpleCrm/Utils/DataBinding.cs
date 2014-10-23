using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.Editors;
using DevComponents.DotNetBar.Controls;


namespace SimpleCrm.Utils
{
    /// <summary>
    /// The data of object map to the control,or else.
    /// </summary>
    [ProvideProperty("PropertyName", typeof(Object))]
    [ProvideProperty("FormatString", typeof(Object))]
    public partial class DataBinding : Component, IExtenderProvider, ISupportInitialize
    {
        private string dateTimeFormat = "yyyy-MM-dd";

        /// <summary>
        /// Gets or sets the date time format.
        /// </summary>
        /// <value>The date time format.</value>
        [Browsable(false)]
        public string DateTimeFormat
        {
            get { return dateTimeFormat; }
            set { dateTimeFormat = value; }
        }


        private IDictionary<Control, PropertyPair> m_InnerControlDictionary;
        private static int DefaultPriority = 5;
        private List<PropertyPair> m_SortedList;

        /// <summary>
        /// Gets or sets the inner control dictionary.
        /// </summary>
        /// <value>The inner control dictionary.</value>
        [Browsable(false)]
        public IDictionary<Control, PropertyPair> InnerControlDictionary
        {
            get { return this.m_InnerControlDictionary; }
            private set { this.m_InnerControlDictionary = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataBinding"/> class.
        /// </summary>
        public DataBinding()
        {
            this.m_InnerControlDictionary = new Dictionary<Control, PropertyPair>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBinding"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public DataBinding(IContainer container)
            : this()
        {
            container.Add(this);
        }


        #region ISupportInitialize Members

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {

            m_SortedList = new List<PropertyPair>(m_InnerControlDictionary.Values);
            m_SortedList.Sort();           
        }

        #endregion


        #region IExtenderProvider Members

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DefaultValue("")]
        [Category("Mapping")]
        [Description("The property of the class.Syntax is 'name:priority',priority may ignore,default priority is 5.")]
        public string GetPropertyName(object item)
        {
            if (item is Control && m_InnerControlDictionary.ContainsKey((Control)item))
            {
                return m_InnerControlDictionary[(Control)item].DisplayPropertyName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the name of the property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        public void SetPropertyName(object item, string value)
        {
            if (item is Control)
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (m_InnerControlDictionary.ContainsKey((Control)item))
                    {
                        m_InnerControlDictionary.Remove((Control)item);
                        //m_PriorityList.
                    }
                    return;
                }

                //create the pair.
                if (m_InnerControlDictionary.ContainsKey((Control)item) == false)
                {
                    PropertyPair kv = new PropertyPair();
                    kv.Control = (Control)item;
                    m_InnerControlDictionary[(Control)item] = kv;
                }
                m_InnerControlDictionary[(Control)item].DisplayPropertyName = value;
            }

        }

        /// <summary>
        /// Gets the format string.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DefaultValue("")]
        [Category("Mapping")]
        [Description("The format of the output string.")]
        public string GetFormatString(object item)
        {
            if (item is Control && m_InnerControlDictionary.ContainsKey((Control)item))
            {
                return m_InnerControlDictionary[(Control)item].FormatString;
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the format string.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        public void SetFormatString(object item, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (m_InnerControlDictionary.ContainsKey((Control)item))
                {
                    m_InnerControlDictionary[(Control)item].FormatString = "";
                }
                return;
            }

            if (item is Control)
            {
                if (m_InnerControlDictionary.ContainsKey((Control)item) == false)
                {
                    PropertyPair kv = new PropertyPair();
                    kv.Control = (Control)item;
                    m_InnerControlDictionary[(Control)item] = kv;

                }
                m_InnerControlDictionary[(Control)item].FormatString = value;

            }
        }

        /// <summary>
        /// Specifies whether this object can provide its extender properties to the specified object.
        /// </summary>
        /// <param name="extendee">The <see cref="T:System.Object"></see> to receive the extender properties.</param>
        /// <returns>
        /// true if this object can provide extender properties to the specified object; otherwise, false.
        /// </returns>
        public bool CanExtend(object extendee)
        {
            //todo Some control shall be exluded,eg ,button.
            if (extendee is TextBox || extendee is Label || extendee is ComboBox || extendee is CheckBox
                || extendee is ListControl || extendee is DateTimePicker || extendee is VisualControlBase
                || extendee is TextBoxDropDown)
            {
                return true;
            }
            return false;
        }

        #endregion


        #region Public Mapping Method
        /// <summary>
        /// Gets value of Control to assign to object.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void MapToObject(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("The argument of mapping object don't allow to be null.");
            }

            // System.ComponentModel.
            foreach (KeyValuePair<Control, PropertyPair> kv in m_InnerControlDictionary)
            {
                if (string.IsNullOrEmpty(kv.Value.PropertyName))
                {
                    continue;
                }

                //Find the property from object.
                object declaredObject = obj;
                PropertyInfo pi = GetProperty(kv.Value.PropertyName, ref declaredObject);

                if (pi == null)
                {
                    throw new Exception(String.Format("The property {0} didn't be found.", kv.Value.PropertyName));
                }
                Type propertyType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                TypeConverter converter = TypeDescriptor.GetConverter(propertyType);
                if (pi.PropertyType == typeof(bool))
                {
                    converter = new BooleanConverterEx();
                }
                object value = null;

                if (kv.Key is TextBoxBase || kv.Key is Label || kv.Key is TextBoxDropDown)
                {
                    Control control = kv.Key as Control;
                    if (control.Text.Trim() == "")
                    {
                        value = null;
                    }
                    else
                    {
                        value = control.Text.Trim();
                    }
                }
                else if (kv.Key is ComboBox)
                {
                    ComboBox combobox = kv.Key as ComboBox;

                    value = combobox.SelectedValue;
                    if (combobox.SelectedItem == null
                        || value == null
                        || String.IsNullOrEmpty(value.ToString()))
                    {
                        value = null;
                    }
                }
                else if (kv.Key is CheckBox)
                {
                    value = (kv.Key as CheckBox).Checked;
                }
                else if (kv.Key is DateTimePicker)
                {
                    value = (kv.Key as DateTimePicker).Value;
                }
                else if (kv.Key is DateTimeInput)
                {
                    value = (kv.Key as DateTimeInput).ValueObject;
                }
                else if (kv.Key is IntegerInput)
                {
                    value = (kv.Key as IntegerInput).ValueObject;
                }
                else if (kv.Key is DoubleInput)
                {
                    value = Convert.ToString((kv.Key as DoubleInput).ValueObject);
                }

                if (value != null && value.GetType() != propertyType)
                {
                    value = converter.ConvertFrom(value);
                }
                pi.SetValue(declaredObject, value, null);

            }
        }

        /// <summary>
        /// Resets the value of all controls.
        /// </summary>
        public void ClearControlValue()
        {
            if (m_InnerControlDictionary.Count == 0)
            {
                return;
            }

            foreach (PropertyPair pair in m_SortedList)
            {
                //Find the property from object.
                if (pair.Control is TextBoxBase || pair.Control is Label || pair.Control is TextBoxDropDown)
                {
                    pair.Control.Text = "";
                }
                else if (pair.Control is ComboBox)
                {
                    ComboBox control = pair.Control as ComboBox;
                    control.SelectedIndex = -1;
                }
                else if (pair.Control is CheckBox)
                {
                    (pair.Control as CheckBox).Checked = false;
                }
                else if (pair.Control is DateTimePicker)
                {
                    (pair.Control as DateTimePicker).Checked = false;
                }
                else if (pair.Control is DateTimeInput)
                {
                    (pair.Control as DateTimeInput).ValueObject = null;
                }
                else if (pair.Control is IntegerInput)
                {
                    (pair.Control as IntegerInput).ValueObject = null;
                }
                else if (pair.Control is DoubleInput)
                {
                    (pair.Control as DoubleInput).ValueObject = null;
                }


            }
        }

        /// <summary>
        /// Display value from object.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void MapToControl(object obj)
        {

            if (obj == null)
            {
                throw new ArgumentException("The argument of mapping object don't allow to be null.");
            }
            if (m_InnerControlDictionary.Count == 0)
            {
                return;
            }
            if (m_SortedList == null)
            {
                m_SortedList = new List<PropertyPair>(m_InnerControlDictionary.Values);
                m_SortedList.Sort();
            }

            foreach (PropertyPair pair in m_SortedList)
            {
                //Find the property from object.
                object declaredObject = obj;
                PropertyInfo pi = GetProperty(pair.PropertyName, ref declaredObject);
                if (pi == null)
                {
                    throw new Exception(String.Format("The property {0} didn't be found.", pair.PropertyName));
                }
                Type propertyType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                object value = pi.GetValue(declaredObject, null);
                string valueStr = Convert.ToString(value);
                if (valueStr == "")
                {
                    valueStr = null;
                }
                if (pair.Control is TextBoxBase || pair.Control is Label || pair.Control is TextBoxDropDown)
                {
                    //Format the ouput string.
                    if (String.IsNullOrEmpty(pair.FormatString) == false)
                    {
                        valueStr = String.Format("{0:" + pair.FormatString + "}", value);
                    }

                    if (value == null)
                    {
                        valueStr = "";
                    }
                    else
                    {
                        if (propertyType == typeof(DateTime))
                        {
                            valueStr = ((DateTime)value).ToString(dateTimeFormat, DateTimeFormatInfo.InvariantInfo);
                        }
                    }

                    pair.Control.Text = valueStr;
                }
                else if (pair.Control is ComboBox)
                {
                    ComboBox control = pair.Control as ComboBox;
                    if (value == null)
                    {
                        control.SelectedIndex = -1;
                    }
                    else
                    {
                        control.SelectedValue = value;
                    }
                }
                else if (pair.Control is CheckBox)
                {
                    (pair.Control as CheckBox).Checked = Convert.ToBoolean(value ?? false);
                }
                else if (pair.Control is DateTimePicker)
                {
                    DateTime valueDate;
                    if (value is String)
                    {
                        valueDate = DateTime.MinValue;
                        if (DateTime.TryParse(value.ToString(), out valueDate))
                        {
                            value = valueDate;
                        }
                        else
                        {
                            value = valueDate;
                        }
                    }
                    else
                    {
                        valueDate = (DateTime)value;
                    }

                    (pair.Control as DateTimePicker).Value = valueDate;
                }
                else if (pair.Control is DateTimeInput)
                {
                    (pair.Control as DateTimeInput).ValueObject = value;
                }
                else if (pair.Control is IntegerInput)
                {
                    (pair.Control as IntegerInput).ValueObject = value;
                }
                else if (pair.Control is DoubleInput)
                {
                    DoubleInput dicontrol = pair.Control as DoubleInput;
                    if (String.IsNullOrEmpty(valueStr))
                    {
                        dicontrol.ValueObject = null;
                    }
                    else
                    {
                        (pair.Control as DoubleInput).ValueObject = Convert.ToDouble(valueStr);
                    }
                }


            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="declaredObj">The declared obj.</param>
        /// <returns></returns>
        public PropertyInfo GetProperty(String propertyName, ref object declaredObj)
        {
            if (declaredObj == null || propertyName == "")
            {
                return null;
            }

            Type objectType = declaredObj.GetType();

            //propertyName may composite the string with dot  spilter,eg, name.firstname.
            string realPropertyName = "";
            int dotLocation = propertyName.IndexOf('.');
            if (dotLocation == 0 || dotLocation == propertyName.Length - 1)
            {
                throw new Exception("The format of property name " + propertyName + " is wrong.");
            }
            if (dotLocation > 0)
            {
                realPropertyName = propertyName.Substring(0, dotLocation);
                propertyName = propertyName.Substring(dotLocation + 1);
            }
            else
            {
                realPropertyName = propertyName;
                propertyName = "";
            }
            //Find the property from object.
            PropertyInfo pi = objectType.GetProperty(realPropertyName);
            //if (pi == null)
            //{
            //    throw new Exception(String.Format("The property {0} didn't be found.", realPropertyName));
            //}

            if (pi == null || propertyName == "")
            {
                return pi;
            }
            else
            {
                declaredObj = pi.GetValue(declaredObj, null);
                return GetProperty(propertyName, ref declaredObj);
            }

        }



        #endregion
        /// <summary>
        /// Pair of perperty and value,control,priority.
        /// </summary>
        public class PropertyPair : IComparable<PropertyPair>
        {
            private string _key;

            /// <summary>
            /// Gets or sets the name of the property.
            /// </summary>
            /// <value>The name of the property.</value>
            public string PropertyName
            {
                get { return _key; }
                set { _key = value; }
            }

            /// <summary>
            /// Gets or sets the display name of the property.
            /// </summary>
            /// <value>The display name of the property.</value>
            public string DisplayPropertyName
            {
                get
                {
                    if (priority == DataBinding.DefaultPriority)
                    {
                        return _key;
                    }
                    else
                    {
                        return _key + ":" + priority.ToString();
                    }
                }
                set
                {
                    string[] s = value.Split(':');
                    _key = s[0];
                    if (s.Length > 1)
                    {
                        int p;
                        if (int.TryParse(s[1], out p))
                        {
                            priority = p;
                        }
                        else
                        {
                            priority = DataBinding.DefaultPriority;
                        }
                    }

                }
            }

            private string _value;

            /// <summary>
            /// Gets or sets the format string.
            /// </summary>
            /// <value>The format string.</value>
            public string FormatString
            {
                get { return _value; }
                set { _value = value; }

            }

            private Control control;

            /// <summary>
            /// Gets or sets the control.
            /// </summary>
            /// <value>The control.</value>
            public Control Control
            {
                get { return control; }
                set { control = value; }
            }


            private int priority = DataBinding.DefaultPriority;

            /// <summary>
            /// Gets or sets the priority.
            /// </summary>
            /// <value>The priority.</value>
            public int Priority
            {
                get { return priority; }
                set { priority = value; }
            }

            #region IComparable<PropertyPair> Members

            /// <summary>
            /// Compares the current object with another object of the same type.
            /// </summary>
            /// <param name="other">An object to compare with this object.</param>
            /// <returns>
            /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the other parameter.Zero This object is equal to other. Greater than zero This object is greater than other.
            /// </returns>
            public int CompareTo(PropertyPair other)
            {
                if (this.priority == other.priority)
                {
                    return 0;
                }
                else if (this.priority > other.priority)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }


    }



}
