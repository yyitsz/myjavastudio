using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfOrm;
using System.Reflection;
using ConfOrm.Mappers;
using Framework.NHibernateExt;

namespace Framework.ConfOrmExt
{
    public class NullableEnumPropertyAsStringApplier : IPatternApplier<MemberInfo, IPropertyMapper>
    {
        public bool Match(MemberInfo subject)
        {
            if (subject == null)
            {
                return false;
            }
            var memberType = subject.GetPropertyOrFieldType();
            return memberType.IsEnumOrNullableEnum() && !memberType.IsFlagEnumOrNullableFlagEnum();
        }

        public void Apply(MemberInfo subject, IPropertyMapper applyTo)
        {
            var memberType = subject.GetPropertyOrFieldType();
            applyTo.Type(typeof(NullableEnumStringType<>).MakeGenericType(new[] { memberType }), null);
        }
    }
}
