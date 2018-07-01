//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System.Collections.Generic;

    using static ClrStructureSpec;

    public sealed class ImplementationArea : WorkspaceArea<ImplementationArea>
    {
        public const string DefaultName = "src";

        public static implicit operator WorkspaceArea(ImplementationArea area)
            => new WorkspaceArea(area);

        public ImplementationArea(string AreaName, IEnumerable<ProjectContentFile> Content)
            : base(AreaName)
        {
            this.Content = Content.ToReadOnlyList();
        }

        public ImplementationArea(IEnumerable<ProjectContentFile> Content)
            : this(DefaultName, Content)
        { }

        public IReadOnlyList<ProjectContentFile> Content { get; }
    }


}
