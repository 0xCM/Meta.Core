//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;


    using sxc = contracts;


    public class predicate_negation : predicate<sxc.predicate>
    {
        public static predicate operator !(predicate_negation p)
            => new predicate(p);


        public predicate_negation(sxc.predicate expression)
            : base(expression)
        {

        }

        public override string ToString()
            => $"not {expression}";

        public predicate negate()
            => new predicate(this);

    }


}