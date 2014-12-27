using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Data;
using Excel;
using SimpleCrm.Common;

namespace SimpleCrm.CSV
{
    public class ExcelImporter
    {

        private IDictionary<Type, TypeConverter> converters = new Dictionary<Type, TypeConverter>();

        public IDictionary<Type, TypeConverter> Converters
        {
            get { return converters; }
        }
        private string path;
        private Boolean firstRowIsHead;

        public ExcelImporter(String path, Boolean firstRowIsHead)
        {
            this.path = path;
            this.firstRowIsHead = firstRowIsHead;
        }
        /// <summary> 
        /// Imports Excel file to DataSet.
        /// </summary> 
        /// <param name="Path">The full file path.</param> 
        /// <returns>returns the dataset.</returns> 
        public DataSet ExcelToDS()
        {
            if (path.EndsWith("xls", StringComparison.InvariantCultureIgnoreCase))
            {
                Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateBinaryReader(File.OpenRead(path));
                reader.IsFirstRowAsColumnNames = firstRowIsHead;
                DataSet ds = reader.AsDataSet(true);
                reader.Close();
                return ds;
            }
            else if (path.EndsWith("xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(File.OpenRead(path));
                reader.IsFirstRowAsColumnNames = firstRowIsHead;
                DataSet ds = reader.AsDataSet(true);
                reader.Close();
                return ds;
            }
            throw new Exception("Not support file format.");
        }


        public List<T> ExcelToList<T>() where T : new()
        {

            List<T> list = new List<T>();

            Dictionary<PropertyInfo, CsvPositionAttribute> csvProperties = GetProperties(typeof(T));
            IExcelDataReader reader = null;
            Dictionary<int, String> headerMap = null;
            try
            {
                reader = CreateReader();
                int rowIndex = 0;

                while (reader.Read())
                {
                    rowIndex++;
                    if (rowIndex == 1 && firstRowIsHead)
                    {
                        headerMap = CreateMap(reader);
                    }
                    else
                    {
                        if (rowIndex == 1 && firstRowIsHead == false)
                        {
                            headerMap = CreateMap(reader.FieldCount);
                        }
                        T obj = new T();
                        list.Add(obj);
                        foreach (var map in csvProperties)
                        {
                            int index = FindIndexByMapping(map, headerMap);
                            if (reader.IsDBNull(index) == false)
                            {
                                PropertyInfo pi = map.Key;
                                Type propertyType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                                object value = null;
                                if (propertyType == typeof(DateTime))
                                {
                                    value = reader.GetDateTime(index);
                                }
                                else if (propertyType == typeof(Int32))
                                {
                                    value = reader.GetInt32(index);
                                }
                                else if (propertyType == typeof(Decimal))
                                {
                                    value = reader.GetDecimal(index);
                                }
                                else if (propertyType == typeof(Int16))
                                {
                                    value = reader.GetInt16(index);
                                }
                                else if (propertyType == typeof(Int64))
                                {
                                    value = reader.GetInt64(index);
                                }
                                else if (propertyType == typeof(char))
                                {
                                    value = reader.GetChar(index);
                                }
                                else if (propertyType == typeof(Boolean))
                                {
                                    value = reader.GetBoolean(index);
                                }
                                else if (propertyType == typeof(Double))
                                {
                                    value = reader.GetDouble(index);
                                }
                                else if (propertyType == typeof(float))
                                {
                                    value = reader.GetFloat(index);
                                }
                                else
                                {
                                    value = reader.GetString(index).Trim();
                                }

                                TypeConverter converter = GetConverter(propertyType);
                                try
                                {
                                    if (value != null)
                                    {
                                        if (value.GetType().Equals(propertyType) == false)
                                        {
                                            value = converter.ConvertFrom(value);
                                        }
                                    }
                                    pi.SetValue(obj, value, null);
                                }
                                catch (Exception ex)
                                {

                                    String errorMessage = string.Format("单元格[{0}, {1}]数据转换发生了错误。{2}", rowIndex, index, ex.Message);
                                    throw new AppException(errorMessage, ex);
                                }
                            }
                            else
                            {
                                if (map.Value.Required)
                                {
                                    throw new AppException(map.Value.Header + "是必填的.");
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
            }
            return list;
        }

        private int FindIndexByMapping(KeyValuePair<PropertyInfo, CsvPositionAttribute> map, Dictionary<int, string> headerMap)
        {
            CsvPositionAttribute posAttr = map.Value;
            if (posAttr.Position >= 0)
            {
                if (headerMap.ContainsKey(posAttr.Position))
                {
                    return posAttr.Position;
                }
                else
                {
                    throw new AppException(String.Format("Wrong definition for position {0}, or wrong template.", posAttr.Position));
                }
            }
            else
            {
                foreach (KeyValuePair<int, String> kvp in headerMap)
                {
                    if (kvp.Value == posAttr.Header)
                    {
                        return kvp.Key;
                    }
                }
                throw new AppException(String.Format("Wrong definition for position {0}, or wrong template.", posAttr.Header));
            }
        }

        private Dictionary<int, string> CreateMap(int count)
        {
            Dictionary<int, string> headerMap = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
            {
                headerMap[i] = "C" + i.ToString();
            }
            return headerMap;
        }

        private Dictionary<int, string> CreateMap(IExcelDataReader reader)
        {
            Dictionary<int, string> headerMap = new Dictionary<int, string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.IsDBNull(i))
                {
                    headerMap[i] = "C" + i.ToString();
                }
                else
                {
                    headerMap[i] = reader.GetString(i).Trim();
                }
            }
            return headerMap;
        }

        private Tuple<PropertyInfo, CsvPositionAttribute> FindMapping(Dictionary<PropertyInfo, CsvPositionAttribute> csvProperties, int index, Dictionary<int, String> headerMap)
        {
            String colName = headerMap[index];
            foreach (var item in csvProperties)
            {
                CsvPositionAttribute pos = item.Value;
                if (pos.Position >= 0 && index == pos.Position
                    || pos.Position < 0 && pos.Header == colName)
                {
                    return Tuple.Create(item.Key, item.Value);
                }
            }
            return null;
        }

        private Dictionary<PropertyInfo, CsvPositionAttribute> GetProperties(Type type)
        {
            Dictionary<PropertyInfo, CsvPositionAttribute> dic = new Dictionary<PropertyInfo, CsvPositionAttribute>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var p in properties)
            {
                CsvPositionAttribute pos = p.GetCustomAttributes(typeof(CsvPositionAttribute), false).FirstOrDefault() as CsvPositionAttribute;
                if (pos != null)
                {
                    dic.Add(p, pos);
                }
            }
            return dic;
        }

        private Excel.IExcelDataReader CreateReader()
        {
            if (path.EndsWith("xls", StringComparison.InvariantCultureIgnoreCase))
            {
                Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateBinaryReader(File.OpenRead(path));
                reader.IsFirstRowAsColumnNames = firstRowIsHead;
                return reader;
            }
            else if (path.EndsWith("xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(File.OpenRead(path));
                reader.IsFirstRowAsColumnNames = firstRowIsHead;
                return reader;
            }
            throw new Exception("Not support file format.");
        }

        private TypeConverter GetConverter(Type type)
        {
            if (converters.ContainsKey(type))
            {
                return converters[type];
            }
            return TypeDescriptor.GetConverter(type);
        }


        public static string ConvertToExcelColumn(int columnIndex)
        {
            columnIndex--;
            if (columnIndex < 0)
            {
                return "";
            }

            string result = "";
            int quotient = columnIndex;
            do
            {
                quotient = quotient / 26;
                int residual = columnIndex % 26;
                result = ((char)((int)('A') + residual)).ToString() + result;

            } while (quotient > 0);
            return result;
        }

        public static int ConvertToNumberIndex(string excelColumn)
        {
            if (string.IsNullOrEmpty(excelColumn))
            {
                return 0;
            }
            int columnIndex = 0;
            foreach (char c in excelColumn)
            {
                columnIndex = columnIndex * 26 + ((int)c - (int)'A' + 1);
            }

            return columnIndex;
        }
    }
}

