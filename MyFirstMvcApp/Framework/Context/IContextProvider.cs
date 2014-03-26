using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Context
{
    public interface IContextProvider
    {
        T GetContext<T>(string key);
        T SetContext<T>(string key, T instance);
    }
}
