using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace INCT.FNHProviders
{
    public static class SessionHelper
    {
        public static ISessionFactory CreateSessionFactory(string connstr)
        {
            return Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005
                .ConnectionString(connstr)
                )

                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<INCT.FNHProviders.Membership.FNHMembershipProvider>())
                .BuildSessionFactory();
        }
    }
}
