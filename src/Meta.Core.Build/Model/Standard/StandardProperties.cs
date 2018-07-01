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
        public class StandardProperties : SymbolicPropertyGroup<StandardProperties>
        {
            public StandardProperties()
            { }


            public SymbolicVariable MSBuildExtensionsPath
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable MSBuildProjectName
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TargetName
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable BaseIntermediateOutputPath
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable IntermediateOutputPath
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable ProjectGuid
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable Name
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable RootNamespace
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable AssemblyName
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TargetFrameworkVersion
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TargetLanguage
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable Configuration
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable Platform
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable AppDesignerFolder
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable RootPath
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable BaseBuildDir
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable BaseSrcDir
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable OutputPath
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable BuildScriptName
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TreatWarningsAsErrors
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable DebugType
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable Optimize
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable DefineDebug
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable ErrorReport
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable WarningLevel
            {
                get { return read(); }
                set { write(value); }
            }

        }

    }

}