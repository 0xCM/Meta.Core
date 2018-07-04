//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;
    using Meta.Models;

    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public class parameter_declaration<r> : Model<parameter_declaration<r>>, sxc.parameter_declaration<r>
            where r : sxc.data_type_ref
        {
            public parameter_declaration(SqlParameterName name, r type, sxc.scalar_expression init = null)
            {
                this.Name = name;
                this.parameter_type = type;
                this.init = new ModelOption<sxc.scalar_expression>(init);
            }

            public r parameter_type { get; }

            public SqlParameterName Name { get; }

            public ModelOption<sxc.scalar_expression> init { get; }

            sxc.data_type_ref sxc.parameter_declaration.parameter_type
                => parameter_type;
        }

        public sealed class parameter_declaration : parameter_declaration<sxc.data_type_ref>
        {
            public parameter_declaration(SqlParameterName name, sxc.data_type_ref parameter_type, sxc.scalar_expression init = null)
                : base(name, parameter_type, init)
            {
            }
        }

    }
}