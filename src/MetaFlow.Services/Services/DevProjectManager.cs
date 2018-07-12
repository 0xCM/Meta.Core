//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Core;
    using Meta.Core.Project;
    using Meta.Core.Build;
    using SqlT.Core;
    using MetaFlow.Core;
   
    using static metacore;


    class DevProjectManager : PlatformService<DevProjectManager,IDevProjectManager>, IDevProjectManager
    {
        static string SolutionId(FileName SolutionFileName)
            => SolutionFileName.RemoveExtension()
                                .Replace("MetaFlow.", string.Empty)
                                .Replace('.', '_');

        static string ProjectId(FileName ProjectFileName)
            => ProjectFileName.RemoveExtension()
                               .Replace('.', '_');

        Lazy<IMetaBuild> _MetaBuild { get; }

        public DevProjectManager(INodeContext C)
            : base(C)
        {
            _MetaBuild = defer(() => C.MetaBuild());

        }

        IMetaBuild MetaBuild
            => _MetaBuild.Value;

        FolderPath AreaDir
            => PlatformVariables.DevAreaDir;


        Option<string> GetTargetDatabase(IEnumerable<PropertyEvaluation> properties)
            => properties.TryGetFirst(p => equals(p.PropertyName, "TargetDatabase"))
                         .Map(z => z.EpandedValue);                        
       
        Seq<SystemIdentifier> Systems
            => from literal in ClrEnum.Get<PlatformSystemKind>().Literals
               where literal.LiteralName != PlatformSystemKind.None.ToString()
               select SystemIdentifier.Parse(literal.LiteralName);

        public Seq<FolderPath> AreaFolders
             => from s in Systems
                let folderName = FolderName.Parse(s.Identifier)
                select AreaDir + folderName;

        public Seq<FilePath> SolutionFiles
            => from f in AreaFolders
               from s in seq(f.GetFiles("*.sln"))
               select s;

        public FilePath SystemSolutionFile(SystemIdentifier sysId)
            => (AreaDir + FolderName.Parse(sysId)).GetFiles("*.sln").FirstOrDefault();

        public Option<SolutionDescription> SystemSolution(SystemIdentifier sysId)
            => MetaBuild.DescribeSolution(SystemSolutionFile(sysId));

        public IEnumerable<FilePath> SystemProjectFiles(SystemIdentifier sysId)
            => (AreaDir + FolderName.Parse(sysId)).GetFiles(stream(SqlProject.FileExtension, CSharpProject.FileExtension), true);

        public IEnumerable<SolutionName> SystemSolutionNames(SystemIdentifier id)
            => from f in (AreaDir + FolderName.Parse(id)).GetFiles("*.sln")
               select SolutionName.Parse(f.FileName);

        public Seq<FilePath> ProjectFiles(string type)
            => from f in AreaFolders
               from p in seq(f.GetFiles($"*.{type}", true))
               select p;

        public Seq<DevProjectName> SystemProjectNames(string type)
            => from p in ProjectFiles(type)
               select DevProjectName.Parse(p.FileName);

        public Seq<SolutionName> SystemSolutionNames()
            => from f in SolutionFiles
               select SolutionName.Parse(f.FileName);

        public IEnumerable<PlatformProject> DiscoverPlatformProjects()
            => from system in Systems.Stream()
               let sln = SystemSolution(system).OnNone(Notify)
               where sln.IsSome()
               let slnId = sln.MapRequired(x => SolutionId(x.Name))
               from project in sln.Require().Projects
               let properties = project.Evaluations
               select new PlatformProject
               (
                   SystemId: system.Identifier,
                   SolutionId: slnId,
                   ProjectId: ProjectId(project.AbsolutePath.FileName),
                   ProjectName: project.Name,
                   TargetAssembly: project.AssemblyName.ValueOrDefault(),
                   IsSqlProject: project.AbsolutePath.Extension == CommonFileExtensions.SqlProject,
                   TargetDatabase: GetTargetDatabase(properties).ValueOrDefault()
               );

        public IEnumerable<Core.PlatformSolution> DiscoverPlatformSolutions()
            => from s in Systems.Stream()
               let folderName = FolderName.Parse(s.Identifier)
               let folderPath = AreaDir + folderName
               from file in folderPath.GetFiles("*.sln")
               select new Core.PlatformSolution(
                    SystemId: s.Identifier,
                    SolutionId: SolutionId(file.FileName),
                    SolutionName: file.FileName
                   );
    }
}