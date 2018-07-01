//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    partial class BuildSyntax
    {

        public sealed class ProjectItemType : DomainPrimitive<ProjectItemType, string>
        {
            public static ProjectItemType FromValue(string Value)
                => new ProjectItemType(Value);

            public ProjectItemType(string Value)
                : base(Value)
            { }
        }

    }
}
