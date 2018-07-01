//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Meta.Core.Build;

    using MSEV = Microsoft.Build.Evaluation;    
    using MSEX = Microsoft.Build.Execution;

    using static metacore;
    using static Meta.Core.Build.BuildSyntax;
    using static Distribution;

    public static class ServiceFactory
    {
        public static BuildNavigator BuildNavigator(this INodeContext C, FolderName AreaFolder)
            => C.NFS().Nav<BuildNavigator>(C.Host, AreaFolder);
                               
        public static IMetaBuild MetaBuild(this IApplicationContext C)
            => C.Service<IMetaBuild>();

        internal static IEnumerable<MSEX.ProjectItemInstance> AllItems(this MSEX.ProjectInstance project)
            => project.Items;

        internal static IEnumerable<MSEX.ProjectItemInstance> FilteredItems(this MSEX.ProjectInstance project, IEnumerable<ProjectItemType> types)
            => from item in project.Items
               where types.Contains(ProjectItemType.FromValue(item.ItemType))
               select item;

        internal static IEnumerable<MSEX.ProjectItemInstance> FindItems(this MSEX.ProjectInstance project, params ProjectItemType[] filter)
            => filter.Length == 0 ? project.AllItems() : project.FilteredItems(filter);

        public static IDistributionLibrary DistributionLibrary(this INodeContext C, FolderPath DistRoot = null, FolderPath DistArchiveRoot = null)
            => new DistributionLibrary(C, DistRoot, DistArchiveRoot);
    }

    public static class MsBuild
    {
        public static void AddProjectFiles(FilePath ProjectFile, IReadOnlyList<FilePath> files, bool build = false)
        {
            var project = new MSEV.Project(ProjectFile);
            var projectFolder = ProjectFile.Folder;
            foreach (var file in files)
            {
                var itemType = StandardItemTypes.InferItemType(file.FileName);
                var relativePath = file.Value.Replace(projectFolder.FullPath, String.Empty);
                if (relativePath.StartsWith("\\"))
                    relativePath = relativePath.Substring(1);

                project.AddItem(itemType, relativePath);
            }
            project.Save();
            if (build)
                project.Build();
        }
    }
}
