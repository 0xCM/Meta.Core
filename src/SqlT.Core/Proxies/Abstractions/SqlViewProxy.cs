//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{


    public abstract class SqlViewProxy : SqlTabularProxy, ISqlViewProxy
    {

    }

    public  abstract class SqlViewProxy<T> : SqlTabularProxy<T>, ISqlViewProxy<T>
        where T : SqlViewProxy<T>, new()
    {


    }


}