package org.yy.base.dao.dynamic2;

import java.util.ArrayList;
import java.util.List;


    public class AndExpression extends Expression
    {
        public  String Eval(ExpressionContext ctx)
        {
            if (lists.size() == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            List<String> results = new ArrayList<String>();
            for (int i = 0; i < lists.size(); i++)
            {
                Expression ex = lists.get(i);
                String result = ex.Eval(ctx);
                if (result != null && result.trim().length() > 0)
                {
                    results.add(result);
                }
            }

            if (results.size() == 0)
            {
                return "";
            }
            for (int i = 0; i < results.size(); i++)
            {
                sb.append("(");
                sb.append(results.get(i));
                sb.append(") ");
                if (i != results.size() - 1)
                {
                    sb.append(" AND ");
                }
            }

            return sb.toString();
        }
    }

