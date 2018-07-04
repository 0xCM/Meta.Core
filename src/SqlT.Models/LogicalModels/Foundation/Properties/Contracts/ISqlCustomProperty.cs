//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    using static metacore;

    using SqlT.SqlSystem;



    public interface ISqlCustomProperty
    {
        SqlExtendedPropertyName PropertyName { get; }

        object PropertyValue { get; }
    }

    public interface ISqlCustomProperty<out V> : ISqlCustomProperty
    {

        new V PropertyValue { get; }
    }



}