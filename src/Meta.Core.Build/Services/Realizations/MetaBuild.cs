//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using static metacore;

    

    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Linq;

    using Microsoft.Build.Framework;

    using static BuildSyntax;

    using MSC = Microsoft.Build.Construction;
    using MSEV = Microsoft.Build.Evaluation;
    using MSEX = Microsoft.Build.Execution;
    using MSL = Microsoft.Build.Logging;
    using SL = Microsoft.Build.Logging.StructuredLogger;

    class MetaBuild : ApplicationService<MetaBuild, IMetaBuild>, IMetaBuild
    {
        
        public MetaBuild(IApplicationContext C)
            : base(C)
        {

        }

        public IReadOnlyList<FilePath> GetProjectFiles(FilePath ProjectFile)
        {
            try
            {
                var project = new MSEX.ProjectInstance(ProjectFile);
                var evaluations = project.Items.Map(item => (item.ItemType, item.EvaluatedInclude));
                var paths = evaluations.Where(e => e.Item1 == "Build")
                                       .Select(x => ProjectFile.Folder.GetCombinedFilePath(x.Item2)).Where(f => f.Exists()).ToList();
                return paths;

            }
            catch(Exception e)
            {
                Notify(error($"Error occurred during evaluation of {ProjectFile}: {e}"));
                return metacore.rolist<FilePath>();
            }
        }

        public Option<string> BuildSolution(FilePath SolutionPath)
        {
            var manager = MSEX.BuildManager.DefaultBuildManager;
            var project = new MSEX.ProjectInstance(SolutionPath);

            var logPath = SolutionPath.ChangeExtension("binlog");
            var buildRequest = new MSEX.BuildRequestData(project, array("Build"));
            var result = manager.Build
            (
                new MSEX.BuildParameters
                {
                    Loggers = metacore.rolist<ILogger>(new MSL.ConsoleLogger())

                }, 
                buildRequest
            );

            var targetResults = result.ResultsByTarget["Build"];
            return targetResults.ResultCode.ToString();
        }


        public Option<SolutionDescription> DescribeSolution(FilePath SrcPath)
        {
            try

            {
                var slnFile = MSC.SolutionFile.Parse(SrcPath);


                var projects =

                    list(from project in slnFile.ProjectsInOrder

                         where project.ProjectType == MSC.SolutionProjectType.KnownToBeMSBuildFormat
                            || project.AbsolutePath.EndsWith(".sqlproj")
                         select new ProjectDescription
                         (
                           project.ProjectName,
                           project.AbsolutePath,
                           project.RelativePath,
                           project.ProjectGuid
                           )
                         {
                            Dependencies = project.Dependencies,
                            Files = GetProjectFiles(project.AbsolutePath),
                            Properties = metacore.rolist(EvaluateProjectProperties(project.AbsolutePath))

                         });
                return new SolutionDescription(SrcPath, projects.Stream());                       

            }
            catch(Exception e)
            {
                return none<SolutionDescription>(e);
            }

        }

        public Option<BuildSummary> SummarizeStructuredLog(FilePath BuildLogPath)
        {
            if (!BuildLogPath.Exists())
                return none<BuildSummary>(error($"The file {BuildLogPath} does not exist"));

            try
            {
                var log = SL.BinaryLog.ReadBuild(BuildLogPath);
                return new BuildSummary
                {
                    Duration = log.Duration,
                    EndTime = log.EndTime,
                    ProjectName = log.Children.OfType<SL.Project>().FirstOrDefault()?.Name ?? "Unknown Project",
                    StartTime = log.StartTime,
                    Succeeded = log.Succeeded,
                    BuildLog = BuildLogPath
                };
            }
            catch (Exception e)
            {
                return none<BuildSummary>(e);
            }
        }

        public IEnumerable<Option<BuildSummary>> SummarizeStructuredLogs(FolderPath SrcDir, FileExtension ext = null)
        {
            var defaultExt = new FileExtension("binlog");
            var pattern = $"*.{ext ?? defaultExt}";
            var paths = Directory.EnumerateFiles(SrcDir, pattern, SearchOption.TopDirectoryOnly);
            foreach (var srcPath in paths)
                yield return SummarizeStructuredLog(srcPath);
        }

        public IEnumerable<object> EvaluateProjectItems(FilePath ProjectFile)
        {
            try
            {
                var project = new MSEV.Project(ProjectFile);
                var query = from g in project.AllEvaluatedItems
                            group g by g.ItemType into ig
                            orderby ig.Key
                            from i in ig
                            select i;
                return query;
            }
            catch(Exception e)
            {
                Notify(error($"Error occurred during item evaluation of {ProjectFile}: {e}"));
                return stream<object>();
            }

        }

        ItemGroups ItemGroups(MSEV.Project project)
            => array(from g in project.Xml.ItemGroups
                     select new ItemGroup
                     (                        
                        from i in g.Items
                            where isNotBlank(i.Include)
                            select new ItemGroupMember
                            (
                                i.ElementName,
                                SymbolicLiteral.Define(i.Include),
                                i.Label,
                                i.Condition
                             ),
                            g.Label
                     ));

        PropertyGroups PropertyGroups(MSEV.Project project)
            => array(from g in project.Xml.PropertyGroups
                     select new PropertyGroup
                        (from p in g.Properties
                            select new PropertyGroupMember
                                (p.Name, SymbolicLiteral.Define(p.Value), ifBlank(p.Label, p.Parent?.Label), p.Condition),
                            g.Label)
                     );

        ProjectImports ProjectImports(MSEV.Project project, int pos = 0)
            => array(from p in project.Xml.Imports
                     select new ProjectImport(SymbolicLiteral.Define(p.Project), p.Label, p.Condition, pos++));

        PropertyGroupMembers ProjectProperties(MSEV.Project project)
            => array(from p in project.Xml.Properties
                     select new PropertyGroupMember(p.Name, SymbolicLiteral.Define(p.Value), ifBlank(p.Label, p.Parent?.Label), p.Condition));

        public Option<ProjectDataset> ProjectDataset(FilePath ProjectFile)
        {
            var project = new MSEV.Project(ProjectFile);
            try
            {                                             
                return new ProjectDataset
                {
                    ToolsVersion = project.ToolsVersion,
                    ProjectFile = ProjectFile,
                    Imports = ProjectImports(project),
                    PropertyGroups = PropertyGroups(project),
                    ItemGroups = ItemGroups(project)
                };
            }
            catch(Exception e)
            {
                return none<ProjectDataset>(e);
            }
        }
            
        public IEnumerable<PropertyEvaluation> EvaluateProjectProperties(FilePath ProjectFile)
        {
            try
            {
                var project = new MSEV.Project(ProjectFile);                
                var evaluations = list(from p in project.AllEvaluatedProperties
                            orderby p.Name                            
                            let pe = new PropertyEvaluation(p.Name, p.UnevaluatedValue, p.EvaluatedValue,p.IsEnvironmentProperty)
                            select pe);
                return evaluations.Stream();
            }
            catch(Exception e)
            {
                Notify(error($"Error occurred during property evaluation of {ProjectFile}: {e}"));
                return stream<PropertyEvaluation>();
            }
        }

        /// <summary>
        /// Adds files to a project and optionally builds the updated project
        /// </summary>
        /// <param name="ProjectFile">The path to the VS project</param>
        /// <param name="files">The files to add</param>
        /// <param name="build">Spcifies whether the updated project should be built</param>
        public void AddProjectFiles(FilePath ProjectFile, IReadOnlyList<FilePath> files, bool build = false)
            => MsBuild.AddProjectFiles(ProjectFile, files, build);
    }

}