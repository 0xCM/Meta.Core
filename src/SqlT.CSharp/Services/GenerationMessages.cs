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
        public static IAppMessage DefiningProxies(string SchemaName)
            => AppMessage.Inform("Defining proxies for the @SchemaName schema", new
            {
                SchemaName
            });

        public static IAppMessage EmittingDependencyFiles(FolderPath OutputFolder)
            => AppMessage.Inform("Emitting dependencies to @OutputPath",
                new
                {
                    OutputFolder
                });

        public static IAppMessage InvalidProfile(FilePath SrcPath)
            => AppMessage.Error($"The file {SrcPath} does not define a valid profile");

        public static IAppMessage InvalidProfileText()
            => AppMessage.Error($"The supplied text could not be interpreted as valid profile");

        public static IAppMessage InitiatingProxyEmission()
            => AppMessage.Inform("Emitting proxy source code ");

        public static IAppMessage SavingFile(string OutputPath)
            => AppMessage.Inform("Saving @OutputPath", new
            {
                OutputPath
            });

        public static IAppMessage GeneratingProject(this CodeGenerationProfile gp)
            =>  AppMessage.Inform("Generating @ProjectName project", new
            {
                gp.ProjectName
            });

        public static IAppMessage BuildingProject(this CodeGenerationProfile gp)
            => AppMessage.Inform("Building @ProjectName project", new
            {
                gp.ProjectName
            });

    }

}





