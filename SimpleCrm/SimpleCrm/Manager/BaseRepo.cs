using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using SimpleCrm.Model;
using SimpleCrm.Common;
using System.Linq;

namespace SimpleCrm.Manager
{
    [Serializable]
    public class BaseRepo
    {
        public IDbConnection Connection { get; protected set; }
    }

    public class BaseRepo<Tm, Tk> : BaseRepo where Tm : BaseModel
    {

        public virtual int Create(Tm entity)
        {
            int c = Connection.Insert(entity);
            IChangeTracker tracker = entity as IChangeTracker;
            entity.MarkAsPersisted();
            return c;
        }

        public virtual int Update(Tm entity)
        {
            IChangeTracker tracker = entity as IChangeTracker;

            int c = 0;
            if (tracker == null || tracker.IsUpdated())
            {
                c = Connection.Update(entity);
            }

            entity.MarkAsPersisted();
            return c;
        }

        public virtual int Delete(Tm entity)
        {
            return Connection.Delete(entity);
        }

        public virtual Tm FindOne(Tk id)
        {
            Tm entity = Connection.Get<Tm>(id);
            IChangeTracker tracker = entity as IChangeTracker;
            entity.MarkAsPersisted();
            return entity;
        }

        public virtual int Count(object whereObj)
        {
            return Connection.Count<Tm>(whereObj);
        }

        public virtual void SaveBatch(IEnumerable<Tm> list)
        {
            foreach (Tm var in list)
            {
                Save(var);
            }
        }


        public virtual void DeleteBatch(IEnumerable<Tm> list)
        {
            foreach (Tm var in list)
            {
                Delete(var);
            }
        }

        public virtual int Save(Tm var)
        {
            if (var.IsNew())
            {
                ValidateExists(var);
                return this.Create(var);
            }
            else
            {
                return this.Update(var);
            }

        }

        protected virtual void ValidateExists(Tm var)
        {
            return;
        }

        public void SaveBatch(IEnumerable<Tm> exists, IEnumerable<Tm> saving, Action<Tm, Tm> copyFunc = null, Func<Tm, Tm, bool> equalFunc = null)
        {
            List<Tm> inserting = new List<Tm>();
            List<Tm> updating = new List<Tm>();
            List<Tm> deleting = new List<Tm>();

            Clastify(exists, saving, inserting, updating, deleting, copyFunc, equalFunc);
            deleting.ForEach(m => Delete(m));
            updating.ForEach(m => Update(m));
            inserting.ForEach(m => Create(m));
        }

        protected void Clastify(IEnumerable<Tm> exists, IEnumerable<Tm> saving, List<Tm> inserting, List<Tm> updating, List<Tm> deleting, Action<Tm, Tm> copyFunc = null, Func<Tm, Tm, bool> equalFunc = null)
        {
            if (equalFunc == null)
            {
                equalFunc = (t1, t2) => t1.GetPK().Equals(t2.GetPK());
            }
            foreach (var save in saving)
            {
                Tm existTm = default(Tm);
                foreach (var exist in exists)
                {
                    if (equalFunc(exist, save))
                    {
                        existTm = exist;
                        break;
                    }
                }
                if (existTm == default(Tm))
                {
                    inserting.Add(save);
                }
                else
                {
                    if (copyFunc != null)
                    {
                        copyFunc(existTm, save);
                        updating.Add(existTm);
                    }
                    else
                    {
                        updating.Add(save);
                    }
                }

            }

            foreach (var exist in exists)
            {
                bool found = false;
                foreach (var save in saving)
                {
                    if (equalFunc(exist, save))
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    deleting.Add(exist);
                }
            }
        }

        protected Tuple<string, object> BuildCollectionSql(string field, IEnumerable<Object> collection)
        {
            StringBuilder sb = new StringBuilder();
            _InFieldParam param = new _InFieldParam();
            sb.Append(field)
                .Append(" in (");
            int total = collection.Count();
            Type type = param.GetType();
            for (int i = 0; i < total; i++)
            {
                String propertyName = "_InField_" + i;
                sb.Append("@")
                    .Append(propertyName);
                if (i < total - 1)
                {
                    sb.Append(", ");
                }
                type.GetProperty(propertyName).SetValue(param, collection.ElementAt(i), null);

            }
            sb.Append(")");
            return Tuple.Create(sb.ToString(), (Object)param);
        }
    }

    public class _InFieldParam
    {
        public object _InField_0 { get; set; }
        public object _InField_1 { get; set; }
        public object _InField_2 { get; set; }
        public object _InField_3 { get; set; }
        public object _InField_4 { get; set; }
        public object _InField_5 { get; set; }
        public object _InField_6 { get; set; }
        public object _InField_7 { get; set; }
        public object _InField_8 { get; set; }
        public object _InField_9 { get; set; }
        public object _InField_10 { get; set; }
        public object _InField_11 { get; set; }
        public object _InField_12 { get; set; }
        public object _InField_13 { get; set; }
        public object _InField_14 { get; set; }
        public object _InField_15 { get; set; }
        public object _InField_16 { get; set; }
        public object _InField_17 { get; set; }
        public object _InField_18 { get; set; }
        public object _InField_19 { get; set; }
        public object _InField_20 { get; set; }
        public object _InField_21 { get; set; }
        public object _InField_22 { get; set; }
        public object _InField_23 { get; set; }
        public object _InField_24 { get; set; }
        public object _InField_25 { get; set; }
    }
}
