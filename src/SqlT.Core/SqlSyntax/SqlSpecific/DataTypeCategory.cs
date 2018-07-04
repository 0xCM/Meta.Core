//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    public enum DataTypeCategory
    {
        None = 0,
        Number = 1,
        Text = 2,
        Binary = 3,
        Chronology = 4,
        Clr = 5,
        Guid = 6,
        Variant = 7,
        Any = 100,

    }
}
