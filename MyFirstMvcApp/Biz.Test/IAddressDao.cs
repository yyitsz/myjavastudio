using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biz.Model;
using Framework.Dao;
using Framework.Attributes;
using Castle.Services.Transaction;

namespace Biz.Test
{
    public interface IAddressDao : IBaseDao<Address,long>
    {
        
        [ImplementedBy(typeof(TestImplementor))]
        IList<Person> ThrowAnException(int firstResult,int maxResults);
    }
}
