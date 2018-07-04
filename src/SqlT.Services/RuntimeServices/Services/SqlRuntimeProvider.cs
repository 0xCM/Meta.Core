//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    class SqlRuntimeProvider : ApplicationService<SqlRuntimeProvider, ISqlRuntimeProvider>, ISqlRuntimeProvider
    {
        public SqlRuntimeProvider(IApplicationContext C)
            : base(C)
        {


        }

        public ISqlDatabaseRuntime Database(ISqlDatabaseHandle h)        
            => new SqlDatabaseRuntime(C, h);
        
        public ISqlIndexRuntime Index(ISqlIndexHandle h)
            =>new SqlIndexRuntime(C, h);

        public ISqlSequenceRuntime Sequence(ISqlSequenceHandle h)
            => new SqlSequenceRuntime(C, h);

        public ISqlServerRuntime Server(ISqlServerHandle h)        
            => new SqlServerRuntime(C, h);
        
        public ISqlTableRuntime Table(ISqlTableHandle h)        
            => new SqlTableRuntime(C, h);
        
    }

}