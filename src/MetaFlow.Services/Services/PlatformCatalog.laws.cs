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

    using MetaFlow.Core;
    using SqlT.Core;

    public interface IPlatformCatalog
    {
        IEnumerable<PlatformDatabase> PlatformDatabases { get; }

        SqlDatabaseName CanonicalDbName(PlatformDatabaseKind DbType);
    }
}