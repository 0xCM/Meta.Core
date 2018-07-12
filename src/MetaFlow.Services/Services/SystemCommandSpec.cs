//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using Meta.Core;

    using static metacore;

    using MetaFlow.WF;

    [CommandSpec]
    public class SystemCommandSpec : CommandSpec<SystemCommandSpec>, ISystemCommand
    {
        public SystemCommandSpec()
        {
            SourceNodeId = string.Empty;
            CommandNode = string.Empty;
            Body = string.Empty;
            CommandUri = string.Empty;
        }

        public SystemCommandSpec(SystemUri CommandUri, string SourceNodeId, string TargetNodeId, string Body, CorrelationToken? CT = null)
            : base(CommandUri.ToString())
        {
            this.CommandUri = CommandUri;
            this.SourceNodeId = SourceNodeId;
            this.CommandNode = TargetNodeId;
            this.Body = Body;
            this.CT = CT;
        }

        [CommandParameter]
        public string CommandUri { get; }

        [CommandParameter]
        public string SourceNodeId { get; set; }

        [CommandParameter]
        public string CommandNode { get; set; }

        [CommandParameter]
        public string Body { get; set; }

        [CommandParameter]
        public CorrelationToken? CT { get; set; }
        
    }
}