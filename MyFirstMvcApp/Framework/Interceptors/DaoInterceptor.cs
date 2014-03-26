using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Facilities.NHibernateIntegration;
using Castle.DynamicProxy;
using Framework.Attributes;
using Framework.Utils;
using Framework.Executor;
using Framework.Dao;
using NHibernate;
using Framework.Transaction;
using Framework.Container;
using Castle.MicroKernel;
using Common.Logging;

namespace Framework.Interceptors
{
    public class DaoInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private static ILog log = LogManager.GetLogger<DaoInterceptor>();

        private IMiniContainer container;
        private IExecutor[] executors;
        private string sessionFactoryAlias;
        private IMemberAccessor accessor;
        public DaoInterceptor(IMiniContainer container,string sessionFactoryAlias)
        {
            this.container = container;
            this.sessionFactoryAlias = sessionFactoryAlias;
            this.executors = this.container.ResolveAll<IExecutor>();
            try
            {
                accessor = this.container.Resolve<IMemberAccessor>();
            }
            catch (Exception ex)
            {
                accessor = new ReflectionMemberAccessor();
                log.Warn("Please register IMemberAccessor. Using ReflectionMemberAccessor.",ex);
                
            }
        }

        public void Intercept(IInvocation invocation)
        {
            // Console.WriteLine("Calling " + invocation.Method.Name);

            if (invocation.Method.DeclaringType.IsGenericType
                && invocation.Method.DeclaringType.GetGenericTypeDefinition() == typeof(IBaseDao<,>))
            {
                Arguments arg = new Arguments();
                if (string.IsNullOrEmpty(this.sessionFactoryAlias) == false)
                {
                    arg.Add("sessionFactoryAlias",this.sessionFactoryAlias);
                }
                object target = container.Resolve(
                    typeof(IBaseDao<,>)
                        .MakeGenericType(invocation.Method.DeclaringType.GetGenericArguments())
                    ,arg);
                invocation.ReturnValue = accessor.InvokeMethod(target
                    , invocation.Method.Name
                    , ReflectionHelper.GetParameterTypes(invocation.Method)
                    , invocation.Arguments);

            }
            else
            {
                foreach (var executor in this.executors)
                {
                    if (executor.Support(invocation.Method))
                    {
                        ISessionManager sessionManager = this.container.Resolve<ISessionManager>();

                        ExecutorContext ctx = new ExecutorContext(container,invocation.Method,invocation.Arguments, sessionManager,this.sessionFactoryAlias);
                        invocation.ReturnValue = executor.Execute(ctx);
                        return;
                    }
                }
                throw new Exception(String.Format("{0} does not supported.", invocation.Method.Name));
            }


        }


    }
}
