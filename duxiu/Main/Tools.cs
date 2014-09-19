using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
namespace Mouse.Main
{
    internal class Tools
    {
        private static String BooksPath = "AppConfig.xml";

        public static String getPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BooksPath);
        }
        public static void Save(AppConfig config)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(AppConfig));
            using (TextWriter tw = new System.IO.StreamWriter(getPath()))
            {
                xmlSerializer.Serialize(tw, config);
            }
        }

        public static AppConfig Load()
        {
            String path = getPath();
            if (File.Exists(path))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(AppConfig));
                using (TextReader tr = new System.IO.StreamReader(getPath()))
                {
                    Object obj = xmlSerializer.Deserialize(tr);
                    return (AppConfig)obj;
                }
            }
            return new AppConfig();
        }
    }
}
