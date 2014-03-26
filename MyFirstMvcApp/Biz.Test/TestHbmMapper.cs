using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.HbmMapper;
using ConfOrm;
using Biz.Model;
using ConfOrm.NH;
using ConfOrm.Mappers;
using ConfOrm.Patterns;
using ConfOrm.Shop.Packs;
using Framework.ConfOrmExt;
using Framework.Entity;

namespace Biz.Test
{
    public class TestHbmMapper : IHbmMapper
    {
        public static void BaseEntityMap<T>(IClassMapper<T> mapper) where T : class,IAuditable, IVersionable
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

        public NHibernate.Cfg.MappingSchema.HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            orm.Patterns.PoidStrategies.Add(new NativePoidPattern());

            NullableEnumPropertyAsStringApplier a = new NullableEnumPropertyAsStringApplier();
            IPatternsAppliersHolder patternsAppliers = new SafePropertyAccessorPack();
            patternsAppliers.Property.Add(a);
            patternsAppliers.Property.Add(new BooleanPropertyAsCharApplier());

            var entities = new[] { typeof(Person), typeof(Address) };
            orm.Cascade<Person, Address>(Cascade.Detach | Cascade.Merge | Cascade.Persist | Cascade.ReAttach | Cascade.Refresh);
            orm.TablePerClass(entities);
            orm.VersionProperty<CommonBaseEntity<long>>(p => p.VersionNo);

            var mapper = new Mapper(orm, patternsAppliers);
            orm.ManyToOne<Person, Address>();

            mapper.Class<CommonBaseEntity<long>>(p => BaseEntityMap(p));
            mapper.Class<CommonBaseEntity<int>>(p => BaseEntityMap(p));

            mapper.Class<Person>(p =>
            {
                p.Table("PERSONS");
                p.Id(
                    idm => idm.Id,
                    idp =>
                    {
                        idp.Column("PERSON_ID");
                        //idp.Generator(Generators.Native);
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
                        // idp.Generator(Generators.Native);
                    });
                p.Property<String>(pr => pr.Street, pm => pm.Length(200));

            });



            return mapper.CompileMappingFor(entities);
        }

        public string GetMapingName()
        {
            return "Test.hbm.xml";
        }
    }
}
