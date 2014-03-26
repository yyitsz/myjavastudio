using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfOrm;
using ConfOrm.NH;
using Biz.Model;
using NUnit.Framework;
using Biz.Extensions;
using NHibernate.Tool.hbm2ddl;
using Castle.DynamicProxy;

namespace Biz.Test
{
    [TestFixture]
    public class Test2
    {
  
        [NUnit.Framework.Test]
        [Ignore]
        public void TestProxyWihoutTarget()
        {
             Proxy.Wrap<IFoo>().Bar("abcf");

        }
    
    }

    public interface IFoo
    {
        void Bar(string s);
    }
    public class Proxy
    {
        static ProxyGenerator _proxyGenerator = new ProxyGenerator();

        public static T Wrap<T>() where T:class
        {
            return _proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(new PrintIntercepter());

        }
    }

    public class PrintIntercepter : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Call "+ invocation.Method.Name);
        }
    }
}
