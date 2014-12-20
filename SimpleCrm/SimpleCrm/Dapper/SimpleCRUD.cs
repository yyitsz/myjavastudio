using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper
{
    /// <summary>
    /// Main class for Dapper.SimpleCRUD extensions
    /// </summary>
    public static class SimpleCRUD
    {
        private static IDictionary<Type, EntityMeta> entityMetaCache = new Dictionary<Type, EntityMeta>(10);
        public static ICrudContext CrudContext { get; set; }

        private static EntityMeta GetEntityMeta(Type type)
        {
            EntityMeta result;
            if (entityMetaCache.TryGetValue(type, out result) == false)
            {
                result = new EntityMeta();
                entityMetaCache[type] = result;
                result.EntityType = type;
                result.TableName = GetTableName(type);
                IEnumerable<PropertyInfo> idProps = GetIdProperties(type);
                result.Keys = idProps.ToList();
                result.Columns = GetNonIdProperties(type).ToList();

                if (!idProps.Any())
                {
                    throw new ArgumentException("Only supports an entity with a [Key] or Id property");
                }
                if (idProps.Count() > 1)
                {
                    throw new ArgumentException("Only supports an entity with a single [Key] or Id property");
                }

            }
            return result;
        }



        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>By default filters on the Id column</para>
        /// <para>-Id column name can be overridden by adding an attribute on your primary key property [Key]</para>
        /// <para>Returns a single entity by a single id from table T</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="id"></param>
        /// <returns>Returns a single entity by a single id from table T.</returns>
        public static T Get<T>(this IDbConnection connection, object id)
        {
            var currenttype = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(currenttype);

            var onlyKey = entityMeta.Keys[0];
            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            sb.AppendFormat("Select * from {0}", name);
            sb.Append(" where " + onlyKey.Name + " = @Id");

            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id, null, null, null);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Get<{0}>: {1} with Id: {2}", currenttype, sb, id));
            }

            return connection.Query<T>(sb.ToString(), dynParms).FirstOrDefault();
        }

        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>whereConditions is an anonymous type to filter the results ex: new {Category = 1, SubCategory=2}</para>
        /// <para>Returns a list of entities that match where conditions</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="whereConditions"></param>
        /// <returns>Gets a list of entities with optional exact match where conditions</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, object whereConditions)
        {
            var currenttype = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(currenttype);

            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            var whereprops = GetAllProperties(whereConditions).ToArray();
            sb.AppendFormat("Select * from {0}", name);

            if (whereprops.Any())
            {
                sb.Append(" where ");
                BuildWhere(sb, whereprops);
            }

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("GetList<{0}>: {1}", currenttype, sb));
            }
            return connection.Query<T>(sb.ToString(), whereConditions);
        }

        public static int Count<T>(this IDbConnection connection, object whereConditions)
        {
            var currenttype = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(currenttype);

            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            var whereprops = GetAllProperties(whereConditions).ToArray();
            sb.AppendFormat("Select count(*) from {0}", name);

            if (whereprops.Any())
            {
                sb.Append(" where ");
                BuildWhere(sb, whereprops);
            }

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Count<{0}>: {1}", currenttype, sb));
            }
            return connection.ExecuteScalar<int>(sb.ToString(), whereConditions, null, null, null);
        }

        public static int Count(this IDbConnection connection, String countSql, object whereConditions)
        {
            var sb = new StringBuilder();
            var whereprops = GetAllProperties(whereConditions).ToArray();
            sb.Append(countSql);

            if (whereprops.Any())
            {
                sb.Append(" where ");
                BuildWhere(sb, whereprops);
            }

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Count: {0}", sb));
            }
            return connection.ExecuteScalar<int>(sb.ToString(), whereConditions, null, null, null);
        }

        public static IEnumerable<T> GetListByExample<T>(this IDbConnection connection, object whereConditions)
        {
            var currenttype = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(currenttype);

            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            var whereprops = GetAllProperties(whereConditions).ToArray();
            sb.AppendFormat("Select * from {0}", name);

            BuildWhereWithExample(sb, whereprops, whereConditions);


            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("GetList<{0}>: {1}", currenttype, sb));
            }
            return connection.Query<T>(sb.ToString(), whereConditions);
        }

        public static IEnumerable<T> SearchByCriteria<T>(this IDbConnection connection, String selectSql, object whereConditions)
        {

            var sb = new StringBuilder();
            var whereprops = GetAllProperties(whereConditions).ToArray();
            sb.Append(selectSql);

            BuildWhereWithExample(sb, whereprops, whereConditions);


            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("SearchByCriteria: {0}", sb));
            }
            return connection.Query<T>(sb.ToString(), whereConditions);
        }

        private static void BuildWhereWithExample(StringBuilder sb, PropertyInfo[] allProperties, object whereConditions)
        {
            StringBuilder tmpSb = new StringBuilder();
            string and = " and ";
            for (var i = 0; i < allProperties.Length; i++)
            {
                PropertyInfo pi = allProperties[i];
                if (pi.PropertyType.IsSimpleType()
                    && pi.GetValue(whereConditions, null) != null)
                {
                    tmpSb.AppendFormat("{0} = @{1}", pi.Name, pi.Name);
                    tmpSb.AppendFormat(and);
                }
            }
            if (tmpSb.Length > and.Length)
            {
                tmpSb.Remove(tmpSb.Length - and.Length, and.Length);
            }
            if (tmpSb.Length > 0)
            {
                sb.Append(" where ")
                    .Append(tmpSb.ToString());
            }
        }

        public static IEnumerable<T> GetList<T>(this IDbConnection connection, String whereConditions, Object paramObj)
        {
            var currenttype = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(currenttype);

            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            sb.AppendFormat("Select * from {0} where {1}", name, whereConditions);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("GetList<{0}>: {1}", currenttype, sb));
            }
            return connection.Query<T>(sb.ToString(), paramObj);
        }

        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Returns a list of all entities</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <returns>Gets a list of all entities</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection)
        {
            return connection.GetList<T>(new { });
        }

        public static int Insert<T>(this IDbConnection connection, T entityToInsert)
        {
            return Insert(connection, entityToInsert, null, null);
        }

        /// <summary>
        /// <para>Inserts a row into the database</para>
        /// <para>By default inserts into the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Insert filters out Id column and any columns with the [Key] attribute</para>
        /// <para>Properties marked with attribute [Editable(false)] and complex types are ignored</para>
        /// <para>Supports transaction and command timeout</para>
        /// <para>Returns the ID (primary key) of the newly inserted record if it is identity using the defined type, otherwise null</para>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToInsert"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The ID (primary key) of the newly inserted record if it is identity using the defined type, otherwise null</returns>
        public static int Insert<T>(this IDbConnection connection, T entityToInsert, IDbTransaction transaction, int? commandTimeout)
        {
            Type entityType = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(entityType);

            var name = entityMeta.TableName;
            var sb = new StringBuilder();
            sb.AppendFormat("insert into {0}", name);
            sb.Append(" (");
            BuildInsertParameters(entityMeta, sb);
            sb.Append(") values (");
            BuildInsertValues(entityMeta, sb);
            sb.Append(")");

            if (entityMeta.IsAutoIncrementKey)
            {
                //var r = connection.Query("select last_insert_rowid() id", null, transaction, true, commandTimeout, null);
                //object idVal = r.FirstOrDefault()["id"];
                //entityMeta.Keys[0].SetValue(entityListToInsert, idVal, null);
                sb.Append(";")
                    .Append("select last_insert_rowid() id");
            }
            //sqlce doesn't support scope_identity so we have to dumb it down
            //sb.Append("; select cast(scope_identity() as int)");
            //var newId = connection.Query<int?>(sb.ToString(), entityToInsert).Single();
            //return (newId == null) ? 0 : (int)newId;

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Insert: {0}", sb));
            }

            UpdateAuditableField(entityToInsert as IAuditable);
            UpdateVersionableField(entityToInsert as IVersionable);
            if (entityMeta.IsAutoIncrementKey)
            {
                var r = connection.Query(sb.ToString(), entityToInsert);
                object idVal = r.FirstOrDefault().id;
                entityMeta.Keys[0].SetValue(entityToInsert, idVal, null);
                return 1;
            }
            else
            {
                return connection.Execute(sb.ToString(), entityToInsert, transaction, commandTimeout, null);
            }

        }

        private static void UpdateVersionableField(IVersionable entity)
        {
            if (entity == null)
            {
                return;
            }
            if (entity.VersionNo == null || entity.VersionNo.Value <= 0)
            {
                entity.VersionNo = 1;
            }
            else
            {
                entity.VersionNo = entity.VersionNo.Value + 1;
            }
        }

        private static void UpdateAuditableField(IAuditable auditable)
        {
            if (auditable == null)
            {
                return;
            }
            DateTime curr = DateTime.Now;
            if (auditable.CreateTime == null)
            {
                auditable.CreateTime = curr;
            }
            if (CrudContext != null && CrudContext.GetUser() != null)
            {
                auditable.UpdatedBy = CrudContext.GetUser();
            }
            auditable.UpdateTime = curr;
        }

        public static int InsertBatch<T>(this IDbConnection connection, IEnumerable<T> entityListToInsert, IDbTransaction transaction, int? commandTimeout)
        {
            Type entityType = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(entityType);

            var name = entityMeta.TableName;
            var sb = new StringBuilder();
            sb.AppendFormat("insert into {0}", name);
            sb.Append(" (");
            BuildInsertParameters(entityMeta, sb);
            sb.Append(") values (");
            BuildInsertValues(entityMeta, sb);
            sb.Append(")");
            if (entityMeta.IsAutoIncrementKey)
            {
                //var r = connection.Query("select last_insert_rowid() id", null, transaction, true, commandTimeout, null);
                //object idVal = r.FirstOrDefault()["id"];
                //entityMeta.Keys[0].SetValue(entityListToInsert, idVal, null);
                sb.Append(";")
                    .Append("select last_insert_rowid() id");
            }
            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Insert: {0}", sb));
            }
            foreach (var v in entityListToInsert)
            {
                UpdateVersionableField(v as IVersionable);
            }
            int count = connection.Execute(sb.ToString(), entityListToInsert, transaction, commandTimeout, null);

            return count;
        }

        public static int Update<T>(this IDbConnection connection, T entityToUpdate)
        {
            return Update(connection, entityToUpdate, null, null);
        }

        /// <summary>
        ///  <para>Updates a record or records in the database</para>
        ///  <para>By default updates records in the table matching the class name</para>
        ///  <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        ///  <para>Updates records where the Id property and properties with the [Key] attribute match those in the database.</para>
        ///  <para>Properties marked with attribute [Editable(false)] and complex types are ignored</para>
        ///  <para>Supports transaction and command timeout</para>
        ///  <para>Returns number of rows effected</para>
        ///  </summary>
        ///  <param name="connection"></param>
        ///  <param name="entityToUpdate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of effected records</returns>
        public static int Update<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction, int? commandTimeout)
        {
            Type entityType = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(entityType);

            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;
            IVersionable versionableEntity = entityToUpdate as IVersionable;

            var sb = new StringBuilder();
            sb.AppendFormat("update {0}", name);

            sb.AppendFormat(" set ");
            BuildUpdateSet(entityMeta, entityToUpdate, sb);
            sb.Append(" where ");
            if (versionableEntity != null && versionableEntity.VersionNo != null)
            {
                sb.Append(" VersionNo = ")
                    .Append(versionableEntity.VersionNo.Value)
                    .Append(" and ");
            }
            BuildWhere(sb, idProps);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Update: {0}", sb));
            }

            UpdateAuditableField(entityToUpdate as IAuditable);

            if (versionableEntity != null)
            {
                UpdateVersionableField(versionableEntity);
            }
            int count = connection.Execute(sb.ToString(), entityToUpdate, transaction, commandTimeout, null);
            if (count == 0 && versionableEntity != null)
            {
                throw new StaleRecordException(entityToUpdate);
            }
            return count;
        }

        public static int Delete<T>(this IDbConnection connection, T entityToDelete)
        {
            return Delete(connection, entityToDelete, null, null);
        }
        /// <summary>
        /// <para>Deletes a record or records in the database that match the object passed in</para>
        /// <para>-By default deletes records in the table matching the class name</para>
        /// <para>Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Supports transaction and command timeout</para>
        /// <para>Returns the number of records effected</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entityToDelete"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records effected</returns>
        public static int Delete<T>(this IDbConnection connection, T entityToDelete, IDbTransaction transaction, int? commandTimeout)
        {
            Type entityType = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(entityType);
            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            sb.AppendFormat("delete from {0}", name);

            sb.Append(" where ");
            BuildWhere(sb, idProps);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Delete: {0}", sb));
            }
            return connection.Execute(sb.ToString(), entityToDelete, transaction, commandTimeout, null);
        }

        public static int Delete<T>(this IDbConnection connection, object id, IDbTransaction transaction, int? commandTimeout)
        {
            Type entityType = typeof(T);
            EntityMeta entityMeta = GetEntityMeta(entityType);
            var idProps = entityMeta.Keys;

            var name = entityMeta.TableName;

            var sb = new StringBuilder();
            sb.AppendFormat("delete from {0}", name);

            sb.Append(" where ");
            BuildWhere(sb, idProps);
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add(idProps[0].Name, id);
            if (Debugger.IsAttached)
            {
                Trace.WriteLine(String.Format("Delete: {0}", sb));
            }
            return connection.Execute(sb.ToString(), param, transaction, commandTimeout, null);
        }

        /// <summary>
        /// <para>Deletes a record or records in the database by ID</para>
        /// <para>By default deletes records in the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Deletes records where the Id property and properties with the [Key] attribute match those in the database</para>
        /// <para>The number of records effected</para>
        /// <para>Supports transaction and command timeout</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records effected</returns>
        public static int DeleteById<T>(this IDbConnection connection, object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var currenttype = typeof(T);
            var idProps = GetIdProperties(currenttype).ToList();


            if (!idProps.Any())
                throw new ArgumentException("Delete<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Delete<T> only supports an entity with a single [Key] or Id property");

            var onlyKey = idProps.First();
            var name = GetTableName(currenttype);

            var sb = new StringBuilder();
            sb.AppendFormat("Delete from {0}", name);
            sb.Append(" where " + onlyKey.Name + " = @Id");

            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id, null, null, null);

            if (Debugger.IsAttached)
                Trace.WriteLine(String.Format("Delete<{0}> {1}", currenttype, sb));

            return connection.Execute(sb.ToString(), dynParms, transaction, commandTimeout, null);
        }

        //build update statement based on list on an entity
        private static void BuildUpdateSet(EntityMeta entityMeta, object entityToUpdate, StringBuilder sb)
        {
            var nonIdProps = entityMeta.Columns;

            for (var i = 0; i < nonIdProps.Count; i++)
            {
                var property = nonIdProps[i];

                sb.AppendFormat("{0} = @{1}", property.Name, property.Name);
                if (i < nonIdProps.Count - 1)
                    sb.AppendFormat(", ");
            }
        }

        //build where clause based on list of properties
        private static void BuildWhere(StringBuilder sb, IEnumerable<PropertyInfo> idProps)
        {
            var propertyInfos = idProps.ToArray();
            for (var i = 0; i < propertyInfos.Count(); i++)
            {
                sb.AppendFormat("{0} = @{1}", propertyInfos.ElementAt(i).Name, propertyInfos.ElementAt(i).Name);
                if (i < propertyInfos.Count() - 1)
                {
                    sb.AppendFormat(" and ");
                }
            }
        }

        //build insert values which include all properties in the class that are not marked with the Editable(false) attribute,
        //are not marked with the [Key] attribute, and are not named Id
        private static void BuildInsertValues(EntityMeta entityMeta, StringBuilder sb)
        {
            var props = entityMeta.Columns;
            if (entityMeta.IsAutoIncrementKey == false)
            {
                sb.AppendFormat("@{0}", entityMeta.Keys[0].Name);
                sb.Append(", ");
            }

            for (var i = 0; i < props.Count(); i++)
            {
                var property = props[i];

                sb.AppendFormat("@{0}", property.Name);
                if (i < props.Count() - 1)
                {
                    sb.Append(", ");
                }
            }
            if (sb.ToString().EndsWith(", "))
            {
                sb.Remove(sb.Length - 2, 2);
            }

        }

        //build insert parameters which include all properties in the class that are not marked with the Editable(false) attribute,
        //are not marked with the [Key] attribute, and are not named Id
        private static void BuildInsertParameters(EntityMeta entityMeta, StringBuilder sb)
        {
            var props = entityMeta.Columns;
            if (entityMeta.IsAutoIncrementKey == false)
            {
                sb.Append(entityMeta.Keys[0].Name);
                sb.Append(", ");
            }
            for (var i = 0; i < props.Count(); i++)
            {
                var property = props[i];

                sb.Append(property.Name);
                if (i < props.Count() - 1)
                {
                    sb.Append(", ");
                }
            }
            if (sb.ToString().EndsWith(", "))
            {
                sb.Remove(sb.Length - 2, 2);
            }
        }

        //Get all properties in an entity
        private static IEnumerable<PropertyInfo> GetAllProperties(object entity)
        {
            if (entity == null) entity = new { };
            return entity.GetType().GetProperties();
        }

        //Get all properties that are not decorated with the Editable(false) attribute
        private static IEnumerable<PropertyInfo> GetScaffoldableProperties(Type type)
        {
            var props = type.GetProperties().Where(p => p.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(EditableAttribute) && !IsEditable(p)) == false);
            return props.Where(p => p.PropertyType.IsSimpleType() || IsEditable(p));
        }

        //Determine if the Attribute has an AllowEdit key and return its boolean state
        //fake the funk and try to mimick EditableAttribute in System.ComponentModel.DataAnnotations 
        //This allows use of the DataAnnotations property in the model and have the SimpleCRUD engine just figure it out without a reference
        private static bool IsEditable(PropertyInfo pi)
        {
            object[] attributes = pi.GetCustomAttributes(false);
            if (attributes.Length > 0)
            {
                object write = attributes.FirstOrDefault(x => x.GetType() == typeof(EditableAttribute));
                if (write != null)
                {
                    return ((EditableAttribute)write).AllowEdit;
                }
            }
            return false;
        }


        //Get all properties that are NOT named Id and DO NOT have the Key attribute
        private static IEnumerable<PropertyInfo> GetNonIdProperties(Type type)
        {
            return GetScaffoldableProperties(type).Where(p => p.Name != "Id" && p.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute) || attr.GetType() == typeof(TransientAttribute)) == false);
        }


        //Get all properties that are named Id or have the Key attribute
        //For Get(id) and Delete(id) we don't have an entity, just the type so this method is used
        private static IEnumerable<PropertyInfo> GetIdProperties(Type type)
        {
            return type.GetProperties().Where(p => p.Name == "Id" || p.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute)));
        }


        //Gets the table name for this type
        //For Get(id) and Delete(id) we don't have an entity, just the type so this method is used
        //Use dynamic type to be able to handle both our Table-attribute and the DataAnnotation
        //Uses class name by default and overrides if the class has a Table attribute
        private static string GetTableName(Type type)
        {
            var tableName = String.Format("[{0}]", type.Name);

            var tableattr = type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType() == typeof(TableAttribute)) as TableAttribute;
            if (tableattr != null)
            {
                tableName = String.Format("[{0}]", tableattr.Name);

                if (!String.IsNullOrEmpty(tableattr.Schema))
                {
                    tableName = String.Format("[{0}].[{1}]", tableattr.Schema, tableattr.Name);
                }

            }

            return tableName;
        }
    }



    /// <summary>
    /// Optional Table attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify the table name of a poco
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Optional Table attribute.
        /// </summary>
        /// <param name="tableName"></param>
        public TableAttribute(string tableName)
        {
            Name = tableName;
        }
        /// <summary>
        /// Name of the table
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Name of the schema
        /// </summary>
        public string Schema { get; set; }
    }


    /// <summary>
    /// Optional Key attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify the Primary Key of a poco
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
        public bool AutoIncrement { get; set; }
        public KeyAttribute()
            : this(true)
        {
        }
        public KeyAttribute(Boolean autoIncrement)
        {
            AutoIncrement = autoIncrement;
        }
    }

    /// <summary>
    /// Optional Key attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify the Primary Key of a poco
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TransientAttribute : Attribute
    {
    }

    /// <summary>
    /// Optional Editable attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify the properties that are editable
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableAttribute : Attribute
    {
        /// <summary>
        /// Optional Editable attribute.
        /// </summary>
        /// <param name="iseditable"></param>
        public EditableAttribute(bool iseditable)
        {
            AllowEdit = iseditable;
        }
        /// <summary>
        /// Does this property persist to the database?
        /// </summary>
        public bool AllowEdit { get; private set; }
    }

    public class EntityMeta
    {
        private IList<PropertyInfo> keys;

        public Type EntityType { get; set; }
        public String TableName { get; set; }
        public string Schema { get; set; }
        public IList<PropertyInfo> Keys
        {
            get { return keys; }
            set
            {
                keys = value;
                if (keys != null && keys.Count == 1)
                {
                    Type keyType = keys[0].PropertyType;
                    var underlyingType = Nullable.GetUnderlyingType(keyType);
                    var keytype = underlyingType ?? keyType;
                    if (keytype != typeof(int)
                        && keytype != typeof(uint)
                        && keytype != typeof(long)
                        && keytype != typeof(ulong)
                        && keytype != typeof(short)
                        && keytype != typeof(ushort))
                    {
                        IsAutoIncrementKey = false;
                    }
                    else
                    {
                        object[] attrs = Keys[0].GetCustomAttributes(typeof(KeyAttribute), true);
                        if (attrs == null || attrs.Length == 0)
                        {
                            IsAutoIncrementKey = false;
                        }

                        IsAutoIncrementKey = ((KeyAttribute)attrs[0]).AutoIncrement;
                    }

                }
                else
                {
                    IsAutoIncrementKey = false;
                }
            }
        }
        public IList<PropertyInfo> Columns { get; set; }

        public Boolean IsAutoIncrementKey { get; private set; }
    }

    public interface IAuditable
    {
        DateTime? CreateTime { get; set; }
        String UpdatedBy { get; set; }
        DateTime? UpdateTime { get; set; }
    }

    public interface IVersionable
    {
        long? VersionNo { get; set; }
    }

    public interface ICrudContext
    {
        String GetUser();
    }

    public class EnquiryParam
    {
        int? StartPage { get; set; }
        int? PageSize { get; set; }
    }
    public interface IPagination
    {
        EnquiryParam EnquiryParam { get; }
    }
    public interface IPaginationResult
    {
        int? TotalRecord { set; }
    }
}

[global::System.Serializable]
public class StaleRecordException : Exception
{
    private Object entity;
    public StaleRecordException(Object entity)
        : base("Data is stale, it may be modified by another user. Please refresh UI.")
    {
        this.entity = entity;
    }

    protected StaleRecordException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}

static class TypeExtension
{
    //You can't insert or update complex types. Lets filter them out.
    public static bool IsSimpleType(this Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type);
        type = underlyingType ?? type;
        var simpleTypes = new List<Type>
                               {
                                   typeof(byte),
                                   typeof(sbyte),
                                   typeof(short),
                                   typeof(ushort),
                                   typeof(int),
                                   typeof(uint),
                                   typeof(long),
                                   typeof(ulong),
                                   typeof(float),
                                   typeof(double),
                                   typeof(decimal),
                                   typeof(bool),
                                   typeof(string),
                                   typeof(char),
                                   typeof(Guid),
                                   typeof(DateTime),
                                   typeof(DateTimeOffset),
                                   typeof(byte[])
                               };
        return simpleTypes.Contains(type) || type.IsEnum;
    }
}