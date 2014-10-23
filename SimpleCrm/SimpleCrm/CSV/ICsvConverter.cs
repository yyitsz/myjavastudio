using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Conver field to Object.
    /// </summary>
    public interface ICsvConverter
    {
        /// <summary>
        /// Converts from field to an object.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        Object ConvertFrom(int lineNum, string[] headers,string[] fields);
    }
}
