//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.IO;

    using static NuGetSpec;
    using static metacore;

    public class PackageDependency : ValueObject<PackageDependency>
    {
        public PackageDependency(string ArtifactType, string ArtifactName, SemanticVersion ArtifactVersion)
        {
            this.ArtifactType = ArtifactType;
            this.ArtifactName = ArtifactName;
            this.ArtifactVersion = ArtifactVersion;
        }

        /// <summary>
        /// The type of artifact for which a dependency exists
        /// </summary>
        public string ArtifactType { get; }

        /// <summary>
        /// The name of an artifact on which a client takes a dependency
        /// </summary>
        public string ArtifactName { get; }

        /// <summary>
        /// The version of the artifact on which a cilent is dependent
        /// </summary>
        public SemanticVersion ArtifactVersion { get; }

        /// <summary>
        /// A name for the symbolic version
        /// </summary>
        public string VersionMoniker
            => ArtifactName + "Version";

        public override string ToString()
            => $"{ArtifactName}({ArtifactType},{ArtifactVersion})";
    }


    [CommandPattern]
    public class NuGetProcess : CommandProcessPattern<NuGetProcess, NuGetSpec, NuGetResult>
    {
        static readonly FileName EXE = "nuget.exe";

        static string GetNetFramworkVersionNumber(Version version)
        {
            var versionNumber = $"{version.Major}{version.Minor}"
                         + (version.Build != 0 && version.Build != -1 ? $"{version.Build}" : String.Empty);
            return versionNumber;
        }

        static IReadOnlyList<string> GetDefaultInputFiles(params Assembly[] assemblies)
        {
            var files = new List<string>();
            foreach (var assembly in assemblies)
            {
                var assemblyPath = assembly.CodeBase.Replace("file:///", String.Empty);
                files.Add(assemblyPath);
                var pdb = Path.ChangeExtension(assemblyPath, ".pdb");
                if (File.Exists(pdb))
                    files.Add(pdb);

                var xml = Path.ChangeExtension(assemblyPath, ".xml");
                if (File.Exists(xml))
                    files.Add(xml);
            }
            return files;
        }

        /// <summary>
        /// Creates the <see cref="NugetConfig"/> settings that drive package creation
        /// </summary>
        /// <param name="PrimaryAssembly">The primary assembly to be packaged</param>
        /// <param name="outdir">The directory to which the produced package will be published</param>
        /// <param name="resid">The name of the .nuspec embedded resource to use</param>
        /// <returns></returns>
        public static NugetConfig Create(
            Assembly PrimaryAssembly,
            string outdir,
            string resid,
            Version netVersion,
            IEnumerable<string> inputFiles = null

            )
        {
            return new NugetConfig
            {
                NuspecTemplateName = resid,
                OutputFileName = resid,
                OutputDirectory = outdir,
                PackageVersion = PrimaryAssembly.GetSemanticVersion(),
                WorkingDirectory = Path.Combine(Path.GetTempPath(), PrimaryAssembly.GetSimpleName()),
                InputFiles = metacore.rolist(inputFiles) ?? GetDefaultInputFiles(PrimaryAssembly),
                NuspecText = PrimaryAssembly.GetResourceText(resid),
                NetVersion = $"net{GetNetFramworkVersionNumber(netVersion)}",
            };
        }


        static Option<NugetConfig> CreateConfig(Assembly PrimaryAssembly, IEnumerable<string> files = null, string nuspec = null)
        {
            var outdir = Environment.GetEnvironmentVariable("NugetLib");
            if (isNotBlank(outdir) && not(Directory.Exists(outdir)))
                return none<NugetConfig>(AppMessage.Error($"Environment variable 'NugetLib' is specified but referenced directory {outdir} does not exist"));

            if (isBlank(outdir))
                outdir = Environment.CurrentDirectory;

            var designator = PrimaryAssembly.Designator();
            var netVersion = PrimaryAssembly.GetNetFrameworkVersion();
            return new NugetConfig
            {
                NuspecTemplateName = nuspec ?? $"{PrimaryAssembly.GetSimpleName()}.nuspec",
                OutputFileName = nuspec ?? $"{PrimaryAssembly.GetSimpleName()}.nuspec",
                OutputDirectory = outdir,
                PackageVersion = PrimaryAssembly.GetSemanticVersion(),
                WorkingDirectory = Path.Combine(Path.GetTempPath(), PrimaryAssembly.GetSimpleName()),
                InputFiles = files == null ? GetDefaultInputFiles(PrimaryAssembly) : files.ToList(),
                NuspecText = PrimaryAssembly.GetResourceText(nuspec),
                NetVersion = $"net{GetNetFramworkVersionNumber(netVersion)}",
            };
        }

        public static NuGetSpec Prepare(Assembly PrimaryAssembly, IReadOnlyList<string> InputFiles)
        {
            var config = CreateConfig(PrimaryAssembly, InputFiles).Require();
            var workdir = config.WorkingDirectory;
            if (Directory.Exists(workdir))
                Directory.Delete(workdir, true);
            Directory.CreateDirectory(workdir);

            var designator = PrimaryAssembly.Designator();

            var nuspec = new Script(config.NuspecText);
            if (designator != null)
                nuspec = nuspec.SpecifyParameter("PackageId", designator.ModuleName);

            var dependencies = stream<PackageDependency>();

            nuspec = nuspec.SpecifyParameter("PackageVersion", config.PackageVersion)
                           .SpecifyParameters(dict(map(dependencies, dependency =>
                                    (dependency.VersionMoniker, dependency.ArtifactVersion))), true);
            File.WriteAllText(config.OutputPath, nuspec);

            var libdir = Path.Combine(workdir, $@"lib\{config.NetVersion}");
            Directory.CreateDirectory(libdir);
            foreach (var file in config.InputFiles)
            {
                File.Copy(file, Path.Combine(libdir, Path.GetFileName(file)));
            }

            var spec = Pack(config.OutputPath, config.OutputDirectory);
            return spec;
        }

        public static NuGetSpec Prepare(Assembly PrimaryAssembly, params Assembly[] dependencies)
        {
            var files = new List<string>();
            files.AddRange(GetDefaultInputFiles(PrimaryAssembly));
            files.AddRange(GetDefaultInputFiles(dependencies));
            return Prepare(PrimaryAssembly, files);
        }

        public static NuGetSpec Prepare(IAssemblyDesignator designator)
            => Prepare(designator.DesignatedModule, designator.ModuleDependencies.ToArray());


        public NuGetProcess(IApplicationContext context)
            : base(context)
        { }

        static string FormatArgs(NuGetSpec spec)
        {
            var args = spec.GetArguments();
            var sb = new StringBuilder();
            switch (spec.Action)
            {
                case ToolAction.Pack:
                    var target = spec.Target.Require();
                    sb.Append($"pack  {target.PackageSpecPath}");
                    if (isNotBlank(target.OutputDirectory))
                        sb.Append($" -OutputDirectory {target.OutputDirectory}");
                    if (spec.Verbosity != VerbosityLevel.Normal)
                        sb.Append($" -Verbosity {spec.Verbosity}");
                    break;
            }
            var format = sb.ToString();
            return format;
        }

        protected override FileName ExecutableName
            => EXE;

        protected override string FormatArguments(NuGetSpec spec)
            => FormatArgs(spec);

        protected override Option<NuGetResult> InterpretOutome(CommandProcessExecutionLog log)
        {
            return log.ExitCode == 0
                ? some(new NuGetResult())
                : none<NuGetResult>();
        }

    }
}