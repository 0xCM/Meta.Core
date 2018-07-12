//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Models;
    using SqlT.Core;
   
    using static metacore;
    using N = SystemNode;
    using static StatusMessages;

    using Meta.Core;

    public class SqlDacNav : FileSystemNavigator<SqlDacNav>
    {
        public SqlDacNav(IApplicationContext C, N Host, NodeFolderPath Location)
            : base(C, Host)
            => NavRoot = Location;

        public SqlDacNav(INodeContext C, NodeFolderPath Location)
            : base(C)
            => NavRoot = Location;


        public override NodeFolderPath NavRoot { get; }
            
        FolderName DacPacFolderName { get; }
            = "dacpac";

        FolderName DacProfileFolderName { get; }
            = "dacpac";

        FolderName BacPacFolderName { get; }
            = "bacpac";

        FolderName ScriptFolderName { get; }
            = "scripts";

        FolderName GenDacPacFolderName { get; }
            = "dac.g";
        FolderName ReportFolderName { get; }
            = "dac.reports";

        public NodeFolderPath DacPacLocation
            => NavRoot + DacPacFolderName;

        public NodeFolderPath DacProfileLocation
            => NavRoot + DacProfileFolderName;

        public Option<NodeFilePath> ProfileFile(SqlPackageName PackageName, SqlDatabaseServer Target)
        {
            var profileFileName = PackageName.DefaultProfileFileName(Target.Host);
            var candidate = DacProfileLocation + profileFileName;
            return candidate.AbsolutePath.Exists()
                ? candidate
                : none<NodeFilePath>(SqlPackageProfileNotFound(PackageName, Target.Host, candidate));
        }

        public Option<NodeFilePath> DacAssemblyFile(SqlPackageName PackageName)
        {
            var candidate = DacPacLocation + PackageName.DefaultAssemblyFileName();
            return candidate.AbsolutePath.Exists()
                ? candidate
                : none<NodeFilePath>(SqlAssemblyNotFound(PackageName,candidate));
        }

        public Option<NodeFilePath> DacPacFile(SqlPackageName PackageName)
        {
            var candidate = DacPacLocation + PackageName.DefaultPackageFileName();
            return candidate.AbsolutePath.Exists()
                ? candidate
                : none<NodeFilePath>(SqlPackageNotFound(PackageName, candidate));
        }

        public IEnumerable<NodeFilePath> DacPacFiles
            => DacPacLocation.Files(SqlArtifactExtensions.SqlDacPackageExtension);

        public IEnumerable<NodeFilePath> BacPacFile
            => DacPacLocation.Files(SqlArtifactExtensions.SqlBacPackageExtension);

        public IEnumerable<NodeFilePath> DacProfileFiles            
            => DacPacLocation.Files(SqlArtifactExtensions.SqlDacProfileExtension);
    }
}