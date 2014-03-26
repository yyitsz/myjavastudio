using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class LiteralExpression : Expression
    {

        public override string Eval(IExpressionContext ctx)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Expression ex in lists)
            {
                sb.Append(ex.Eval(ctx));
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
