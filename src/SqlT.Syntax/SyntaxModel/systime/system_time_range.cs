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


        public sealed class system_time_range : Model<system_time_range>
        {

            public system_time_range(system_time_arg start, system_time_arg end)
            {
                this.start = start;
                this.end = end;
            }

            public system_time_arg start { get; }

            public system_time_arg end { get; }
        }


    }

}