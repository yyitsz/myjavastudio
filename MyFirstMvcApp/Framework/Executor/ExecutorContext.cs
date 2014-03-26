using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;
using System.Reflection;
using Framework.Attributes;
using Framework.Utils;
using Framework.Entity;
using Framework.Container;
using NHibernate.Transform;
using System.Collections;

namespace Framework.Executor
{
    public class ExecutorContext
    {
        public static readonly string FUTURE = "Futrue";
        public static readonly string ENUMERATE = "Enumerate";
        public static readonly string LIST = "List";


        public int FirstResult { get; private set; }
        public int MaxResults { get; private set; }
        public bool IsReadonly { get; set; }
        public IDictionary<String, Object> Parameters { get; private set; }
        public IDictionary<String, LockMode> LockModes { get; set; }
        public object ParameterObject { get; set; }
        public Type ResultType { get { return this.CalledMethod.ReturnType; } }
        private TransformerAttribute transformerAttribute;

        private Type actualType;


        public int FetchSize { get; set; }

        public NHibernate.FlushMode? FetchMode { get; set; }

        public MethodInfo CalledMethod { get; private set; }
        public Object[] InvocationParameters { get; private set; }
        public Type[] InvocationParameterTypes { get { return ReflectionHelper.GetParameterTypes(CalledMethod); } }
        public BaseDaoAttribute daoAttribute { get; private set; }
        public ISessionManager SessionManager { get; private set; }
        private String factoryAlias;
        public IMiniContainer Container { get; private set; }
        public String OrderSql { get; private set; }

        public ExecutorContext(IMiniContainer container, MethodInfo calledMethod, Object[] invocationParameters, ISessionManager sessionManager)
            : this(container, calledMethod, invocationParameters, sessionManager, null)
        { }

        public ExecutorContext(IMiniContainer container, MethodInfo calledMethod, Object[] invocationParameters, ISessionManager sessionManager, String alias)
        {
            this.Container = container;

            this.CalledMethod = calledMethod;
            this.daoAttribute = ReflectionHelper.GetAttribute<BaseDaoAttribute>(calledMethod);
            this.InvocationParameters = invocationParameters;

            if (this.InvocationParameters == null)
            {
                this.InvocationParameters = new object[0];
            }

            if (this.CalledMethod.GetParameters().Length != this.InvocationParameters.Length)
            {
                throw new Exception("the method's parameter must be samed.");
            }
            this.SessionManager = sessionManager;
            this.factoryAlias = alias;
            FirstResult = int.MinValue;
            MaxResults = int.MinValue;
            FetchSize = int.MinValue;
            Parameters = new Dictionary<String, Object>();
            LockModes = new Dictionary<String, LockMode>();

            //get data from parameters
            ParameterInfo[] paramsInfo = this.CalledMethod.GetParameters();
            IEnumerable<OrderBy> orderByObject = null;
            for (int i = 0; i < this.InvocationParameters.Length; i++)
            {
                ParameterInfo pi = paramsInfo[i];
                if (pi.IsDefined(typeof(FirstResultAttribute), false))
                {
                    this.FirstResult = (int)this.InvocationParameters[i];
                }
                else if (pi.IsDefined(typeof(MaxResultsAttribute), false))
                {
                    this.MaxResults = (int)this.InvocationParameters[i];
                }
                else if (typeof(IEnumerable<OrderBy>).IsAssignableFrom(pi.ParameterType))
                {
                    orderByObject = (IEnumerable<OrderBy>)this.InvocationParameters[i];
                }
                else if (pi.IsDefined(typeof(ParamAttribute), false))
                {
                    Parameters.Add(ReflectionHelper.GetAttribute<ParamAttribute>(pi).Name, this.InvocationParameters[i]);
                }
                else if (this.InvocationParameters[i] is BaseSearchingEntity)
                {
                    BaseSearchingEntity be = this.InvocationParameters[0] as BaseSearchingEntity;
                    this.FirstResult = be.FirstResult;
                    this.MaxResults = be.MaxResults;
                    this.ParameterObject = be;
                    if (be.OrderBy.Count > 0)
                    {
                        orderByObject = be.OrderBy;
                    }
                }
                else
                {
                    Parameters.Add(pi.Name, this.InvocationParameters[i]);
                }
            }
            this.OrderSql = CreateOrderBySql(orderByObject);
            TransformerAttribute transformAttr = ReflectionHelper.GetAttribute<TransformerAttribute>(this.CalledMethod);

            if (transformAttr != null)
            {
                this.transformerAttribute = transformAttr;
                this.actualType = transformAttr.ReturnType;
            }

        }

        private string CreateOrderBySql(IEnumerable<OrderBy> orderByObject)
        {
            if (orderByObject == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();

            foreach (var item in orderByObject)
            {
                sb.Append(item.PropertyName)
                    .Append(" ")
                    .Append(item.Direction);
            }

            if (sb.Length > 0)
            {
                sb.Insert(0, " ORDER BY ");
            }
            return sb.ToString();
        }



        public string GetCalledMethodName()
        {
            if (this.CalledMethod.Name.StartsWith("Future"))
            {
                return FUTURE;
            }
            else if (this.CalledMethod.Name.StartsWith("Enumerate"))
            {
                return ENUMERATE;
            }
            else if (this.CalledMethod.Name.StartsWith("Find") || this.CalledMethod.Name.StartsWith("Get"))
            {
                return LIST;
            }
            return this.CalledMethod.Name;
        }

        public ISession GetSession()
        {
            if (string.IsNullOrEmpty(factoryAlias))
            {
                return SessionManager.OpenSession();
            }
            else
            {
                return SessionManager.OpenSession(factoryAlias);
            }
        }
        public IStatelessSession GetStatelessSession()
        {
            if (string.IsNullOrEmpty(factoryAlias))
            {
                return SessionManager.OpenStatelessSession();
            }
            else
            {
                return SessionManager.OpenStatelessSession(factoryAlias);
            }
        }

        public NHibernate.Transform.IResultTransformer ResultTransformer
        {
            get
            {
                return CreateTransformer();
            }
        }

        private NHibernate.Transform.IResultTransformer CreateTransformer()
        {
            if (this.transformerAttribute != null && this.ResultType != null)
            {
                Type entityType = GetEntityType();
                if (entityType == null)
                {
                    throw new NotSupportedException("The result Type can not be inferred,plese use TransformerAttribute to specify result type in method ." + this.CalledMethod.ToString());
                }


                return this.transformerAttribute.CreateTransformer(this.CalledMethod, entityType);
            }
            return null;
        }

        public Type GetEntityType()
        {
            if (actualType != null)
            {
                return actualType;
            }

            if (this.ResultType != null)
            {
                this.actualType = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), ResultType);
                if (this.actualType == null)
                {
                    if (this.ResultType.IsGenericType)
                    {
                        if (ResultType.GetGenericTypeDefinition() == typeof(IList<>)
                            || ResultType.GetGenericTypeDefinition() == typeof(IFutureValue<>)
                            || ResultType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                        {
                            this.actualType = ResultType.GetGenericArguments()[0];
                        }

                    }
                    else if (this.ResultType.IsGenericParameter)
                    {
                        this.actualType = ResultType;
                    }
                    else if (ResultType.GetGenericTypeDefinition() == typeof(IList)
                            || ResultType.GetGenericTypeDefinition() == typeof(IEnumerable))
                    {
                        this.actualType = null;
                    }
                    else
                    {
                        this.actualType = this.ResultType;
                    }
                }

            }
            return this.actualType;
        }
    }
}
