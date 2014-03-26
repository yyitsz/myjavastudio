using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate.Cfg.MappingSchema;
using NHMembershipProvider.Mappings;
using Biz;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Framework;
using MyFirstMvcApp.Windsor;
using Framework.Container;
using Castle.MicroKernel.Registration;
using Common.Logging;
using Framework.Context;
using Framework.NHibernateExt;

namespace MyFirstMvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        static ILog log = LogManager.GetLogger<MvcApplication>();
 
        public IWindsorContainer Container
        {
            get { return AppContext.Container.RawContainer as IWindsorContainer; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            log.Debug("Register Routers");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = false;
            //routes.IgnoreRoute("{resource}.js");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            log.Debug("Starting Application");

            BootstrapContainer();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_End()
        {
            AppContext.Container.Dispose();
            AppContext.Container = null;
            log.Debug("Disposed Container");
            log.Debug("Stopped Application");
        }

      
        private static void BootstrapContainer()
        {
            log.Debug("Creating Container");
            WindsorContainer windosorContainer = new WindsorContainer();
            AppContext.Container = new WindsorContainerAdapter(windosorContainer);
            windosorContainer.Register(Component.For<IMiniContainer>().Instance(AppContext.Container));

            windosorContainer.Install(new HbmMapperInstaller());
            windosorContainer.Register(Component.For<IContextProvider>().ImplementedBy<WebContextProvider>());
            windosorContainer.Register(Component.For<AuditEventListener>());

            windosorContainer.Install(Castle.Windsor.Installer.Configuration.FromXmlFile("context.xml"));

            windosorContainer.Install(new BaseServiceInstaller(), new DaoInstaller(), new ServiceInstaller(), new ControllerInstaller());

            log.Debug("Create Custom Controller Factory");
            var controllerFactory = new CustomControllerFactory(AppContext.Container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);


        }

    }
}