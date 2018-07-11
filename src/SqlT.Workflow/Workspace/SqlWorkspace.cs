//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using Meta.Core;

    using SqlT;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Syntax;

    using N = SystemNode;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;

    class SqlWorkspaceSession : LinkedSqlSession<SqlWorkspaceSession>
    {
        static readonly SqlDatabaseName WsDbName = "WS";

        SqlWorkspaceSession(ILinkedContext C)
            : base(C, link(WsDbName, WsDbName))
        {

        }

        protected ISqlDatabaseRuntime WsDb(N Host = null)
           => DbRuntime(Host ?? SourceNode, WsDbName);

        protected Option<SqlTable> CreateWorkspaceTable<P>(SqlTableName name)
            where P : ISqlTableTypeProxy, new() => WsDb().Table(name).CreateIfMissing<P>();

        protected ISqlProxyBroker WsBroker<P>()
            where P : ISqlProxy
                => ~SqlProxyBroker.CreateBroker<P>(WsDb().Broker.ConnectionString);

        public bool IsTableInWorkspace(string TableName)
        {

            return WsDb().Table(SqlTableName.Parse(TableName))
                         .Exists().MapValueOrElse(
                v => v == SqlBooleanValue.True,
                msg => throw new Exception(msg.Format())
               );
        }

        protected void PurgeWorkspaceTables()
            => iter(WsDb().Tables,
                    table => Process(table.DropIfExists(),
                        _ => NotifyStatus($"Dropped {table} from workspace database")));

        protected override SqlUserCredentials SqlCredentials(SystemNodeIdentifier SqlNodeId)
            => SqlUserCredentials.Integrated;

        protected override SqlUserCredentials SqlNodeCredentials(N Host)
                => SqlUserCredentials.Integrated;

        protected Option<Y> Evaluate<X, Y>(Option<X> src, Func<X, Y> evaluator)
            => src.Map(x => evaluator(x));

        protected Option<Y> Evaluate<X, Y>(SqlOutcome<X> src, Func<X, Y> evaluator)
            => Evaluate(src.ToOption(), evaluator);

        protected Option<int> FlowToWorkspace<P>(IReadOnlyList<P> src, SqlTableName dst, bool dropIfExists = false)
            where P : class, ISqlTabularProxy, new()
        {
            var dstDb = WsDb();
            var dstTable = dstDb.Table(dst);
            var dstSqlConnector = dstDb.Broker.ConnectionString;
            var dstBroker = WsBroker<P>();

            if (dropIfExists)
                dstTable.DropIfExists();

            dstDb.CreateSchemaIfMissing(dst.SchemaName)
                    .OnNone(Notify)
                    .OnSome(result =>
                    {
                        if (result == ConditionalCreateResult.Created)
                            SessionMessages.CreatedSchema(dst.SchemaName);
                    });

            dstTable.CreateIfMissing<P>()
                    .OnNone(Notify)
                    .OnSome(result => SessionMessages.CreatedTable(result.Name));

            return Evaluate(dstBroker.BulkCopy(src, SqlCopyOptions.Create<P>(dstSqlConnector, dst, BatchSize: src.Count)),
                count =>
                {
                    SessionMessages.CapturedRecords(src.Count);
                    return src.Count;
                });
        }

        protected Option<IReadOnlyList<T>> Select<T>(SqlTableName Source)
            where T : ISqlTabularProxy, new()
            => WsBroker<T>().Select<T>($"{SELECT} {STAR} {FROM} {Source}");

        protected IReadOnlyList<T> Rows<T>(SqlTableName Source)
            where T : ISqlTabularProxy, new()
            => WsBroker<T>().Select<T>($"{SELECT} {STAR} {FROM} {Source}").OnNone(Notify).Items();

        protected Option<IReadOnlyList<T>> Select<T>(SqlTableName Source, string conditions)
            where T : ISqlTabularProxy, new()
            => WsBroker<T>().Select<T>($"{SELECT} {STAR} {FROM} {Source} {WHERE} {conditions}");
    }
}