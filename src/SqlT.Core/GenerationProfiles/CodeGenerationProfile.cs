//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.ComponentModel;
    using static metacore;


    /// <summary>
    /// Specifies domain-agnostic generation settings
    /// </summary>
    public class CodeGenerationProfile
    {
        public CodeGenerationProfile()
        {
            Name = string.Empty;
            RootNamespace = string.Empty;
            OutputDirectory = string.Empty;
            DefaultUsings = array("System", "System.Collections.Generic");
            Internalize = false;
            EmitSingleFile = true;
            EmitGenerationSpec = false;
            ProjectName = string.Empty;
            EmitProject = false;
            BuildProject = false;
            AssemblyVersion = "1.0.0";
            AssemblyDesignatorName = string.Empty;
            DistributionLabel = string.Empty;
            AssemblyReferences = new string[] { };
            ReturnTypeStyle = MonadicFlavour.Outcome;
            EmitTypeContracts = false;

        }

        public CodeGenerationProfile
        (
            string Name,
            FolderPath OutputDirectory, 
            string AssemblyDesignatorName,
            string RootNamespace
        ): this()
        {
            this.Name = Name;
            this.OutputDirectory = OutputDirectory;
            this.AssemblyDesignatorName = AssemblyDesignatorName;
            this.RootNamespace = RootNamespace;
        }

        /// <summary>
        /// Classifies the type of profile being specified
        /// </summary>
        [
            Description("Classifies the type of profile being specified")
        ]
        public CodeGenerationProfileKind ProfileType { get; set; }


        /// <summary>
        /// Specifies the name of the profile and impacts the name of generated artifacts
        /// </summary>
        [
            Description("Specifies the name of the profile and impacts the name of generated artifacts")
        ]
        public string Name { get; set; }


        /// <summary>
        /// The top-level namespace under which generated types reside
        /// </summary>
        [
            Description("The top-level namespace under which generated types reside")
        ]
        public string RootNamespace { get; set; }

        /// <summary>
        /// The directory into which generated artifacts are emitted. If uspecified, artifacts are emitted into the current working directory
        /// </summary>
        [
            Description("The directory into which generated artifacts are emitted. If uspecified, artifacts are emitted into the current working directory")
        ]
        public string OutputDirectory { get; set; }

        /// <summary>
        /// The namespaces that will be brought into scope via using directives for all generated artifacts
        /// </summary>
        [
            Description("The namespaces that will be brought into scope via using directives for all generated artifacts")
        ]
        public string[] DefaultUsings { get; set; }

        /// <summary>
        /// Specifies whether the internal modifier should be applied to generated types
        /// </summary>
        [
            Description("Specifies whether the internal modifier should be applied to generated types"),
            DefaultValue(false)
        ]
        public bool Internalize { get; set; }

        /// <summary>
        /// Specifies whether framework code should be emitted so that the generated output will be dependency-free
        /// </summary>
        [
            Description("Specifies whether framework code that implements broker capabilitied should be emitted along with the proxies"),
            DefaultValue(false)
        ]
        public bool EmitDependencies { get; set; }

        /// <summary>
        /// Specifies whether all generated output should be combined into a single file
        /// </summary>
        [
            Description("Specifies whether all generated output should be combined into a single file"),
            DefaultValue(true)
        ]
        public bool EmitSingleFile { get; set; }

        /// <summary>
        /// Specifies whether the profile itself, which specifies the supplied settings, should be emitted along with the proxies
        /// </summary>
        [
            Description("Specifies whether the profile itself, which specifies the supplied settings, should be emitted along with the proxies"),
            DefaultValue(false)
        ]
        public bool EmitGenerationSpec { get; set; }

        /// <summary>
        /// Specifies the name that will be used, when enabled, to name the emitted VS project
        /// </summary>
        [
            Description("Specifies the name that will be used, when enabled, to name the emitted VS project")
        ]
        public string ProjectName { get; set; }

        /// <summary>
        /// Identifies the distribution, if any, with which the generated component is included
        /// </summary>
        [
            Description("Specifies the name that will be used, when enabled, to name the emitted VS project")
        ]
        public string DistributionLabel { get; set; }

        /// <summary>
        /// Specifies whether a VS project should be emitted that includes the emitted code
        /// </summary>
        [
            Description("Specifies whether a VS project should be emitted that includes the emitted code"),
            DefaultValue(false)
        ]
        public bool EmitProject { get; set; }

        /// <summary>
        /// Specifies whether the compile an emitted project
        /// </summary>
        [
            Description("Specifies whether the compile an emitted project"),
            DefaultValue(false)
        ]
        public bool BuildProject { get; set; }

        /// <summary>
        /// For an emitted project, specifies the name of the assembly designator
        /// </summary>
        [
            Description("For an emitted project, specifies the name of the assembly designator"),
        ]
        public string AssemblyDesignatorName { get; set; }


        /// <summary>
        /// For an emitted project, specifies the version of the assembly
        /// </summary>
        [
            Description("For an emitted project, specifies the version of the assembly"),
        ]
        public string AssemblyVersion { set; get; }

        /// <summary>
        /// Provides access to the database whose data/metadata will drive generation processes
        /// </summary>
        [
            Description("Provides access to the database whose data/metadata will drive generation processes")
        ]
        public string ConnectionString { get; set; }

        /// <summary>
        /// For an emitted project, specifies a list of asssemblies that should be referenced
        /// </summary>
        [
            Description("For an emitted project, specifies a list of asssemblies that should be referenced")
        ]
        public string[] AssemblyReferences { get; set; }

        /// <summary>
        /// Specifies monadic return type preference
        /// </summary>
        [
            Description("Specifies monadic return type preference"), 
            DefaultValue(MonadicFlavour.Outcome)
        ]
        public MonadicFlavour ReturnTypeStyle { get; set; }

        /// <summary>
        /// Specifies whether interfaces determined by the fields for emitted types should be emitted
        /// </summary>
        [
            Description("Specifies whether interfaces determined by the columns defined for emitted UDTT's should be emitted"),
            DefaultValue(true)
        ]
        public bool EmitTypeContracts { get; set; }

    }
}
