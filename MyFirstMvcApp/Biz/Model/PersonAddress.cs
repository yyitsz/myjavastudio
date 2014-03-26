using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Entity;

namespace Biz.Model
{
    //public abstract class EntityBase : BaseEntity<Int64>
    //{
    //    public virtual DateTime? CreatedTime { get; set; }
    //    public virtual DateTime? UpdatedTime { get; set; }
    //    public virtual String CreatedBy { get; set; }
    //    public virtual String UpdatedBy { get; set; }
    //    public virtual int VersionNo { get; set; }
    //}
    public class Person : CommonBaseEntity<long>
    {

        public virtual string Name { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual Decimal? Age { get; set; }
        public virtual Address Address { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual bool? IsMarried { get; set; }
    }

    public class Address : CommonBaseEntity<long>
    {
        //  public virtual int Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int CivicNumber { get; set; }
        public virtual Int64 PersonId { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
    }
}
