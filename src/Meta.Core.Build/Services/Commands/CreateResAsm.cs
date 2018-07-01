//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using static metacore;

    public class CreateResAsm : CommandSpec<CreateResAsm, FilePath>
    {
        public CreateResAsm()
        { }

        public CreateResAsm(FilePath ProjectFile, FolderPath OutputFolder, string SimpleAssemblyName, string AssemblyVersion = null)
        {
            this.ProjectFile = ProjectFile;
            this.OutputFolder = OutputFolder;
            this.SimpleAssemblyName = SimpleAssemblyName;
            this.SpecName = $"{CommandName}-{ProjectFile.FileName.RemoveExtension()}";
            this.AssemblyVersion = ifBlank(AssemblyVersion, "1.0.0");
        }

        /// <summary>
        /// The path to the VS project whose files will be embedded as resources
        /// </summary>
        [CommandParameter("The path to the VS project whose files will be embedded as resources")]
        public FilePath ProjectFile { get; set; }

        /// <summary>
        /// The path of the folder into which the assembly will be emitted
        /// </summary>
        [CommandParameter("The path of the folder into which the assembly will be emitted")]
        public FolderPath OutputFolder { get; set; }

        /// <summary>
        /// The simple name of the essembly, e.g., Meta.Core.Resources
        /// </summary>
        [CommandParameter("The simple name of the essembly, e.g., Meta.Core.Resources")]
        public string SimpleAssemblyName { get; set; }

        /// <summary>
        /// The version of the assembly, e.g., 1.3.343
        /// </summary>
        [CommandParameter("The version of the assembly")]
        public string AssemblyVersion { get; set; }

        public override IApplicationMessage DescribeIntent()
            => Describe("Creating a source code resource assembly for the @ProjectFile project",
                    new
                    {
                        ProjectFile
                    }
                );
    }
}