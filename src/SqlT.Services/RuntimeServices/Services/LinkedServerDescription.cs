//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using SqlT.Core;

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
