//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public interface ISqlIndexHandle : ISqlHandle
    {
        new SqlIndexName ElementName { get; }
        SqlTableName TableName { get; }
    }


    public interface ISqlIndexHandle<I> : ISqlProxyHandle<I>, ISqlIndexHandle
       where I : ISqlIndexProxy
    {

    }

    public interface ISqlIndexHandle<I, T> : ISqlIndexHandle<I>
       where I : ISqlIndexProxy
       where T : ISqlTableProxy
    {

    }


}