using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace RecourceConverter
{
    public class XmlUtils
    {
        public static string FormatXml(string sUnformattedXml)
        {
            if (string.IsNullOrEmpty(sUnformattedXml))
            {
                return "";
            }
            sUnformattedXml = sUnformattedXml.Trim();
            //load unformatted xml into a dom

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);

            //will hold formatted xml

            StringBuilder sb = new StringBuilder();

            //pumps the formatted xml into the StringBuilder above

            StringWriter sw = new StringWriter(sb);

            //does the formatting

            XmlTextWriter xtw = null;

            try
            {
                //point the xtw at the StringWriter

                xtw = new XmlTextWriter(sw);

                //we want the output formatted

                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 2;

                //get the dom to dump its contents into the xtw 

                xd.WriteTo(xtw);
            }
            finally
            {
                //clean up even if error

                if (xtw != null)
                {
                    xtw.Close();
                }
            }

            //return the formatted xml

            return sb.ToString();
        }


    }
}

