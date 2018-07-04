//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;

    public class SqlSystemViews : ISystemViewProvider
    {
        public static ISystemViewProvider Create(SystemViewsSettings settings)
            => new SqlSystemViews(settings);

        readonly NativeViewProvider sysviews;

        readonly ConcurrentDictionary<Type, object> syscache;
        readonly ConcurrentDictionary<Type, object> virtcache;
        readonly IReadOnlyDictionary<Type, Func<IEnumerable<vSystemElement>>> virtviews;
        readonly IReadOnlySet<string> searchedSchemas;

        readonly IReadOnlyList<vSystemPrimitive> system_primitives;
        readonly IReadOnlyList<vUserPrimitive> user_primitives;
        readonly IReadOnlyList<vAssemblyType> assembly_types;
        readonly IReadOnlyList<vType> primitives;
        readonly IReadOnlyList<vTableType> table_types;
        readonly IReadOnlyList<vType> all_types;

        readonly SystemViewsSettings settings;

        vType find_type(int user_type_id)
            => all_types.Single(x => x.UserTypeId == user_type_id);

        bool ExcludeSystemObjects
            => settings.Filter.ExcludeSystemObjects;

        IReadOnlyList<T> sysview<T>(string name = "")
                where T : ISystemElement
            => sysviews.GetNativeView<T>(name);

        IReadOnlyList<T> virtview<T>() where T : vSystemElement
        {
            var query = (IEnumerable<T>)virtviews[typeof(T)]();
            return
                (IReadOnlyList<T>)virtcache.GetOrAdd(typeof(T), t => list(query));
        }

        IReadOnlyList<ISystemObject> sys_objects()
            => sysview<ISystemObject>();

        IReadOnlyList<ISystemObject> sys_all_objects()
            => sysview<ISystemObject>(SystemViewNames.all_objects);

        IReadOnlyList<IType> sys_types()
            => sysview<IType>();

        IReadOnlyList<IView> sys_views()
            => sysview<IView>();

        IReadOnlyList<IView> sys_all_views()
            => sysview<IView>(SystemViewNames.all_views);

        IReadOnlyList<ITableType> sys_table_types()
            => sysview<ITableType>();

        IReadOnlyList<ISchema> sys_schemas()
            => sysview<ISchema>();

        IReadOnlyList<ITable> sys_tables()
            => sysview<ITable>();

        IReadOnlyList<IFileTable> sys_filetables()
            => sysview<IFileTable>();
        IReadOnlyList<ISystemMessage> sys_messages()
            => sysview<ISystemMessage>();

        IReadOnlyList<IColumn> sys_columns()
            => sysview<IColumn>();

        IReadOnlyList<IColumn> sys_all_columns()
            => sysview<IColumn>(SystemViewNames.all_columns);

        IReadOnlyList<IForeignKey> sys_foreign_keys()
            => sysview<IForeignKey>();

        IReadOnlyList<IForeignKeyColumn> sys_foreign_key_columns()
            => sysview<IForeignKeyColumn>();

        IReadOnlyList<IIndexColumn> sys_index_columns()
            => sysview<IIndexColumn>();

        IReadOnlyList<IIndex> sys_indexes()
            => sysview<IIndex>();

        IReadOnlyList<IParameter> sys_parameters()
            => sysview<IParameter>();

        IReadOnlyList<IParameter> sys_all_parameters()
            => sysview<IParameter>(SystemViewNames.all_parameters);

        IReadOnlyList<IProcedure> sys_procedures()
            => sysview<IProcedure>(SystemViewNames.procedures);

        IReadOnlyList<IExtendedProperty> sys_extended_properties()
            => sysview<IExtendedProperty>();

        IReadOnlyList<ISequence> sys_sequences()
            => sysview<ISequence>();

        IReadOnlyList<IDatabase> sys_databases()
            => sysview<IDatabase>();

        IReadOnlyList<IMasterFile> sys_master_files()
            => sysview<IMasterFile>();

        IReadOnlyList<IServiceMessageType> sys_service_message_types()
            => sysview<IServiceMessageType>();

        IReadOnlyList<IParameter> sys_selected_parameters()
            => ExcludeSystemObjects ? sys_parameters() : sys_all_parameters();

        IReadOnlyList<IProcedure> sys_all_procedures()
            => rolist(from o in sys_all_objects()
                    where   o.type.Trim() == SqlObjectTypeCodes.P.TypeCode
                    select new all_procedures(o));

        IReadOnlyList<IProcedure> sys_selected_procedures()
            => ExcludeSystemObjects ? sys_procedures() : sys_all_procedures();

        IEnumerable<ISystemObject> sys_primary_key_objects()
            => from o in sys_objects()
               where o.type == SqlObjectTypeCodes.PK.TypeCode
               select o;

        IEnumerable<IExtendedProperty> properties(int majorid)
            => from p in sys_extended_properties()
               where p.major_id == majorid
               select p;

        IEnumerable<IExtendedProperty> properties(int majorid, int minorid)
            => from p in properties(majorid)
               where p.minor_id == minorid
               select p;

        IReadOnlyList<IView> sys_selected_views()
            => ExcludeSystemObjects ? sys_views() : sys_all_views();

        IReadOnlyList<ISystemObject> sys_selected_objects()
            => ExcludeSystemObjects
            ? sys_objects().Where(x => x.is_user_defined).ToList()
            : sys_all_objects();

        IExtendedProperty property(int majorid, int minorid, string name)
            => properties(majorid, minorid).FirstOrDefault(p => p.name == name);

        IReadOnlyList<IColumn> sys_selected_columns()
            => ExcludeSystemObjects
            ? sys_columns()
            : sys_all_columns();

        IEnumerable<vColumn> columns()
            => from c in sys_selected_columns()
               join o in sys_selected_objects() on c.object_id equals o.object_id
               join s in sys_schemas() on o.schema_id equals s.schema_id
               join t in primitives on c.user_type_id equals t.UserTypeId
               select new vColumn(s, o, c, t, properties(o.object_id, c.column_id));

        IEnumerable<vDatabaseFileInfo> db_file_infos()
            => from mf in sys_master_files()
               join db in sys_databases() on mf.database_id equals db.database_id
               select new vDatabaseFileInfo(db.name, mf.name, mf.physical_name, mf.size, mf.type == 0, mf.type == 1);

        IEnumerable<vColumn> columns(int parent_id)
            => virtview<vColumn>().Where(x => x.ParentId == parent_id);

        IEnumerable<vPrimaryKeyColumn> primary_key_columns()
            => from ix in sys_indexes()
               join ixc in sys_index_columns()
                   on new { ix.object_id, ix.index_id } equals new { ixc.object_id, ixc.index_id }
               join c in sys_columns()
                   on new { ixc.object_id, ixc.column_id } equals new { c.object_id, c.column_id }
               join t in sys_tables() on c.object_id equals t.object_id
               join s in sys_schemas() on t.schema_id equals s.schema_id
               where ix.is_primary_key == true
               select new vPrimaryKeyColumn
               (
                   schema: s,
                   parent: t,
                   index: ix,
                   parentcol: c,
                   coldataType: find_type(c.user_type_id),
                   indexcol: ixc,
                   properties: properties(ix.object_id)
                 );

        IEnumerable<vIndexColumn> index_columns()
            => from ix in sys_indexes()
               join ixc in sys_index_columns()
                   on new { ix.object_id, ix.index_id } equals new { ixc.object_id, ixc.index_id }
               join c in sys_columns()
                   on new { ixc.object_id, ixc.column_id } equals new { c.object_id, c.column_id }
               join t in sys_tables() on c.object_id equals t.object_id
               join s in sys_schemas() on t.schema_id equals s.schema_id
               select new vIndexColumn
               (
                   schema: s,
                   parent: t,
                   index: ix,
                   parentcol: c,
                   colDataType: find_type(c.user_type_id),
                   indexcol: ixc,
                   properties: properties(ix.index_id, ixc.index_column_id)
                );

        IEnumerable<vIndexColumn> index_columns(int parent_schema_id, int parent_id, int index_id)
            => from c in virtview<vIndexColumn>()
               where
                    c.ParentSchemaId == parent_schema_id
               && c.ObjectId == parent_id
               && c.IndexId == index_id
               orderby c.IndexColumnPosition
               select c;

        IEnumerable<vPrimaryKeyColumn> primary_key_columns(int parent_schema_id, int parent_id)
            => from c in virtview<vPrimaryKeyColumn>()
               where c.ParentSchemaId == parent_schema_id
                  && c.ParentId == parent_id
               orderby c.KeyColumnPosition
               select c;

        IEnumerable<vPrimaryKey> primary_keys()
            => from ix in sys_indexes()
               join t in sys_tables() on ix.object_id equals t.object_id
               join s in sys_schemas() on t.schema_id equals s.schema_id
               join pko in sys_primary_key_objects() on t.object_id equals pko.parent_object_id
               where ix.is_primary_key == true
               select new vPrimaryKey(s, t, pko, ix,
                   primary_key_columns(s.schema_id, t.object_id),
                   properties(pko.object_id));

        IEnumerable<vForeignKeyColumn> foreign_key_columns()
            => from c in sys_foreign_key_columns()
               select new vForeignKeyColumn(null, null, null, null, null, null, null, null, null);

        IEnumerable<vForeignKey> foreign_keys()
           => from fk in sys_foreign_keys()
              join sfk in sys_schemas() on fk.schema_id equals sfk.schema_id
              join tClient in sys_tables() on fk.parent_object_id equals tClient.object_id
              join sClient in sys_schemas() on tClient.schema_id equals sClient.schema_id
              join tSupplier in sys_tables() on fk.referenced_object_id equals tSupplier.object_id
              join sSupplier in sys_schemas() on tSupplier.schema_id equals sSupplier.schema_id
              select new vForeignKey(sfk, fk, sClient, tClient, sSupplier, tSupplier,
                    rolist(foreign_key_columns()),
                    properties(fk.object_id, tClient.object_id));

        IEnumerable<vIndex> indexes()
            => from ix in sys_indexes()
               where (SqlIndexType)ix.type != SqlIndexType.Heap
               join t in sys_tables() on ix.object_id equals t.object_id
               join s in sys_schemas() on t.schema_id equals s.schema_id
               select new vIndex(s, t, ix,
                   index_columns(s.schema_id, t.object_id, ix.index_id),
                   properties(ix.object_id, ix.index_id));

        IEnumerable<vTable> tables()
            => from t in sys_tables()
               join s in sys_schemas() on t.schema_id equals s.schema_id
               select new vTable(s, t, columns(t.object_id), properties(t.object_id));

        IEnumerable<vFileTable> filetables()
            => from f in sys_filetables()
               join t in sys_tables() on f.object_id equals t.object_id
               join s in sys_schemas() on t.schema_id equals s.schema_id
               select new vFileTable(s, f, t, columns(t.object_id), properties(t.object_id));

        IEnumerable<vView> views()
            => from v in sys_selected_views()
               join s in sys_schemas() on v.schema_id equals s.schema_id
               select new vView(s, v, columns(v.object_id), properties(v.object_id));

        IEnumerable<vSequence> sequences()
            => from q in sys_sequences()
               join s in sys_schemas() on q.schema_id equals s.schema_id
               join t in primitives on q.user_type_id equals t.UserTypeId
               select new vSequence(s, q, t, properties(q.object_id));

        IEnumerable<vParameter> parameters()
            => from p in sys_selected_parameters()
               join o in sys_selected_objects() on p.object_id equals o.object_id
               join s in sys_schemas() on o.schema_id equals s.schema_id
               join t in all_types on p.user_type_id equals t.UserTypeId
               select new vParameter(s, o, p, t, properties(o.object_id, p.parameter_id));

        IEnumerable<vServiceMessageType> service_message_types()
            => ExcludeSystemObjects ?
            from t in sys_service_message_types()
            where t.is_user_defined == true
            select new vServiceMessageType(t.name, t.message_type_id, t.principal_id,
                t.validation, t.validation_desc, t.xml_collection_id, t.is_user_defined)
            : from t in sys_service_message_types()
              select new vServiceMessageType(t.name, t.message_type_id, t.principal_id,
                  t.validation, t.validation_desc, t.xml_collection_id, t.is_user_defined);

        IEnumerable<vParameter> parameters(int parent_id)
            => virtview<vParameter>().Where(x => x.ParentId == parent_id);

        IEnumerable<vProcedure> procedures()
            => from p in sys_selected_procedures()
               join s in sys_schemas() on p.schema_id equals s.schema_id
               select new vProcedure(s, p, parameters(p.object_id), properties(p.object_id));

        IEnumerable<vTableFunction> table_functions()
            => from o in sys_selected_objects()
               where o.is_user_defined == (ExcludeSystemObjects ? true : o.is_user_defined)
                   && (o.type == SqlObjectTypeCodes.IF.TypeCode
                       || o.type == SqlObjectTypeCodes.TF.TypeCode
                       || o.type == SqlObjectTypeCodes.FT.TypeCode)
               join s in sys_schemas() on o.schema_id equals s.schema_id
               select new vTableFunction(s, o, parameters(o.object_id), columns(o.object_id), properties(o.object_id));

        IEnumerable<vTableTypeColumn> table_type_columns(ITableType x)
            => from c in sys_selected_columns()
               where c.object_id == x.type_table_object_id
               let o = sys_objects().Single(tt => tt.object_id == x.type_table_object_id)
               join s in sys_schemas() on o.schema_id equals s.schema_id
               join t in primitives on c.user_type_id equals t.UserTypeId
               select new vTableTypeColumn(s, x, c, t, properties(x.user_type_id, c.column_id));

        IEnumerable<vTableTypeColumn> table_type_columns()
            => table_types.Select(t => table_type_columns(t)).Reduce();

        IEnumerable<vExtendedProperty> extended_properties()
            => sys_extended_properties().Select(p => new vExtendedProperty(p));

        /// <summary>
        /// Selects the system-defined primitives
        /// </summary>
        /// <remarks>
        /// The last bit of the query is to deal with the weirdness involved when
        /// SQL Server ships with a custom primitive, which by definition is not user-defined.
        /// For example, the sysname type which constraints nvarchar to a maximum length of 128
        /// and disallows nulls
        /// </remarks>
        IReadOnlyList<vSystemPrimitive> get_system_primitives()
            => rolist(from t in sys_types()
                    join s in sys_schemas() on t.schema_id equals s.schema_id
                    where t.user_type_id == t.system_type_id
                        || (t.user_type_id != t.system_type_id
                             && not(t.is_user_defined)
                             && not(t.is_assembly_type)
                            )
                    select new vSystemPrimitive(s, t));

        IReadOnlyList<vUserPrimitive> get_user_primitives()
            => rolist(from t in sys_types()
                    join s in sys_schemas() on t.schema_id equals s.schema_id
                    where t.is_user_defined && system_primitives.Select(p => p.SystemTypeId).Contains(t.system_type_id)
                    let b = system_primitives.Where(x => x.SystemTypeId == t.system_type_id).Single(y => y.Name != "sysname")
                    select new vUserPrimitive(s, t, properties(t.system_type_id), b));

        IReadOnlyList<vAssemblyType> get_assembly_types()
            => rolist(from t in sys_types()
                    join s in sys_schemas() on t.schema_id equals s.schema_id
                    where t.is_assembly_type
                    select new vAssemblyType(s, t, properties(t.system_type_id)));

        IReadOnlyList<vTableType> get_table_types()
            => rolist(from t in sys_table_types()
                    join s in sys_schemas() on t.schema_id equals s.schema_id
                    select new vTableType(s, t, table_type_columns(t), properties(t.user_type_id)));

        IEnumerable<vSchema> schemas()
            => from s in sys_schemas()
               where s.is_user_defined == (ExcludeSystemObjects ? true : s.is_user_defined)
                  || s.name == "dbo"
               select new vSchema(s, properties(s.schema_id));

        IReadOnlyList<vDatabase> databases()
            => rolist(from db in sys_databases()
                    select new vDatabase(db, properties(0)));

        IReadOnlyDictionary<Type, Func<IEnumerable<vSystemElement>>> CreateViewIndex()
            => new Dictionary<Type, Func<IEnumerable<vSystemElement>>>
            {
                [typeof(vSchema)] = schemas,
                [typeof(vTable)] = tables,
                [typeof(vFileTable)] = filetables,
                [typeof(vView)] = views,
                [typeof(vPrimaryKeyColumn)] = primary_key_columns,
                [typeof(vPrimaryKey)] = primary_keys,
                [typeof(vType)] = () => primitives,
                [typeof(vSystemPrimitive)] = () => system_primitives,
                [typeof(vUserPrimitive)] = () => user_primitives,
                [typeof(vSequence)] = sequences,
                [typeof(vProcedure)] = procedures,
                [typeof(vParameter)] = parameters,
                [typeof(vTableFunction)] = table_functions,
                [typeof(vColumn)] = columns,
                [typeof(vTableType)] = () => table_types,
                [typeof(vIndexColumn)] = index_columns,
                [typeof(vIndex)] = indexes,
                [typeof(vTableTypeColumn)] = table_type_columns,
                [typeof(vDatabase)] = databases,
                [typeof(vDatabaseFileInfo)] = db_file_infos,
                [typeof(vServiceMessageType)] = service_message_types,
                [typeof(vExtendedProperty)] = extended_properties

            };

        SqlSystemViews(SystemViewsSettings settings)
        {
            this.settings = settings;
            this.sysviews = new NativeViewProvider(settings.Connector, settings.Source);
            this.syscache = new ConcurrentDictionary<Type, object>();
            this.virtcache = new ConcurrentDictionary<Type, object>();
            this.virtviews = CreateViewIndex();

            var allSchemas = setM(sys_schemas().Select(x => x.name));
            if (this.settings.Filter.IsActive)
            {
                if (this.settings.Filter.IncludedSchemas.Count != 0)
                    searchedSchemas = roset<string>(this.settings.Filter.IncludedSchemas);
                else if (this.settings.Filter.ExcludedSchemas.Count != 0)
                    searchedSchemas = setM(allSchemas.Where(x => not(this.settings.Filter.ExcludedSchemas.Contains(x))));
            }
            else
                searchedSchemas = allSchemas;

            this.system_primitives = get_system_primitives();
            this.user_primitives = get_user_primitives();
            this.primitives = rolist(system_primitives.Union(user_primitives.Cast<vType>()));
            this.table_types = get_table_types();
            this.assembly_types = get_assembly_types();
            this.all_types = rolist(union(primitives, table_types, assembly_types));


        }

        string ISystemViewProvider.HostServerName
            => settings.Connector.ServerName;

        string ISystemViewProvider.HostDatabaseName
            => settings.Connector.DatabaseName;

        IReadOnlyList<T> INativeViewProvider.GetNativeView<T>()
            => sysview<T>();

        IReadOnlyList<T> IVirtualViewProvider.GetVirtualView<T>()
            => virtview<T>();
    }
}
