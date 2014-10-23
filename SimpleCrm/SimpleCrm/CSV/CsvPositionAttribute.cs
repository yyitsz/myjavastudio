using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm
{
    /// <summary>
    /// Define position
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvPositionAttribute : System.Attribute
    {
        private int position = -1;
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public int Position
        {
            get { return position; }
            private set { position = value; }
        }

        private string header;

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string Header
        {
            get { return header; }
            private set { header = value; }
        }


        private Type dataConverter;
        /// <summary>
        /// Gets or sets the data converter.
        /// </summary>
        /// <value>The data converter.</value>
        public Type DataConverter
        {
            get { return dataConverter; }
            private set { dataConverter = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CsvPositionAttribute"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="dataConverter">The data converter.</param>
        public CsvPositionAttribute(int position, Type dataConverter)
        {
            if (position < 0)
            {
                throw new Exception("Position must start from 0.");
            }
            Position = position;
            header = null;
            this.DataConverter = dataConverter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvPositionAttribute"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="dataConverter">The data converter.</param>
        public CsvPositionAttribute(string header,Type dataConverter)
        {
            if (string.IsNullOrEmpty(header))
            {
                throw new ArgumentNullException("header");
            }
            Header = header;
            position = -1;
            DataConverter = dataConverter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvPositionAttribute"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public CsvPositionAttribute(int position):this(position,null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvPositionAttribute"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        public CsvPositionAttribute(string header):this(header,null)
        {
          
        }

    }
}
