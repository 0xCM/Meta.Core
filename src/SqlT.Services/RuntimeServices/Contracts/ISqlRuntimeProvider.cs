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

    public interface ISqlRuntimeProvider
    {
        ISqlIndexRuntime Index(ISqlIndexHandle h);

        ISqlDatabaseRuntime Database(ISqlDatabaseHandle h);

        ISqlSequenceRuntime Sequence(ISqlSequenceHandle h);

        ISqlServerRuntime Server(ISqlServerHandle h);

        ISqlTableRuntime Table(ISqlTableHandle h);
    
    }
}