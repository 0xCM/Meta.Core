//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class LinkedServerDescription
    {
        public LinkedServerDescription(SqlServerName HostServerName, SqlLinkedServerHandle LinkedServer, bool New)
        {
            this.HostServerName = HostServerName;
            this.LinkedServer = LinkedServer;
            this.New = New;
        }
        public SqlServerName HostServerName { get; }

        public SqlLinkedServerHandle LinkedServer { get; }

        public bool New { get; }
    }
}
