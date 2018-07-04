//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Represents a boolean/logical value in SQL
    /// </summary>
    public enum SqlBooleanValue : int
    {
        False = -1,
        Unknown = 0,
        True = 1
    }

    public enum ConditionalCreateResult
    {
        None = 0,
        Created = 1,
        NotCreated = 2
    }

}