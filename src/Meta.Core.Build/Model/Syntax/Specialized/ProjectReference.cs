//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{


    using Build;
    using Meta.Core.Project;

    partial class BuildSyntax
    {

        public class ProjectReference : SyntaxElement<ProjectReference>
        {

            public ProjectReference(DevProjectName ReferencedProject, string Label = null)
                : base(new ElementDescriptor("", Label))
            {

                this.ReferencedProject = ReferencedProject;
            }


            public DevProjectName ReferencedProject { get; set; }

            public override string ToString()
                => ReferencedProject.ToString();

        }

        public sealed class ProjectReferences : TypedItemList<ProjectReferences, ProjectReference>
        {

        }


    }
}
