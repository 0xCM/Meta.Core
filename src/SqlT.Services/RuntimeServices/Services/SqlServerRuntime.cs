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
    using SqlT.SqlSystem;
    using System.Threading.Tasks;

    using Meta.Core;

    using SqlT.Syntax;
    using SqlT.Language;

    using static SqlT.Syntax.SqlSyntax;
    using static metacore;

    class SqlServerRuntime : SqlElementRuntime<SqlServerRuntime, ISqlServerHandle>, ISqlServerRuntime
    {
        static string ifTrue(bool criterion, Func<string> f)
            => criterion ? f() : string.Empty;

        static string option(bool criterion, object s, bool prefix = true)
            => criterion ?$", {s}" : string.Empty;

        static string option(string s, bool prefix = true)
            => prefix ? $", {s}" : string.Empty;

        static string assign(object x, object y)
            => $"{x} = {y}";
        static (string, object) sqlparam(string name, object value)
            => (name.StartsWith("@") ? name : "@" + name, value);

        public SqlServerRuntime(IApplicationContext C, ISqlServerHandle Handle)
            : base(C, Handle)
        {

        }

        ISystemViewProvider ISqlServerRuntime.SystemViews
            => SystemViews;

        Option<int> exec(string sql)
            => Broker.ExecuteNonQuery(sql);

        Option<int> ISqlServerRuntime.BringDatabaseOnline(SqlDatabaseName DbName)
            => exec(join(eol(), BringDatabaseOnlineSql(DbName)));

        Option<SqlServerInstanceDescription> ISqlServerRuntime.DescribeServer()
            => SqlMetadataCollector.DescribeServer(Broker, Handle.ServerName);

        Option<int> ISqlServerRuntime.DropLinkedServer(SqlServerName name)
            => Broker.ExecuteProcedure(new SqlProcedureName("dbo", "sp_dropserver"),
                sqlparam("server", Handle.ServerName.UnqualifiedName),
                sqlparam("droplogins", "droplogins"));

        Option<int> ISqlServerRuntime.Execute(string sql)
            => exec(sql);

        ScalarResult<T> ISqlServerRuntime.CallScalarFunction<T>(SqlFunctionName f, params object[] args)
            => ExecuteScalarFunction<T>(f, args);

        ScalarResult<T> ExecuteScalarScript<T>(string sql, params (string, object)[] args)
            => Broker.ExecuteScalarScript<T>(sql, args);

        ScalarResult<T> ISqlServerRuntime.ExecuteScalarScript<T>(string sql, params (string, object)[] args)
            => ExecuteScalarScript<T>(sql, 
                    args.Select(a => (a.Item1, a.Item2)).ToArray());

        Option<int> ISqlServerRuntime.Execute(SqlProcedureName procedure, params (string, object)[] args)
            => Broker.ExecuteProcedure(procedure, args.Select(a => (a.Item1, a.Item2)).ToArray());

        Option<SqlVersion> ISqlServerRuntime.GetServerVersion()
        {
            var sql = new SqlDatabaseName(Handle.ServerName, "model").SQL_COMPATIBILITY_LEVEL();
            return ExecuteScalarScript<byte>(sql).TryMapValue(x => ((SqlVersionIndicator)x).GetVersion());
        }

        public Option<SqlElementExists> HasLinkedServer(SqlServerName name)
            => Broker.LinkedServer(name).Exists();

        Option<LinkedServerDescription> ISqlServerRuntime.LinkServer(SqlLinkedServer model, bool conditional)
        {

            var h = this.Handle;
            var exists = HasLinkedServer(model.ServerName.UnqualifiedName) == SqlElementExists.Yes;
            if (conditional && exists)
                return new LinkedServerDescription(h.ServerName, h.Broker.LinkedServer(model.ServerName), false);

            var product = model.ServerProduct ? (isBlank(~model.ServerProduct) ? null : ~model.ServerProduct) : null;
            var provider = model.Provider ? (isBlank(~model.Provider) ? null : ~model.Provider) : null;
            var datasrc = model.DataSource ? (isBlank(~model.DataSource) ? null : ~model.DataSource) : null;
            return
                from serverName in some(model.ServerName.UnqualifiedName)
                from x in h.Broker.ExecuteProcedure(new SqlProcedureName("dbo", "sp_addlinkedserver"),
                            sqlparam("server", serverName),
                            sqlparam("srvproduct", product),
                            sqlparam("provider", provider),
                            sqlparam("datasrc", datasrc))
                from y in h.Broker.ExecuteProcedure(new SqlProcedureName("dbo", "sp_addlinkedsrvlogin"),
                            sqlparam("rmtsrvname", serverName),
                            sqlparam("useself", "False"),
                            sqlparam("rmtuser", model.RemoteUser.MapValueOrDefault(u => u.ElementName)),
                            sqlparam("rmtpassword", model.RemoteUser.MapValueOrDefault(u => u.Password)))
                select new LinkedServerDescription(h.ServerName, new SqlLinkedServerHandle(h.Broker, serverName), true);

        }

        Option<SqlDataFrame> ISqlServerRuntime.Select(string sql)
            => Broker.Select(sql);

        Option<SqlVariant?> ISqlServerRuntime.ServerProperty(SqlServerPropertyName PropertyName)
        {
            var sql = $"{SELECT} {SERVERPROPERTY}({squote(PropertyName)})";
            return Broker.ExecuteScalarScript(sql).MapValueOrDefault(value => SqlVariant.FromObject(value));             
        }

        Option<int> ISqlServerRuntime.TakeDatabaseOffline(SqlDatabaseName DbName)
            => exec($"{ALTER} {DATABASE} {DbName.TrimServer().Format(true)} {SET} {OFFLINE} {WITH} {ROLLBACK} {IMMEDIATE}");

        Option<ISqlDatabaseHandle> ISqlServerRuntime.CreateDatabase(SqlDatabase definition)
            => Broker.Database(definition.Name).Create(definition);

        Option<ISqlDatabaseHandle> ISqlServerRuntime.CreateDatabaseIfMissing(SqlDatabase definition)
            => CreateIfMissing(Broker.Database(definition.Name), definition);

        Option<ISqlDatabaseHandle> CreateIfMissing(ISqlDatabaseHandle h, SqlDatabase definition)
            => from x in h.Exists().Map(exists => exists == SqlElementExists.No ? h.Create(definition) : some(h))
               select h;

        Option<int> ISqlServerRuntime.SetSingleUser(SqlDatabaseName DbName)
            => exec($"{ALTER} {DATABASE} {DbName} {SET} {SINGLE_USER} {WITH} {ROLLBACK} {IMMEDIATE}");        

        Option<int> ISqlServerRuntime.SetMultiUser(SqlDatabaseName DbName)
            => exec($"{ALTER} {DATABASE} {DbName} {SET} {MULTI_USER}");

        Option<int> ISqlServerRuntime.DropServerTrigger(SqlServerTriggerName TriggerName)
            => exec($"{DROP} {TRIGGER} {TriggerName} {ON} {ALL} {SERVER}");

        Option<int> ISqlServerRuntime.AttachDatabase(SqlDatabaseName DbName, FilePath DataFile, FilePath LogFile)
            => exec($"{CREATE} {DATABASE} {ON} ({FILENAME} = {squote(DataFile)}) ({FILENAME} = {squote(LogFile)}) {FOR} {ATTACH}");

        IEnumerable<string> BringDatabaseOnlineSql(SqlDatabaseName DbName)
        {
            var formatted = DbName.TrimServer().Format(true);
            yield return $"{ALTER} {DATABASE} {DbName} {SET} {SINGLE_USER} {WITH} {ROLLBACK} {IMMEDIATE}";
            yield return $"{ALTER} {DATABASE} {DbName} {SET} {ONLINE}";
            yield return $"{ALTER} {DATABASE} {DbName} {SET} {MULTI_USER}";
        }

        SqlScript BackupSql(SqlDatabaseName DbName, FilePath DstPath, bool noFormat, bool init,
            bool compression, int stats, SqlName LogicalName)
        {
            var lName = squote(LogicalName?.Format(false)
                       ?? $"{DbName.Format(false)}.Backup");
            var options = assign(NAME, lName);
            options += option(noFormat, NOFORMAT);
            options += option(init, INIT);
            options += option(compression, COMPRESSION);
            options += option(assign(STATS, stats));
            var sql = $"{BACKUP} {DATABASE} {bracket(DbName)} {TO} {DISK} = {squote(DstPath)} {WITH} {options}";
            return sql;
        }

        ISystemViewProvider SystemViews
            => SqlSystemViews.Create(new SystemViewsSettings
                (
                    Broker.ConnectionString,
                    Source: new SqlDatabaseName(Handle.ServerName, "master")
                ));


        ScalarResult<T> ExecuteScalarFunction<T>(SqlFunctionName f, params object[] args)
                => Broker.ExecuteScalarFunction<T>(f, args);

        public IReadOnlyList<vDatabaseFileInfo> DatabaseFileCatalog
            => SystemViews.GetVirtualView<vDatabaseFileInfo>();

        public IReadOnlyList<vDatabase> DatabaseCatalog
            => SystemViews.GetVirtualView<vDatabase>();

        public Option<int> Backup(SqlDatabaseName DbName, FilePath DstPath, bool noFormat = true, bool init = true,
            bool compression = true, int stats = 1, SqlName LogicalName = null)
            => BackupAsync(DbName, DstPath, null, noFormat, init, compression, stats, LogicalName).Result;

        public Task<Option<int>> BackupAsync(SqlDatabaseName DbName, FilePath DstPath, SqlNotificationObserver Observer = null,
            bool noFormat = true, bool init = true, bool compression = true, int stats = 1, SqlName LogicalName = null)
        {
            DstPath.Folder.CreateIfMissing();
            var sql = BackupSql(DbName, DstPath, noFormat, init, compression, stats, LogicalName);
            return Handle.Broker.ExecuteNonQueryAsync(sql, Observer);
        }

        public Option<int> RestoreDatabase(SqlRestoreDatabase spec)
            => Broker.ExecuteNonQuery(SqlGenerator.GenerateScript(spec));

        public new ISqlDatabaseRuntime Database(SqlDatabaseName DbName)
            => SqlRuntime.Database(new SqlDatabaseHandle(Broker, DbName));     
    }
}
 