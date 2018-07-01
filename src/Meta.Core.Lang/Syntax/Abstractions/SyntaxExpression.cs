//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{

    using Meta.Models;

    public abstract class SyntaxExpression<e> : Model<e>, ISyntaxExpression
        where e : SyntaxExpression<e>

    {

    }

    public sealed class SyntaxExpression : SyntaxExpression<SyntaxExpression>
    {

        public SyntaxExpression(ISyntaxExpression Value)
            => this.Value = Value;

        public ISyntaxExpression Value { get; }

        public override string ToString()
            => Value.ToString();
    }
}