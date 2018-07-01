//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;

    public abstract class BinaryExpression<e, l, r> : SyntaxExpression<e>, IBinaryExpression<l, r>
        where e : BinaryExpression<e, l, r>
        where l : ISyntaxExpression
        where r : ISyntaxExpression
    {
        protected BinaryExpression(l left, r right)
        {
            this.Left = left;
            this.Right = right;

        }

        public l Left { get; }

        public r Right { get; }

        ISyntaxExpression IBinaryExpression.Left
            => Left;

        ISyntaxExpression IBinaryExpression.Right
            => Right;
    }

    public abstract class BinaryExpression<l, r> : BinaryExpression<BinaryExpression<l, r>, l, r>
        where l : ISyntaxExpression
        where r : ISyntaxExpression
    {
        public BinaryExpression(l left, r right)
            : base(left, right)
        { }
    }
}