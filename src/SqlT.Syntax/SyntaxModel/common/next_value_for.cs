//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public class next_value_for : scalar_expression<next_value_for>
        {
            public next_value_for(sxc.sequence_name sequence)
            {
                this.sequence = sequence;
            }

            public sxc.sequence_name sequence { get; }

            public override string ToString()
                => string.Join(" ", NEXT, VALUE, FOR, $"{sequence.Format(true)}");
        }
    }
}