//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp.Templates
{
    using System;

    using static metacore;

    public class ProjectTemplate : ScriptTemplate<ProjectTemplate>
    {

        public static readonly Guid CSharpProjectType = Guid.Parse("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}");
        public static readonly Guid FSharpProjectType = Guid.Parse("{F2A71F9B-5D33-465A-A702-920D77279786}");
        public static readonly Guid SSDTProjectType = Guid.Parse("00D1A9C2-B5F0-4AF3-8072-F6C62B433612");

        internal static readonly string DefaultNamespace = "Acme.Proxies";
        internal static readonly string DefaultAssemblyName = "Acme.Proxies";
        internal static readonly string DefaultProjectName = "Acme.Proxies";
        static readonly string DefaultDistributionLabel = "acme-proxies";
        static readonly string DefaultOutputType = "Library";
        static readonly string DefaultBaseOutputDir = @"$(ProjectDir)..\..\bin\";

        public static ProjectTemplate Expand
            (
                string ProjectName,
                string RootNamespace = null,
                string AssemblyName = null,
                Guid? ProjectId = null,
                string DistributionLabel = null
            )
        {

            return new ProjectTemplate
            {
                ProjectName = ProjectName,
                AssemblyName = AssemblyName ?? ProjectName,
                RootNamespace = RootNamespace ?? ProjectName,
                ProjectId = ProjectId ?? Guid.NewGuid(),                
                OutputType = DefaultOutputType,
                BaseOutputDir = DefaultBaseOutputDir,
                DistributionLabel = ifBlank(DistributionLabel,DefaultDistributionLabel),
                ProjectTypeId = CSharpProjectType,
            };
        }


        public ProjectTemplate()
        {
            ProjectId = Guid.NewGuid();
            ProjectName = DefaultAssemblyName;
            ProjectTypeId = CSharpProjectType;
            RootNamespace = DefaultNamespace;
            AssemblyName = DefaultAssemblyName;
            OutputType = DefaultOutputType;
            BaseOutputDir = DefaultBaseOutputDir;
            DistributionLabel = DefaultDistributionLabel;
        }

        public Guid ProjectId { get; set; }

        public Guid ProjectTypeId { get; set; }

        public string RootNamespace { get; set; }

        public string AssemblyName { get; set; }

        public string ProjectName { get; set; }

        public string OutputType { get; set; }

        public string BaseOutputDir { get; set; }

        public string DistributionLabel { get; set; }

        public SolutionTemplate CompanionSolution()
            => new SolutionTemplate
            {

                ProjectTypeId = ProjectTypeId,
                ProjectId = ProjectId,
                ProjectName = ProjectName
            };
    }
}
