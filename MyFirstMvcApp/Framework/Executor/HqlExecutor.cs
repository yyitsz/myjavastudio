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
    public class HqlExecutor : AbstractExecutor
    {
        private static ILog log = LogManager.GetLogger<HqlExecutor>();

        //public override object Execute(ExecutorContext ctx)
        //{
        //    IStatelessSession statelessSession = null;
        //    ISession session = null;
        //    HqlAttribute attribute = ctx.daoAttribute as HqlAttribute;
        //    try
        //    {
        //        String hql = attribute.Sql;
        //        string countHql = null;

        //        if (attribute.IsDynamic)
        //        {
        //            hql = ParseSql(hql, ctx);

        //        }
        //        if (String.IsNullOrEmpty(attribute.Count) == false)
        //        {
        //            int formIndex = hql.IndexOf("from", StringComparison.OrdinalIgnoreCase);
        //            if (formIndex < 0)
        //            {
        //                throw new Exception("Illegal hql string. Cant found FROM when calculating total records.");
        //            }

        //            countHql = "SELECT COUNT(" + attribute.Count + ") " + hql.Substring(formIndex);
        //            log.InfoFormat("Count HQL:{0}", countHql);

        //        }

        //        hql += ctx.OrderSql;

        //        if (string.IsNullOrEmpty(countHql))
        //        {
        //            IQuery query = null;
        //            if (attribute.IsStateless)
        //            {
        //                statelessSession = ctx.GetStatelessSession();
        //                query = statelessSession.CreateQuery(hql);
        //            }
        //            else
        //            {
        //                session = ctx.GetSession();
        //                query = session.CreateQuery(hql);
        //            }
                    
        //            SetAllParameters(ctx, query);

        //            return ExecuteQuery(query, ctx, attribute.IsQuery);
        //        }
        //        else
        //        {
        //            Type entityType = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>),ctx.ResultType);
        //            if(entityType == null)
        //            {
        //                throw new Exception("The return type must be base on BaseSearchingResult<> type.");
        //            }

        //            IQuery query = null;
        //            IQuery countQuery = null;

        //            session = ctx.GetSession();
        //            query = session.CreateQuery(hql);
        //            countQuery = session.CreateQuery(countHql);

        //            SetCountSqlParameters(ctx, countQuery);
        //            SetAllParameters(ctx, query);

        //            //IMultiQuery mq = session.CreateMultiQuery();
        //            //mq.Add("count", countQuery);
        //            //mq.Add("result", query);

        //            //int count = 0;
        //            //IList countResult = (IList)mq.GetResult("count");
        //            //count = (int)countResult[0];
        //            //IList result = (IList)mq.GetResult("result");

        //            //using future

        //            IFutureValue<long> count = countQuery.FutureValue<long>();
        //            IEnumerable resultList =  query.Enumerable();
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

        //    }
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

        protected override IQuery CreateQuery(ExecutorContext ctx, ISession session, String sql)
        {
            return session.CreateQuery(sql);
        }

        protected override IQuery CreateQuery(ExecutorContext ctx, IStatelessSession session, String sql)
        {
            return session.CreateQuery(sql);
        }

        public override bool Support(MethodBase method)
        {
            return method.IsDefined(typeof(HqlAttribute), false);
        }
    }
}
