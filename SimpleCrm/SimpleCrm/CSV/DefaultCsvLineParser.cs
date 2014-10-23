using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.CSV
{
    /// <summary>
    /// Line Parser.
    /// </summary>
    public class DefaultCsvLineParser : ICsvLineParser
    {
        private List<CsvError> errors = new List<CsvError>();
        #region ICSVLineParser Members

        /// <summary>
        /// Parses the specified line.
        /// </summary>
        /// <param name="lineNum">The line num.</param>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public string[] Parse(int lineNum, string line, char delimiter)
        {
            this.errors.Clear();

            List<String> result = new List<string>();

            if (string.IsNullOrEmpty(line))
            {
                return new string[] { };
            }
            int lineIndex = 0;
            while (lineIndex < line.Length)
            {
                String field = ReadNextField(lineNum, line, delimiter, ref lineIndex);

                result.Add(field);
                if (this.errors.Count > 0)
                {
                    break;
                }
                lineIndex++;//ignore delimiter.
            }
            if (line[line.Length - 1] == delimiter)
            {
                result.Add(string.Empty);
            }
            return result.ToArray();
        }

        private String ReadNextField(int lineNum, string line, char delimiter, ref int lineIndex)
        {
            bool hasQuote = false;
            bool endQuote = false;

            //elimate head blank.
            while (lineIndex < line.Length)
            {
                if (line[lineIndex] == ' ')//blank
                {
                    lineIndex++;
                }
                else
                {
                    break;
                }
            }

            if (lineIndex >= line.Length)
            {
                return string.Empty;
            }

            StringBuilder cache = new StringBuilder();
            if (line[lineIndex] == '"')
            {
                hasQuote = true;
                lineIndex++;
            }

            while (lineIndex < line.Length)
            {
                char c = line[lineIndex];

                if (c == '"')
                {
                    char nextC = '\0';
                    if (lineIndex + 1 < line.Length)
                    {
                        nextC = line[lineIndex + 1];
                    }

                    if (nextC == '"' && hasQuote)
                    {  //"adsfasd""
                        lineIndex++; //eat " char.
                    }
                    else if (hasQuote)
                    {
                        //"aasfasdf"
                        endQuote = true;
                        lineIndex++;
                        break;
                    }
                    cache.Append(c);//apend " char.
                }
                else if (c == delimiter)
                {
                    if (hasQuote)
                    {
                        cache.Append(c);
                    }
                    else
                    {// delimiter char. break loop.
                        break;
                    }
                }
                else
                {
                    cache.Append(c);
                }
                lineIndex++;
            }

            if (hasQuote && endQuote == false)
            {
                errors.Add(new CsvError(lineNum, CsvError.ERROR_0001, "The closed quotation can not be found."));
            }
            else
            {
                //ignore chars after " char. e.g. : "ADFA"xdsd, ignore xdsd
                while (lineIndex < line.Length)
                {

                    if (line[lineIndex] != delimiter)
                    {
                        if (line[lineIndex] != ' ') //only blank char can be ignored.
                        {
                            errors.Add(new CsvError(lineNum, CsvError.ERROR_0002, "Some chars are ignored, but those chars is not blank"));
                            break;
                        }
                        lineIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            String result = cache.ToString();
            //if no quotation, trim head and tail blank.
            if (hasQuote == false)
            {
                result = result.Trim();
            }
            return result;
        }
        #endregion

        #region ICsvLineParser Members


        /// <summary>
        /// when fail to error or exist error, return a non empty list.
        /// </summary>
        /// <value></value>
        public List<CsvError> Errors
        {
            get { return errors; }
        }

        #endregion
    }
}
