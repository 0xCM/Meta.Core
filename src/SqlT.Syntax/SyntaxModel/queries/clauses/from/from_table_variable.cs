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

        public class from_table_variable : Model<from_table_variable>
        {
            public from_table_variable(SqlVariableName variable_name, table_alias table_alias = null)
            {
                this.variable_name = variable_name;
                this.table_alias = table_alias;
            }

            public SqlVariableName variable_name { get; }

            public ModelOption<table_alias> table_alias { get; }


        }


    }

}