using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biz.Model;
using Framework.Dao;
using Framework.Attributes;
using Castle.Services.Transaction;
using Framework.Entity;
using NHibernate.Transform;

namespace Biz.Test
{
    //[Transactional]
    public interface IPersonDao : IBaseDao<Person, long>
    {
        [Hql("from Person")]
        [Transaction]
        IList<Person> FindAllPersons();



        [Hql("from Person")]
        IList<Person> FindAllPersons([FirstResult]int firstResult, [MaxResults]int maxResults);

        [Hql("from Person p where p.Id=:id")]
        [Transaction]
        Person FindPerson(long id);

        [ImplementedBy(typeof(TestImplementor))]
        IList<Person> FindPagninationPersons(int firstResult, int maxResults);

        [Hql("from Person p where p.Name=:name")]
        IList<Person> GetByName(string name);

        [Hql(
@"from Person p 
@where {
  @and{
        @if(name){p.Name=:name},
        @if(isMarried){p.IsMarried =:isMarried}
  }
}
"
            , IsDynamic = true)]
        IList<Person> SearchPersons(string name, bool? isMarried);

        [Hql(
        @"from Person p 
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
"
                    , IsDynamic = true)]
        IList<Person> SearchPersons(SearchingPerson criteria);

        [Hql(
        @"SELECT p.Name as Name, p.Age as Age, p.IsMarried as IsMarried, p.Gender as Gender, a.Street as Street from Person p LEFT JOIN p.Address a
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
", IsDynamic = true)]
        [PropertyTransformerAttribute]
        IList<PersonDto> SearchPersonDto(SearchingPerson criteria);

        [Hql(
       @"SELECT p.Name as Name, p.Age as Age, p.Gender as Gender, p.IsMarried as IsMarried, a.Street as Street from Person p LEFT JOIN p.Address a
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
", IsDynamic = true)]
        [PropertyTransformer]
        IList<PersonDto> SearchPersonDto2(SearchingPerson criteria);

        //        [Hql(
        //      @"SELECT new PersonDto(p.Name as Name, p.Age as Age, p.Gender as Gender, p.IsMarried as IsMarried, a.Street as Street) from Person p LEFT JOIN p.Address a
        //@where {
        //  @and{
        //        @if(Name){p.Name=:Name},
        //        @if(IsMarried){p.IsMarried =:IsMarried},
        //        @if(Birthday){p.Birthday = :Birthday},
        //        @if(Age){p.Age=:Age},
        //        @if(Gender){p.Gender=:Gender}
        //  }
        //}
        //", IsDynamic = true)]
        //        //[TransformerAttribute(typeof(AliasToBeanConstructorResultTransformer))]
        //        IList<PersonDto> SearchPersonDto4(SearchingPerson criteria);

        [Hql(
  @"SELECT p.Name , p.Age , p.Gender , p.IsMarried, a.Street as Street from Person p LEFT JOIN p.Address a
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
", IsDynamic = true)]
        [ConstructorTransformerAttribute(typeof(string), typeof(decimal?), typeof(Gender?), typeof(bool?), typeof(string))]
        IList<PersonDto> SearchPersonDto3(SearchingPerson criteria);

        [Hql(
        @"SELECT p.Name as Name, p.Age as Age, p.IsMarried as IsMarried, p.Gender as Gender, a.Street as Street from Person p LEFT JOIN p.Address a
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
", IsDynamic = true, Count = "p.id")]
        [PropertyTransformer]
        BaseSearchingResult<PersonDto> SearchPersonDtoWithCounting(SearchingPerson criteria);

        [Hql(
       @"SELECT p.Name as Name, p.Age as Age, p.IsMarried as IsMarried, p.Gender as Gender, a.Street as Street from Person p LEFT JOIN p.Address a
@where {
  @and{
        @if(Name){p.Name=:Name},
        @if(IsMarried){p.IsMarried =:IsMarried},
        @if(Birthday){p.Birthday = :Birthday},
        @if(Age){p.Age=:Age},
        @if(Gender){p.Gender=:Gender}
  }
}
", IsDynamic = true, Count = "p.id")]
        [PropertyTransformer]
        BaseSearchingResult<PersonDto> SearchPersonDtoWithCountingAndOrder(SearchingPerson criteria);
    }

    public class SearchingPerson : BaseSearchingEntity
    {
        public virtual string Name { get; set; }
        public virtual DateTime? Birthday { get; set; }
        public virtual Decimal? Age { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual bool? IsMarried { get; set; }
    }
}
