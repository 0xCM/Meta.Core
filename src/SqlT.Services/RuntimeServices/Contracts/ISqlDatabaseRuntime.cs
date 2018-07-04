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

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;

    using sx = SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Provides access to database-centric runtime capabilities
    /// </summary>
    public interface ISqlDatabaseRuntime : ISqlElementRuntime
    {
        /// <summary>
        /// Specifies the names of the tables defined by the database
        /// </summary>
        IEnumerable<SqlTableName> TableNames { get; }

        /// <summary>
        /// Specifies the names of the views defined by the database
        /// </summary>
        IEnumerable<SqlViewName> ViewNames { get; }

        /// <summary>
        /// Specifies the names of the sequences defined by the database
        /// </summary>
        IEnumerable<SqlSequenceName> SequenceNames { get; }

        /// <summary>
        /// The server hosting the database
        /// </summary>
        ISqlServerRuntime Server { get; }

        /// <summary>
        /// The name of the database
        /// </summary>
        SqlDatabaseName Name { get; }

        /// <summary>
        /// The configured compatibility version
        /// </summary>
        SqlVersion CompatibilityVersion { get; }

        ISystemViewProvider SystemViews { get; }

        IEnumerable<ISqlTableRuntime> Tables { get; }

        IEnumerable<ISqlSequenceRuntime> Sequences { get; }

        ISqlSequenceRuntime Sequence(SqlSequenceName name);

        IReadOnlyList<vTable> TableCatalog { get; }

        IReadOnlyList<vTableType> TableTypeCatalog{ get; }

        IReadOnlyList<vView> ViewCatalog { get; }

        IReadOnlyList<vTableFunction> TableFunctionCatalog { get; }

        IReadOnlyList<vPrimaryKey> PrimaryKeyCatalog { get; }

        ISqlTableRuntime Table(SqlTableName name);

        ISqlSchemaHandle Schema(SqlSchemaName name);

        IEnumerable<ISqlSchemaHandle> Schemas { get; }

        IReadOnlyList<vSequence> SequenceCatalog { get; }

        IReadOnlyList<vIndex> IndexCatalog { get; }

        IReadOnlyList<vIndexColumn> IndexColumnCatalog { get; }

        /// <summary>
        /// Determines whether the represented database exists
        /// </summary>
        /// <returns></returns>
        Option<SqlElementExists> Exists();

        /// <summary>
        /// Creates a schema in the represented database
        /// </summary>
        /// <param name="name">The schema name</param>
        /// <returns></returns>
        Option<SqlSchema> CreateSchema(SqlSchemaName name);

        /// <summary>
        /// Creates a schema in the represented database if it does not exist
        /// </summary>
        /// <param name="name">The schema name</param>
        /// <returns></returns>
        Option<ConditionalCreateResult> CreateSchemaIfMissing(SqlSchemaName name);


        IEnumerable<sx.xprop_value> ExtendedProperties { get; }

        Option<int> EnableBroker();

        Option<int> DisableBroker();

        /// <summary>
        /// Takes the represented database offline
        /// </summary>
        /// <returns></returns>
        Option<int> TakeOffline();

        Option<int> RenameFilestreamDirectory(FolderName NewName);

        /// <summary>
        /// Invokes the DBCC shrinkfile command on the represented database
        /// </summary>
        /// <param name="filename">The name of the file to shrink</param>
        /// <param name="targetSize">The desired size</param>
        /// <param name="truncateOnly">Wheter to shrik only by truncation as opposed to page reorganization</param>
        /// <returns></returns>
        Option<SqlShrinkFileResult> ShrinkFile(SqlFileName filename, int targetSize = 0, 
            bool truncateOnly = true);
    }
}
