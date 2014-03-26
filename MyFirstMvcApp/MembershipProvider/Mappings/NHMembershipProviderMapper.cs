using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg.MappingSchema;
using ConfOrm;
using ConfOrm.NH;
using NHMembershipProvider.Entities;
using Framework.HbmMapper;

namespace NHMembershipProvider.Mappings
{
    public class NHMembershipProviderMapper : IHbmMapper
    {
 
        public HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new[] { typeof(Profile), typeof(Role), typeof(User) };

            orm.TablePerClass(entities);
            orm.ManyToMany<User, Role>();
            orm.Cascade<User, Role>(Cascade.All);



            var mapping = mapper.CompileMappingFor(entities);
            return mapping;
        }

        public string GetMapingName()
        {
            return "NHMembershipProviderMapper.hbm.xml";
        }
    }
}
