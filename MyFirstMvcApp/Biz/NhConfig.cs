using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg.MappingSchema;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using ConfOrm;
using Biz.Model;
using ConfOrm.NH;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
namespace Biz
{
    public class NhConfig
    {
        private const string ConnectionString = @"Server=127.0.0.1;Initial Catalog=TestDB;User Id=root;Password=;";

        public static Configuration ConfigureNHibernate()
        {
            Configuration cfg = new Configuration();
            cfg.SessionFactory()
                .Named("Demo")
                .Proxy.Through<ProxyFactoryFactory>()

                .Integrate
                    .Using<NHibernate.Dialect.MySQL5Dialect>()
                    .LogSqlInConsole()
                    .Schema
                        .Updating()
                    .BatchingQueries
                        .Each(100)
                    .Connected
                        .By<NHibernate.Driver.MySqlDataDriver>()
                        .Releasing(NHibernate.ConnectionReleaseMode.AfterTransaction)
                        .Using(ConnectionString)
                    .CreateCommands
                        .AutoCommentingSql()
                        ;

            return cfg;
        }

        public static ISessionFactory SessionFactory { get; private set; }

        public static void InitializeSessionFactory(params HbmMapping[] mappings)
        {
            Configuration config = ConfigureNHibernate();
            int i = 0;
            foreach (HbmMapping m in mappings)
            {
                i++;
                config.AddDeserializedMapping(m, "abcd" + i);
            }

            SchemaMetadataUpdater.QuoteTableAndColumns(config);
            //new SchemaExport(config).Create(true, true);
            SessionFactory = config.BuildSessionFactory();
        }

        public static string Serialize(HbmMapping hbmElement)
        {
            var setting = new XmlWriterSettings { Indent = true };
            var serializer = new XmlSerializer(typeof(HbmMapping));
            using (var memStream = new MemoryStream(2048))
            using (var xmlWriter = XmlWriter.Create(memStream, setting))
            {
                serializer.Serialize(xmlWriter, hbmElement);
                memStream.Flush();
                memStream.Position = 0;
                var sr = new StreamReader(memStream);
                return sr.ReadToEnd();
            }
        }





        public static void CloseSessionFactory()
        {
            if (SessionFactory != null && SessionFactory.IsClosed == false)
            {
                SessionFactory.Close();
            }
        }
    }
}
