using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ConfOrm.Mappers;
using Framework.NHibernateExt;
using NHibernate.Type;
using ConfOrm;
using Framework.Utils;

namespace Framework.ConfOrmExt
{
    public class BooleanPropertyAsCharApplier : IPatternApplier<MemberInfo, IPropertyMapper>
    {
        public bool Match(MemberInfo subject)
        {
            if (subject == null)
            {
                return false;
            }
            var memberType = subject.GetPropertyOrFieldType();
            return memberType.IsBoolOrNullableBool();
        }

        public void Apply(MemberInfo subject, IPropertyMapper applyTo)
        {
            var memberType = subject.GetPropertyOrFieldType();
            applyTo.Type(typeof(YesNoType), null);
        }
    }
}
