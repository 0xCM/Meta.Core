//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;
    public interface ISqlViewHandle : ISqlTabularHandle
    {
        new SqlViewName ElementName { get; }
    }


    public interface ISqlTabularHandle : ISqlObjectHandle
    {
        new sxc.tabular_name ElementName { get; }
    }

    public interface ISqlTabularHandle<P> : ISqlObjectHandle<P>, ISqlTabularHandle
        where P : ISqlTabularProxy
    {

    }




}