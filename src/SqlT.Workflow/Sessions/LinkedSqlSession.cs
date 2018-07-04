//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.ComponentModel;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Services;
    using SqlT.SqlSystem;
    using SqlT.Templates;
    using static metacore;
    using N = SystemNode;
    
    using Db = SqlT.Core.SqlDatabaseName;

    public abstract class LinkedSqlSession<T> : LinkedSession<T>, ILinkedSqlSession
        where T : LinkedSqlSession<T>
    {

        protected IApplicationMessage ReceivingRecords<P>(IReadOnlyList<P> records)
            => inform($"Receiving  {records.Count}, {typeof(P).Name} records");



        protected LinkedSqlSession(ILinkedContext C, Link<Db> DbLink)
            : base(C)
        {

            SqlMetadata = C.SqlMetadataProvider();
            SqlGenerator = C.SqlGenerator();
            cmd = ProcessAdapter.ExecuteCmd(
                packet => NotifyStatus(packet.Payload),
                packet => NotifyError(packet.Payload),
                Inspect);
            SessionMessages = new SqlSessionMessages(C);

            SourceNodeConnected += OnSourceNodeConnected;
            TargetNodeConnected += OnTargetNodeConnected;
            SourceDbConnected += OnSourceDbConnected;
            TargetDbConnected += OnTargetDbConnected;
            SyncContext(DbLink.Source, DbLink.Target);
        }

        protected ILinkedSqlContext SqlContext { get; private set; }


        protected event Action<Db> SourceDbConnected;

        protected event Action<Db> TargetDbConnected;

        public Db SourceDbName
            => SqlContext.SourceContext.DatabaseName;

        public Db TargetDbName
            => SqlContext.TargetContext.DatabaseName;

        protected SqlConnectionString SessionConnector(N Host, Db DbName)
             => SqlConnectionString.Build(Host.NodeServer, DbName)
                                 .OnPort(Host.Port)
                                 .UsingCredentials(SqlNodeCredentials(Host))
                                 .WithMaxPoolSize(250);

        protected SqlConnectionString SessionConnector(SqlDatabaseServer Host, Db DbName)
        {
            if (Host.Alias)
                return Host.Alias.MapValue(alias => SqlConnectionString.Build(alias, DbName))
                                 .UsingCredentials(SqlCredentials(Host.NodeIdentifier))
                                 .WithMaxPoolSize(250);
            else

                return SqlConnectionString.Build(Host.NetworkName, DbName)
                                     .OnPort(Host.Port)
                                     .UsingCredentials(SqlCredentials(Host.NodeIdentifier))
                                     .WithMaxPoolSize(250);

        }


        protected abstract SqlUserCredentials SqlCredentials(SystemNodeIdentifier SqlNodeId);
        protected abstract SqlUserCredentials SqlNodeCredentials(N Host);


        protected SqlConnectionString SqlConnector(Db DbName, SqlConnectionCredentials Credentials)
            => SqlConnectionString.Build(DbName.ServerName, DbName.UnqualifiedName).UsingCredentials(Credentials);

        protected ISqlClientBroker ClientBroker(N Host, Db DbName, SqlNotificationObserver observer = null)
                    => SessionConnector(Host, DbName).GetClientBroker(observer ?? OnSqlNotification);


        protected ISqlServerRuntime ServerRuntime(SqlDatabaseServer Host)
            => C.SqlRuntimeProvider().Server(
                SessionConnector(Host, Db.Master()).GetClientBroker().Server());
                    

        protected ISqlServerRuntime ServerRuntime(N Host)
        {
            var broker = SessionConnector(Host, "master")
                          .GetClientBroker(OnSqlNotification);
            return C.SqlRuntimeProvider().Server((broker.Server()));
        }

        protected ISqlRuntimeProvider SqlRuntime
            => C.SqlRuntimeProvider();

        void SyncContext(Db srcDb, Db dstDb)
        {
            if (isNull(srcDb) || isNull(dstDb))
                throw new ArgumentNullException();

            var srcCredentials = SqlNodeCredentials(C.SourceNode);
            var dstCredentials = SqlNodeCredentials(C.TargetNode);
            var srcConnector = SqlConnectionString.Build(SqlServer(C.SourceNode), srcDb).UsingCredentials(srcCredentials).Finish();
            var dstConnector = SqlConnectionString.Build(SqlServer(C.TargetNode), dstDb).UsingCredentials(dstCredentials).Finish();
            SqlContext = new LinkedSqlContext(C, C.Link,  link(srcConnector,dstConnector));
            SourceDbConnected(srcDb);
            TargetDbConnected(dstDb);
        }


        protected void UseSource(Db SourceDbName)
            => SyncContext(SourceDbName, TargetDbName);
        
        protected void UseTarget(Db TargetDbName)
            => SyncContext(SourceDbName, TargetDbName);
        
        void OnSourceNodeConnected(N Source)
        {
            SyncContext(SourceDbName,TargetDbName);
            ProcessValue(ServerRuntime(Source).SystemViews.GetNativeView<IServer>(),
                servers =>
                {
                    SessionMessages.ConnectedToSourceNode(Source);
                });
        }

        void OnTargetNodeConnected(N Target)
        {
            SyncContext(SourceDbName, TargetDbName);
            ProcessValue(ServerRuntime(Target).SystemViews.GetNativeView<IServer>(),
                servers =>
                {
                    SessionMessages.ConnectedToTargetNode(Target);
                });
        }

        protected virtual bool AnnonceConnectionChanges
            => true;

        void OnSourceDbConnected(Db DbName)
        {
            if(AnnonceConnectionChanges)
                Notify(SessionMessages.ConnectedToSourceDb(DbName));
        }

        void OnTargetDbConnected(Db DbName)
        {
            if(AnnonceConnectionChanges)
                Notify(SessionMessages.ConnectedToTargetDb(DbName));
        }

            
        protected ISqlDatabaseRuntime DbRuntime(N Host, Db dbName)
        {
            var broker = SessionConnector(Host, dbName)
                          .GetClientBroker(notify => OnSqlNotification(notify));
            var dbRuntime = C.SqlRuntimeProvider().Database(broker.Database(dbName));
            return dbRuntime;
        }

        
        protected SqlSessionMessages SessionMessages { get; }

        IProcess cmd { get; }


        protected Option<X> opt<X>(SqlOutcome<X> oc)
            => oc.ToOption();

        protected void Process(IOption result, Action<IOption> processor)
            => processor(result);

        protected void Process<X>(Option<X> result)
            => result.OnMessage(Notify);

        protected void Process<P>(SqlOutcome<IReadOnlyList<P>> result,
            Action<IReadOnlyList<P>> receiver,
            Func<IApplicationMessage> onPreProcess = null)
        {
            if (onPreProcess != null)
                Notify(onPreProcess());

            result.ToOption()
                  .OnNone(Notify)
                    .OnSome(records =>
                    {
                        ReceivingRecords(records);
                        receiver(records);
                    });
        }

        protected void ProcessItems<P>(SqlOutcome<IReadOnlyList<P>> result, Action<P> receiver)
            => Process(result, items => iter(items, receiver));                                                                                      

        protected void Process<X>(SqlOutcome<X> result,
            Action<X> receiver,
            Func<IApplicationMessage> onPreProcess = null)
        {
            if (onPreProcess != null)
                Notify(onPreProcess());

            result.ToOption()
                  .OnNone(Notify)
                    .OnSome(receiver);
        }

        public void SessionServices()
            => ProcessItems(C.ProvidedServices,
                    s => NotifyStatus($"{s}"));

        protected ISqlGenerator SqlGenerator { get; }

        protected ISqlMetadataProvider SqlMetadata { get; }


        [ShellCommand, Description("Brings source/target databases into scope")]
        public virtual void use(string SrcDb, string DstDb)
        {
            if(isNotBlank(SrcDb))
                UseSource(SrcDb);

            if(isNotBlank(DstDb))
                UseTarget(DstDb);
        }


        [ShellCommand,Description("Enumerates databases in both source/target catalogs")]
        public void dblist()
        {

            Print("Source Databases");
            iter(ServerRuntime(SourceNode).DatabaseCatalog, Print);
            Print("Target Databases");
        }

        public override void who()
        {
            Notify(inform(SqlContext.ToString()));
        }


        protected Task<Option<Db>> RestoreDatabase(FilePath SrcPath, N DstNode, Db DstDb, FolderPath DstFolder)
            => Task.Factory.StartNew(() =>
            {
                var dstDFN = FileName.Parse(DstDb.UnqualifiedName).AddExtension("mdf");
                var dstLFN = FileName.Parse(DstDb.UnqualifiedName).AddExtension("ldf");
                var movements = array(
                    new SqlRestoreDatabase.Move(DstDb.UnqualifiedName, DstFolder + dstDFN),
                    new SqlRestoreDatabase.Move(DstDb.UnqualifiedName + "_log", DstFolder + dstLFN));
                var spec = new SqlRestoreDatabase(SrcPath, DstDb, movements);

                ServerRuntime(DstNode).RestoreDatabase(spec);
                return some(DstDb);

            });

        protected ISqlServerRuntime SourceServer
            => ServerRuntime(SourceNode);

        protected ISqlServerRuntime TargetServer
            => ServerRuntime(TargetNode);

        protected ISqlDatabaseRuntime SourceDbRuntime
            => DbRuntime(SourceNode, SourceDbName);

        protected ISqlDatabaseRuntime TargetDbRuntime
            => DbRuntime(TargetNode, TargetDbName);
       
        protected virtual void OnSqlNotification(SqlNotification notification)
            => C.Notify(notification.ToApplicationMessage());

        ISqlClientBroker ILinkedSqlSession.SourceBoker()
            => SessionConnector(SourceNode, SourceDbName).GetClientBroker(OnSqlNotification);

        ISqlClientBroker ILinkedSqlSession.SourceBroker(N Host, Db DbName)
            => SessionConnector(Host, DbName).GetClientBroker(OnSqlNotification);

        ISqlClientBroker ILinkedSqlSession.SourceBroker(N Host)
            => SessionConnector(Host, SourceDbName).GetClientBroker(OnSqlNotification);

        ISqlClientBroker ILinkedSqlSession.TargetBroker()
            => SessionConnector(TargetNode, TargetDbName).GetClientBroker(OnSqlNotification);

        ISqlClientBroker ILinkedSqlSession.TargetBroker(N Host, Db DbName)
            => SessionConnector(Host, DbName).GetClientBroker(OnSqlNotification);

        ISqlClientBroker ILinkedSqlSession.TargetBroker(N Host)
            => SessionConnector(Host, TargetDbName).GetClientBroker(OnSqlNotification);

        protected IReadOnlyList<vTable> SourceTableCatalog
            => SourceDbRuntime.TableCatalog;

        protected IReadOnlyList<vTable> TargetTableCatalog
            => TargetDbRuntime.TableCatalog;

        protected Link<IReadOnlyList<vTable>> TableCatalogs
            => link(SourceTableCatalog, TargetTableCatalog);


        protected IReadOnlyList<vSequence> SourceSequenceCatalog
            => SourceDbRuntime.SequenceCatalog;

        protected IReadOnlyList<vSequence> TargetSequenceCatalog
            => TargetDbRuntime.SequenceCatalog;

        protected Link<IReadOnlyList<vSequence>> SequenceCatalogs
            => link(SourceSequenceCatalog,TargetSequenceCatalog);

        public void ExecuteSqlScript(string ScriptPath, string DstNode = null, string DstDatabase = null)
        {
            var db = DstDatabase ?? Db.Master();
            var broker = ClientBroker(node(DstNode), db, msg => NotifyStatus(msg.Detail));
            var batches = SqlScript.FromText(FilePath.Parse(ScriptPath).ReadAllText(), null, null);
            var input = C.SqlParser().ParseBatches(batches);
            input.OnNone(Notify).OnSome(batchScript =>
            {
                iter(batchScript.Segments, segment =>
                {
                    Process(broker.ExecuteNonQuery(segment.ScriptText),
                        _ => SessionMessages.ExecutedSqlBatchSegment(segment));
                });
            });
        }

        static SqlServerName SqlServer(N Host)
            => new SqlServerName(Host.NodeName);

    }


}