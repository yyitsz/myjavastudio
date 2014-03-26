using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class StringExpression : Expression
    {
        String s;
        public StringExpression(string s)
        {
            this.s = s; 
        }

        public override string Eval(IExpressionContext ctx)
        {
            return s;
        }
    }
}
