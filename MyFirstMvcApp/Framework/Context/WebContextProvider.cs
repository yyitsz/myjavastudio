using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Context
{
    public class WebContextProvider : IContextProvider
    {
        public T GetContext<T>(string key)
        {
            return (T)HttpContext.Current.Items[key];
        }

        public T SetContext<T>(string key, T instance)
        {
            T old = GetContext<T>(key);
            HttpContext.Current.Items[key] = instance;
            return old;
        }
    }
}
