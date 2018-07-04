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
    using Meta.Models;

    using sxc = contracts;

    public abstract class predicate<e> : Model<predicate<e>>, sxc.predicate
       where e : ISyntaxExpression
    {
        public static implicit operator predicate(predicate<e> p)
            => new predicate(p);

        public predicate(e expression)
        {
            this.expression = expression;
        }

        public e expression { get; }

        ISyntaxExpression sxc.predicate.expression
            => expression;
    }



}