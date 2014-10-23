using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm
{
    /// <summary>
    /// Pass the line number to specified property that defined by this attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvLineNumberAttribute : System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvLineNumberAttribute"/> class.
        /// </summary>
        public CsvLineNumberAttribute()
        {
        }
    }
}
