using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// CSV file importer.
    /// </summary>
    public class CsvImporter
    {
        private String fileName;

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public String FileName
        {
            get { return fileName; }
        }
        public Encoding Encoding { get; set; }

        private List<CsvError> errors = new List<CsvError>();

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<CsvError> Errors
        {
            get { return errors; }
        }

        private ICsvConverter converter;

        /// <summary>
        /// Gets or sets the converter.
        /// </summary>
        /// <value>The converter.</value>
        public ICsvConverter Converter
        {
            get { return converter; }
            set { converter = value; }
        }

        private ICsvLineParser lineParser;

        /// <summary>
        /// Gets or sets the line parser.
        /// </summary>
        /// <value>The line parser.</value>
        public ICsvLineParser LineParser
        {
            get { return lineParser; }
            set { lineParser = value; }
        }


        private bool firstRowIsHeader = true;
        private static readonly int MAX_ERROR_NUMBER = 10;


        /// <summary>
        /// Initializes a new instance of the <see cref="CsvImporter"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="firstRowIsHeader">if set to <c>true</c> [first row is header].</param>
        public CsvImporter(string fileName, bool firstRowIsHeader)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");

            }
            this.fileName = fileName;
            this.firstRowIsHeader = firstRowIsHeader;

            this.Encoding = Encoding.GetEncoding("GBK");
        }


        /// <summary>
        /// Parses this instance.
        /// </summary>
        /// <returns></returns>
        public IList Parse()
        {
            CheckDefaultValue();
            errors.Clear();

            ArrayList list = new ArrayList();
            List<String> header = new List<string>();

            System.IO.StreamReader reader = new System.IO.StreamReader(fileName, this.Encoding);
            int lineNum = 0;

            try
            {
                while (reader.EndOfStream == false)
                {
                    string str = reader.ReadLine();

                    lineNum++;

                    if (str == null)
                    {
                        continue;
                    }

                    str = str.Trim();
                    if (str.Length == 0)
                    {
                        continue;
                    }

                    string[] split = lineParser.Parse(lineNum, str, ',');
                    if (lineParser.Errors.Count > 0)
                    {
                        this.errors.AddRange(lineParser.Errors);
                        if (this.errors.Count >= MAX_ERROR_NUMBER)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (lineNum == 1)
                        {
                            if (firstRowIsHeader)
                            {

                                for (int i = 0; i < split.Length; i++)
                                {
                                    header.Add(split[i].Trim());
                                }
                                continue;
                            }
                            else
                            {
                                for (int i = 0; i < split.Length; i++)
                                {
                                    header.Add("C" + i.ToString());
                                }
                            }
                        }
                        Object obj = converter.ConvertFrom(lineNum, header.ToArray(), split);

                        list.Add(obj);
                    }
                }
                if (errors.Count > 0)
                {
                    throw new CsvImportException(this.errors);
                }
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        /// <summary>
        /// Checks the default value.
        /// </summary>
        private void CheckDefaultValue()
        {
            if (converter == null)
            {
                converter = new DictionaryConverter();
            }

            if (lineParser == null)
            {
                lineParser = new DefaultCsvLineParser();
            }
        }


    }
}
