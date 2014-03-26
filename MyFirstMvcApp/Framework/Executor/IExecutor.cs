using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework.Executor
{
    public interface IExecutor
    {
        bool Support(MethodBase method);
        object Execute(ExecutorContext ctx);
    }
}
