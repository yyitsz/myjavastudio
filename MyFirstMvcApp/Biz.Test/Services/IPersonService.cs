using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Attributes;
using Biz.Model;
using Framework.Entity;

namespace Biz.Test.Services
{
    public interface IPersonService
    {

        int DeleteAll();

        IList<Person> FindAllPersons();

        void Save(Person p);
       
        //IList<Person> FindAllPersons(int firstResult,int maxResults);
     
        //Person FindPerson(long id);

      
        //IList<Person> FindPagninationPersons(int firstResult, int maxResults);

      
        //IList<Person> GetByName(string name);

     
        //IList<Person> SearchPersons(string name, bool? isMarried);

      
        //IList<Person> SearchPersons(SearchingPerson criteria);

      
        //IList<PersonDto> SearchPersonDto(SearchingPerson criteria);

      
        //BaseSearchingResult<PersonDto> SearchPersonDtoWithCounting(SearchingPerson criteria);
    }
}
