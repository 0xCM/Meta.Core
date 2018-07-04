//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;

    using sxc = contracts;



    public sealed class predicate : predicate<ISyntaxExpression>
    {

        public static predicate_negation operator !(predicate p)
            => new predicate_negation(p);

        public predicate(sxc.predicate predicate)
             : base(predicate.expression)
        {


        }


        public override string ToString()
            => expression.ToString();

        public predicate_negation negate()
            => new predicate_negation(this);
    }


}