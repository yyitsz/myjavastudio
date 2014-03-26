using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using System.Reflection;

namespace Framework.Transaction
{
    public interface ITransactionMatcher
    {
        bool Match(Type type);
        TransactionAttribute Match(MethodInfo method);
    }
}
