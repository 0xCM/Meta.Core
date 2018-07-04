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

        public sealed class system_time_from : Model<system_time_from>
        {
            public system_time_from(system_time_range range)
            {
                this.range = range;
            }


            public system_time_range range { get; }

        }



    }

}