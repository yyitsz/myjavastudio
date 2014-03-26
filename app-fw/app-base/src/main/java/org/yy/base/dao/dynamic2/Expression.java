package org.yy.base.dao.dynamic2;

import java.util.ArrayList;
import java.util.List;


    public abstract class Expression
    {
        protected List<Expression> lists = new ArrayList<Expression>();
        public void Append(Expression exp)
        {
            lists.add(exp);
        }
        public abstract String Eval(ExpressionContext ctx);
    }

