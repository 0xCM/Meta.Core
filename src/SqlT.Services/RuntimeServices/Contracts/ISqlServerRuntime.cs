//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;
    using SqlT.Language;

    public interface ISqlServerRuntime : ISqlElementRuntime
    {
        ISystemViewProvider SystemViews { get; }

        Option<SqlServerInstanceDescription> DescribeServer();

        Option<SqlElementExists> HasLinkedServer(SqlServerName name);

        IReadOnlyList<vDatabase> DatabaseCatalog { get; }

        IReadOnlyList<vDatabaseFileInfo> DatabaseFileCatalog { get; }

        Option<int> DropLinkedServer(SqlServerName name);

        Option<SqlVersion> GetServerVersion();

        Option<int> TakeDatabaseOffline(SqlDatabaseName name);

        Option<int> BringDatabaseOnline(SqlDatabaseName name);

        Option<int> AttachDatabase(SqlDatabaseName DbName, FilePath DataFile, FilePath LogFile);

        Option<SqlDataFrame> Select(string sql);

        Option<int> Execute(string sql);

        ScalarResult<T> CallScalarFunction<T>(SqlFunctionName f, params object[] args);

        ScalarResult<T> ExecuteScalarScript<T>(string sql, params (string, object)[] args);

        Option<int> Execute(SqlProcedureName procedure, params (string,object)[] args);

        Option<SqlVariant?> ServerProperty(SqlServerPropertyName name);

        Option<LinkedServerDescription> LinkServer(SqlLinkedServer server, bool ifNotExists);

        Option<ISqlDatabaseHandle> CreateDatabase(SqlDatabase model);

        Option<ISqlDatabaseHandle> CreateDatabaseIfMissing(SqlDatabase model);

        Option<int> SetSingleUser(SqlDatabaseName name);

        Option<int> SetMultiUser(SqlDatabaseName name);

        Option<int> Backup(SqlDatabaseName DbName, FilePath DstPath, bool noFormat = true, bool init = true,
                    bool compression = true, int stats = 1, SqlName LogicalName = null);

        Task<Option<int>> BackupAsync(SqlDatabaseName DbName, FilePath DstPath, 
            SqlNotificationObserver Observer = null,  bool noFormat = true, bool init = true,
                    bool compression = true, int stats = 1, SqlName LogicalName = null);

        Option<int> RestoreDatabase(SqlRestoreDatabase spec);

        Option<int> DropServerTrigger(SqlServerTriggerName TriggerName);

        ISqlDatabaseRuntime Database(SqlDatabaseName DbName);
    }
}