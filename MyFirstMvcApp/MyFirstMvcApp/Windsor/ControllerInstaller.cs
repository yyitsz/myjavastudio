using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;
using MyFirstMvcApp.Controllers;

namespace MyFirstMvcApp.Windsor
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                .BasedOn<IController>()
                                .If(Component.IsInSameNamespaceAs<HomeController>())
                                .If(t => t.Name.EndsWith("Controller"))
                                .Configure((ConfigureDelegate)(c => c.Named(c.ServiceType.Name)
                                            .LifeStyle.Transient)));
        }
    }
}