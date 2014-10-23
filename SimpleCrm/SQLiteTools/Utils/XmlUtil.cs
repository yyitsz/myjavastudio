using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SQLiteTools.Utils
{
    public class XmlUtil
    {
        private static XmlWriterSettings settings;
        static XmlUtil () 
        {
            settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
        }
        public static string Serialize(object obj)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                using (StringWriter outputStream = new StringWriter(sb))
                using (XmlWriter xmlWriter = XmlWriter.Create(outputStream,settings))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(xmlWriter, obj);
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T Deserialize<T>(string text)
        {
            if (null == text)
            {
                return default(T);
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(new StringReader(text));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
