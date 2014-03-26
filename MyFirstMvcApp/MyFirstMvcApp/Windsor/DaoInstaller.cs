using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;
using MyFirstMvcApp.Controllers;
using MyFirstMvcApp.Models;
using Castle.Facilities.Logging;
using Castle.Facilities.NHibernateIntegration;
using Framework.Dao;
using NHMembershipProvider.Dao;
using Castle.Facilities.AutoTx;
using Framework.Transaction;
using Framework.Executor;
using Framework.Interceptors;

namespace MyFirstMvcApp.Windsor
{
    public class DaoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
         
            container.Register(Component.For(typeof(IBaseDao<,>))
                .ImplementedBy(typeof(NHibernateBaseDao<,>)));

            container.Register(Component.For(typeof(IExecutor))
                .ImplementedBy<SqlExecutor>());
            container.Register(Component.For(typeof(IExecutor))
              .ImplementedBy<HqlExecutor>());
            container.Register(Component.For(typeof(IExecutor))
              .ImplementedBy<ImplementorExecutor>());

            container.Register(Component.For<DaoInterceptor>()
                .Parameters(Parameter.ForKey("sessionFactoryAlias").Eq("TestDb")));

            container.Register(Component.For<IUserDao>()
                .ImplementedBy<UserDao>()
                .Parameters(Parameter.ForKey("sessionFactoryAlias").Eq("TestDb")));
          
        }
    }
}