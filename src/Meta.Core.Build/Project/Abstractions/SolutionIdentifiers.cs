//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;


    /// <summary>
    /// Encapsulates a set of <see cref="SolutionIdentifier"/>
    /// </summary>
    public abstract class SolutionIdentifiers<X> : TypedItemList<X, SolutionIdentifier>
       where X : SolutionIdentifiers<X>, new()
    {
        protected SolutionIdentifiers()
            : base(semicolon())
        {

        }

    }


}