//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    
    using Meta.Models;
    
    public abstract class LogicalOperator<r> : Operator<r,LogicalValue>, ILogicalOperator
        where r : LogicalOperator<r>
    {
        protected LogicalOperator(IKeyword kw)
            : base(kw.KeywordName)
        {
            this.Designator = Designator;
        }

        public IKeyword Designator { get; }
    }
}
