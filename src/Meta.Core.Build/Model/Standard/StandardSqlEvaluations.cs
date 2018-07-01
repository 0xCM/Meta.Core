//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;


    partial class BuildSyntax
    {
        public class StandardSqlEvaluations : EvaluatedProperties<StandardSqlEvaluations>
        {

            public StandardSqlEvaluations(IEnumerable<PropertyEvaluation> PropertyValues)
                : base(PropertyValues)
            {

            }


            public Option<PropertyEvaluation> TargetDatabase
                => GetProperty();

            public Option<PropertyEvaluation> ModelCollation
                => GetProperty();

            public Option<PropertyEvaluation> TargetDatabaseSet
                => GetProperty();

            public Option<PropertyEvaluation> DefaultSchema
                => GetProperty();

            public Option<PropertyEvaluation> DeployDatabase
                => GetProperty();

            public Option<PropertyEvaluation> Containment
                => GetProperty();

            public Option<PropertyEvaluation> Recovery
                => GetProperty();

            public Option<PropertyEvaluation> DSP
                => GetProperty();

            public Option<PropertyEvaluation> PackageDir
                => GetProperty();

            public Option<PropertyEvaluation> PublishDir
                => GetProperty();

            public Option<PropertyEvaluation> SchemaVersion
                => GetProperty();

            public Option<PropertyEvaluation> ProjectVersion
                => GetProperty();

            public Option<PropertyEvaluation> DefaultFileStructure
                => GetProperty();

            public Option<PropertyEvaluation> OutputType
                => GetProperty();

            public Option<PropertyEvaluation> SqlServerVerification
                => GetProperty();

            public Option<PropertyEvaluation> IncludeCompositeObjects
                => GetProperty();

            public Option<PropertyEvaluation> SuppressTSqlWarnings
                => GetProperty();

            public Option<PropertyEvaluation> GenerateCreateScript
                => GetProperty();

            public Option<PropertyEvaluation> Trustworthy
                => GetProperty();

            public Option<PropertyEvaluation> DefaultFileStreamFilegroup
                => GetProperty();

            public Option<PropertyEvaluation> FileStreamDirectoryName
                => GetProperty();

            public Option<PropertyEvaluation> NonTransactedFileStreamAccess
                => GetProperty();


            public Option<PropertyEvaluation> ServiceBrokerOption
                 => GetProperty();

        }
    }
}