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
    using Meta.Models;
    using SqlT.Core;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        /// <summary>
        /// Represents a select clause
        /// </summary>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/queries/select-clause-transact-sql
        /// </remarks>
        public sealed class select_clause : Clause<select_clause>
        {

            public select_clause(selected_item item, top_clause top = null, kwt.DISTINCT distinct = null)
                : base(SELECT)
            {
                this.select_list = new select_list(item);
                this.top = top;
                this.distinct = distinct;
            }

            public select_clause(select_list select_list, top_clause top = null, kwt.DISTINCT distinct = null)
                : base(SELECT)
            {
                this.select_list = select_list;
                this.top = top;
                this.distinct = distinct;
            }


            public select_list select_list { get; }

            public ModelOption<top_clause> top;

            public ModelOption<kwt.DISTINCT> distinct;

            public override string ToString()
                => $"{SELECT} {top} {distinct} {select_list}";
        }

        
    }
}