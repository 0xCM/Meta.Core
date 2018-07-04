//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using static metacore;
    using SqlT.Core;

    using N = SystemNode;

    public class SqlSessionMessages : ApplicationComponent
    {
        public SqlSessionMessages(IApplicationContext C)
            : base(C)
        {

        }


        public IApplicationMessage CreatedTable(SqlTableName TableName)
            => PostMessage(inform("Created table @TableName", new
            {
                TableName
            }));

        public IApplicationMessage CreatedSchema(SqlSchemaName SchemaName)
            => PostMessage(inform("Created schema @SchemaName", new
            {
                SchemaName
            }));


        public IApplicationMessage DroppedTable(SqlTableName TableName)
            => PostMessage(inform("Dropped @TableName", new
            {
                TableName
            }));

        public IApplicationMessage ConnectedToSourceNode(N Source)
            => PostMessage(inform("Connected to @Source", new
            {
                Source
            }));

        public IApplicationMessage ConnectedToTargetNode(N Target)
            => PostMessage(inform("Connected to @Target", new
            {
                Target
            }));

        public IApplicationMessage ConnectedToTargetDb(SqlDatabaseName Target)
            => PostMessage(inform("Connected to target database @Target", new
            {
                Target
            }));


        public IApplicationMessage ConnectedToSourceDb(SqlDatabaseName Source)
            => PostMessage(inform("Connected to source database @Source", new
            {
                Source
            }));


        public IApplicationMessage CapturingRecords(int Count)
            => PostMessage(inform("Capturing @Count records", new
            {
                Count
            }));

        public IApplicationMessage CapturedRecords(int Count)
            => PostMessage(inform("Captured @Count records", new
            {
                Count
            }));

        public IApplicationMessage TraversingSqlPackageArchive(FolderPath ArchivePath)
            => inform($"Traversing package archive @ArchivePath", new
            {
                ArchivePath
            });

        public IApplicationMessage DiscoveredSqlPackageDependency(SqlPackageName ClientPackage, SqlPackageName SupplierPackage)
            => inform($"Discovered dependency @ClientPackage -> @SupplierPackage", new
            {
                ClientPackage,
                SupplierPackage
            });

        public IApplicationMessage ExecutedSqlBatchSegment(SqlBatchScriptSegment Segment)
            => inform($"Executed batch segment [{Segment.StartLine}, {Segment.EndLine}]");

        public IApplicationMessage ToolProcessCompleted(FileName ToolName)
            => babble($"The {ToolName} tool process has completed");


        public static IApplicationMessage DispatchingCommand(N Host, ICommandDispatch dispatch)
            => inform("Dispatching @SpecName", new
            {
                Host,
                dispatch.Spec.CommandName,
                dispatch.Spec.SpecName,
            });

        public static IApplicationMessage CompletedCommand(N Host, ICommandCompletion completion)
            => completion.Succeeded ? inform($"{Host}: {completion.Spec.SpecName} Succeeded")
                                    : error($"{Host}: {completion.Spec.SpecName} Failed");




    }


}