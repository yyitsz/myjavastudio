using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Castle.MicroKernel;
using System.Web.Routing;
using Framework.Container;

namespace Framework
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly IMiniContainer container;

        public CustomControllerFactory(IMiniContainer container)
        {
            this.container = container;
        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var name = controllerName + "controller";
            return container.Resolve<IController>(name);
        }
    }
}
