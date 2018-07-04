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