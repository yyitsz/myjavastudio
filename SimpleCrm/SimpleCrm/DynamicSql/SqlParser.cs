using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SimpleCrm.DynamicSql
{
    public class SqlParser
    {
        public static readonly Regex COUNT_REG = new Regex(@"@count\(([^\)]+)\)\s*{([^}]{1,})}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
        public static readonly Regex IF_REG = new Regex(@"@if\(([^\)]+)\)\s*{([^{}]*(((?<Open>{)[^{}]*)+((?<-Open>})[^{}]*)+)*(?(Open)(?!)))}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
        public static readonly Regex ORDER_REG = new Regex(@"@order\(\)\s*{([^}]{1,})}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

        private static Dictionary<String, SqlExpression> cache = new Dictionary<string, SqlExpression>();

        public static Tuple<String, String> Eval(String sql, Object context)
        {
            SqlExpression exp;
            if (!cache.TryGetValue(sql, out exp))
            {
                exp = new SqlParser().Parse(sql);
                cache.Add(sql, exp);
            }

            return exp.Eval(context);
        }

        public SqlExpression Parse(String sql)
        {
            SqlExpression exp = new SqlExpression();
            exp.SqlStr = sql;
            int index = 0;
            Match match = COUNT_REG.Match(sql, index);

            if (match.Success)
            {
                if (match.Groups.Count != 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                if (match.Index != index)
                {
                    StringExpression stringExp = new StringExpression();
                    stringExp.value = sql.Substring(index, match.Index - index);
                    exp.ExpList.Add(stringExp);
                }
                CountExpression countExp = new CountExpression();
                countExp.CountSql = match.Groups[1].Value;
                countExp.Columns = match.Groups[2].Value;
                index = match.Index + match.Length;
                exp.ExpList.Add(countExp);
            }

            match = IF_REG.Match(sql, index);
            while (match.Success)
            {
                if (match.Groups.Count < 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                if (match.Index != index)
                {
                    StringExpression stringExp = new StringExpression();
                    stringExp.value = sql.Substring(index, match.Index - index);
                    exp.ExpList.Add(stringExp);
                }
                IfExpression ifExp = new IfExpression();
                ifExp.VarName = match.Groups[1].Value;
                String sqlStr = match.Groups[2].Value;
                exp.ExpList.Add(ifExp);
                ParseChildIfExp(ifExp, sqlStr);
                index = match.Index + match.Length;
                match = match.NextMatch();

            }

            match = ORDER_REG.Match(sql, index);
            if (match.Success)
            {
                if (match.Groups.Count != 2)
                {
                    throw new Exception("Wrong Order by expression.");
                }
                if (match.Index != index)
                {
                    StringExpression stringExp = new StringExpression();
                    stringExp.value = sql.Substring(index, match.Index - index);
                    exp.ExpList.Add(stringExp);
                }
                OrderByExpression orderbyExp = new OrderByExpression();
                orderbyExp.DefaultOrderBySql = match.Groups[1].Value;
                index = match.Index + match.Length;
                exp.ExpList.Add(orderbyExp);
            }
            if (index < sql.Length - 1)
            {
                StringExpression stringExp = new StringExpression();
                stringExp.value = sql.Substring(index);
                exp.ExpList.Add(stringExp);
            }
            return exp;
        }



        private void ParseChildIfExp(IfExpression parentExp, String parentSqlStr)
        {
            int index = 0;
            Match match = IF_REG.Match(parentSqlStr, index);

            while (match.Success)
            {
                if (match.Groups.Count < 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                if (match.Index != index)
                {
                    StringExpression stringExp = new StringExpression();
                    stringExp.value = parentSqlStr.Substring(index, match.Index - index);
                    parentExp.ChildrenExp.Add(stringExp);
                }
                IfExpression ifExp = new IfExpression();
                ifExp.VarName = match.Groups[1].Value;
                String sqlStr = match.Groups[2].Value;
                parentExp.ChildrenExp.Add(ifExp);
                ParseChildIfExp(ifExp, sqlStr);
                index = match.Index + match.Length;
                match = match.NextMatch();
            }

            if (index < parentSqlStr.Length - 1)
            {
                StringExpression stringExp = new StringExpression();
                stringExp.value = parentSqlStr.Substring(index);
                parentExp.ChildrenExp.Add(stringExp);
            }
        }
    }

    public class SqlExpression
    {
        public String SqlStr { get; set; }

        public List<BaseExpression> ExpList { get; set; }
        public SqlExpression()
        {
            ExpList = new List<BaseExpression>();
        }

        public Tuple<String, String> Eval(object context)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder countSql = new StringBuilder();
            Boolean hasCountSql = false;
            foreach (BaseExpression exp in ExpList)
            {
                String childSqlStr = exp.Eval(context);
                sb.Append(childSqlStr);
                if (exp is CountExpression)
                {
                    hasCountSql = true;
                    countSql.Append(((CountExpression)exp).EvalCountSql());
                }
                else
                {
                    countSql.Append(childSqlStr);
                }
            }
            if (hasCountSql)
            {
                return Tuple.Create(sb.ToString(), countSql.ToString());
            }
            else
            {
                return Tuple.Create(sb.ToString(), "");
            }

        }
    }

    public abstract class BaseExpression
    {
        public abstract String Eval(Object context);

        protected bool EvalConditionalExp(Object context, String varName)
        {
            Object val = GetValue(context, varName);
            if (val == null)
            {
                return false;
            }

            if (val is Boolean)
            {
                return (Boolean)val;
            }
            if (val is String)
            {
                return !String.IsNullOrEmpty((String)val);
            }
            return true;
        }

        protected Object GetValue(Object context, String varName)
        {
            if (context is IDictionary<String, Object>)
            {
                IDictionary<String, Object> dic = context as IDictionary<String, Object>;
                if (dic.ContainsKey(varName))
                {
                    return dic[varName];
                }
                return null;
            }
            else
            {
                PropertyInfo pi = context.GetType().GetProperty(varName);
                if (pi == null)
                {
                    return null;
                }
                return pi.GetValue(context, null);
            }
        }
    }

    public class StringExpression : BaseExpression
    {
        public String value { get; set; }
        public override String Eval(object context)
        {
            return value;
        }
    }

    public class CountExpression : BaseExpression
    {
        public String CountSql { get; set; }
        public String Columns { get; set; }

        public String EvalCountSql()
        {
            if (String.IsNullOrWhiteSpace(CountSql))
            {
                CountSql = "*";
            }

            return " COUNT(" + CountSql + ") ";

        }
        public override String Eval(object context)
        {
            return " " + Columns + " ";
        }
    }
    public class OrderByExpression : BaseExpression
    {
        public String DefaultOrderBySql { get; set; }
        public override String Eval(object context)
        {
            return DefaultOrderBySql;
        }

    }
    public class IfExpression : BaseExpression
    {
        public String VarName { get; set; }

        public List<BaseExpression> ChildrenExp { get; set; }

        public IfExpression()
        {
            ChildrenExp = new List<BaseExpression>();
        }

        public override String Eval(object context)
        {
            String varName = VarName;
            if (varName.StartsWith("$"))
            {
                varName = varName.Substring(1);
            }
            bool val = EvalConditionalExp(context, varName);
            if (val)
            {
                StringBuilder result = new StringBuilder();
                foreach (BaseExpression exp in ChildrenExp)
                {
                    String childSqlStr = exp.Eval(context);
                    result.Append(childSqlStr);
                }
                return result.ToString();

            }
            return "";
        }
    }
}
