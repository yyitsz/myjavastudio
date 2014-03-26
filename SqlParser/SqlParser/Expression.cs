using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public abstract class Expression
    {
        protected List<Expression> lists = new List<Expression>();
        public void Append(Expression exp)
        {
            lists.Add(exp);
        }
        public abstract string Eval(IExpressionContext ctx);
    }
}
