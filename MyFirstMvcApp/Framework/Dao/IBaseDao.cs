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
    using Framework.Entity;
    using System.Collections.Generic;
    using NHibernate.Criterion;
    using NHibernate;


    public interface IBaseDao<T, TId> where T : BaseEntity<TId>
    {

        IList<T> FindAll();


        IList<T> FindAll(int firstRow, int maxRows);


        T Load(TId id);

        T Load(TId id, LockMode lockMode);

        T Get(TId id);

        T Get(TId id, LockMode lockMode);

        TId Create(T instance);

        void Update(T instance);

        T Merge(T instance);

        void Delete(T instance);

        void Lock(T instance, LockMode lockMode);

        void Refresh(T instance);

        void Refresh(T instance, LockMode lockMode);

        int DeleteAll();

        /// <summary>
        /// Saves the instance to the database. If the primary key is unitialized
        /// it creates the instance on the database. Otherwise it updates it.
        /// <para>
        /// If the primary key is assigned, then you must invoke <see cref="Create"/>
        /// or <see cref="Update"/> instead.
        /// </para>
        /// </summary>
        /// <param name="instance">The instance to be saved</param>
        void SaveOrUpdate(T instance);

        TId Save(T instance);

        IList<T> FindAllStateless();


        IList<T> FindAllStateless(int firstRow, int maxRows);


        T FindByIdStateless(TId id);

        T CreateStateless(T instance);

        void UpdateStateless(T instance);

        void DeleteStateless(T instance);

        void DeleteAllStateless();



        IList<T> FindAll(ICriterion[] criterias);

        
        IList<T> FindAll(ICriterion[] criterias, int firstRow, int maxRows);

       
        IList<T> FindAll(ICriterion[] criterias, Order[] sortItems);

              IList<T> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows);

        /// <summary>
        /// Finds all with custom query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        IList<T> FindAllWithCustomQuery(string queryString);

        /// <summary>
        /// Finds all with custom HQL query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        IList<T> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows);

        /// <summary>
        /// Finds all with named HQL query.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <returns></returns>
        IList<T> FindAllWithNamedQuery(string namedQuery);

        /// <summary>
        /// Finds all with named HQL query.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        IList<T> FindAllWithNamedQuery(string namedQuery, int firstRow, int maxRows);

        /// <summary>
        /// Initializes the lazy properties.
        /// </summary>
        /// <param name="instance">The instance.</param>
        void InitializeLazyProperties(T instance);

        /// <summary>
        /// Initializes the lazy property.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        void InitializeLazyProperty(T instance, string propertyName);

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        IList<T> FindAllStateless(ICriterion[] criterias);

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        IList<T> FindAllStateless(ICriterion[] criterias, int firstRow, int maxRows);

        /// <summary>
        /// Returns all instances found for the specified type
        /// using criteria and IStatelessSession.
        /// </summary>
        /// <param name="type">The target type.</param>
        /// <param name="criterias">The criteria expression</param>
        /// <param name="sortItems">An <see cref="IList<T>"/> of <see cref="Order"/> objects.</param>
        /// <returns>The <see cref="IList<T>"/> of results.</returns>
        IList<T> FindAllStateless(ICriterion[] criterias, Order[] sortItems);

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
        IList<T> FindAllStateless(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows);

        /// <summary>
        /// Finds all with custom query using IStatelessSession.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        IList<T> FindAllWithCustomQueryStateless(string queryString);

        /// <summary>
        /// Finds all with custom HQL query using IStatelessSession.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        IList<T> FindAllWithCustomQueryStateless(string queryString, int firstRow, int maxRows);

        /// <summary>
        /// Finds all with named HQL query using IStatelessSession.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <returns></returns>
        IList<T> FindAllWithNamedQueryStateless(string namedQuery);

        /// <summary>
        /// Finds all with named HQL query using IStatelessSession.
        /// </summary>
        /// <param name="namedQuery">The named query.</param>
        /// <param name="firstRow">The number of the first row to retrieve.</param>
        /// <param name="maxRows">The maximum number of results retrieved.</param>
        /// <returns></returns>
        IList<T> FindAllWithNamedQueryStateless(string namedQuery, int firstRow, int maxRows);
    }
}