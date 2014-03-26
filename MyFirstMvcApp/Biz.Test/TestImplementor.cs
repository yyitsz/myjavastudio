using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biz.Model;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;
using Common.Logging;

namespace Biz.Test
{
    public class TestImplementor
    {
        private ILog log = LogManager.GetLogger<TestImplementor>();

        public static int count = 0;
        public TestImplementor()
        {
            count++;
            log.InfoFormat("TestImplementor 's called {0}", count);
        }
        public IList<Person> FindPagninationPersons(ISession session, int firstResult, int maxResults)
        {
           return session.CreateQuery("from Person").SetFirstResult(firstResult).SetMaxResults(maxResults).List<Person>();
        }

        public IList<Person> ThrowAnException(ISession session, int firstResult, int maxResults)
        {
            throw new Exception("haha, how do you do?");
         }
        
    }
}
