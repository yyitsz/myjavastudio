using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper
{
    public class DateTimeHandler : Dapper.SqlMapper.ITypeHandler
    {
        public void SetValue(System.Data.IDbDataParameter parameter, object value)
        {
            parameter.Value = value;
            parameter.DbType = System.Data.DbType.DateTime;
        }

        public object Parse(Type destinationType, object value)
        {
            Type destType = Nullable.GetUnderlyingType(destinationType) ?? destinationType;
            if (value is DBNull || value == null) {
                if (destinationType == destType)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return null;
                }
            }
            return Convert.ChangeType(value, destType);
        }
    }
}
