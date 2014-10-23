using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    [Serializable]
    public abstract class BaseModel : IAuditable, IVersionable
    {
        public DateTime? CreateTime { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public long? VersionNo { get; set; }
        public abstract Object GetPK();
        public virtual bool IsNew()
        {
            return GetPK() == null;
        }

        public override bool Equals(object obj)
        {
            BaseModel x = this;
            BaseModel y = obj as BaseModel;

            if (x == y)
            {
                return true;
            }
            if (y == null)
            {
                return false;
            }
            if (x.GetPK() == null || y.GetPK() == null)
            {
                return x == y;
            }
            return x.GetPK().Equals(y.GetPK());
        }
        public override int GetHashCode()
        {
            Object pk = GetPK();
            if (pk == null)
            {
                return base.GetHashCode();
            }
            else 
            {
                return pk.GetHashCode();
            }
        }
    }

    public class ModelEqualityComparer<T> : IEqualityComparer<T> where T : BaseModel
    {

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (x.GetPK() == null || y.GetPK() == null)
            {
                return x == y;
            }
            return x.GetPK().Equals(y.GetPK());
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
