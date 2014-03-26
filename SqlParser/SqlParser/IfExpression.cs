using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class IfExpression : Expression
    {
       

        private Expression defaultExp;

        public Expression DefaultExp
        {
            get { return defaultExp; }
            set { defaultExp = value; }
        }

        public override string Eval(IExpressionContext ctx)
        {
            if (lists.Count == 0)
            {
                return "";
            }

            string result = null;
            for (int i = 0; i < lists.Count; i++)
            {
                Expression ex = lists[i];
                result = ex.Eval(ctx);
                if (result != null)
                {
                    break;
                }
            }
            if (result == null && defaultExp != null)
            {
                result = defaultExp.Eval(ctx);
            }
            if (result == null)
            {
                result = "";
            }
            return result;
        }
    }
}
