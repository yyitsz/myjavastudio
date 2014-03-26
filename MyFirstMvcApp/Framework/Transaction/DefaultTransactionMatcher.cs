using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using System.Reflection;

namespace Framework.Transaction
{
    public class DefaultTransactionMatcher:ITransactionMatcher
    {
        private TransactionConfiguration txConfig;
        public DefaultTransactionMatcher(TransactionConfiguration txConfig)
        {
            this.txConfig = txConfig;
        }

        public bool Match(Type type)
        {
            String fullName = type.FullName;
            foreach (var name in this.txConfig.ClassDef)
            {
                if (name.EndsWith(".*") && name.Length > 2)
                {
                    if (fullName.StartsWith(name.Substring(0, name.Length - 2)))
                    {
                        return true;
                    }

                }
                else
                {
                    if (name == fullName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public TransactionAttribute Match(MethodInfo method)
        {
            TransactionAttribute result = null;
            string methodName = method.Name;
            foreach (var kv in this.txConfig.MethodDef)
            {
                if (kv.Item1 == "*")
                {
                    return kv.Item2;
                }


                if (kv.Item1.EndsWith("*"))
                {
                    if (methodName.StartsWith(kv.Item1.Substring(0, kv.Item1.Length - 1)))
                    {
                        return kv.Item2;
                    }

                }
                else
                {
                    if (kv.Item1 == methodName)
                    {
                        return kv.Item2;
                    }
                }
            }
            return result;
        }
    }
}
