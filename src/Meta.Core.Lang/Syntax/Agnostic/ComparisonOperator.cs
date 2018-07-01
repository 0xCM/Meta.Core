//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using Meta.Models;
    
    public abstract class ComparisonOperator<r> : Operator<r, LogicalValue>, IComparisonOperator
        where r : ComparisonOperator<r>
    {
        protected ComparisonOperator(OperatorName name, string symbol = null)
            : base(name, symbol)
        {

        }
    }

    

}