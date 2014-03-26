using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;
using Framework.Container;

namespace Framework
{
    public sealed class ContainerHelper
    {
        public static IMiniContainer Container
        {
            get;
            set;
        }

        public static ISession OpenSession(string alias)
        {
            ISessionManager sessionManager = Container.Resolve<ISessionManager>();
            ISession session = null;

            if (string.IsNullOrEmpty(alias))
            {
                session = sessionManager.OpenSession();
            }
            else
            {
                session = sessionManager.OpenSession(alias);
            }
            return session;
        }
    }
}
