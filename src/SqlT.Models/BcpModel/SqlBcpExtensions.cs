//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;
    using SqlT.Syntax;

    using Meta.Core;
    using Meta.Core.Resources;

    using static metacore;

    using D = NodeUncDrive;
    using N = SystemNode;
    using P = FilePath;
    using F = FolderName;

    public static class SqlBcpExtensions
    {

        public static SqlScript SqlBcpInsertScript(this SqlTableName TargetTable, FilePath dat, FilePath fmt)
           => TargetTable.SQL_BULK_INSERT(dat.FileSystemPath, fmt.FileSystemPath);

        public static void GenerateBcpImportScripts(this SqlTableName TargetTable, NodeUncDrive src)
        {

            var fmtFiles = src.UncPath.GetFiles("*.fmt").ToDictionary(x => x.FileName.ToString());
            var bcpFiles = src.UncPath.GetFiles("*.dat").ToDictionary(x => x.FileName.ToString());
            var pairs = (from bcpFile in bcpFiles
                         let fmtKey = bcpFile.Key.Replace(".dat", ".fmt")
                         where fmtFiles.ContainsKey(fmtKey)
                         select (DataFile: bcpFile.Value, FormatFile: fmtFiles[fmtKey])
                         ).ToList();
            var scripts = map(pairs,
                pair => TargetTable.SqlBcpInsertScript(pair.DataFile, pair.FormatFile));


            var script = string.Join(eol(), map(scripts, s => s.ScriptText).ToArray());
            var scriptPath = src.UncPath + FileName.Parse("bcp-import.sql");
            scriptPath.Write(script);

        }

        public static D UncDataSetShare(this INodeFileSystemLocator locator, N n)
            => locator.TopUncShare(n, "Datasets");

        public static D UncDatasetShare(this INodeFileSystemLocator locator, N n, F Subfolder)
            => new D(locator.UncDataSetShare(n), Subfolder);

        public static D UncDatasetShare(this INodeFileSystemLocator locator, N n, EndpointPort port)
            => locator.UncDatasetShare(n, port.ToString().ToLower());


    }



}