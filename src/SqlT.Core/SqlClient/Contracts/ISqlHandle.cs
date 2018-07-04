//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Syntax;

    using sxc = Syntax.contracts;


    public interface ISqlHandle
    {
        ISqlClientBroker Broker { get; }

        IName ElementName { get; }

        SqlDatabaseName DefiningCatalog { get; }

        SqlServerName ConnectedServer { get; }

    }

}