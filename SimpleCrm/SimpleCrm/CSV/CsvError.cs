using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Error info when parsing
    /// </summary>
    public class CsvError
    {
        /// <summary>
        /// Incorrect format. The closed quotation can not be found.
        /// </summary>
        public static readonly string ERROR_0001 = "The closed quotation can not be found"; //The closed quotation can not be found
        /// <summary>
        /// Incorrect format. Some chars are ignored, but those chars is not blank.
        /// </summary>
        public static readonly string ERROR_0002 = "some chars are ignored, but those chars is not blank"; //some chars are ignored, but those chars is not blank.
        
        private String errorCode;

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public String ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        private String description;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private int lineNumber;

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>The line number.</value>
        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvError"/> class.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="desc">The desc.</param>
        public CsvError(int lineNumber, string errorCode,string desc)
        {
            this.lineNumber = lineNumber;
            this.errorCode = errorCode;
            this.description = desc;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("In Line {0} has error, Error Code is {1}, Description is {2}.", this.lineNumber, this.errorCode, this.description);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public static string ConvertToString(List<CsvError> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors");
            }
            StringBuilder sb = new StringBuilder();
            foreach (CsvError err in errors)
            {
                sb.Append(err.ToString());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
