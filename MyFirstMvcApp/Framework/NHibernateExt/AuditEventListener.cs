using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Event;
using Framework.Context;
using Framework.Entity;
using NHibernate.Persister.Entity;
using System.Linq.Expressions;

namespace Framework.NHibernateExt
{
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        IContextProvider ctxProvider;
        public AuditEventListener(IContextProvider ctxProvider)
        {
            this.ctxProvider = ctxProvider;
        }

        private UserContext GetUserCtx()
        {

            return ctxProvider.GetContext<UserContext>(UserContext.USER_CONTEXT_KEY);
        }
        public bool OnPreInsert(PreInsertEvent @event)
        {
           
            IAuditable entity = @event.Entity as IAuditable;

            if (entity != null)
            {
                UserContext userCtx = GetUserCtx();
                if (userCtx != null)
                {
                    string userId = userCtx.UserId;
                    entity.CreatedBy = userId;
                    entity.UpdatedBy = userId;
                    Set(@event.Persister, @event.State, e => e.CreatedBy, userId);
                    Set(@event.Persister, @event.State, e => e.UpdatedBy, userId);
                }

                DateTime now = DateTime.Now;
                entity.CreatedAt = now;
                entity.UpdatedAt = now;
                Set(@event.Persister, @event.State, e => e.CreatedAt, now);
                Set(@event.Persister, @event.State, e => e.UpdatedAt, now);
            }

            return false;
        }



        public bool OnPreUpdate(PreUpdateEvent @event)
        {      
            IAuditable entity = @event.Entity as IAuditable;
 
            if (entity != null)
            {
                UserContext userCtx = GetUserCtx();
                if (userCtx != null)
                {
                    string userId = userCtx.UserId;
                    entity.UpdatedBy = userId;
                    Set(@event.Persister, @event.State, e => e.UpdatedBy, userId);
                }

                DateTime now = DateTime.Now;
                entity.UpdatedAt = now;
                Set(@event.Persister, @event.State, e => e.UpdatedAt, now);
            }

            return false;
        }

        private void Set(IEntityPersister persister, object[] state, Expression<Func<IAuditable, Object>> exp, object value)
        {

            string propertName = null;
            if (exp.Body is MemberExpression)
            {
               propertName = (exp.Body as MemberExpression).Member.Name;
            }
            else if (exp.Body is System.Linq.Expressions.UnaryExpression)
            {
                propertName = (((exp.Body as System.Linq.Expressions.UnaryExpression).Operand) as MemberExpression).Member.Name;
            }
            int index = Array.IndexOf(persister.PropertyNames, propertName);
            state[index] = value;
        }
    }
}
