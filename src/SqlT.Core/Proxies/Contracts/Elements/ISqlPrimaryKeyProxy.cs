//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Contract for primary key proxies 
    /// </summary>
    public interface ISqlPrimaryKeyProxy : ISqlObjectProxy
    {

    }

    /// <summary>
    /// Contract for primary key proxies that are parameterized by the proxy for the table 
    /// on which the key is defined
    /// </summary>
    /// <typeparam name="K">The table proxy type</typeparam>
    public interface ISqlPrimaryKeyProxy<K> : ISqlPrimaryKeyProxy
        where K : ISqlTableProxy
    {

    }

    public interface ISqlPrimaryKeyProxy<K,T> : ISqlPrimaryKeyProxy<T>
        where K : ISqlPrimaryKeyProxy<K,T>
        where T : ISqlTableProxy<T>
    {

    }
}
