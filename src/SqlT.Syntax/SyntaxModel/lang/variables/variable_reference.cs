//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using sxc = contracts;
    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class variable_reference : scalar_expression<variable_reference>
        {
            public static implicit operator variable_reference(string varname)
                => new variable_reference(varname);


            public variable_reference(SqlVariableName variable_name)
            {
                this.variable_name = variable_name;
            }

            public SqlVariableName variable_name { get; }

            public override string ToString()
                => variable_name.ToString();

        }

    }

}