using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Utils
{
    public interface IMemberAccessor
    {
        object InvokeMethod(object target, string methodName,Type[] parameterTypes, params object[] parameters);
        object InvokeMethod(object target, string methodName, Type[] genericeTypes, Type[] parameterTypes, params object[] parameters);
    }
}
