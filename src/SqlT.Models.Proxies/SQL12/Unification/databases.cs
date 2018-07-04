//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL12.sys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;



    public partial class databases : IDatabase
    {
        static HashSet<string> sysdbnames = new HashSet<string>(array("master", "tempdb", "model", "msdb"));

        public bool? is_federation_member 
            => null;

        public bool? is_mixed_page_allocation_on 
            => null;

        public bool? is_remote_data_archive_enabled 
            => null;

        public bool is_system_defined 
            => sysdbnames.Contains(name);

        public bool is_user_defined 
            => not(is_system_defined);

        public override string ToString() 
            => name;

    }


}