using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace RecourceConverter
{
    public class ConfigHelper
    {
        public static T LoadConfig<T>(String configFileName)
        {
            if (File.Exists(configFileName))
            {
                using (FileStream fs = File.OpenRead(configFileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    T config = (T)s.Deserialize(fs);
                    return config;
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
