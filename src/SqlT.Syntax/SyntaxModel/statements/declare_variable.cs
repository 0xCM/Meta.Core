//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {


        public class declare_variable<r> : statement<declare_variable<r>>, sxc.variable_declaration<r>
            where r : sxc.data_type_ref
        {
            public declare_variable(SqlVariableName name, r type, sxc.scalar_expression init = null)
                : base(DECLARE)
            {
                this.Name = name;
                this.variable_type = type;
                this.init = new ModelOption<sxc.scalar_expression>(init);
            }

            public r variable_type { get; }

            public SqlVariableName Name { get; }

            public ModelOption<sxc.scalar_expression> init { get; }

            sxc.data_type_ref sxc.variable_declaration.variable_type
                => variable_type;
        }


        public sealed class declare_variable : declare_variable<sxc.data_type_ref>
        {
            public declare_variable(SqlVariableName name, sxc.data_type_ref variable_type, sxc.scalar_expression init = null)
                : base(name, variable_type, init)
            {
            }

        }

    }
}