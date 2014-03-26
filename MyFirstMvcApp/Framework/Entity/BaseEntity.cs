using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    [Serializable]
    public abstract class BaseEntity<TId> : IEntity
    {
        public virtual TId Id { get; set; }
        
    }
    [Serializable]
    public abstract class AuditableBaseEntity<TId> : BaseEntity<TId>, IAuditable
    {
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual String CreatedBy { get; set; }
        public virtual String UpdatedBy { get; set; }

    }
    [Serializable]
    public abstract class VersionableBaseEntity<TId> : BaseEntity<TId>, IVersionable
    {
        public virtual int VersionNo { get; set; }
    }
    [Serializable]
    public abstract class CommonBaseEntity<TId> : AuditableBaseEntity<TId>, IVersionable
    {
        public virtual int VersionNo { get; set; }
    }
}
