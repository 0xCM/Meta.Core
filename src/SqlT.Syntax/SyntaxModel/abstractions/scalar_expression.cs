//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;

    using sxc = contracts;


    public abstract class scalar_expression<e> : SyntaxExpression<e>, sxc.scalar_expression
        where e : scalar_expression<e>
    {

    }


    public abstract class scalar_expression<e, v> : SyntaxExpression<e>, sxc.scalar_expression
        where e : scalar_expression<e, v>
        where v : sxc.literal_value
    {


    }
}