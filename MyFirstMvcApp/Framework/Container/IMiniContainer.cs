using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Framework.Container
{
    public interface IMiniContainer : IDisposable
    {
        object RawContainer { get; }
        //
        // Summary:
        //     Releases a component instance
        //
        // Parameters:
        //   instance:
        void Release(object instance);

        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The component instance
        T Resolve<T>();
        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Parameters:
        //   arguments:
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The component instance
        T Resolve<T>(IDictionary arguments);
        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Parameters:
        //   argumentsAsAnonymousType:
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The component instance
        T Resolve<T>(object argumentsAsAnonymousType);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //     Component's key
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The Component instance
        T Resolve<T>(string key);
        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Parameters:
        //   service:
        object Resolve(Type service);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //
        //   arguments:
        object Resolve(string key, IDictionary arguments);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //     Component's key
        //
        //   arguments:
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The Component instance
        T Resolve<T>(string key, IDictionary arguments);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //
        //   argumentsAsAnonymousType:
        object Resolve(string key, object argumentsAsAnonymousType);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //     Component's key
        //
        //   argumentsAsAnonymousType:
        //
        // Type parameters:
        //   T:
        //     Service type
        //
        // Returns:
        //     The Component instance
        T Resolve<T>(string key, object argumentsAsAnonymousType);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //
        //   service:
        object Resolve(string key, Type service);
        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Parameters:
        //   service:
        //
        //   arguments:
        object Resolve(Type service, IDictionary arguments);
        //
        // Summary:
        //     Returns a component instance by the service
        //
        // Parameters:
        //   service:
        //
        //   argumentsAsAnonymousType:
        object Resolve(Type service, object argumentsAsAnonymousType);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //
        //   service:
        //
        //   arguments:
        object Resolve(string key, Type service, IDictionary arguments);
        //
        // Summary:
        //     Returns a component instance by the key
        //
        // Parameters:
        //   key:
        //
        //   service:
        //
        //   argumentsAsAnonymousType:
        object Resolve(string key, Type service, object argumentsAsAnonymousType);
        //
        // Summary:
        //     Resolve all valid components that match this type.
        //
        // Type parameters:
        //   T:
        //     The service type
        T[] ResolveAll<T>();
        //
        // Summary:
        //     Resolve all valid components that match this type.  The service type Arguments
        //     to resolve the service
        //
        // Parameters:
        //   arguments:
        //     Arguments to resolve the service
        //
        // Type parameters:
        //   T:
        //     The service type
        T[] ResolveAll<T>(IDictionary arguments);
        //
        // Summary:
        //     Resolve all valid components that match this type.  The service type Arguments
        //     to resolve the service
        //
        // Parameters:
        //   argumentsAsAnonymousType:
        //     Arguments to resolve the service
        //
        // Type parameters:
        //   T:
        //     The service type
        T[] ResolveAll<T>(object argumentsAsAnonymousType);
        //
        // Summary:
        //     Resolve all valid components that match this service the service to match
        //
        // Parameters:
        //   service:
        //     the service to match
        Array ResolveAll(Type service);
        //
        // Summary:
        //     Resolve all valid components that match this service the service to match
        //     Arguments to resolve the service
        //
        // Parameters:
        //   service:
        //     the service to match
        //
        //   arguments:
        //     Arguments to resolve the service
        Array ResolveAll(Type service, IDictionary arguments);
        //
        // Summary:
        //     Resolve all valid components that match this service the service to match
        //     Arguments to resolve the service
        //
        // Parameters:
        //   service:
        //     the service to match
        //
        //   argumentsAsAnonymousType:
        //     Arguments to resolve the service
        Array ResolveAll(Type service, object argumentsAsAnonymousType);
    }
}
