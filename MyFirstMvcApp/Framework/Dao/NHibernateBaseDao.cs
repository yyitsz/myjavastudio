#region License

//  Copyright 2004-2010 Castle Project - http://www.castleproject.org/
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 

#endregion

namespace Framework.Dao
{
    using System;
    using System.Collections;
    using NHibernate;
    using NHibernate.Collection;
    using NHibernate.Criterion;
    using NHibernate.Proxy;
    using Castle.Facilities.NHibernateIntegration;
    using Framework.Entity;
    using System.Collections.Generic;
    using Castle.Facilities.NHibernateIntegration.Util;
    using Castle.Services.Transaction;

    /// <summary>
    /// Summary description for GenericDao.
    /// </summary>
    /// <remarks>
    /// Contributed by Steve Degosserie &lt;steve.degosserie@vn.netika.com&gt;
    /// </remarks>
    public class NHibernateBaseDao<T, TId> : IBaseDao<T, TId> where T : BaseEntity<TId>
    {
        private readonly ISessionManager sessionManager;
        private string sessionFactoryAlias = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateBaseDao"/> class.
        /// </summary>
        /// <param name="sessionManager">The session manager.</param>
        public NHibernateBaseDao(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateBaseDao"/> class.
        /// </summary>
        /// <param name="sessionManager">The session manager.</param>
        /// <param name="sessionFactoryAlias">The session factory alias.</param>
        public NHibernateBaseDao(ISessionManager sessionManager, string sessionFactoryAlias)
            : this(sessionManager)
        {
            this.sessionFactoryAlias = sessionFactoryAlias;
        }

        /// <summary>
        /// Gets the session manager.
        /// </summary>
        /// <value>The session manager.</value>
        protected ISessionManager SessionManager
        {
            get { return sessionManager; }
        }

        /// <summary>
        /// Gets or sets the session factory alias.
        /// </summary>
        /// <value>The session factory alias.</value>
        public string SessionFactoryAlias
        {
            get { return sessionFactoryAlias; }
            set { sessionFactoryAlias = value; }
        }

        #region IGenericDAO Members

        /// <summary>
        /// Returns all instances found for the specified type.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <returns>The <see cref="IList<T>"/> of results</returns>
        public virtual IList<T> FindAll()
        {
            return FindAll(int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns a portion of the query results (sliced)
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results</returns>
        public virtual IList<T> FindAll(int firstRow, int maxRows)
        {
            using (ISession session = GetSession())
            {

                ICriteria criteria = session.CreateCriteria<T>();

                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);
                IList<T> result = criteria.List<T>();


                return result;

            }
        }

        /// <summary>
        /// Finds an object instance by an unique ID
        /// </summary>
        /// <param name="type">The AR subclass type</param>
        /// <param name="id">ID value</param>
        /// <returns>The object instance.</returns>
        public virtual T Load(TId id)
        {
            using (ISession session = GetSession())
            {

                return session.Load<T>(id);

            }
        }

        public T Merge(T instance)
        {
            using (ISession session = this.GetSession())
            {
                return (T)session.Merge(instance);
            }
        }
        public void Lock(T instance, LockMode lockMode)
        {
            using (ISession session = this.GetSession())
            {
                session.Lock(instance, lockMode);
            }
        }

        public void Refresh(T instance)
        {
            using (ISession session = this.GetSession())
            {
                session.Refresh(instance);
            }
        }

        public void Refresh(T instance, LockMode lockMode)
        {
            using (ISession session = this.GetSession())
            {
                session.Refresh(instance, lockMode);
            }
        }


        public T Load(TId id, LockMode lockMode)
        {
            using (ISession session = GetSession())
            {
                return session.Load<T>(id, lockMode);
            }
        }

        public T Get(TId id)
        {
            using (ISession session = GetSession())
            {

                return session.Get<T>(id);

            }
        }

        public T Get(TId id, LockMode lockMode)
        {
            using (ISession session = GetSession())
            {
                return session.Get<T>(id, lockMode);
            }
        }

        /// <summary>
        /// Creates (Saves) a new instance to the database.
        /// </summary>
        /// <param name="instance">The instance to be created on the database</param>
        /// <returns>The instance</returns>
        public virtual TId Create(T instance)
        {
            using (ISession session = GetSession())
            {

                return (TId)session.Save(instance);

            }
        }

        /// <summary>
        /// Persists the modification on the instance
        /// state to the database.
        /// </summary>
        /// <param name="instance">The instance to be updated on the database</param>
        public virtual void Update(T instance)
        {
            using (ISession session = GetSession())
            {

                session.Update(instance);

            }
        }

        /// <summary>
        /// Deletes the instance from the database.
        /// </summary>
        /// <param name="instance">The instance to be deleted from the database</param>
        public virtual void Delete(T instance)
        {
            using (ISession session = this.GetSession())
            {

                session.Delete(instance);

            }
        }

        /// <summary>
        /// Deletes all rows for the specified type
        /// </summary>
        /// <param name="type">type on which the rows on the database should be deleted</param>
        public virtual int DeleteAll()
        {
            Type type = typeof(T);
            using (ISession session = GetSession())
            {

               return session.Delete(String.Format("from {0}", type.Name));

            }
        }

        /// <summary>
        /// Saves the instance to the database. If the primary key is unitialized
        /// it creates the instance on the database. Otherwise it updates it.
        /// <para>
        /// If the primary key is assigned, then you must invoke <see cref="Create"/>
        /// or <see cref="Update"/> instead.
        /// </para>
        /// </summary>
        /// <param name="instance">The instance to be saved</param>
        public virtual void SaveOrUpdate(T instance)
        {
            using (ISession session = GetSession())
            {

                session.SaveOrUpdate(instance);

            }
        }
        public virtual TId Save(T instance)
        {
            using (ISession session = GetSession())
            {

                return (TId)session.Save(instance);

            }
        }

        /// <summary>
        /// Returns all instances found for the specified type using IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <returns>The <see cref="IList<T>"/> of results</returns>
        public virtual IList<T> FindAllStateless()
        {
            return FindAllStateless(int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns a portion of the query results (sliced) using IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results</returns>

        public virtual IList<T> FindAllStateless(int firstRow, int maxRows)
        {
            using (IStatelessSession session = this.GetStatelessSession())
            {

                ICriteria criteria = session.CreateCriteria<T>();

                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);
                IList<T> result = criteria.List<T>();


                return result;

            }
        }

        /// <summary>
        /// Finds an object instance by an unique ID using IStatelessSession.
        /// </summary>
        /// <param name="type">The AR subclass type</param>
        /// <param name="id">ID value</param>
        /// <returns>The object instance.</returns>
        public T FindByIdStateless(TId id)
        {
            using (IStatelessSession session = this.GetStatelessSession())
            {

                return session.Get<T>(id);

            }
        }

        /// <summary>
        /// Creates (saves or inserts) a new instance to the database using IStatelessSession.
        /// </summary>
        /// <param name="instance">The instance to be created on the database</param>
        /// <returns>The instance</returns>
        public T CreateStateless(T instance)
        {
            using (IStatelessSession session = GetStatelessSession())
            {

                return (T)session.Insert(instance);

            }
        }

        /// <summary>
        /// Persists the modification on the instance state to the database using IStatelessSession.
        /// </summary>
        /// <param name="instance">The instance to be updated on the database</param>
        public void UpdateStateless(T instance)
        {
            using (IStatelessSession session = GetStatelessSession())
            {

                session.Update(instance);

            }
        }

        /// <summary>
        /// Deletes the instance from the database using IStatelessSession.
        /// </summary>
        /// <param name="instance">The instance to be deleted from the database</param>
        public void DeleteStateless(T instance)
        {
            using (IStatelessSession session = this.GetStatelessSession())
            {

                session.Delete(instance);

            }
        }

        /// <summary>
        /// Deletes all rows for the specified type using IStatelessSession.
        /// </summary>
        /// <param name="type">type on which the rows on the database should be deleted</param>
        public void DeleteAllStateless()
        {
            Type type = typeof(T);
            using (IStatelessSession session = GetStatelessSession())
            {

                session.Delete(String.Format("from {0}", type.Name));

            }
        }

        #endregion

        #region INHibernateGenericDAO Members

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAll(ICriterion[] criterias)
        {
            return FindAll(criterias, null, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAll(ICriterion[] criterias, int firstRow, int maxRows)
        {
            return FindAll(criterias, null, firstRow, maxRows);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="sortItems">An <see cref="IList<T>"/> of <see cref="Order"/> objects.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            return FindAll(criterias, sortItems, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="sortItems">An <see cref="IList<T>"/> of <see cref="Order"/> objects.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows)
        {
            using (ISession session = GetSession())
            {

                ICriteria criteria = session.CreateCriteria<T>();

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                if (sortItems != null)
                {
                    foreach (Order order in sortItems)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);
                IList<T> result = criteria.List<T>();
                return result;

            }
        }

        /// <summary>
        /// Finds all with custom query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithCustomQuery(string queryString)
        {
            return FindAllWithCustomQuery(queryString, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Finds all with custom HQL query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            using (ISession session = GetSession())
            {

                IQuery query = session.CreateQuery(queryString);

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);
                IList<T> result = query.List<T>();

                return result;

            }
        }

        /// <summary>
        /// Finds all with named HQL query.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithNamedQuery(string namedQuery)
        {
            return FindAllWithNamedQuery(namedQuery, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Finds all with named HQL query.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithNamedQuery(string namedQuery, int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(namedQuery)) throw new ArgumentNullException("namedQuery");

            using (ISession session = this.GetSession())
            {

                IQuery query = session.GetNamedQuery(namedQuery);
                if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);
                IList<T> result = query.List<T>();
                return result;

            }
        }

        /// <summary>
        /// Initializes the lazy properties.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void InitializeLazyProperties(T instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");

            using (ISession session = this.GetSession())
            {
                foreach (object val in ReflectionUtility.GetPropertiesDictionary(instance).Values)
                {
                    if (val is INHibernateProxy || val is IPersistentCollection)
                    {
                        if (!NHibernateUtil.IsInitialized(val))
                        {
                            session.Lock(instance, LockMode.None);
                            NHibernateUtil.Initialize(val);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the lazy property.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        public void InitializeLazyProperty(T instance, string propertyName)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");

            var properties = ReflectionUtility.GetPropertiesDictionary(instance);
            if (!properties.ContainsKey(propertyName))
                throw new ArgumentOutOfRangeException("propertyName", "Property "
                                                                      + propertyName + " doest not exist for type "
                                                                      + instance.GetType() + ".");

            using (ISession session = this.GetSession())
            {
                object val = properties[propertyName];

                if (val is INHibernateProxy || val is IPersistentCollection)
                {
                    if (!NHibernateUtil.IsInitialized(val))
                    {
                        session.Lock(instance, LockMode.None);
                        NHibernateUtil.Initialize(val);
                    }
                }
            }
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAllStateless(ICriterion[] criterias)
        {
            return FindAllStateless(criterias, null, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAllStateless(ICriterion[] criterias, int firstRow, int maxRows)
        {
            return FindAllStateless(criterias, null, firstRow, maxRows);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="sortItems">An <see cref="IList<T>"/> of <see cref="Order"/> objects.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAllStateless(ICriterion[] criterias, Order[] sortItems)
        {
            return FindAllStateless(criterias, sortItems, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="sortItems">An <see cref="IList<T>"/> of <see cref="Order"/> objects.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        public virtual IList<T> FindAllStateless(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows)
        {
            using (IStatelessSession session = GetStatelessSession())
            {

                ICriteria criteria = session.CreateCriteria<T>();

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                if (sortItems != null)
                {
                    foreach (Order order in sortItems)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);
                IList<T> result = criteria.List<T>();

                return result;

            }
        }

        /// <summary>
        /// Finds all with custom query using IStatelessSession.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithCustomQueryStateless(string queryString)
        {
            return FindAllWithCustomQueryStateless(queryString, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Finds all with custom HQL query using IStatelessSession.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithCustomQueryStateless(string queryString, int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            using (IStatelessSession session = GetStatelessSession())
            {

                IQuery query = session.CreateQuery(queryString);

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);
                IList<T> result = query.List<T>();

                return result;

            }
        }


        /// <summary>
        /// Finds all with named HQL query using IStatelessSession.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithNamedQueryStateless(string namedQuery)
        {
            return FindAllWithNamedQueryStateless(namedQuery, int.MinValue, int.MinValue);
        }

        /// <summary>
        /// Finds all with named HQL query using IStatelessSession.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        public virtual IList<T> FindAllWithNamedQueryStateless(string namedQuery, int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(namedQuery)) throw new ArgumentNullException("namedQuery");

            using (IStatelessSession session = this.GetStatelessSession())
            {

                IQuery query = session.GetNamedQuery(namedQuery);
                if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);
                IList<T> result = query.List<T>();

                return result;

            }
        }

        #endregion

        #region Private methods

        protected ISession GetSession()
        {
            if (string.IsNullOrEmpty(sessionFactoryAlias))
            {
                return sessionManager.OpenSession();
            }
            else
            {
                return sessionManager.OpenSession(sessionFactoryAlias);
            }
        }

        protected IStatelessSession GetStatelessSession()
        {
            if (string.IsNullOrEmpty(sessionFactoryAlias))
            {
                return sessionManager.OpenStatelessSession();
            }
            else
            {
                return sessionManager.OpenStatelessSession(sessionFactoryAlias);
            }
        }

        #endregion






    }
}