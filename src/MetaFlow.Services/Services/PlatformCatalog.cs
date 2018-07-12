//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;

    using MetaFlow.Core;

    class PlatformCatalog : ApplicationService<PlatformCatalog,IPlatformCatalog>, IPlatformCatalog
    {

        IReadOnlySet<PlatformDatabase>  _PlatformDatabases { get; }

        ISqlProxyBroker Broker
           => C.PlatformBroker(SystemNode.Local);


        public PlatformCatalog(IApplicationContext C)
            : base(C)
        {
            _PlatformDatabases = Broker.PlatformDatabases().Require(); 
            
        }



        public IEnumerable<PlatformDatabase> PlatformDatabases
            => _PlatformDatabases;


        public SqlDatabaseName CanonicalDbName(PlatformDatabaseKind DbType)
            => PlatformDatabases.Where(db => db.DatabaseType == DbType).First().Name;
    }


}