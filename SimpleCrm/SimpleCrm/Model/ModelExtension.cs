using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq.Expressions;
using SimpleCrm.Model;
using SimpleCrm.Utils;
using System.Linq;

namespace SimpleCrm.Model
{
    public static class ModelExtension
    {       
        public static void NotifyPropertyChanged<T, TProperty>(this T model, Expression<Func<T, TProperty>> expression) where T : NotifyBaseModel
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                string propertyName = memberExpression.Member.Name;
                model.RaisePropertyChanged(propertyName);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static void MarkAsPersisted(this IEnumerable<NotifyBaseModel> models)
        {
            if (models == null)
            {
                return;
            }
            models.ForEach(p => p.MarkAsPersisted());
        }

        public static void MarkAsPersisted(this BaseModel model)
        {
            IChangeTracker tracker = model as IChangeTracker;
            if (tracker != null)
            {
                tracker.MarkAsPersisted();
            }
        }

        public static bool IsChanged(this IEnumerable<NotifyBaseModel> models)
        {
            if (models == null)
            {
                return false;
            }
            return models.Any(m => m.IsChanged());
        }
    }
}
