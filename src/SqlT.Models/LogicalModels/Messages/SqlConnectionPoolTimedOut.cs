//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
namespace SqlT.Models
{
    using SqlT.Core;

    public class SqlConnectionPoolTimedOut : SqlClientErrorNotification
    {
        public SqlConnectionPoolTimedOut(InvalidOperationException e, SqlConnectionString cs)
            : base(e,cs) { }

        public override string MessageDetail =>
            $"Timed out while trying to procure a connection to:{Connector}";
    }
}
