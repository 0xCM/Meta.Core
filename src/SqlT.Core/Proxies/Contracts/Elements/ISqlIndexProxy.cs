//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public interface ISqlIndexProxy : ISqlProxy
    {

    }

    public interface ISqlIndexProxy<I> : ISqlIndexProxy, ISqlProxy<I>
        where I : ISqlIndexProxy<I>
    {

    }
    /// <summary>
    /// Contract for index proxies that are parameterized by the table proxy 
    /// on which the index is defined
    /// </summary>
    public interface ISqlIndexProxy<I,T> : ISqlIndexProxy
        where I : ISqlIndexProxy<I, T>
        where T : ISqlTableProxy
    {

    }


}
