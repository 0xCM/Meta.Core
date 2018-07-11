//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Lists the names of recognized extended properties where "recognized", in this context, means
    /// that the framework imbues them with specific semantics
    /// </summary>
    public class SqlPropertyNames
    {
        /// <summary>
        /// Applied to a table, view, proecedure, TVF and anything else that provides tabular data
        /// to specify the user-defined table data type to which the tabular data conforms
        /// </summary>
        public static SqlExtendedPropertyName RecordContractType { get; } = "DM_RecordType";

        /// <summary>
        /// Applied to a table, view, proecedure, TVF and anything else that provides tabular data
        /// to specify the user-defined table data type to which the tabular data conforms
        /// </summary>
        public static SqlExtendedPropertyName RecordContract { get; } = "SqlT_RecordContract";

        /// <summary>
        /// Applied a an element to describe its raison d'être
        /// </summary>
        public static SqlExtendedPropertyName Documentation { get; } = "MS_Description";

        /// <summary>
        /// Applied to a procedure or function to give it a specific query classification
        /// </summary>
        public static SqlExtendedPropertyName QueryType { get; } = "DM_QueryType";

        /// <summary>
        /// Applied to a procedure to signify that it accepts a result from an identified query
        /// </summary>
        /// <remarks>
        /// Intended to be used in conjunction with the <see cref="SourceQuery"/> property
        /// </remarks>
        public static SqlExtendedPropertyName ResultHandler { get; } = "QR_ResultHandler";

        /// <summary>
        /// Applied to a procedure to identify the query that produces the type of result set that it accepts
        /// </summary>
        /// <remarks>
        /// Intended to be used in conjunction with the <see cref="ResultHandler"/> property
        /// </remarks>
        public static SqlExtendedPropertyName SourceQuery { get; } = "QR_SourceQuery";

        /// <summary>
        /// Applied to a query function to identify a peer function
        /// </summary>
        public static SqlExtendedPropertyName QueryPeer { get; } = "DM_QueryPeer";

        /// <summary>
        /// Applied to an table in order to classify its purpose/role
        /// </summary>
        public static SqlExtendedPropertyName TableRole { get; } = "SqlT_TableRole";

        /// <summary>
        /// Applied to a column to describe the role that it plays within the data structure
        /// </summary>
        public static SqlExtendedPropertyName ColumnRole { get; } = "SqlT_ColumnRole";

        /// <summary>
        /// Applied to a function or procedure to specify the name of the table that is intended to
        /// receive result sets obtained from their execution
        /// </summary>
        public static SqlExtendedPropertyName ReceiverName { get; } = "SqlT_ReceiverName";

        /// <summary>
        /// Applied to an element to signify that the values of its attributes conform to a named contract
        /// </summary>
        public static SqlExtendedPropertyName DataContract { get; } = "SqlT_DataContract";

        /// <summary>
        /// Associates a format string with an element
        /// </summary>
        public static SqlExtendedPropertyName FormatString { get; } = "SqlT_FormatString";

        /// <summary>
        /// Applied to an element to signify that the values of its attributes conform to an interface
        /// that is supplied by the referencing environment
        /// </summary>
        public static SqlExtendedPropertyName ExternalContract { get; } = "SqlT_ExternalContract";

        /// <summary>
        /// Applied to an index to specify why it exists
        /// </summary>
        public static SqlExtendedPropertyName IndexReason { get; } = "SqlT_IndexReason";

        /// <summary>
        /// Applied to a table to indicate that a bijection can be defined between the
        /// rows of the table and the literals of a CLR enumeration type 
        /// </summary>
        /// <remarks>
        /// The required and optional features of the table to which the property
        /// is attached are as follows:
        /// The table must have a column named "TypeCode" whose values correspond to 
        /// that of the values of the enum's underlying type domain
        /// The table must have a column named "Identifier" whose values will correspond 
        /// to the enumeration literal names
        /// The table may have a column named "Label" where the values, if present,
        /// will correspond to a Label attribute applied to the corresponding enumeration literal
        /// The table may have a column named "Description" the values, if present,
        /// will correspond to a Description attribute applied to the corresponding enumeration literal
        /// </remarks>
        public static SqlExtendedPropertyName EnumProvider { get; } = "SqlT_EnumProvider";

        /// <summary>
        /// Applied to a database to assign a classification
        /// </summary>
        public static SqlExtendedPropertyName DbType { get; }  = new SqlExtendedPropertyName("SqlT_DbType");

        /// <summary>
        /// Applied to a database to indicate its version
        /// </summary>
        public static SqlExtendedPropertyName DbVersion { get; } = new SqlExtendedPropertyName("SqlT_DbVersion");
    }

}
