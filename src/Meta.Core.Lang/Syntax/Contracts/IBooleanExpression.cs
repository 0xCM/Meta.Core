//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{

    using Meta.Models;


    public interface IBooleanExpression : ISyntaxExpression
    {

    }

    public interface IBooleanExpression<e> : IBooleanExpression
        where e : ISyntaxExpression
    {
    }

    public interface IBooleanExpression<e1, e2> : IBooleanExpression<e1>
        where e1 : ISyntaxExpression
        where e2 : ISyntaxExpression
    {

    }


}