using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Container;
using Common.Logging;

namespace Framework.Context
{
    public class AppContext
    {
        private static ILog log = LogManager.GetLogger<AppContext>();
        public static IMiniContainer Container
        {
            get;
            set;
        }
      
        public static UserContext UserCtx
        {
            get
            {
                if (Container == null)
                {
                    log.Warn("AppContext.Container is not initialized.");
                    return null;
                }
                IContextProvider ctxP = Container.Resolve<IContextProvider>();
                return ctxP.GetContext<UserContext>(UserContext.USER_CONTEXT_KEY);

            }
            set
            {
                if (Container == null)
                {
                    log.Warn("AppContext.Container is not initialized.");
                    return;
                }
                IContextProvider ctxP = Container.Resolve<IContextProvider>();
                ctxP.SetContext(UserContext.USER_CONTEXT_KEY, value);
            }
        }
    }
}
