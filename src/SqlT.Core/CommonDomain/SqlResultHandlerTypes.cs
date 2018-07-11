//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
