using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace SimpleCrm.Utils
{
    public class ExcelImportUtil
    {
        private readonly string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};" + "Extended Properties=\"Excel 8.0;HDR=No; IMEX=1\";";


        private IDictionary<string, PropertyInfo> propertyCache = new Dictionary<string, PropertyInfo>();
        private IDictionary<Type, TypeConverter> converters = new Dictionary<Type, TypeConverter>();



        public IDictionary<Type, TypeConverter> Converters
        {
            get { return converters; }
        }

        public ExcelImportUtil()
        {
            
        }
        /// <summary> 
        /// Imports Excel file to DataSet.
        /// </summary> 
        /// <param name="Path">The full file path.</param> 
        /// <returns>returns the dataset.</returns> 
        public DataSet ExcelToDS(string path)
        {
            string connStr = string.Format(connectionStr, path);
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter adapter = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            adapter = new OleDbDataAdapter(strExcel, connStr);
            ds = new DataSet();
            adapter.Fill(ds, "table1");
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
        public List<T> ExcelToList<T>(string path, int dataFirstRow, int totalColumns,
            IDictionary<int, string> columnPropertyMap, CustomeHandle handler) where T : new()
        {
            string sheetName = GetExcelSheetName(path, 1);
            return ExcelToList<T>(path, dataFirstRow, sheetName,totalColumns,columnPropertyMap, handler);
        }

        /// <summary> 
        /// Imports Excel file to List with the specified the sheet name.
        /// </summary> 
        /// <param name="path">The full file path.</param> 
        /// <param name="columnPropertyMap"></param>
        /// <param name="dataFirstRow">The no. row which import,it is greater than 0. </param>
        /// <returns>returns List.If total number of error greater than 20,the ExcelImportException will be thrown.</returns> 
        /// <exception cref="ExcelImportException">If total number of error greater than 20,the ExcelImportException will be thrown.</exception>
        public List<T> ExcelToList<T>(string path, int dataFirstRow, string sheetName,int totalColumns,
            IDictionary<int, string> columnPropertyMap, CustomeHandle handler) where T : new()
        {
            if (dataFirstRow < 1)
            {
                dataFirstRow = 1;
            }

            List<T> list = new List<T>();

            string connStr = string.Format(connectionStr, path);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                //A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF
                //string sheetname = GetExcelFirstTableName(path);
                string commandStr = CreateSql(sheetName,totalColumns);
                OleDbCommand myCommand = new OleDbCommand(commandStr, conn);

                OleDbDataReader reader = myCommand.ExecuteReader();


                int totalError = 0;
                string errorMessage = "";
                int rowIndex = 0;

                while (reader.Read())
                {
                    rowIndex++;
                    //Skips dataFirstRow row.
                    if (dataFirstRow > 1)
                    {
                        dataFirstRow--;
                        continue;
                    }

                    T obj = new T();
                    list.Add(obj);

                    for (int i = 0; i < reader.VisibleFieldCount; i++)
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

            return list;
        }

        private static string CreateSql(string sheetName,int totalColumns)
        {
            if (totalColumns <= 0)
            {
                totalColumns = 30;
            }
            StringBuilder sb = new StringBuilder("SELECT ");

            for (int i = 1; i < totalColumns; i++)
            {
                sb.Append("F").
                    Append(i).
                    Append(",");
            }

            sb.Append("F").
                   Append(totalColumns).
                   Append(" FROM [").
                   Append(sheetName)
                   .Append("]");

            return sb.ToString();
           // string.Format("select F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,F13,F14,F15,F16,F17,F18,F19,F20,F21,F22,F23,F24,F25,F26,F27,F28,F29,F30,F31,F32 from [{0}]", sheetName);
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

        /// <summary>
        /// Get the sheet name of no. location.
        /// </summary>
        /// <param name="path">The Excel file full path.</param>
        /// <param name="tableNo">Sheet location.It starts from 1.</param>
        /// <returns></returns>
        public string GetExcelSheetName(string path, int tableNo)
        {
            string sheetName = null;
            if (File.Exists(path))
            {
                using (OleDbConnection conn = new OleDbConnection(string.Format(connectionStr, path)))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt.Rows.Count >= tableNo)
                    {
                        sheetName = dt.Rows[tableNo - 1][2].ToString().Trim();
                    }
                }
            }
            return sheetName;
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

    /// <summary>
    /// The user can custome the handler process.
    /// </summary>
    /// <param name="o">the object imported.</param>
    /// <param name="columnIndex">the  column index of the cell.</param>
    /// <param name="cellValue">the current cell value.</param>
    public delegate void CustomeHandle(object o, int columnIndex,string cellValue);
}
