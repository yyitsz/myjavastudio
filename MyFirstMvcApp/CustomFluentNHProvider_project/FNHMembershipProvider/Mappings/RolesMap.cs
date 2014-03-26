using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using INCT.FNHProviders.Entities;

namespace INCT.FNHProviders.Mappings
{
    public class RolesMap : ClassMap<Roles>
    {
        public RolesMap()
        {
            Id(x => x.Id);
            Map(x => x.RoleName);
            Map(x => x.ApplicationName);
            HasManyToMany(x => x.UsersInRole)
            .Cascade.All()
            .Inverse()
            .Table("UsersInRoles");
        }
    }
}
