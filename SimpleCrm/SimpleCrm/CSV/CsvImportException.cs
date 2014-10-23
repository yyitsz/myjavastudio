using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{

    /// <summary>
    /// Csv Import Exception.
    /// </summary>
    [global::System.Serializable]
    public class CsvImportException : Exception
    {
        private List<CsvError> errors;

        /// <summary>
        /// Gets the errors. 
        /// </summary>
        /// <value>The errors.</value>
        public List<CsvError> Errors
        {
            get
            {
                if (errors == null)
                {
                    return new List<CsvError>();
                }
                return errors;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvImportException"/> class.
        /// </summary>
        public CsvImportException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvImportException"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public CsvImportException(List<CsvError> errors)
            : this(CsvError.ConvertToString(errors))
        {
            this.errors = errors;
        }

     

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvImportException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CsvImportException(string message) : base(message) { }

    }
}
