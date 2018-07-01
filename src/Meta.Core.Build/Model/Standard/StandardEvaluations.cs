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

    public class StandardEvaluations : EvaluatedProperties<StandardEvaluations>
    {

        public StandardEvaluations(IEnumerable<PropertyEvaluation> PropertyValues)
            : base(PropertyValues)
        {
            
        }


        public Option<PropertyEvaluation> ProjectGuid
            => GetProperty();
        

        public Option<PropertyEvaluation> Name
            => GetProperty();

        public Option<PropertyEvaluation> RootNamespace
            => GetProperty();

        public Option<PropertyEvaluation> AssemblyName
            => GetProperty();

        public Option<PropertyEvaluation> TargetFrameworkVersion
            => GetProperty();

        public Option<PropertyEvaluation> TargetLanguage
            => GetProperty();

        public Option<PropertyEvaluation> Configuration
            => GetProperty();

        public Option<PropertyEvaluation> Platform
            => GetProperty();

        public Option<PropertyEvaluation> AppDesignerFolder
            => GetProperty();

        public Option<PropertyEvaluation> RootPath
            => GetProperty();

        public Option<PropertyEvaluation> BaseBuildDir
            => GetProperty();

        public Option<PropertyEvaluation> BaseSrcDir
            => GetProperty();

        public Option<PropertyEvaluation> OutputPath
            => GetProperty();

        public Option<PropertyEvaluation> BaseIntermediateOutputPath
            => GetProperty();

        public Option<PropertyEvaluation> IntermediateOutputPath
            => GetProperty();

        public Option<PropertyEvaluation> BuildScriptName
            => GetProperty();

        public Option<PropertyEvaluation> TreatWarningsAsErrors
            => GetProperty();

        public Option<PropertyEvaluation> DebugType
            => GetProperty();

        public Option<PropertyEvaluation> Optimize
            => GetProperty();

        public Option<PropertyEvaluation> DefineDebug
            => GetProperty();

        public Option<PropertyEvaluation> ErrorReport
            => GetProperty();

        public Option<PropertyEvaluation> WarningLevel
            => GetProperty();

    }



}