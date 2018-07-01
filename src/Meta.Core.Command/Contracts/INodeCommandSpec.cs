//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public interface INodeCommandSpec : ICommandSpec
    {
        SystemNodeIdentifier Source { get; }

        SystemNodeIdentifier Target { get; }
        
    }

    public interface INodeCommandSpec<TSpec> : INodeCommandSpec, ICommandSpec<TSpec>
            where TSpec : CommandSpec<TSpec>, new()
    {


    }
        
    
    public interface INodeCommandSpec<TSpec,TPayload> : INodeCommandSpec<TSpec>
        where TSpec : CommandSpec<TSpec, TPayload>, new()
    {

    }






}