//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using SqlT.Core;


    /// <summary>
    /// Characterizes a SQL Server client alias entry as specified in the SQL Server
    /// Configuration Manager
    /// </summary>
    public class SqlServerAlias
    {

        public SqlServerAlias()
        {
            this.AliasName = string.Empty;
            this.ServerName = string.Empty;
            this.ProtocolName = string.Empty;
            this.ConnectionString = string.Empty;
        }

        public SqlServerAlias(string AliasName, string ServerName, string ConnectionString = "", string ProtocolName = "tcp")
        {
            this.AliasName = AliasName;
            this.ServerName = ServerName;
            this.ProtocolName = ProtocolName;
            this.ConnectionString = ConnectionString;
        }

        public string AliasName { get; }
        public string ServerName { get; }
        public string ProtocolName { get; }
        public string ConnectionString { get; }


        public override string ToString()
            => $"{AliasName} - {ProtocolName}://{ServerName}"
            + (String.IsNullOrWhiteSpace(ConnectionString) ? String.Empty : ":{ConnectionString}");
    }

}

