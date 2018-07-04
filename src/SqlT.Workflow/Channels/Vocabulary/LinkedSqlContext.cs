//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Models;


    using Meta.Core;

    using static metacore;


    public class LinkedSqlContext : LinkedContext, ILinkedSqlContext
    {

        public LinkedSqlContext(IApplicationContext PeerContext, NodeLink NodeLink, Link<SqlConnectionString> ConnectorLink)
            : base(PeerContext, NodeLink)
        {
            this.SourceContext = new SqlContext(PeerContext.NodeContext(NodeLink.Source), ConnectorLink.Source);
            this.TargetContext = new SqlContext(PeerContext.NodeContext(NodeLink.Target), ConnectorLink.Target);
        }


        public new ISqlContext SourceContext { get; }

        public SqlDatabaseName SourceDatabaseName
            => SourceContext.SqlConnector.DatabaseName;

        public SqlConnectionString SourceConnector
            => SourceContext.SqlConnector;

        public new ISqlContext TargetContext { get; }

        public SqlDatabaseName TargetDatabaseName
            => TargetConnector.DatabaseName;

        public SqlConnectionString TargetConnector
            => TargetContext.SqlConnector;

        public override string ToString()
            => concat
            (
                $"{SourceNode}/{SourceConnector.DatabaseName}",
                " => ",
                $"{TargetNode}/{TargetConnector.DatabaseName}"
            );

    }

}