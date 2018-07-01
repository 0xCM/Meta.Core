//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    /// <summary>
    /// Categorizes a collection of <see cref="DevArea"/> subdivision
    /// </summary>
    public class DevSegment : SemanticIdentifier<DevSegment, string>
    {

        public static DevWorkspaceIdentifier operator +(DevSegment segment, DevArea area)
            => new DevWorkspaceIdentifier(area, segment);

        public static implicit operator DevSegment(string x)
            => new DevSegment(x);

        protected override DevSegment New(string IdentifierText)
            => new DevSegment(IdentifierText ?? string.Empty);


        DevSegment()
            : base(string.Empty)
        { }

        public DevSegment(string text)
            : base(text)
        {

        }

    }

        

 
}