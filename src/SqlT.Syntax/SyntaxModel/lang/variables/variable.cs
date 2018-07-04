//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using sxc = contracts;

    using Meta.Models;
    using SqlT.Core;

    partial class SqlSyntax
    {


        public abstract class variable<v> : Model<variable<v>>, sxc.variable
            where v : IModel
        {

            protected variable(SqlVariableName name, v value = default(v))
            {
                this.name = name;
                this.value = value;
            }

            public ModelOption<v> value { get; }

            public SqlVariableName name { get; }

            SqlVariableName sxc.variable.name
                => name;
        }



    }

}