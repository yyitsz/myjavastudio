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
    public class SqlExecutor : AbstractExecutor
    {
        private static ILog log = LogManager.GetLogger<HqlExecutor>();

        //public override object Execute(ExecutorContext ctx)
        //{
        //    IStatelessSession statelessSession = null;
        //    ISession session = null;
        //    SqlAttribute attribute = ctx.daoAttribute as SqlAttribute;
        //    try
        //    {
        //        String sql = attribute.Sql;
        //        string countSql = null;

        //        if (attribute.IsDynamic)
        //        {
        //            sql = ParseSql(sql, ctx);

        //        }
        //        if (String.IsNullOrEmpty(attribute.Count) == false)
        //        {
        //            int formIndex = sql.IndexOf("from", StringComparison.OrdinalIgnoreCase);
        //            if (formIndex < 0)
        //            {
        //                throw new Exception("Illegal hql string. Cant found FROM when calculating total records.");
        //            }

        //            countSql = "SELECT COUNT(" + attribute.Count + ") " + sql.Substring(formIndex);
        //            log.InfoFormat("Count Native SQL:{0}", countSql);

        //        }

        //        sql += ctx.OrderSql;

        //        if (string.IsNullOrEmpty(countSql))
        //        {
        //            IQuery query = null;
        //            if (attribute.IsStateless)
        //            {
        //                statelessSession = ctx.GetStatelessSession();
        //                query = statelessSession.CreateSQLQuery(sql);
        //            }
        //            else
        //            {
        //                session = ctx.GetSession();
        //                query = session.CreateSQLQuery(sql);
        //            }

        //            SetAllParameters(ctx, query);

        //            return ExecuteQuery(query, ctx, attribute.IsQuery);
        //        }
        //        else
        //        {
        //            Type entityType = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), ctx.ResultType);
        //            if (entityType == null)
        //            {
        //                throw new Exception("The return type must be base on BaseSearchingResult<> type.");
        //            }

        //            IQuery query = null;
        //            IQuery countQuery = null;

        //            session = ctx.GetSession();
        //            query = session.CreateSQLQuery(sql);
        //            countQuery = session.CreateSQLQuery(countSql);

        //            SetCountSqlParameters(ctx, countQuery);
        //            SetAllParameters(ctx, query);

                 

        //            IFutureValue<long> count = countQuery.FutureValue<long>();
        //            IEnumerable resultList = query.Enumerable();
        //            object returnedResult = Activator.CreateInstance(ctx.ResultType);

        //            IList convertToList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(entityType));

        //            ReflectionHelper.SetValue(returnedResult, "TotalRecords", count.Value);

        //            foreach (var v in resultList)
        //            {
        //                convertToList.Add(v);
        //            }
        //            ReflectionHelper.SetValue(returnedResult, "Result", convertToList);
        //            return returnedResult;
        //        }
            
        //     }
        //    finally
        //    {
        //        if (session != null)
        //        {
        //            session.Dispose();
        //        }
        //        if (statelessSession != null)
        //        {
        //            statelessSession.Dispose();
        //        }
        //    }
        //}


        public override bool Support(MethodBase method)
        {
            return method.IsDefined(typeof(SqlAttribute), false);
        }

        protected override IQuery CreateQuery(ExecutorContext ctx,ISession session, String sql)
        {
            return session.CreateSQLQuery(sql);
        }

        protected override IQuery CreateQuery(ExecutorContext ctx, IStatelessSession session, String sql)
        {
            return session.CreateSQLQuery(sql);
        }
    }
}
