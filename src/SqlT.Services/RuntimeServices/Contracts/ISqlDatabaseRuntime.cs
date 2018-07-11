//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    
    using sx = SqlT.Syntax.SqlSyntax;


    /// <summary>
    /// Provides access to database-centric runtime capabilities
    /// </summary>
    public interface ISqlDatabaseRuntime : ISqlElementRuntime, ICatalogViews
    {
        /// <summary>
        /// Specifies the hosting server
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

        ISqlTableRuntime Table(SqlTableName name);

        ISqlSchemaHandle Schema(SqlSchemaName name);

        IEnumerable<ISqlSchemaHandle> Schemas { get; }

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

        Option<SqlSequence> CreateSequence(SqlSequenceName SequenceName, SqlTypeName TypeName);

        /// <summary>
        /// Creates a schema in the represented database if it does not exist
        /// </summary>
        /// <param name="name">The schema name</param>
        /// <returns></returns>
        Option<ConditionalCreateResult> CreateSchemaIfMissing(SqlSchemaName name);

        IEnumerable<sx.xprop_value> ExtendedProperties { get; }

        /// <summary>
        /// Enables service broker capabilities in the database
        /// </summary>
        /// <returns></returns>
        Option<int> EnableBroker();

        /// <summary>
        /// Sisables service broker capabilities in the database
        /// </summary>
        /// <returns></returns>
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
