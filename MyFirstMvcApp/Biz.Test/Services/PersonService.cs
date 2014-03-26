using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz.Test.Services
{
    public class PersonService : IPersonService
    {
        IPersonDao dao;
        public PersonService(IPersonDao dao)
        {
            this.dao = dao;
        }

        public int DeleteAll()
        {
            return dao.DeleteAll();
        }

        public IList<Model.Person> FindAllPersons()
        {
            return dao.FindAllPersons();
        }

        public void Save(Model.Person p)
        {
            if (p.Id == 0)
            {
                dao.Create(p);
            }
            else
            {
                dao.Merge(p);
            }
        }
    }
}
