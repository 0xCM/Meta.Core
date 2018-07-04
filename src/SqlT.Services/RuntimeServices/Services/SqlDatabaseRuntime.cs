﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;
    using SqlT.Language;
    using SqlT.Syntax;

    using static metacore;

    using static SqlT.Syntax.SqlSyntax;    
    using static SqlT.Syntax.sql;

    using kwt = SqlT.Syntax.SqlKeywordTypes;

    ///<summary>
    /// Implements database runtime commands
    ///</summary> 
    class SqlDatabaseRuntime : SqlElementRuntime<SqlDatabaseRuntime, ISqlDatabaseHandle>, ISqlDatabaseRuntime
    {
       
        public SqlDatabaseRuntime(IApplicationContext C, ISqlDatabaseHandle Handle)
            : base(C, Handle)
        {
            this.Server = C.SqlRuntimeProvider().Server(Handle.Server());
        }

        public ISqlServerRuntime Server { get; }

        IEnumerable<ISqlSequenceHandle> SequenceHandles
            => from v in Handle.SystemViews().GetVirtualView<vSequence>()
               select new SqlSequenceHandle(Handle.Broker, new SqlSequenceName(v.SchemaName, v.Name));


        SqlVersion ISqlDatabaseRuntime.CompatibilityVersion
            => Handle.GetCompatibilityVersion().Require();

        ISystemViewProvider ISqlDatabaseRuntime.SystemViews
            => Handle.SystemViews();

        IEnumerable<ISqlTableRuntime> ISqlDatabaseRuntime.Tables
            => from h in Tables()
               select SqlRuntime.Table(h);

        IEnumerable<ISqlSequenceRuntime> ISqlDatabaseRuntime.Sequences
            => from h in Sequences()
               select SqlRuntime.Sequence(h);

        IEnumerable<ISqlSchemaHandle> Schemas()
            => from t in Handle.SystemViews().GetVirtualView<vSchema>()
               select new SqlSchemaHandle(Broker, new SqlSchemaName(t.Name));

        IEnumerable<ISqlSequenceHandle> Sequences()
            => from t in Handle.SystemViews().GetVirtualView<vSequence>()
               select new SqlSequenceHandle(Broker, new SqlSequenceName(t.SchemaName, t.Name));

        Option<SqlElementExists> ISqlDatabaseRuntime.Exists()
            => Handle.ExecuteScalarScript<int>(Handle.DatabaseName.SQL_EXISTS())
                .TryMapValue(yes => yes == 1 ? SqlElementExists.Yes : SqlElementExists.No);

        Option<int> ISqlDatabaseRuntime.RenameFilestreamDirectory(FolderName NewName)
        {
            var DatabaseName = Handle.DatabaseName.UnquotedLocalName;
            var sql = $"{ALTER} {DATABASE} [{DatabaseName}] {SET} {FILESTREAM}({DIRECTORY_NAME} = '{NewName}') {WITH} {NO_WAIT}";            
            return Broker.ExecuteNonQuery(sql);
        }

        Option<int> ISqlDatabaseRuntime.TakeOffline()
            => Server.TakeDatabaseOffline(Database.Name);

        ISqlTableRuntime ISqlDatabaseRuntime.Table(SqlTableName name)
            => SqlRuntime.Table(Handle.Table(name));

        ISqlSchemaHandle ISqlDatabaseRuntime.Schema(SqlSchemaName name)
            => Handle.Schema(name);


        Option<int> EnableBroker(bool enable)
        {
            var sql = $"alter database [{Handle.DatabaseName}] set "
                + (enable
                    ? "enable_broker"
                    : "disable_broker");
            return Broker.ExecuteNonQuery(sql).ToOption();
        }

        Option<int> ISqlDatabaseRuntime.EnableBroker()
            => EnableBroker(true);

        Option<int> ISqlDatabaseRuntime.DisableBroker()
            => EnableBroker(false);

        Option<SqlSchema> ISqlDatabaseRuntime.CreateSchema(SqlSchemaName name)
        {
            var schema = new SqlSchema(name);
            var statement = create(SCHEMA, name);
            var tSql = statement.TSqlCreate();
            var script = tSql.GenerateScript();
            return Broker.ExecuteNonQuery(script).MapValueOrElse(_ => schema, msg => none<SqlSchema>(msg.ToApplicationMessage()));
        }

        ISqlSequenceRuntime ISqlDatabaseRuntime.Sequence(SqlSequenceName name)
            => SqlRuntime.Sequence(Handle.Sequence(name));

        Option<ConditionalCreateResult> ISqlDatabaseRuntime.CreateSchemaIfMissing(SqlSchemaName name)
            => Handle.Schema(name).CreateIfMissing();

        IEnumerable<ISqlSchemaHandle> ISqlDatabaseRuntime.Schemas
            => Schemas();

        IEnumerable<ISqlTableHandle> Tables()
            => from t in Handle.SystemViews().GetVirtualView<vTable>()
               select new SqlTableHandle(Broker, new SqlTableName(t.SchemaName, t.Name));

        IReadOnlyList<vSequence> ISqlDatabaseRuntime.SequenceCatalog
            => Handle.SystemViews().GetVirtualView<vSequence>();

        IEnumerable<xprop_value> ISqlDatabaseRuntime.ExtendedProperties
            => from prop in Handle.SystemViews().GetNativeView<IExtendedProperty>()
               where prop.@class == 0 && prop.major_id == 0 && prop.minor_id == 0
               let name = SqlExtendedPropertyName.Parse(prop.name)
               let val = new SqlVariant(prop.value)
               select kwt.DATABASE.get().XProp(name, val);

        IReadOnlyList <vTable> ISqlDatabaseRuntime.TableCatalog 
            => Handle.SystemViews().GetVirtualView<vTable>();

        IReadOnlyList<vTableType> ISqlDatabaseRuntime.TableTypeCatalog
            => Handle.SystemViews().GetVirtualView<vTableType>();

        IReadOnlyList<vView> ISqlDatabaseRuntime.ViewCatalog
            => Handle.SystemViews().GetVirtualView<vView>();

        IReadOnlyList<vTableFunction> ISqlDatabaseRuntime.TableFunctionCatalog
            => Handle.SystemViews().GetVirtualView<vTableFunction>();

        IReadOnlyList<vPrimaryKey> ISqlDatabaseRuntime.PrimaryKeyCatalog
            => Handle.SystemViews().GetVirtualView<vPrimaryKey>();

        public IReadOnlyList<vIndex> IndexCatalog
            => Handle.SystemViews().GetVirtualView<vIndex>();

        ISqlDatabaseRuntime Self
            => this;

        SqlDatabaseName ISqlDatabaseRuntime.Name
            => Handle.DatabaseName;

        IEnumerable<SqlTableName> ISqlDatabaseRuntime.TableNames
            => from t in Self.TableCatalog
               select t.ObjectName.AsTableName();

        IEnumerable<SqlViewName> ISqlDatabaseRuntime.ViewNames
            => from t in Self.ViewCatalog
               select t.ObjectName.AsViewName();

        IEnumerable<SqlSequenceName> ISqlDatabaseRuntime.SequenceNames
            => from t in Self.SequenceCatalog
               select t.ObjectName.AsSequenceName();

        IReadOnlyList<vIndex> ISqlDatabaseRuntime.IndexCatalog
            => Handle.SystemViews().GetVirtualView<vIndex>();

        IReadOnlyList<vIndexColumn> ISqlDatabaseRuntime.IndexColumnCatalog
            => Handle.SystemViews().GetVirtualView<vIndexColumn>();

        /// <summary>
        /// Shrinks the size of the specified data or log file for the current database, 
        /// or empties a file by moving the data from the specified file to other files in the same 
        /// filegroup, allowing the file to be removed from the database. You can shrink a file to 
        /// a size that is less than the size specified when it was created. This resets 
        /// the minimum file size to the new value.
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/ms189493.aspx
        /// </remarks>
        public Option<SqlShrinkFileResult> ShrinkFile(SqlFileName filename, int targetSize = 0, bool truncateOnly = true)
        {
            var command = shrinkfile(filename, targetSize, truncateOnly);
            var sql = command.FormatSyntax();
            var result = Broker.Select<SqlShrinkFileResult>(sql);
            return result.Map(r => r.FirstOrDefault());
        }
    }
}
    