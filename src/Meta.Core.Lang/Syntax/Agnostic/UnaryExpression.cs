//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;

    
    public abstract class UnaryExpression<e, v> : SyntaxExpression<e>, IUnaryExpression<v>
        where e : UnaryExpression<e, v>
        where v : ISyntaxExpression
    {
        protected UnaryExpression(v operand)
        {
            this.Operand = operand;

        }

        public v Operand { get; }


        ISyntaxExpression IUnaryExpression.Operand
            => Operand;
    }



    public abstract class UnaryExpression<v> : UnaryExpression<UnaryExpression<v>, v>
        where v : ISyntaxExpression
    {
        public UnaryExpression(v operand)
            : base(operand)
        { }
    }











}