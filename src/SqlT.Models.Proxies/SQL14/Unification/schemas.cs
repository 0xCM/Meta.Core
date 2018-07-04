//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL14.sys
{
    using System.Collections.Generic;
    using static metacore;


    public partial class schemas : ISchema
    {
        static readonly HashSet<string> sysSchemaNames = new HashSet<string>
            (
                new[]
                {
                    "dbo",
                    "guest",
                    "INFORMATION_SCHEMA",
                    "sys",
                    "db_owner",
                    "db_accessadmin",
                    "db_securityadmin",
                    "db_ddladmin",
                    "db_backupoperator",
                    "db_datareader",
                    "db_datawriter",
                    "db_denydatareader",
                    "db_denydatawriter",
                }

            );


        public override string ToString() => name;

        public bool is_user_defined => not(sysSchemaNames.Contains(name));

    }
}