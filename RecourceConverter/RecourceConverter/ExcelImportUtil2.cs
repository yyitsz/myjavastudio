using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace RecourceConverter
{
    public class ExcelImportUtil2
    {

        private IDictionary<string, PropertyInfo> propertyCache = new Dictionary<string, PropertyInfo>();
        private IDictionary<Type, TypeConverter> converters = new Dictionary<Type, TypeConverter>();



        public IDictionary<Type, TypeConverter> Converters
        {
            get { return converters; }
        }

        public ExcelImportUtil2()
        {
            
        }
        /// <summary> 
        /// Imports Excel file to DataSet.
        /// </summary> 
        /// <param name="Path">The full file path.</param> 
        /// <returns>returns the dataset.</returns> 
        public DataSet ExcelToDS(string path)
        {
            Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateBinaryReader(File.OpenRead(path));
            DataSet ds = reader.AsDataSet(true);
            reader.Close();
            return ds;
        }


        /// <summary>
        /// Imports Excel file to List with the first sheet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="dataFirstRow"></param>
        /// <param name="columnPropertyMap"></param>
        /// <returns></returns>
        public List<T> ExcelToList<T>(string path, int dataFirstRow,
            IDictionary<int, string> columnPropertyMap, CustomeHandle handler) where T : new()
        {
            return ExcelToList<T>(path, dataFirstRow, null, columnPropertyMap, handler);
        }

        /// <summary> 
        /// Imports Excel file to List with the specified the sheet name.
        /// </summary> 
        /// <param name="path">The full file path.</param> 
        /// <param name="columnPropertyMap"></param>
        /// <param name="dataFirstRow">The no. row which import,it is greater than 0. </param>
        /// <returns>returns List.If total number of error greater than 20,the ExcelImportException will be thrown.</returns> 
        /// <exception cref="ExcelImportException">If total number of error greater than 20,the ExcelImportException will be thrown.</exception>
        public List<T> ExcelToList<T>(string path, int dataFirstRow, string sheetName,
            IDictionary<int, string> columnPropertyMap, CustomeHandle handler) where T : new()
        {
            sheetName = sheetName.TrimEnd('$');

            if (dataFirstRow < 1)
            {
                dataFirstRow = 1;
            }

            List<T> list = new List<T>();

            Excel.IExcelDataReader reader = null;
            try
            {
                 reader = Excel.ExcelReaderFactory.CreateBinaryReader(File.OpenRead(path));
                int totalError = 0;
                string errorMessage = "";
                int rowIndex = 0;

                Excel.ExcelBinaryReader tmpReader = reader as Excel.ExcelBinaryReader;

               ABC:
                while (reader.Read())
                {

                    while (sheetName != null && reader.Name != sheetName)
                    {
                        if (reader.NextResult() == false)
                        {
                            return list;
                        }
                        else
                        {
                            goto ABC;
                        }
                    }

                    rowIndex++;
                    //Skips dataFirstRow row.
                    if (dataFirstRow > 1)
                    {
                        dataFirstRow--;
                        continue;
                    }

                    T obj = new T();
                    list.Add(obj);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.IsDBNull(i) == false && columnPropertyMap.ContainsKey(i + 1))
                        {
                            object value = reader.GetValue(i).ToString();
                            PropertyInfo pi = GetProperty(typeof(T), columnPropertyMap[i + 1]);
                            if (pi == null)
                            {
                                throw new Exception(String.Format("The property [{0}] didn't be found.", columnPropertyMap[i + 1]));
                            }

                            TypeConverter converter = GetConverter(pi.PropertyType);
                            try
                            {
                                if (value != null)
                                {
                                    if (value.GetType().Equals(pi.PropertyType) == false)
                                    {

                                        value = converter.ConvertFrom(value);

                                    }
                                }
                                pi.SetValue(obj, value, null);
                            }
                            catch (Exception ex)
                            {
                                totalError++;
                                errorMessage += string.Format("The cell [{0}, {1}] data convertion occurs the error.Error:{2} ",
                                    rowIndex, i, ex.Message) + Environment.NewLine;

                                //if (totalError >= 20)
                                // {
                                throw new Exception(errorMessage, ex);
                                // }
                            }
                        }
                        else if (reader.IsDBNull(i) == false)
                        {
                            handler(obj, i + 1, reader.GetValue(i).ToString());
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

        private PropertyInfo GetProperty(Type type, string propertyName)
        {
            string cacheKey = type.FullName + "," + propertyName;
            PropertyInfo pi = null;

            //Get from the cache.
            if (propertyCache.ContainsKey(cacheKey))
            {
                pi = propertyCache[cacheKey];
            }
            else
            {
                pi = type.GetProperty(propertyName);
                propertyCache[cacheKey] = pi;
            }
            return pi;
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
