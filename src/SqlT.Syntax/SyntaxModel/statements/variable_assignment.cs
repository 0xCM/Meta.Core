//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using static metacore;
    using static SqlSyntax;

    partial class SqlSyntax
    {

        public class variable_assignment : statement<variable_assignment>
        {

            public variable_assignment(SqlVariableName variable_name, ISyntaxExpression variable_value)
                : base(SET)
            {
                this.variable_name = variable_name;
                this.variable_value = variable_value;
            }

            public SqlVariableName variable_name { get; }

            public ISyntaxExpression variable_value { get; }

            public override string ToString()
                => $"{SET} {variable_name} = {variable_value}";
        }
    }
}