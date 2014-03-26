using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Framework.Attributes;
using Castle.Facilities.NHibernateIntegration;
using Framework.Utils;
using NHibernate;
using Framework.Container;
using Common.Logging;

namespace Framework.Executor
{
    public class ImplementorExecutor : IExecutor
    {
        private static ILog log = LogManager.GetLogger<ImplementorExecutor>();

        private IMemberAccessor accessor;
        private IMiniContainer container;
        public ImplementorExecutor(IMiniContainer container)
        {
            this.container = container;
            try
            {
                accessor = this.container.Resolve<IMemberAccessor>();
            }
            catch (Exception ex)
            {
                accessor = new ReflectionMemberAccessor();
                log.Warn("Please register IMemberAccessor. Now Using ReflectionMemberAccessor.", ex);

            }
        }
        public object Execute(ExecutorContext ctx)
        {
            ImplementedByAttribute attr = ctx.daoAttribute as ImplementedByAttribute;
            Type targetType = attr.ImplementedType;
            String methodName = attr.MethodName;

            if (string.IsNullOrEmpty(methodName))
            {
                methodName = ctx.CalledMethod.Name;
            }

            Object[] p = new object[ctx.InvocationParameters.Length + 1];

            for (int i = 0; i < ctx.InvocationParameters.Length; i++)
            {
                p[i + 1] = ctx.InvocationParameters[i];
            }

            Type[] paramTypes = new Type[ctx.InvocationParameterTypes.Length + 1];

            for (int i = 0; i < ctx.InvocationParameterTypes.Length; i++)
            {
                paramTypes[i + 1] = ctx.InvocationParameterTypes[i];
            }

            //Type[] genericTypes = null;
            //if (ctx.CalledMethod.IsGenericMethod)
            //{
 
            //}
            Object target = ctx.Container.Resolve(targetType);
            try
            {
                if (attr.IsStateless)
                {
                    using (IStatelessSession session = ctx.GetStatelessSession())
                    {
                        p[0] = session;
                        paramTypes[0] = typeof(IStatelessSession);
                        return accessor.InvokeMethod(target, methodName, paramTypes, p);
                    }
                }
                else
                {
                    using (ISession session = ctx.GetSession())
                    {
                        p[0] = session;
                        paramTypes[0] = typeof(IStatelessSession);
                        return accessor.InvokeMethod(target, methodName, paramTypes, p);
                    }
                }
            }
            finally
            {
                ctx.Container.Release(target);
            }

        }

        public bool Support(MethodBase method)
        {
            return method.IsDefined(typeof(ImplementedByAttribute), false);
        }
    }
}
