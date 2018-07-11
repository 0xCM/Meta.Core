//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Lists the permissible values for the <see cref="SqlPropertyNames.QueryType"/> property
    /// </summary>
    /// <remarks>
    /// This list and the [Reference].[QueryType] table in the reference database must stay in sync!
    /// </remarks>
    public class SqlQueryTypes : TypedItemList<SqlQueryTypes, string>
    {
        /// <summary>
        /// Identifies a query that selects a contiguous sequence of records from a given table
        /// </summary>
        public const string SequentialProjector = nameof(SequentialProjector);

        /// <summary>
        /// Identifies a query that determines the minimum sequence of the records that should be selected for a given table
        /// </summary>
        public const string FirstSequenceNumber = nameof(FirstSequenceNumber);

        /// <summary>
        /// Identifies a query that determines the minimum sequence number from a given table
        /// </summary>
        public const string FirstSequenceNumberDefault = nameof(FirstSequenceNumberDefault);

        /// <summary>
        /// Identifies a query that determines the minimum and maximum change dates for a given  table
        /// </summary>
        public const string ChangeProjector = nameof(ChangeProjector);

        /// <summary>
        /// Identifies a query that determines the range dates and sequences numbers available for a given table
        /// </summary>
        public const string DataAvailability = nameof(DataAvailability);

        /// <summary>
        /// Identifies a query that supplies a result that will be consumed by a procedure that 
        /// accepts a table-valued parameter
        /// </summary>
        /// <remarks>
        /// This terminology derives from ADO.Net which classifies such parameters as "structured"
        /// </remarks>
        public const string Structured = nameof(Structured);
    }

}
