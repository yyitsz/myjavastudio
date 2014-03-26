using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;
using MyFirstMvcApp.Controllers;
using Framework.HbmMapper;
using NHMembershipProvider.Mappings;

namespace MyFirstMvcApp.Windsor
{
    public class HbmMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHbmMapper>()
                .ImplementedBy<NHMembershipProviderMapper>()
                .LifeStyle.Transient);
        }
    }
}