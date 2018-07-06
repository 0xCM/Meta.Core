//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Concurrent;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using systems = SqlT.SqlSystem.systems;

    using static metacore;

    /// <summary>
    /// Encapsulates the metadata for a single catalog
    /// </summary>
    public class SqlDatabaseMetadataSet
    {
        static ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>> propcache
            = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>>();

        static IReadOnlyDictionary<string, PropertyInfo> props(object o)
            => o == null
            ? new Dictionary<string, PropertyInfo>() { }
            : propcache.GetOrAdd(o.GetType(),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(x => x.Name));

        public static IReadOnlyDictionary<string, PropertyInfo> props<T>()
            => propcache.GetOrAdd(typeof(T),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(x => x.Name));

        static TDst project<TSrc, TDst>(TSrc src, TDst dst)
        {
            var srcProps = props(src);
            var dstProps = props(dst);
            foreach (var srcPropName in srcProps.Keys)
                dstProps.TryFind(srcPropName).OnSome(dstProp
                    => dstProp.SetValue(dst, srcProps[srcPropName].GetValue(src)));
            return dst;
        }

        IDictionary<SqlName, systems.v_schemas> schemas { get; }
            = new Dictionary<SqlName, systems.v_schemas>();

        IDictionary<SqlName, systems.v_tables> tables { get; }
            = new Dictionary<SqlName, systems.v_tables>();

        IDictionary<SqlName, systems.v_types> types { get; }
            = new Dictionary<SqlName, systems.v_types>();

        IDictionary<SqlName, systems.v_views> views { get; }
            = new Dictionary<SqlName, systems.v_views>();

        IDictionary<SqlName, systems.v_table_columns> table_columns { get; }
            = new Dictionary<SqlName, systems.v_table_columns>();

        IDictionary<SqlName, systems.v_table_indexes> table_indexes { get; }
            = new Dictionary<SqlName, systems.v_table_indexes>();

        IDictionary<SqlName, systems.v_table_index_columns> table_index_columns { get; }
            = new Dictionary<SqlName, systems.v_table_index_columns>();

        IDictionary<SqlName, systems.v_extended_properties> extended_properties { get; }
            = new Dictionary<SqlName, systems.v_extended_properties>();

        string host_server_name { get; }

        systems.v_servers host_server { get; }

        systems.v_databases database { get; }

        public SqlDatabaseMetadataSet(IServer host, IDatabase database)
        {
            this.host_server_name = host.name;
            this.host_server = project(host, new systems.v_servers
            {
                systems_server_name = host.name
            });
            this.database = project(database, new systems.v_databases
            {
                 systems_server_name = host.name,                
            });                       
        }

        public void Absorb(SqlDatabaseName database_name, IEnumerable<ISchema> src) 
            => schemas.AddRange(map(src, x => project(x, new systems.v_schemas()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName
            })).ToDictionary(x => x.systems_full_name));

        public void Absorb(IEnumerable<systems.v_types> types)
            => this.types.AddRange(types.ToDictionary(x => x.systems_full_name));

        public void Absorb(SqlDatabaseName database_name, string schema_name, IEnumerable<IView> src)
            => views.AddRange(map(src, x => project(x, new systems.v_views()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name
            })).ToDictionary(x => x.systems_full_name));
       
        public void Absorb(SqlDatabaseName database_name, string schema_name, IEnumerable<ITable> src) 
            => tables.AddRange(map(src, x => project(x, new systems.v_tables()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name
            })).ToDictionary(x => x.systems_full_name));

        public void Absorb(SqlDatabaseName database_name, IEnumerable<IExtendedProperty> src)
            => extended_properties.AddRange(map(src, x => project(x, new systems.v_extended_properties()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                @class = x.@class,
                class_desc = x.class_desc,
                major_id = x.major_id,
                minor_id = x.minor_id,
                name = x.name,
                value  = x.value
                                   
            })).ToDictionary(x => x.systems_full_name));

        public void Absorb(SqlDatabaseName database_name, string schema_name, string parent_name, string parent_type, IEnumerable<IIndex> src)
            => table_indexes.AddRange(map(src, x => new systems.v_table_indexes()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name,
                systems_parent_name = parent_name,
                systems_parent_type = parent_type,
                allow_page_locks = x.allow_page_locks,
                allow_row_locks = x.allow_row_locks,
                data_space_id = x.data_space_id,
                object_id = x.object_id,
                fill_factor = x.fill_factor,
                filter_definition = x.filter_definition,
                has_filter = x.has_filter,
                ignore_dup_key = x.ignore_dup_key,
                index_id = x.index_id,
                is_disabled = x.is_disabled,
                is_hypothetical = x.is_hypothetical,
                is_padded = x.is_padded,
                is_primary_key = x.is_primary_key,
                is_unique = x.is_unique,
                is_unique_constraint = x.is_unique_constraint,
                name = x.name,
                type = x.type,
                type_desc = x.type_desc
            }).ToDictionary(x => x.systems_full_name));

        public void Absorb(SqlDatabaseName database_name, string schema_name, string parent_name, string parent_type, string index_name, IIndexColumn src)
        {
            var dst = new systems.v_table_index_columns()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name,
                systems_parent_name = parent_name,
                systems_parent_type = parent_type,
                systems_index_name = index_name,
                systems_column_name = src.name,
                column_id = src.column_id,
                index_column_id = src.index_column_id,
                index_id = src.index_id,
                is_descending_key = src.is_descending_key,
                is_included_column = src.is_included_column,
                key_ordinal = src.key_ordinal,
                object_id = src.object_id,
                partition_ordinal = src.partition_ordinal,
            };

            var key = dst.systems_full_name;
            if(table_index_columns.ContainsKey(key))
                throw new Exception($"The index column {key} has already been specified");

            table_index_columns.Add(key, dst);
        }
            
        public void Absorb(SqlDatabaseName database_name, string schema_name, string parent_name, string parent_type, IColumn src)
            => table_columns.Add(new SqlName(host_server_name, database_name, schema_name, parent_name, src.name), project(src, new systems.v_table_columns
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name,
                systems_parent_name = parent_name,
                systems_parent_type = parent_type
            }));

        public void Absorb(SqlDatabaseName database_name, string schema_name, string parent_name, string parent_type, IEnumerable<IColumn> src)
            => table_indexes.AddRange(map(src, x => project(x, new systems.v_table_indexes()
            {
                systems_server_name = host_server_name,
                systems_database_name = database_name.UnqualifiedName,
                systems_schema_name = schema_name,
                systems_parent_name = parent_name,
                systems_parent_type = parent_type,
            })).ToDictionary(x => new SqlName(host_server_name, database_name, schema_name, parent_name, x.name)));

        public string DatabaseName
            => database.name;

        public systems.v_servers Server
            => host_server;

        public systems.v_databases Database
            => database;

        public IEnumerable<systems.v_schemas> Schemas
            => schemas.Values;

        public IEnumerable<systems.v_tables> Tables
            => tables.Values;

        public IEnumerable<systems.v_types> Types
            => types.Values;

        public IEnumerable<systems.v_views> Views
            => views.Values;

        public IEnumerable<systems.v_extended_properties> ExtendedProperties
            => extended_properties.Values;

        public IEnumerable<systems.v_table_indexes> TableIndexes
            => table_indexes.Values;

        public IEnumerable<systems.v_table_index_columns> TableIndexColumns
            => table_index_columns.Values;

        public IEnumerable<systems.v_table_columns> TableColumns
            => table_columns.Values.Where(c => equals(c.systems_parent_type, SqlObjectTypeCodes.U.TypeCode));

    }
}
