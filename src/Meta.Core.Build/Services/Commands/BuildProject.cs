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

    using Meta.Core.Commands;

    using static metacore;

    [CommandSpec]
    public class BuildProject : CommandSpec<BuildProject, ToolResult>
    {
        public BuildProject()
        {
            Properties = new List<NamedValue>();
            Targets = new List<string>();
        }

        public BuildProject(FilePath ProjectFile)
            : this()
        {
            this.ProjectFile = ProjectFile;
        }


        [CommandParameter]
        public FilePath ProjectFile { get; set; }

        [CommandParameter]
        public IReadOnlyList<NamedValue> Properties { get; set; }

        [CommandParameter]
        public IReadOnlyList<string> Targets { get; set; }

    }



}