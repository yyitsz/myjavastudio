using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace Framework.Container
{
    public class WindsorContainerAdapter : IMiniContainer
    {
        object IMiniContainer.RawContainer
        {
            get { return this.WindsorContainer; }
        }

        public IWindsorContainer WindsorContainer { get; private set; }

        public WindsorContainerAdapter(IWindsorContainer windsorContainer)
        {
            if (windsorContainer == null)
            {
                throw new ArgumentNullException("windsorContainer");
            }

            this.WindsorContainer = windsorContainer;
        }
        public void Release(object instance)
        {
            this.WindsorContainer.Release(instance);
        }

        public T Resolve<T>()
        {
            return this.WindsorContainer.Resolve<T>();
        }

        public T Resolve<T>(System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.Resolve<T>(arguments);
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        public T Resolve<T>(string key)
        {
            return this.WindsorContainer.Resolve<T>(key);
        }

        public object Resolve(Type service)
        {
            return this.WindsorContainer.Resolve(service);
        }

        public object Resolve(string key, System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.Resolve(key,arguments);
        }

        public T Resolve<T>(string key, System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.Resolve<T>(key, arguments);
        }

        public object Resolve(string key, object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.Resolve(key, argumentsAsAnonymousType);
        }

        public T Resolve<T>(string key, object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.Resolve<T>(key, argumentsAsAnonymousType);
        }

        public object Resolve(string key, Type service)
        {
            return this.WindsorContainer.Resolve(key, service);
        }

        public object Resolve(Type service, System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.Resolve(service,arguments);
        }

        public object Resolve(Type service, object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.Resolve(service, argumentsAsAnonymousType);
        }

        public object Resolve(string key, Type service, System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.Resolve(key,  service, arguments);
        }

        public object Resolve(string key, Type service, object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.Resolve(key, service, argumentsAsAnonymousType);
        }

        public T[] ResolveAll<T>()
        {
            return this.WindsorContainer.ResolveAll<T>();
        }

        public T[] ResolveAll<T>(System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.ResolveAll<T>(arguments);
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.ResolveAll<T>(argumentsAsAnonymousType);
        }

        public Array ResolveAll(Type service)
        {
            return this.WindsorContainer.ResolveAll(service);
        }

        public Array ResolveAll(Type service, System.Collections.IDictionary arguments)
        {
            return this.WindsorContainer.ResolveAll(service, arguments);
        }

        public Array ResolveAll(Type service, object argumentsAsAnonymousType)
        {
            return this.WindsorContainer.ResolveAll(service, argumentsAsAnonymousType);
        }



        public void Dispose()
        {
            if (this.WindsorContainer != null)
            {
                this.WindsorContainer.Dispose();
                this.WindsorContainer = null;
            }
        }
    }
}
