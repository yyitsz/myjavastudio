using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Framework.Context
{
    public class CallDataContextProvider : IContextProvider
    {
        public T GetContext<T>(string key)
        {
            return (T)CallContext.GetData(key);
        }

        public T SetContext<T>(string key, T instance)
        {
            T oldValue = GetContext<T>(key);

            CallContext.SetData(key, instance);

            return oldValue;
        }
    }
}
