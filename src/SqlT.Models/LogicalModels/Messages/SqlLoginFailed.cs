//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    using static metacore;

    using SqlT.Core;

    
    public class SqlLoginFailed : SqlServerErrorNotification
    {        

        public SqlLoginFailed()
        {

        }

        internal SqlLoginFailed(SqlException e, SqlConnectionString cs)
            : base(e)
        {
            DbName = cs.DatabaseName;
        }

        
        public string DbName { get; set; }
    }
}
