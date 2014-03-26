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
using Castle.Facilities.AutoTx;
using Framework.Transaction;
using NHMembershipProvider.Services;

namespace MyFirstMvcApp.Windsor
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
 
            container.Register(Component.For<IMembershipService>()
                            .ImplementedBy<AccountMembershipService>()
                            .LifeStyle.Singleton);

            container.Register(Component.For<IFormsAuthenticationService>()
                            .ImplementedBy<FormsAuthenticationService>()
                            .LifeStyle.Singleton);

            container.Register(Component.For<IUserService>()
                            .ImplementedBy<UserService>()
                            .LifeStyle.Singleton);
          
        }
    }
}