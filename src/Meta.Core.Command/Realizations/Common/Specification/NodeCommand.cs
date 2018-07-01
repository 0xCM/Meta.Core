//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using static metacore;

    using N = SystemNodeIdentifier;

    public abstract class NodeCommand<TSpec, TPayload> : CommandSpec<TSpec, TPayload>, INodeCommandSpec<TSpec,TPayload>, INodeMessage<CommandArguments>
        where TSpec : NodeCommand<TSpec, TPayload>, new()

    {
        protected NodeCommand()
        {
            this.Source = N.Empty;
            this.Target = N.Empty;
            this.SpecName = this.ToString();

        }

        protected NodeCommand(NodeLink L)
        {
            this.Source = Source;
            this.Target = Target;
            this.SpecName = ToString();
        }

        protected NodeCommand(N Source, N Target)
        {
            this.Source = Source;
            this.Target = Target;
            this.SpecName = ToString();
        }


        [CommandParameter]
        public N Source { get; set; }

        [CommandParameter]
        public N Target { get; set; }



        CorrelationToken? ICorrelated.CT
            => null;

        CommandArguments INodeMessage<CommandArguments>.Content
            => this.Arguments;

        object INodeMessage.Content
            => this.Arguments;
    }


}
