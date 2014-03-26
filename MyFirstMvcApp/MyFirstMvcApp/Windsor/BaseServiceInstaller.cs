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

namespace MyFirstMvcApp.Windsor
{
    public class BaseServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
            //container.AddFacility<TransactionManagerFacility>();
            container.Register(Component.For(typeof(TransactionTemplate))
    .ImplementedBy<TransactionTemplate>());
        
          
        }
    }
}