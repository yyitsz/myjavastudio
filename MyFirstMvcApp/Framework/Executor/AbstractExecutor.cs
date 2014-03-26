using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;
using System.Collections;
using NHibernate.Mapping;
using System.Reflection;
using Framework.Utils;
using Framework.Attributes;
using Common.Logging;
using Framework.Entity;

namespace Framework.Executor
{
    public abstract class AbstractExecutor : IExecutor
    {
        private static ILog log = LogManager.GetLogger<AbstractExecutor>();

        protected string ParseSql(string sql, ExecutorContext ctx)
        {
            SqlParser.Parser parser = new SqlParser.Parser(sql);
            SqlParser.Expression exp = parser.Parse();

            SqlParser.ObjectExpressionContext expCtx = new SqlParser.ObjectExpressionContext(ctx.ParameterObject);
            foreach (var kv in ctx.Parameters)
            {
                expCtx.Add(kv.Key, kv.Value);
            }

            string result = exp.Eval(expCtx);
            log.DebugFormat("SQL:{0}", result);
            return result;

        }
        public virtual object Execute(ExecutorContext ctx)
        {
            IStatelessSession statelessSession = null;
            ISession session = null;
            SqlBaseDaoAttribute attribute = ctx.daoAttribute as SqlBaseDaoAttribute;
            try
            {
                String sql = attribute.Sql;
                string countSql = null;

                if (attribute.IsDynamic)
                {
                    sql = ParseSql(sql, ctx);

                }
                if (String.IsNullOrEmpty(attribute.Count) == false)
                {
                    int formIndex = sql.IndexOf("from", StringComparison.OrdinalIgnoreCase);
                    if (formIndex < 0)
                    {
                        throw new Exception("Illegal hql string. Cant found FROM when calculating total records.");
                    }

                    countSql = "SELECT COUNT(" + attribute.Count + ") " + sql.Substring(formIndex);
                    log.InfoFormat("Count HQL:{0}", countSql);

                }

                sql += ctx.OrderSql;

                if (string.IsNullOrEmpty(countSql))
                {
                    IQuery query = null;
                    if (attribute.IsStateless)
                    {
                        statelessSession = ctx.GetStatelessSession();
                        query = CreateQuery(ctx, statelessSession, sql);
                    }
                    else
                    {
                        session = ctx.GetSession();
                        query = CreateQuery(ctx,session, sql);
                    }

                    SetAllParameters(ctx, query);

                    return ExecuteQuery(query, ctx, attribute.IsQuery);
                }
                else
                {
                    Type entityType = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), ctx.ResultType);
                    if (entityType == null)
                    {
                        throw new Exception("The return type must be base on BaseSearchingResult<> type.");
                    }

                    IQuery query = null;
                    IQuery countQuery = null;

                    session = ctx.GetSession();
                    query = CreateQuery(ctx, session, sql);
                    countQuery = CreateQuery(ctx, session, countSql); ;

                    SetCountSqlParameters(ctx, countQuery);
                    SetAllParameters(ctx, query);

                 

                    IFutureValue<long> count = countQuery.FutureValue<long>();
                    IEnumerable resultList = query.Enumerable();
                    object returnedResult = Activator.CreateInstance(ctx.ResultType);

                    IList convertToList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(entityType));

                    ReflectionHelper.SetValue(returnedResult, "TotalRecords", count.Value);

                    foreach (var v in resultList)
                    {
                        convertToList.Add(v);
                    }
                    ReflectionHelper.SetValue(returnedResult, "Result", convertToList);
                    return returnedResult;
                }

            }
            finally
            {
                if (session != null)
                {
                    session.Dispose();
                }
                if (statelessSession != null)
                {
                    statelessSession.Dispose();
                }
            }
        }

      
        

        protected void SetCountSqlParameters(ExecutorContext ctx, IQuery query)
        {
            if (ctx.ParameterObject != null)
            {
                query.SetProperties(ctx.ParameterObject);
            }

            foreach (var item in query.NamedParameters)
            {
                object value = null;
                if (ctx.Parameters.TryGetValue(item, out value))
                {
                    query.SetParameter(item, value);
                }

            }
 
        }
        protected void SetAllParameters(ExecutorContext ctx, IQuery query)
        {
            if (ctx.ParameterObject != null)
            {
                query.SetProperties(ctx.ParameterObject);
            }

            foreach (var item in query.NamedParameters)
            {
                object value = null;
                if (ctx.Parameters.TryGetValue(item, out value))
                {
                    query.SetParameter(item, value);
                }
               
            }
            if (ctx.ResultTransformer != null)
            {
                query.SetResultTransformer(ctx.ResultTransformer);
            }
            if (ctx.FetchSize > 0)
            {
                query.SetFetchSize(ctx.FetchSize);
            }
            if (ctx.FetchMode != null)
            {
                query.SetFlushMode(ctx.FetchMode.Value);
            }
            if (ctx.FirstResult >= 0 && ctx.MaxResults > 0)
            {
                query.SetFirstResult(ctx.FirstResult);
                query.SetMaxResults(ctx.MaxResults);
            }
            query.SetReadOnly(ctx.IsReadonly);
            foreach (var item in ctx.LockModes)
            {
                query.SetLockMode(item.Key, item.Value);
            }

        }

        protected object ExecuteQuery(IQuery query, ExecutorContext ctx, bool isQuery)
        {
            if (isQuery == false || ctx.ResultType == null)
            {
                return query.ExecuteUpdate();
            }
            if (ctx.ResultType.IsGenericType)
            {
                if (ctx.ResultType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    return ReflectionHelper.InvokeGenericeMethod(query, "List", new Type[] { ctx.ResultType.GetGenericArguments()[0] });
                }
                else if (ctx.ResultType.GetGenericTypeDefinition() == typeof(IFutureValue<>))
                {
                    return ReflectionHelper.InvokeGenericeMethod(query, "FutureValue", new Type[] { ctx.ResultType.GetGenericArguments()[0] });
                }
                else if (ctx.ResultType.GetGenericTypeDefinition() == typeof(IEnumerable<>) && ctx.GetCalledMethodName() == ExecutorContext.ENUMERATE)
                {
                    return ReflectionHelper.InvokeGenericeMethod(query, "Enumerable", new Type[] { ctx.ResultType.GetGenericArguments()[0] });
                }
                else if (ctx.ResultType.GetGenericTypeDefinition() == typeof(IEnumerable<>) && ctx.GetCalledMethodName() == ExecutorContext.FUTURE)
                {
                    return ReflectionHelper.InvokeGenericeMethod(query, "Future", new Type[] { ctx.ResultType.GetGenericArguments()[0] });
                }

                throw new NotSupportedException("Executor does not support type " + ctx.ResultType.Name);
            }
            else
            {
                if (ctx.ResultType == typeof(IList))
                {
                    return query.List();
                }
                if (ctx.ResultType == typeof(IEnumerable))
                {
                    return query.Enumerable();
                }
                else if (ctx.ResultType.IsGenericParameter)
                {
                    return ReflectionHelper.InvokeGenericeMethod(query, "UniqueResult", new Type[] { ctx.ResultType });
                }
                else
                {
                    return query.UniqueResult();
                }

                throw new NotSupportedException("HsqlExecutor does not support type " + ctx.ResultType.Name);
            }
        }

        public abstract bool Support(MethodBase method);

        protected abstract IQuery CreateQuery(ExecutorContext ctx, ISession session, String sql);

        protected abstract IQuery CreateQuery(ExecutorContext ctx, IStatelessSession session, String sql);

    }
}
