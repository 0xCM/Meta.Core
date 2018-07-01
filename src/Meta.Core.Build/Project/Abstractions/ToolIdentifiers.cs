//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using static metacore;

    using L = Tools;
    using I = Tooldentifier;

    public abstract class ToolIdentifiers<X> : TypedItemList<X, I>
       where X : ToolIdentifiers<X>, new()
    {
        protected ToolIdentifiers()
            : base(semicolon())
        {

        }
    }


}