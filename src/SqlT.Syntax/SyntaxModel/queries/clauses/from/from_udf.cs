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

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public class from_udf : Model<from_udf>
        {
            public from_udf(SqlFunctionName function_name, table_alias table_alias = null)
            {
                this.function_name = function_name;
                this.table_alias = table_alias;
            }

            public SqlFunctionName function_name { get; }

            public ModelOption<table_alias> table_alias { get; }
        }


    }

}