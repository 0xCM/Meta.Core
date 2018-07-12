//This file was generated at 3/9/2018 10:57:19 PM using version 1.0.78.30752 the SqT data access toolset.
namespace MetaFlow.Proxies.WS
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    public sealed class WSTableNames
    {
        public readonly static SqlTableName AgentRunStatusCode = "[WS].[AgentRunStatusCode]";
    }

    [SqlTable("WS", "AgentRunStatusCode")]
    public partial class AgentRunStatusCode : SqlTableProxy
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Description", 2), SqlTypeFacets("nvarchar", true, 500)]
        public string Description
        {
            get;
            set;
        }

        public AgentRunStatusCode()
        {
        }

        public AgentRunStatusCode(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Description = (string)items[2];
        }

        public AgentRunStatusCode(byte TypeCode, string Identifier, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Description = (string)items[2];
        }
    }

    public sealed class WSProcedureNames
    {
        public readonly static SqlProcedureName DefineAgentRunStatusCodes = "[WS].[DefineAgentRunStatusCodes]";
    }

    [SqlProcedure("WS", "DefineAgentRunStatusCodes")]
    public partial class DefineAgentRunStatusCodes : SqlProcedureProxy
    {
        public DefineAgentRunStatusCodes()
        {
        }
    }

    /// <summary>
    /// Routines defined in the WS schema
    /// </summary>
    [SqlOperationContract()]
    public interface IWorkspaceOps
    {
        [SqlProcedure("WS", "DefineAgentRunStatusCodes")]
        SqlOutcome<Int32> DefineAgentRunStatusCodes();
    }

    public sealed class WSViewNames
    {
        public readonly static SqlViewName AgentJobHistory = "[WS].[AgentJobHistory]";
    }

    [SqlView("WS", "AgentJobHistory")]
    public partial class AgentJobHistory : SqlViewProxy
    {
        [SqlColumn("RowId", 0), SqlTypeFacets("bigint", true)]
        public long? RowId
        {
            get;
            set;
        }

        [SqlColumn("EntryId", 1), SqlTypeFacets("int", false)]
        public int EntryId
        {
            get;
            set;
        }

        [SqlColumn("JobId", 2), SqlTypeFacets("uniqueidentifier", false)]
        public Guid JobId
        {
            get;
            set;
        }

        [SqlColumn("JobName", 3), SqlTypeFacets("sysname", false)]
        public string JobName
        {
            get;
            set;
        }

        [SqlColumn("StepId", 4), SqlTypeFacets("int", false)]
        public int StepId
        {
            get;
            set;
        }

        [SqlColumn("StepName", 5), SqlTypeFacets("sysname", false)]
        public string StepName
        {
            get;
            set;
        }

        [SqlColumn("MessageId", 6), SqlTypeFacets("int", false)]
        public int MessageId
        {
            get;
            set;
        }

        [SqlColumn("MessageSeverity", 7), SqlTypeFacets("int", false)]
        public int MessageSeverity
        {
            get;
            set;
        }

        [SqlColumn("Message", 8), SqlTypeFacets("nvarchar", true, 8000)]
        public string Message
        {
            get;
            set;
        }

        [SqlColumn("RunStatus", 9), SqlTypeFacets("nvarchar", false, 150)]
        public string RunStatus
        {
            get;
            set;
        }

        [SqlColumn("RunTS", 10), SqlTypeFacets("datetime2", true, -1, 0)]
        public DateTime? RunTS
        {
            get;
            set;
        }

        public AgentJobHistory()
        {
        }

        public AgentJobHistory(object[] items)
        {
            RowId = (long?)items[0];
            EntryId = (int)items[1];
            JobId = (Guid)items[2];
            JobName = (string)items[3];
            StepId = (int)items[4];
            StepName = (string)items[5];
            MessageId = (int)items[6];
            MessageSeverity = (int)items[7];
            Message = (string)items[8];
            RunStatus = (string)items[9];
            RunTS = (DateTime?)items[10];
        }

        public AgentJobHistory(long? RowId, int EntryId, Guid JobId, string JobName, int StepId, string StepName, int MessageId, int MessageSeverity, string Message, string RunStatus, DateTime? RunTS)
        {
            this.RowId = RowId;
            this.EntryId = EntryId;
            this.JobId = JobId;
            this.JobName = JobName;
            this.StepId = StepId;
            this.StepName = StepName;
            this.MessageId = MessageId;
            this.MessageSeverity = MessageSeverity;
            this.Message = Message;
            this.RunStatus = RunStatus;
            this.RunTS = RunTS;
        }

        public override object[] GetItemArray()
        {
            return new object[] { RowId, EntryId, JobId, JobName, StepId, StepName, MessageId, MessageSeverity, Message, RunStatus, RunTS };
        }

        public override void SetItemArray(object[] items)
        {
            RowId = (long?)items[0];
            EntryId = (int)items[1];
            JobId = (Guid)items[2];
            JobName = (string)items[3];
            StepId = (int)items[4];
            StepName = (string)items[5];
            MessageId = (int)items[6];
            MessageSeverity = (int)items[7];
            Message = (string)items[8];
            RunStatus = (string)items[9];
            RunTS = (DateTime?)items[10];
        }
    }
}
namespace MetaFlow.Proxies
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class ProxyBrokerFactory : SqlProxyBrokerFactory<ProxyBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"PDMS.Workspace";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<ProxyBrokerFactory>)(new ProxyBrokerFactory())).CreateBroker(cs);
    }
}
// Emission concluded at 3/9/2018 10:57:19 PM
