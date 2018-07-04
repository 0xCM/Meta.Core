//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using SqlT.Core;
    using Meta.Models;

    partial class SqlSyntax
    {


        public sealed class scalar_variable<v> : variable<v>, sxc.scalar_variable
            where v : sxc.scalar_type
        {
            public scalar_variable(SqlVariableName name, v value = default(v))
                : base(name, value)
            { }
        }
    }

}