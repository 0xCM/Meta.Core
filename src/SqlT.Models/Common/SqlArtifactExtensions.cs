//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public static class SqlArtifactExtensions
    {
        public static readonly FileExtension SqlDacProfileExtension = "publish.xml";
        public static readonly FileExtension SqlDacPackageExtension = "dacpac";
        public static readonly FileExtension SqlDacAssemblyExtension = "dll";
        public static readonly FileExtension SqlScriptExtension = "sql";
        public static readonly FileExtension SqlBacPackageExtension = "bacpac";
        public static readonly FileExtension SqlDatabaseExtension = "mdf";
        public static readonly FileExtension SqlDatabaseLogExtension = "ldf";
    }
}