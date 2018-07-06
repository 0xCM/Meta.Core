//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Collections.Generic;

    using Meta.Core;
    using Meta.Core.Resources;

    using SqlT.Core;
    using SqlT.Services;
    
    using static metacore;

    class SqlBcpScriptBuilder : ApplicationComponent, ISqlBcpScriptBuilder

    {
        SqlBcpScriptBuilder(IApplicationContext C, SqlTableQuery SourceQuery, SqlTableName TargetTable, NodeFolderPath ArtifactFolder, NodeFolderPath DatasetFolder)
            : base(C)
        {
            this.SystemResources = C.Service<INodeFileSystemLocator>();
            this.SourceQuery = SourceQuery;
            this.TargetTable = TargetTable;
            this.WorkflowArtifactFolder = ArtifactFolder;
            this.TargetDatasetLocation = DatasetFolder;
        }


        SqlTableQuery SourceQuery { get; set; }

        SqlTableName TargetTable { get; set; }

        INodeFileSystemLocator SystemResources { get; }

        SqlBcpFileName ExportScriptFileName
            => SqlBcpFileName.Create(BcpFileType.BcpExportScript, SourceTable, Discriminator);

        FilePath ExportScriptPath
            => WorkflowArtifactFolder + ExportScriptFileName;

        SystemNode FindNode(SystemNodeIdentifier id)
            => SystemNode.Local;

        SystemUri TableDatasetUri(SqlTableName table, EndpointPort port)
            => table.GetUri().WithAppendedPathComponts($"datasets/{port.ToString().ToLower()}");

        NodeUncDrive UncDatasetDrive(SystemUri dsUri, EndpointPort port)
        {
            var host = dsUri.Host;
            var node = FindNode(host.IdentifierText);
            return SystemResources.UncDatasetShare(node, port);
        }

        SqlTableName SourceTable
            => SourceQuery.SourceName;

        SystemNode SourceNode
            => FindNode(SourceQuery.SourceName.ServerNamePart);

        Option<SqlUserCredentials> SourceCredentials
            => null;

        SystemUri SourceDataset
            => TableDatasetUri(SourceTable, EndpointPort.Incoming);

        string Discriminator
            => SourceQuery.FilterValue;

        SqlBcpFileName DataFileName
            => SqlBcpFileName.Create(BcpFileType.DataFile, SourceTable, Discriminator);

        FilePath DataFilePath
            => TargetUncShare + DataFileName;

        SqlBcpFileName FormatFileName
            => SqlBcpFileName.Create(BcpFileType.FormatFile, SourceTable, Discriminator);

        FilePath FormatFilePath
            => TargetUncShare + FormatFileName;

        public SqlBcpFileName FormatScriptFilename
            => SqlBcpFileName.Create(BcpFileType.BcpFormatScript, SourceTable, Discriminator);

        public FilePath FormatScriptPath
            => WorkflowArtifactFolder + FormatScriptFilename;

        public SqlBcpFileName ImportScriptFileName
            => SqlBcpFileName.Create(BcpFileType.BcpImportScript, TargetTable, Discriminator);

        FilePath ImportScriptPath
            => WorkflowArtifactFolder + ImportScriptFileName;

        NodeFolderPath WorkflowArtifactFolder { get; }

        public SystemNode TargetNode
            => FindNode(TargetTable.ServerNamePart);


        public SystemUri TargetDataset
            => SourceDataset.WithNewHost(TargetNode);

        NodeFolderPath TargetDatasetLocation { get; }

        NodeUncDrive TargetUncDrive
            => UncDatasetDrive(TargetDataset, EndpointPort.Incoming);

        FolderPath TargetUncShare
            => TargetUncDrive.Share.SharePath;

        SqlScript TargetInsertScript
            => TargetTable.SqlBcpInsertScript(
                TargetUncDrive.HostPath + TargetDatasetLocation + DataFileName,
                TargetUncDrive.HostPath + TargetDatasetLocation + FormatFileName);

        SqlBcpFileName TargetInsertScriptFileName
            => SqlBcpFileName.Create(BcpFileType.SqlInsertScript, TargetTable, Discriminator);

        FilePath InsertScriptPath
            => WorkflowArtifactFolder + TargetInsertScriptFileName;

        SqlBcpCommand SourceExportCommand
            => new SqlBcpCommand(
                Action: BcpToolAction.Export,
                SourceQuery: SourceQuery,
                TargetTable: TargetTable,
                DataFile: DataFilePath,
                FormatFile: FormatFilePath,
                Credentials: SourceCredentials.ValueOrDefault()
                );

        SqlBcpCommand SourceFormatCommand
            => SourceExportCommand.WithNewAction(BcpToolAction.Format);

        SqlBcpCommand TargetInsertCommand
            => SourceExportCommand.WithNewAction(BcpToolAction.Import);

        Option<SqlBcpArtifactSet> SaveArtifacts()
            => from export in ExportScriptPath.Write(SourceExportCommand.ToString()).ToFileOption()
               from format in FormatScriptPath.Write(SourceFormatCommand.ToString()).ToFileOption()
               from insert in InsertScriptPath.Write(TargetInsertScript.ToString()).ToFileOption()
               from import in ImportScriptPath.Write(TargetInsertCommand.ToString()).ToFileOption()
               select new SqlBcpArtifactSet(
                   ExportScript: export,
                   FormatScript: format,
                   InsertScript: insert,
                   ImportScript: import
                   );

        public Option<SqlBcpArtifactSet> DefineBcpCommands(SqlTableName srcTable, SqlTableName dstTable)
        {
            var query = new SqlTableQuery(srcTable, new SqlScript($"select * from {srcTable}"));
            var builder = new SqlBcpScriptBuilder(C, query, dstTable, NodeFolderPath.Empty, NodeFolderPath.Empty);
            return builder.SaveArtifacts();
        }

        public Option<SqlBcpArtifactSet> DefineBcpCommands(Link<SystemNode> path, SqlTableName srcTable, SqlTableName dstTable)
        {
            var qualifiedSrc = new SqlServerName(path.Source.NodeName) + srcTable;
            var qualifiedDst = new SqlServerName(path.Target.NodeName) + dstTable;
            return DefineBcpCommands(qualifiedSrc, qualifiedDst);
        }

    }

}