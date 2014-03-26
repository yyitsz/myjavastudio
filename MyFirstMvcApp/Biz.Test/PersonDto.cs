using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biz.Model;

namespace Biz.Test
{
    public class PersonDto
    {
        public virtual string Name { get; set; }
        public virtual Decimal? Age { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual bool? IsMarried { get; set; }
        public virtual string Street { get; set; }

        public PersonDto()
        {

        }

        public PersonDto(string name, decimal? age, Gender? gender, bool? isMarried, string street)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.IsMarried = isMarried;
            this.Street = street;
        }
    }
}
