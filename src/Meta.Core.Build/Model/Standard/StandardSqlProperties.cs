//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;


    partial class BuildSyntax
    {
        public class StandardSqlProperties : SymbolicPropertyGroup<StandardSqlProperties>
        {
            public SymbolicVariable TargetDatabase
                => read();

            public SymbolicVariable ModelCollation
                => read();

            public SymbolicVariable TargetDatabaseSet
                => read();

            public SymbolicVariable DefaultSchema
                => read();

            public SymbolicVariable DeployDatabase
                => read();

            public SymbolicVariable Containment
                => read();

            public SymbolicVariable Recovery
                => read();

            public SymbolicVariable DSP
                => read();

            public SymbolicVariable PackageDir
                => read();

            public SymbolicVariable PublishDir
                => read();

            public SymbolicVariable SchemaVersion
                => read();

            public SymbolicVariable ProjectVersion
                => read();

            public SymbolicVariable DefaultFileStructure
                => read();

            public SymbolicVariable OutputType
                => read();

            public SymbolicVariable SqlServerVerification
                => read();

            public SymbolicVariable IncludeCompositeObjects
                => read();

            public SymbolicVariable SuppressTSqlWarnings
                => read();

            public SymbolicVariable GenerateCreateScript
                => read();

            public SymbolicVariable Trustworthy
                => read();

            public SymbolicVariable DefaultFileStreamFilegroup
                => read();

            public SymbolicVariable FileStreamDirectoryName
                => read();

            public SymbolicVariable NonTransactedFileStreamAccess
                => read();


            public SymbolicVariable ServiceBrokerOption
                 => read();


        }

    }

}