using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfOrm;
using ConfOrm.NH;
using Biz.Model;
using NUnit.Framework;
using Biz.Extensions;
using NHibernate.Tool.hbm2ddl;

namespace Biz.Test
{
    [TestFixture]
    public class Test1
    {
        [NUnit.Framework.Test]
        [Ignore]
        public void UnidirectionalOneToOneMappingTest() 
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] {typeof(Person),typeof(Address) };

            orm.TablePerClass(entities);
            orm.OneToOne<Person, Address>();
            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();
            
            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void BidirectionalOneToOneMappingTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person2), typeof(Address2) };

            orm.TablePerClass(entities);
            orm.OneToOne<Person2, Address2>();
            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void BidirectionalOneToOneMappingForeignKeyTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person2), typeof(Address2) };

            orm.TablePerClass(entities);
            orm.ManyToOne<Person2, Address2>();
            orm.OneToOne<Address2, Person2>();
            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void UnidirectionalManyToManyMappingUsingSetTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person3), typeof(Address3) };

            orm.TablePerClass(entities);
            orm.ManyToMany<Person3, Address3>();

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void UnidirectionalManyToManyMappingUsingBagTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person4), typeof(Address4) };

            orm.TablePerClass(entities);
            orm.ManyToMany<Person4, Address4>();

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void UnidirectionalManyToManyMappingUsingListTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person5), typeof(Address5) };

            orm.TablePerClass(entities);
            orm.ManyToMany<Person5, Address5>();

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void UnidirectionalManyToManyMappingUsingDicTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Person6), typeof(Address6) };

            orm.TablePerClass(entities);
            orm.ManyToMany<Person6, Address6>();

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void BidirectionalManyToManyMappingUsingSetTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(User), typeof(Role) };

            orm.TablePerClass(entities);
            orm.ManyToMany<User, Role>();

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void ComponentTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Employee) };

            orm.TablePerClass(entities);
  
            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
        }

        [NUnit.Framework.Test]
         [Ignore]
        public void ComponentSetTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Employee2) };

            orm.TablePerClass(entities);

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);
            ExportDDL(mapping, "Employee2");
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void BidirectionalComponentSetTest()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Employee3) };

            orm.TablePerClass(entities);

            var mapping = mapper.CompileMappingFor(entities);
            String s = mapping.AsString();

            Console.WriteLine(s);

            ExportDDL(mapping, "Employee3");

        }

        private static void ExportDDL(NHibernate.Cfg.MappingSchema.HbmMapping mapping,string name)
        {
            var conf = NhConfig.ConfigureNHibernate();
            conf.AddDeserializedMapping(mapping, name);
            SchemaMetadataUpdater.QuoteTableAndColumns(conf);
            SchemaExport exporter = new SchemaExport(conf);
            exporter.Create(true, false);
        }
    }
}
