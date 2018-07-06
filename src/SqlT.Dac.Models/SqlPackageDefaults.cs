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

    using static metacore;

    using N = SystemNode;
    using static SqlArtifactExtensions;

    /// <summary>
    /// Defines a conventional set of defaults
    /// </summary>
    public static class SqlPackageDefaults
    {
        public static FileName DefaultProfileFileName(this SqlPackageName PackageName, N DstNode)
            => FileName.Parse($"{PackageName.DefaultPackageFileName().RemoveExtension()}.{DstNode}")
                + SqlDacProfileExtension;

        public static FileName DefaultPackageFileName(this SqlPackageName PackageName)
            => FileName.Parse(PackageName).AddExtension(SqlDacPackageExtension,true);

        public static FileName DefaultAssemblyFileName(this SqlPackageName PackageName)
            => FileName.Parse(PackageName).AddExtension(SqlDacAssemblyExtension, true);

        public static FileName DefaultScriptFilename(this SqlPackageName PackageName, N Node)
            => PackageName.DefaultPackageFileName().ChangeExtension($"{Node}.sql");

        public static SqlPackageProfile DefaultProfile(this SqlPackageName PackageName, N Node, SqlDatabaseName Db, SqlUserCredentials Credentials = null)
            => new SqlPackageProfile(true)
            {
                IncludeCompositeObjects = true,
                TargetDatabaseName = Db,
                DeployScriptFileName = DefaultScriptFilename(PackageName, Node),
                BlockOnPossibleDataLoss = true,
                GenerateSmartDefaults = true,
                DropConstraintsNotInSource = true,
                TargetConnectionString =
                    Credentials== null 
                    ? SqlConnectionString.Build().ConnectTo($"{Node.NodeName}")
                        .UsingIntegratedSecurity()
                    : SqlConnectionString.Build().ConnectTo($"{Node.NodeName}")
                        .UsingCredentials(Credentials)
            };
    }
}