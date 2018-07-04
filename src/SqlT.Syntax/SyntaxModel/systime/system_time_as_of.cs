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


        public sealed class system_time_as_of : Model<system_time_as_of>
        {
            public system_time_as_of(system_time_arg as_of)
            {
                this.as_of = as_of;
            }

            public system_time_arg as_of { get; }
        }


    }

}