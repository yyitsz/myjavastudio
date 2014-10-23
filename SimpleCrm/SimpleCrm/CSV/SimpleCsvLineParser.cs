using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Use String.Split method to parse.
    /// </summary>
    public class SimpleCsvLineParser : ICsvLineParser
    {
        /// <summary>
        /// Parses the specified line.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public string[] Parse(int lineNum, string line, char delimiter)
        {
            return line.Split(delimiter);
        }



        /// <summary>
        /// always return empty list.
        /// </summary>
        /// <value></value>
        public List<CsvError> Errors
        {
            get { return new List<CsvError>(); }
        }


    }
}
