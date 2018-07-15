//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    public interface IForkExecutor : IConnectorExecutor
    {

    }

    public interface IForkExecutor<in S, out T> : IForkExecutor
    {

    }

    public interface IForkExecutor<in S, out X, out Y> : IForkExecutor<S, X>
    {

    }

}
