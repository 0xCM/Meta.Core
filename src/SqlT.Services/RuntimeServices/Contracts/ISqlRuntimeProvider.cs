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

    public interface ISqlRuntimeProvider
    {
        ISqlIndexRuntime Index(ISqlIndexHandle h);

        ISqlDatabaseRuntime Database(ISqlDatabaseHandle h);

        ISqlSequenceRuntime Sequence(ISqlSequenceHandle h);

        ISqlServerRuntime Server(ISqlServerHandle h);

        ISqlTableRuntime Table(ISqlTableHandle h);
    
    }
}