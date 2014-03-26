using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlParser
{
    public interface IExpressionContext
    {
        object GetValue(string condition);
    }
}
