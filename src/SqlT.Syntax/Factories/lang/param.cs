//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using SqlT.Models;
    using SqlT.Core;

    using static SqlSyntax;
    using sxc = contracts;


    public static partial class sql
    {
        public static parameter_declaration param(SqlParameterName name, sxc.data_type_ref type, sxc.scalar_expression init = null)
            => new parameter_declaration(name, type, init);

    }

}