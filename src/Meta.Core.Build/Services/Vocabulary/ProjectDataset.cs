//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static BuildSyntax;

    public sealed class ProjectDataset
    {
        public ProjectDataset(   )
        {
            Imports = new ProjectImports();
            PropertyGroups = new PropertyGroups();
            ProjectFile = FilePath.Empty;
            ItemGroups = new ItemGroups();
            ToolsVersion = string.Empty;
        }

        public string ToolsVersion { get; set; }

        public FilePath ProjectFile { get; set; }

        public ProjectImports Imports { get; set; }

        public PropertyGroups PropertyGroups { get; set; }

        public ItemGroups ItemGroups { get; set; }

        public IEnumerable<PropertyGroupMember> Properties
            => from g in PropertyGroups
               from p in g.Properties
               select p;

        public IEnumerable<ItemGroupMember> Items
            => from g in ItemGroups
               from p in g.Members
               select p;
    }
}