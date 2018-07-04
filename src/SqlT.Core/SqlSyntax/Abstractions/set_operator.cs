//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;
    using Meta.Syntax;


    public abstract class set_operator<r> : Operator<r>
        where r : set_operator<r>
    {
        protected set_operator(IKeyword kw)
            : base(kw.KeywordName) { }
    }
}