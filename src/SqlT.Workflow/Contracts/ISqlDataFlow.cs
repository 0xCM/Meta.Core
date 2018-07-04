//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System.Reflection;
    using SqlT.Core;
    using SqlT.Models;

    using N = SystemNode;


    public interface ISqlDataFlow : ILinkedComponent
    {
        WorkFlowed<int> Execute(ISqlDataFlowArgs args);

    }

    public interface ISqlDataFlow<A> : ISqlDataFlow
        where A : ISqlDataFlowArgs
        
    {

        WorkFlowed<int> Execute(A args);
    }

    public interface ISqlDataFlow<A,X> : ISqlDataFlow<A>
        where A : ISqlDataFlowArgs
       where X : class, ISqlProxyAssembly, new()

    {

    }

    public interface ISqlDataFlow<A, X, Y> : ISqlDataFlow<A>
        where A : ISqlDataFlowArgs
       where X : class, ISqlProxyAssembly, new()
        where Y : class, ISqlProxyAssembly, new()

    {

    }

}