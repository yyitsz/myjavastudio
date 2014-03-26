using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Entity;

namespace NHMembershipProvider.Entities
{
    public class Profile : AuditableBaseEntity<int>
    {
       // public virtual int Id { get;  private set; }
        public virtual int UserId { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual bool IsAnonymous { get;  set; }
        public virtual DateTime LastActivityDate { get; set; }
        public virtual DateTime LastUpdatedDate { get; set; }
        public virtual string Subscription { get; set; }
        public virtual string Language { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Occupation { get; set; }
        public virtual string Website { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Country { get; set; }

        public Profile()
        {
            LastActivityDate = Utils.MinDate();
            LastUpdatedDate = Utils.MinDate();
            BirthDate = Utils.MinDate();  
        }
    }


}
