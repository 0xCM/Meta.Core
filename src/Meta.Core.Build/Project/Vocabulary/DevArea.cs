//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    /// <summary>
    /// Groups a collection of related projects
    /// </summary>
    public class DevArea : SemanticIdentifier<DevArea, string>
    {

        public static DevWorkspaceIdentifier operator +(DevArea area, DevSegment segment)
            => new DevWorkspaceIdentifier(area, segment);


        public static implicit operator DevArea(ClrItemIdentifier name)
            => new DevArea(name);

        public static implicit operator DevArea(string name)
            => new DevArea(name);

        protected override DevArea New(string IdentifierText)
            => new DevArea(IdentifierText ?? string.Empty);


        DevArea()
            : base(string.Empty)
        { }

        public DevArea(string text)
            : base(text)
        {

        }

        public DevArea(ClrItemIdentifier name)
            : base(name)
        {

        }

    }


}