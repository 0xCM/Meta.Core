//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using static metacore;

    public abstract class SystemNodeCommand<TSpec, TPayload> : CommandSpec<TSpec, TPayload>
        where TSpec : SystemNodeCommand<TSpec, TPayload>, new()

    {
        protected SystemNodeCommand()
        {
            this.HostNode = string.Empty;
            this.SourceNode = string.Empty;
            this.TargetNode = string.Empty;
            this.SpecName = FormatSpecName(HostNode, SourceNode, TargetNode);

        }

        protected SystemNodeCommand(SystemNode HostNode, SystemNode SourceNode, SystemNode TargetNode)
        {
            this.HostNode = HostNode.NodeName;
            this.SourceNode = SourceNode.NodeName;
            this.TargetNode = TargetNode.NodeName;
            this.SpecName = FormatSpecName(HostNode, SourceNode, TargetNode);

        }


        protected SystemNodeCommand(NodeFlow Flow)
        {
            this.HostNode = Flow.HostNode.NodeName;
            this.SourceNode = Flow.SourceNode.NodeName;
            this.TargetNode = Flow.TargetNode.NodeName;
            this.SpecName = FormatSpecName(HostNode, SourceNode, TargetNode);

        }

        [CommandParameter]
        public string HostNode { get; set; }

        [CommandParameter]
        public string SourceNode { get; set; }

        [CommandParameter]
        public string TargetNode { get; set; }

        public override string ToString()
            => $"{HostNode}:{SourceNode}->{TargetNode}";

    }
}
