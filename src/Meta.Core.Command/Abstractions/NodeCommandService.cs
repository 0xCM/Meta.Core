//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public abstract class NodeCommandService<TExec, TSpec, TResult> : CommandExecutionService<TExec, TSpec, TResult>
    where TSpec : CommandSpec<TSpec, TResult>, new()
    where TExec : NodeCommandService<TExec, TSpec, TResult>
{
    protected NodeCommandService(IApplicationContext C)
        : base(C)
    {

    }

    protected SystemNode LookupNode(string NodeName)
        => TryLookupNode(NodeName).Require();

    protected abstract Option<SystemNode> TryLookupNode(string NodeName);


}
