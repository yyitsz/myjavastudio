using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class AndExpression : Expression
    {
        public override string Eval(IExpressionContext ctx)
        {
            if (lists.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            List<String> results = new List<string>();
            for (int i = 0; i < lists.Count; i++)
            {
                Expression ex = lists[i];
                string result = ex.Eval(ctx);
                if (result != null && result.Trim().Length > 0)
                {
                    results.Add(result);
                }
            }

            if (results.Count == 0)
            {
                return "";
            }
            for (int i = 0; i < results.Count; i++)
            {
                sb.Append("(");
                sb.Append(results[i]);
                sb.Append(") ");
                if (i != results.Count - 1)
                {
                    sb.Append(" AND ");
                }
            }

            return sb.ToString();
        }
    }
}
