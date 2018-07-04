//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.extended_properties)]
    public interface IExtendedProperty : ISystemElement
    {
        byte @class { get; }

        string class_desc { get; }

        int major_id { get; }

        int minor_id { get; }

        object value { get; }

    }

}