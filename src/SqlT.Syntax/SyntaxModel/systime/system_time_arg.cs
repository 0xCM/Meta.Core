//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    partial class SqlSyntax
    {

        public sealed class system_time_arg : du<datetime_literal, variable<chronology_type>>
        {
            public system_time_arg(datetime_literal v1)
                : base(v1) { }

            public system_time_arg(variable<chronology_type> v2)
                : base(v2) { }

        }




    }

}