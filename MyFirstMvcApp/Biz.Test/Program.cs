using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.hbm2ddl;
using Biz.Model;
using System.IO;
using System.Reflection;
using NUnit.Core;
using NHibernate.Mapping;
using NHibernate.Cfg.MappingSchema;
using ConfOrm;
using ConfOrm.NH;
using NHibernate;
using ConfOrm.Mappers;
using NHMembershipProvider.Mappings;
using Biz.Extensions;
using Framework.Utils;
using Framework.Attributes;
using Framework.Entity;

namespace Biz.Test
{
    public interface ITestService
    {
        [ImplementedBy(typeof(TestService), MethodName = "abc")]
        string Echo(string echo);
    }

    public class TestService : ITestService
    {
        public string Echo(string echo)
        {
            Console.WriteLine("Called Echo(string)");
            return echo;
        }
        public string Echo()
        {
            Console.WriteLine("Called Echo");
            return "Echo, no parameters";
        }

        private string PrivateEcho()
        {
            Console.WriteLine("Called privaste Echo");
            return "Private Echo, no parameters";
        }
        public T Echo<T>() where T : new()
        {
            Console.WriteLine("Called Echo<T>");
            return new T();
        }
    }
    public class Foo<T> where T : new()
    {
        public T Get()
        {
            return new T();
        }

        public List<T2> Put<T2>(T2 x)
        {

            return new List<T2>();
        }

        public T2 Echo<T2>(T2 x)
        {

            return x;
        }
    }
    public class Program
    {
        // private static NLog.Logger log = LogManager.GetCurrentClassLogger();
        public static void Main()
        {
            // NUnit.ConsoleRunner.Runner.Main(new[] { "Biz.Test.exe" });
            Test5();
            //Console.WriteLine(Util.Gen(128));
            //Console.WriteLine(Util.Gen(48));
            Console.In.Read();
        }

