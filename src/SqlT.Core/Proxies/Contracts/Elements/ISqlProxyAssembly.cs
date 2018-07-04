//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Reflection;

    public interface ISqlProxyAssembly : IAssemblyDesignator, ISqlProxyBrokerFactory, ISqlProxyMetadataIndex
    {
        Assembly DefininingAssembly { get; }

        string ComponentName { get; }
    }

    public interface ISqlProxyAssembly<A> : ISqlProxyAssembly, ISqlProxyBrokerFactory<A>
        where A : class, ISqlProxyAssembly, new()
    {


    }
}