using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class ConditionalExpression : Expression
    {
        private string condition;

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }


        public Expression Exp
        {
            get
            {
                if (lists.Count > 0)
                {
                    return lists[0];
                }
                else
                {
                    return null;
                }
            }
            set {
                if (lists.Count > 0)
                {
                    lists[0] = value;
                }
                else
                {
                    lists.Add(value);
                }
            }
        }


        public override string Eval(IExpressionContext ctx)
        {
            if (Eval(ctx, condition))
            {
                return Exp.Eval(ctx);
            }
            return null;
        }

        private bool Eval(IExpressionContext ctx, string condition)
        {
            object o = ctx.GetValue(condition);
            if (o == null)
            {
                return false;
            }
            if (o.GetType() == typeof(bool))
            {
                return (bool)o;
            }
            return true;
        }
    }
}
