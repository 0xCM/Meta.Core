//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System.Collections.Generic;

    using static ClrStructureSpec;
    

    public sealed class CSharpImplementationArea : WorkspaceArea<ImplementationArea>
    {
        public const string DefaultName = "src";

        public static implicit operator WorkspaceArea(CSharpImplementationArea area)
            => new WorkspaceArea(area);

        public CSharpImplementationArea(string AreaName, IEnumerable<CodeFileSpec> Content)
            : base(AreaName)
        {
            this.Content = Content.ToReadOnlyList();
        }

        public CSharpImplementationArea(IEnumerable<CodeFileSpec> Content)
            : this(DefaultName, Content)
        { }

        public IReadOnlyList<CodeFileSpec> Content { get; }
    }

}
