//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    public sealed class DevWorkspaceIdentifier : SemanticIdentifier<DevWorkspaceIdentifier, (DevArea, DevSegment)>
    {
        public static implicit operator DevWorkspaceIdentifier(string x)
            => new DevWorkspaceIdentifier(x);

        protected override DevWorkspaceIdentifier New(string IdentifierText)
            => new DevWorkspaceIdentifier(IdentifierText ?? string.Empty);

        public DevWorkspaceIdentifier(DevArea Area, DevSegment Segment)
            : base((Area, Segment))
        { }


        DevWorkspaceIdentifier()
            : base((DevArea.Empty, DevSegment.Empty))
        { }

        public DevWorkspaceIdentifier(string text)
            : base((text.Split('/')[0], text.Split('/')[1]))
        {

        }

        public override string ToString()
            => $"{Identifier.Item1}/{Identifier.Item2}";
    }
}