using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Data Converter.
    /// </summary>
    public interface ICsvDataConverter
    {
        /// <summary>
        /// Converts the form.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        Object convertForm(Object target, String str);
    }
}
