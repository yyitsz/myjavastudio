using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class WhereExpression : Expression
    {

        public WhereExpression()
        {
        }
        public override string Eval(IExpressionContext ctx)
        {
            if (this.lists.Count == 0 )
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            string result = this.lists[0].Eval(ctx);
            if (result != null && result.Trim().Length > 0)
            {
                sb.Append(" WHERE ");
                sb.Append(result);
            }

            return sb.ToString();
        }
    }
}
