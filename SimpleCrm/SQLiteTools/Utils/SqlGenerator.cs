using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SimpleCrm.DynamicSql
{
    public class SqlGenerator
    {
        public static readonly Regex COUNT_REG = new Regex(@"@count\(([^\)]+)\)\s*{([^}]{1,})}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
        public static readonly Regex IF_REG = new Regex(@"@if\(([^\)]+)\)\s*{([^{}]*(((?<Open>{)[^{}]*)+((?<-Open>})[^{}]*)+)*(?(Open)(?!)))}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
        public static readonly Regex ORDER_REG = new Regex(@"@order\(\)\s*{([^}]{1,})}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);


        public Tuple<String, String> GenerateSql(String sql, object paramObj)
        {
            SqlExpression exp = new SqlExpression();
            exp.SqlStr = sql;
            Match match = COUNT_REG.Match(sql);
            if (match.Success)
            {
                if (match.Groups.Count != 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                CountExpression countExp = new CountExpression();
                countExp.CountSql = match.Groups[1].Value.Trim();
                countExp.Columns = match.Groups[2].Value.Trim();
                countExp.Index = match.Index;
                countExp.Length = match.Length;
                exp.CountExp = countExp;
            }

            match = ORDER_REG.Match(sql);
            if (match.Success)
            {
                if (match.Groups.Count != 2)
                {
                    throw new Exception("Wrong Order by expression.");
                }
                OrderByExpression orderbyExp = new OrderByExpression();
                orderbyExp.DefaultOrderBySql = match.Groups[1].Value.Trim();
                orderbyExp.Index = match.Index;
                orderbyExp.Length = match.Length;
                exp.OrderByExp = orderbyExp;
            }

            match = IF_REG.Match(sql);
            while (match.Success)
            {
                if (match.Groups.Count < 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                IfExpression ifExp = new IfExpression();
                ifExp.VarName = match.Groups[1].Value.Trim();
                ifExp.SqlStr = match.Groups[2].Value.Trim();
                ifExp.Index = match.Index;
                ifExp.Length = match.Length;
                exp.IfExpList.Add(ifExp);
                ParseChildIfExp(ifExp);
                match = match.NextMatch();
            }

            return exp.eval(paramObj);
        }

        private void ParseChildIfExp(IfExpression parentExp)
        {
            Match match = IF_REG.Match(parentExp.SqlStr);
            while (match.Success)
            {
                if (match.Groups.Count < 3)
                {
                    throw new Exception("Wrong Count expression.");
                }
                IfExpression ifExp = new IfExpression();
                ifExp.VarName = match.Groups[1].Value.Trim();
                ifExp.SqlStr = match.Groups[2].Value.Trim();
                ifExp.Index = match.Index;
                ifExp.Length = match.Length;
                parentExp.ChildrenIfExp.Add(ifExp);
                ParseChildIfExp(ifExp);
                match = match.NextMatch();
            }
        }
    }

    public class SqlExpression
    {
        public String SqlStr { get; set; }
        public CountExpression CountExp { get; set; }
        public List<IfExpression> IfExpList { get; set; }
        public OrderByExpression OrderByExp { get; set; }

        public SqlExpression()
        {
            IfExpList = new List<IfExpression>();
        }

        public Tuple<String, String> eval(object context)
        {
            String sql = SqlStr;
            if (OrderByExp != null)
            {
                sql = sql.Remove(OrderByExp.Index, OrderByExp.Length)
                            .Insert(OrderByExp.Index, OrderByExp.eval(context));
            }

            foreach (IfExpression ifExp in IfExpList)
            {
                String childSqlStr = ifExp.eval(context);
                sql = sql.Remove(ifExp.Index, ifExp.Length).Insert(ifExp.Index, childSqlStr);
            }
            String countSql = "";
            if (CountExp != null)
            {
                countSql = sql;
                sql = sql.Remove(CountExp.Index, CountExp.Length);

                countSql = sql.Insert(CountExp.Index, CountExp.EvalCountSql());
                sql = sql.Insert(CountExp.Index, CountExp.eval(context));
            }
            return Tuple.Create(sql, countSql);
        }
    }

    public abstract class BaseExpression
    {
        public int Index { get; set; }
        public int Length { get; set; }

        public abstract String eval(Object context);

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
        public override String eval(object context)
        {
            return " " + Columns + " ";
        }
    }
    public class OrderByExpression : BaseExpression
    {
        public String DefaultOrderBySql { get; set; }
        public override String eval(object context)
        {
            return DefaultOrderBySql;
        }

    }
    public class IfExpression : BaseExpression
    {
        public String VarName { get; set; }
        public String SqlStr { get; set; }

        public List<IfExpression> ChildrenIfExp { get; set; }

        public IfExpression()
        {
            ChildrenIfExp = new List<IfExpression>();
        }

        public override String eval(object context)
        {
            String varName = VarName;
            if (varName.StartsWith("$"))
            {
                varName = varName.Substring(1);
            }
            Object v = GetValue(context, varName);
            if (v != null)
            {
                if (v is Boolean && (Boolean)v == false)
                {
                    return "";
                }
                else
                {
                    String result = SqlStr;
                    foreach (IfExpression ifExp in ChildrenIfExp)
                    {
                        String childSqlStr = ifExp.eval(context);
                        result = result.Remove(ifExp.Index, ifExp.Length).Insert(ifExp.Index, childSqlStr);
                    }
                    return result;
                }
            }
            return "";
        }
    }
}
