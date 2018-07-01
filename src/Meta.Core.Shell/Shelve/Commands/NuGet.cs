//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.IO;
    using System.Linq;

    using static metacore;


    [CommandSpec]
    public class NuGetSpec : CommandSpec<NuGetSpec, NuGetResult>
    {

        /// <summary>
        /// Enumerates the tool-specific commands available for execution through the spec
        /// </summary>
        public enum ToolAction
        {
            /// <summary>
            /// Specifies that a NuGet package should be created
            /// </summary>
            Pack = 1,
        }


        /// <summary>
        /// Specifies how chatty the tool will be when executed
        /// </summary>
        public enum VerbosityLevel
        {
            Normal = 0,

            Quiet = 1,

            Detailed = 2
        }

        public static NuGetSpec Pack(string PackageSpecPath, string OutputDirectory)
            => new NuGetSpec
            {
                Action = ToolAction.Pack,
                Verbosity = VerbosityLevel.Detailed,
                Target = new TargetPackage
                {
                    OutputDirectory = enquote(OutputDirectory),
                    PackageSpecPath = enquote(PackageSpecPath)
                }
            };


        public class NugetPackageIdentifier : DomainPrimitive<NugetPackageIdentifier, string>
        {
            public NugetPackageIdentifier(string Value)
                : base(Value)
            { }

        }

        public class NugetDependency : ValueObject<NugetDependency>
        {
            public NugetDependency(NugetPackageIdentifier PackageIdentifier, SemanticVersion PackageVersion)
            {
                this.PackageIdentifier = PackageIdentifier;
                this.PackageVersion = PackageVersion;
            }

            public NugetPackageIdentifier PackageIdentifier { get; }
            public SemanticVersion PackageVersion { get; }

            public override string ToString()
                => $"{PackageIdentifier} v{PackageVersion}";

        }

        public class NugetConfig
        {


            public string WorkingDirectory { get; set; }

            public string OutputDirectory { get; set; }

            public string OutputFileName { get; set; }

            public SemanticVersion PackageVersion { get; set; }

            public IReadOnlyList<string> InputFiles { get; set; }

            public string NuspecTemplateName { get; set; }

            public string NuspecText { get; set; }

            public string NetVersion { get; set; }

            public string OutputPath
                => Path.Combine(WorkingDirectory, OutputFileName);
        }


        public class TargetPackage : CommandArgumentSet<TargetPackage>
        {

            /// <summary>
            /// The path to the NUSPEC or project file used as input
            /// </summary>
            [CommandParameter("The path to the NUSPEC or project file used as input")]
            public string PackageSpecPath { get; set; }

            /// <summary>
            /// Specifies the directory into which the created package will be depositied
            /// </summary>
            /// <remarks>
            /// Defaults to the current directory if unspecified
            /// </remarks>
            [CommandParameter("Specifies the directory into which the created package will be depositied")]
            public string OutputDirectory { get; set; }

        }

        public ToolAction Action { get; set; }

        /// <summary>
        /// Specifies the verbosity
        /// </summary>
        public VerbosityLevel Verbosity { get; set; }

        public Option<TargetPackage> Target { get; set; }

        public NuGetSpec()
        {

        }


        IEnumerable<CommandArgument> DeriveArguments()
        {
            if (Target)
            {
                foreach (var arg in Target.ValueOrDefault().GetArguments())
                    yield return arg;
            }
            yield return new CommandArgument("Verbosity", Verbosity.ToString());
        }


        public override CommandArguments GetArguments()
            => new CommandArguments(DeriveArguments());

    }


    public class NuGetResult { }
}