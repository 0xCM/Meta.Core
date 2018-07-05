//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    
    public abstract class SqlIndexProxy : SqlElementProxy, ISqlIndexProxy
    {

    }



    public abstract class SqlIndexProxy<I, T> : SqlIndexProxy, ISqlIndexProxy<I, T>
        where I : ISqlIndexProxy<I, T>
        where T : ISqlTableProxy
    {

    }


    public abstract class SqlIndexProxy<T> : SqlIndexProxy<SqlIndexProxy<T>, T>
        where T : ISqlTableProxy
    {

    }


}