        public static void Test6()
        {
            MethodInfo mi = typeof(Foo<Object>).GetMethod("Get", BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public, null, new Type[] { }, null);
            MethodInfo mi2 = typeof(Foo<Object>).GetMethod("Put", BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(String) }, null);
            MethodInfo mi3 = typeof(Foo<Object>).GetMethod("Put[T]", BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(String) }, null);
            MethodInfo mi4 = typeof(Foo<Object>).GetMethod("Put[[T]]", BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public, null, new Type[] { }, null);
        }

        public static void Test5()
        {
            MethodInfo mi = typeof(Foo<Object>).GetMethod("Get");
            Console.WriteLine(mi.Name + "'s result type is generic :" + mi.ReturnType.IsGenericType + ", is generic parameter " + mi.ReturnType.IsGenericParameter);
            MethodInfo mi2 = typeof(Foo<Object>).GetMethod("Put");
            Console.WriteLine(mi2.Name + "'s result type is generic :" + mi2.ReturnType.IsGenericType + ", is generic parameter " + mi2.ReturnType.IsGenericParameter);

            MethodInfo mi3 = mi2.MakeGenericMethod(typeof(String));
            Console.WriteLine(mi3.Name + "'s result type is generic :" + mi3.ReturnType.IsGenericType + ", is generic parameter " + mi3.ReturnType.IsGenericParameter);

            MethodInfo mi4 = typeof(Foo<Object>).GetMethod("Echo");
            Console.WriteLine(mi4.Name + "'s result type is generic :" + mi4.ReturnType.IsGenericType + ", is generic parameter " + mi4.ReturnType.IsGenericParameter);

            MethodInfo mi5 = mi4.MakeGenericMethod(typeof(String));
            Console.WriteLine(mi5.Name + "'s result type is generic :" + mi5.ReturnType.IsGenericType + ", is generic parameter " + mi5.ReturnType.IsGenericParameter);

        }
        public static void Test4()
        {
            TestService target = new TestService();
            Console.WriteLine(ReflectionHelper.InvokeMethod(target, "Echo"));
            Console.WriteLine(ReflectionHelper.InvokeMethod(target, "Echo", "Hello."));
            Console.WriteLine(ReflectionHelper.InvokeMethod(target, "PrivateEcho"));
            Console.WriteLine(ReflectionHelper.InvokeGenericeMethod(target, "Echo", new Type[] { typeof(Object) }));
        }
        private static void Test3()
        {
            HbmMapping mapping = new NHMembershipProviderMapper().GetMapping();
            Console.WriteLine(mapping.AsString());
            NhConfig.InitializeSessionFactory(mapping);
            using (var s = NhConfig.SessionFactory.OpenSession())
            {
                using (var tx = s.BeginTransaction())
                {

                    NHMembershipProvider.Entities.User u = new NHMembershipProvider.Entities.User();
                    u.Username = "yy";
                    u.Password = "asfsa";
                    s.Save(u);
                    tx.Commit();
                }
            }
            NhConfig.CloseSessionFactory();

        }
        //private static void Test1()
        //{

        //    ITestService service = new TestService();
        //    service = service.Proxy<ITestService>
        //        (new EmitProxyInterceptor<ITestService>(MyInterceptorMethod));
        //    Console.Out.WriteLine(service.Echo("Hello")); //Prints "Hello World!";
        //}

        //public static object MyInterceptorMethod(ITestService proxiedObject,
        //    string methodName, object[] parameters, EmitProxyExecute<ITestService> execute)
        //{
        //    return execute(proxiedObject, parameters[0] + " World!");
        //}

        private static void Test2()
        {
            Console.Out.WriteLine("Config...");
            // log.Debug("Config...");
            var conf = NhConfig.ConfigureNHibernate();
            conf.AddDeserializedMapping(GetMapping(), "Person");
            SchemaMetadataUpdater.QuoteTableAndColumns(conf);
            new SchemaExport(conf).Create(true, true);
            var factory = conf.BuildSessionFactory();
            ShowXmlMapping();
            var p = new Person { Name = "Wang Ba" };

            using (var s = factory.OpenSession())
            {
                using (var tx = s.BeginTransaction())
                {

                    s.Save(p);
                    tx.Commit();
                }
            }
            Person p2 = null;
            using (var s = factory.OpenSession())
            {
                using (var tx = s.BeginTransaction())
                {

                    p2 = s.Get<Person>(p.Id);

                    Console.WriteLine("Name={0}, Age={1}", p2.Name, p2.Age);
                }
            }
            // PersistenceManager.
            using (var s = factory.OpenSession())
            {
                using (var tx = s.BeginTransaction())
                {

                    s.CreateQuery("delete from Person").ExecuteUpdate();
                    tx.Commit();
                }
            }

            new SchemaExport(conf).Drop(false, true);


        }

        public static HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            var entities = new[] { typeof(Person), typeof(Address) };

            orm.TablePerClass(entities);
            orm.VersionProperty<CommonBaseEntity<long>>(p => p.VersionNo);

            var mapper = new Mapper(orm);
            orm.OneToOne<Person, Address>();

            mapper.Class<CommonBaseEntity<long>>(p => BaseEntityMap(p));

            mapper.Class<Person>(p =>
            {
                p.Table("PERSONS");
                p.Id(
                    idm => idm.Id,
                    idp =>
                    {
                        idp.Column("PERSON_ID");
                        idp.Generator(Generators.Native);
                    });
                p.Property<String>(pr => pr.Name, pm => pm.Length(50));
                p.ManyToOne<Address>(pr => pr.Address, pm => pm.Column("ADDRESS_ID"));

            });

            mapper.Class<Address>(p =>
            {
                p.Table("ADDRESSES");
                p.Id(
                    idm => idm.Id,
                    idp =>
                    {
                        idp.Column("ADDRESS_ID");
                        idp.Generator(Generators.Native);
                    });
                p.Property<String>(pr => pr.Street, pm => pm.Length(200));

            });



            return mapper.CompileMappingFor(entities);
        }

        public static void BaseEntityMap<T>(IClassMapper<T> mapper) where T : class, IVersionable, IAuditable
        {
            mapper.Version(pr => pr.VersionNo,
                   pm =>
                   {
                       pm.Column(c =>
                       {
                           c.Name("VERSION_NO");

                       });
                       pm.UnsavedValue(0);

                   });

            mapper.Property<String>(pr => pr.CreatedBy, pm =>
            {
                pm.Length(50);
                pm.Column("CREATED_BY");
            });

            mapper.Property<String>(pr => pr.UpdatedBy, pm =>
            {
                pm.Length(50);
                pm.Column("UPDATED_BY");
            });

            mapper.Property<DateTime?>(pr => pr.CreatedAt, pm =>
            {
                pm.Column("CREATED_TIME");
            });

            mapper.Property<DateTime?>(pr => pr.UpdatedAt, pm =>
            {
                pm.Column("UPDATED_TIME");
            });
        }
        public static void ShowXmlMapping()
        {
            var document = NhConfig.Serialize(GetMapping());
            File.WriteAllText("Person.hbm.xml", document);
            Console.Write(document);
        }
    }
}
