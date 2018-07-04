//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public interface ISqlProxy
    {
        object[] GetItemArray();
        void SetItemArray(object[] items);
    }

    public interface ISqlProxy<P> : ISqlProxy
        where P : ISqlProxy
    {


    }

}
