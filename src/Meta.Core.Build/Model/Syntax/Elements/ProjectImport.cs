//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    partial class BuildSyntax
    {
        public sealed class ProjectImport : ProjectElement<ProjectImport>
        {

            public ProjectImport()
                : base(nameof(ProjectImport), string.Empty, string.Empty, 0)
            {

            }

            public ProjectImport(ISymbolicExpression Project, string Label = null, string Condition = null, int Position = 0)
                : base(nameof(ProjectImport), Label ?? string.Empty, Condition ?? string.Empty, Position)
            {
                this.Project = Project;
                this.Condition = Condition ?? string.Empty;
                this.Position = Position;
            }

            public ISymbolicExpression Project { get; set; }



            public override string ToXml()
                => $"<Import Project=\"{Project}\" Condition=\"{Condition}\"/>";
        }

        public sealed class ProjectImports : TypedItemList<ProjectImports, ProjectImport>
        {
            public static implicit operator ProjectImports(ProjectImport[] imports)
                => Create(imports);

        }


    }
}