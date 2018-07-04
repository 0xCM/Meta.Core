//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    partial class SqlSyntax
    {

        public sealed class for_system_time : 
            Meta.Models.du
            <
                system_time_as_of,
                system_time_from,
                system_time_between,
                system_time_contained_in,
                system_time_all
            >
        {

            public for_system_time(system_time_as_of v)
                : base(v) { }

            public for_system_time(system_time_from v)
                : base(v) { }

            public for_system_time(system_time_between v)
                : base(v) { }

            public for_system_time(system_time_contained_in v)
                : base(v) { }

            public for_system_time(system_time_all v)
                : base(v) { }

        }




    }


}