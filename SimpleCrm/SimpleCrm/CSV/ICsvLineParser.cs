using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Parse one line.
    /// </summary>
    public interface ICsvLineParser
    {
        /// <summary>
        /// Parses the specified line.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        string[] Parse(int lineNum, String line, char delimiter);
        /// <summary>
        /// when fail to error or exist error, return a non empty list.
        /// </summary>
        List<CsvError> Errors { get;}
    }
}
