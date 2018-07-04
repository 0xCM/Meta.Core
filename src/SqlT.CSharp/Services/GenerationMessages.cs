//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using SqlT.Core;

    /// <summary>
    /// Defines messages emitted during the generation process
    /// </summary>
    static class GenerationMessages
    {
        public static IApplicationMessage DefiningProxies(string SchemaName)
            => ApplicationMessage.Inform("Defining proxies for the @SchemaName schema", new
            {
                SchemaName
            });

        public static IApplicationMessage EmittingDependencyFiles(FolderPath OutputFolder)
            => ApplicationMessage.Inform("Emitting dependencies to @OutputPath",
                new
                {
                    OutputFolder
                });

        public static IApplicationMessage InvalidProfile(FilePath SrcPath)
            => ApplicationMessage.Error($"The file {SrcPath} does not define a valid profile");

        public static IApplicationMessage InvalidProfileText()
            => ApplicationMessage.Error($"The supplied text could not be interpreted as valid profile");

        public static IApplicationMessage InitiatingProxyEmission()
            => ApplicationMessage.Inform("Emitting proxy source code ");

        public static IApplicationMessage SavingFile(string OutputPath)
            => ApplicationMessage.Inform("Saving @OutputPath", new
            {
                OutputPath
            });

        public static IApplicationMessage GeneratingProject(this CodeGenerationProfile gp)
            =>  ApplicationMessage.Inform("Generating @ProjectName project", new
            {
                gp.ProjectName
            });

        public static IApplicationMessage BuildingProject(this CodeGenerationProfile gp)
            => ApplicationMessage.Inform("Building @ProjectName project", new
            {
                gp.ProjectName
            });

    }

}





