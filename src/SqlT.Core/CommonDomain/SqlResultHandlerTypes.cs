//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Lists the permissible values for the <see cref="SqlPropertyNames.ResultHandler"/> property
    /// </summary>
    public class SqlResultHandlerTypes : TypedItemList<SqlResultHandlerTypes, string>
    {
        /// <summary>
        /// Identifies a procedure that accepts a single TVP and merges the incoming results with the underlying data source
        /// </summary>
        public const string RecordMerge = nameof(RecordMerge);

    }
}
