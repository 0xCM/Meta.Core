//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using System.Collections.Generic;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;


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