//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class partition_by_clause : Clause<partition_by_clause>
        {
            public partition_by_clause(sxc.value_expression expression)
                : base(KeyPhrase.create(PARTITION, BY))
            {
                this.expression = expression;
            }


            public sxc.value_expression expression { get; }
           
        }

    }


}