//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
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