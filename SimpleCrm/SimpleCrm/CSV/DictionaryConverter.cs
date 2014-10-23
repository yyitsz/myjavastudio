using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Convert to Dictionary per line. line number is saved with key LINE_NUMBER_KEY.
    /// </summary>
    public class DictionaryConverter : ICsvConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static string LINE_NUMBER_KEY = "__LineNumber__";
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryConverter"/> class.
        /// </summary>
        public DictionaryConverter( )
        {
        }
        #region IConverter Members

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="header">The header.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public Object ConvertFrom(int lineNum,string[] header, string[] fields)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic[LINE_NUMBER_KEY] = lineNum.ToString();

            for (int i = 0; i < header.Length; i++)
            {
                if (i < fields.Length)
                {
                    dic[header[i]] = fields[i];
                }
                else
                {
                    dic[header[i]] = "";
                }
            }
            return dic;
        }

        #endregion



    }
}
