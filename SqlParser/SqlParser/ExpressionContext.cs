using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class ExpressionContext : Dictionary<String, Object>, IExpressionContext
    {
        public object GetValue(string condition)
        {
            Object o = null;
            if (TryGetValue(condition, out o))
            {
                return o;
            }
            return null;
        }
    }
}
