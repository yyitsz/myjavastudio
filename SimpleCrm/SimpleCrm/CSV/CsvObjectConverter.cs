using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Convert to Object.
    /// </summary>
    public class CsvObjectConverter : ICsvConverter
    {
        private Type type;

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type
        {
            get { return type; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvObjectConverter"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CsvObjectConverter(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            this.type = type;
        }
        #region IConverter Members

        /// <summary>
        /// Converts from field to an object.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public Object ConvertFrom(int lineNum, string[] headers, string[] fields)
        {
            Object tempObj = Activator.CreateInstance(type);
            Load(lineNum, tempObj, headers,fields);
            return tempObj;
        }

        #endregion

        /// <summary>
        /// Loads the specified target.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="target">The target.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="fields">The fields.</param>
        private void Load(int lineNum, object target, string[] headers, string[] fields)
        {
            PropertyInfo[] properties = type.GetProperties();

            // Loop through properties
            foreach (PropertyInfo property in properties)
            {
                // Make sure the property is writeable (has a Set operation)
                if (property.CanWrite)
                {
                    // find CSVPosition attributes assigned to the current property
                    CsvPositionAttribute positionAttr = GetAttribute<CsvPositionAttribute>(property);
                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    // if Length is greater than 0 we have at least one CSVPositionAttribute
                    if (positionAttr != null)
                    {

                        //Retrieve the postion value from the CSVPositionAttribute
                        int position = positionAttr.Position;
                        if (position < 0)
                        {
                            string header = positionAttr.Header;
                            if (string.IsNullOrEmpty(header))
                            {
                                throw new CsvConvertionException("CsvPostionAttribute has to use positon or header.");
                            }
                            position = FindPosition(headers,header);
                            if (position < 0 && positionAttr.Required)
                            {
                                CsvConvertionException ex = new CsvConvertionException("The header [" + header + "] defined in CsvPositionAttribute can not be found in headers of file.");
                                throw ex;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (position + 1 > fields.Length)
                        {
                            continue;
                        }
                        try
                        {
                            // get the CSV data to be manipulate and written to object
                            object data = fields[position].Trim();

                            // check for a Tranform operation that needs to be executed
                            if (positionAttr.DataConverter != null)
                            {
                                ICsvDataConverter converter = Activator.CreateInstance(positionAttr.DataConverter) as ICsvDataConverter;
                                if (converter != null)
                                {
                                    data = converter.convertForm(target, fields[position]);
                                }
                                else
                                {
                                    CsvConvertionException converterEx = new CsvConvertionException("The DataConverter can not be created on " + property.Name + " in " + type.Name);
                                    converterEx.LineNumber = lineNum;
                                    throw converterEx;
                                }
                            }
                            // set the ue on our target object with the data
                            property.SetValue(target, Convert.ChangeType(data, targetType), null);
                        }
                        catch (Exception ex)
                        {

                            CsvConvertionException converterEx = new CsvConvertionException("Error occurred when set value to " + property.Name + " in " + type.Name, ex);
                            converterEx.LineNumber = lineNum;
                            throw converterEx;

                        }
                    }
                    else
                    {
                        CsvLineNumberAttribute attr = GetAttribute<CsvLineNumberAttribute>(property);
                        if (attr != null)
                        {
                            try
                            {
                                property.SetValue(target, Convert.ChangeType(lineNum, targetType), null);
                            }
                            catch (Exception ex)
                            {
                                CsvConvertionException converterEx = new CsvConvertionException("Error occurred when set line numer to " + property.Name + " in " + type.Name, ex);
                                converterEx.LineNumber = lineNum;
                                throw converterEx;
                            }

                        }

                    }

                }
            }
        }

        private int FindPosition(string[] headers,string header)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i] == header)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        private static T GetAttribute<T>(PropertyInfo property) where T : Attribute
        {
            object[] attributes = property.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            return null;
        }


    }
}
