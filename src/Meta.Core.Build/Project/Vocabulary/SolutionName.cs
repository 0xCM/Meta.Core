//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    /// <summary>
    /// Represents the display name of a <see cref="SolutionModule"/> that,
    /// like a <see cref="SolutionIdentifier"/>, identifies a solution within
    /// some context
    /// </summary>
    public sealed class SolutionName : SemanticIdentifier<SolutionName, string>
    {
        public static implicit operator SolutionName(string x)
            => new SolutionName(x);

        protected override SolutionName New(string IdentifierText)
            => new SolutionName(IdentifierText);

        SolutionName()
            : base(string.Empty)
        {

        }

        public SolutionName(string name)
            : base(name)
        {

        }

    }


}