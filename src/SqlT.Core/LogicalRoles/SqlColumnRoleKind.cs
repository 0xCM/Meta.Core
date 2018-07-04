//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates common/well-known column classes and defines the allowable values 
    /// for the <see cref="SqlPropertyNames.ColumnRole"/> property
    /// </summary>
    public enum SqlColumnRoleKind : int
    {

        /// <summary>
        /// Specifies the absence of a role assignment
        /// </summary>
        [Description("Specifies the absence of a role assignment")]
        Unclassified,

        /// <summary>
        /// Identifies a rowversion column
        /// </summary>
        [Description("Identifies a rowversion column")]
        SystemVersion,

        /// <summary>
        /// Applied to a column to denote that it specifies the time at which a record has been created
        /// </summary>
        [Description("Applied to a column to denote that it specifies the time at which a record has been created")]
        CreateTime,

        /// <summary>
        /// Applied to a column to denote that it specifies the user that created a recored
        /// </summary>
        [Description("Applied to a column to denote that it specifies the user that created a recored")]
        CreateUser,

        /// <summary>
        /// Applied to a column to denote that it specifies the user the time at which the record was last updated
        /// </summary>
        [Description("Applied to a column to denote that it specifies the user the time at which the record was last updated")]
        UpdateTime,

        /// <summary>
        /// Applied to a column to denote that it specifies the user that last updated a recored
        /// </summary>
        [Description("Applied to a column to denote that it specifies the user that last updated a recored")]
        UpdateUser,

        /// <summary>
        /// Applied to a column to denote that it specifies an intregal value that specifies, relative
        /// to some fixed constant, the time at which the record was created or last updated
        /// </summary>
        [Description("Applied to a column to denote that it specifies an intregal value that specifies, relative to some fixed constant, the time at which the record was created or last updated")]
        ChangeMarker,

        /// <summary>
        /// Identifies an integral surrogate key column that has a default constraint specifying the values from a sequence object
        /// </summary>
        [Description("Identifies an integral surrogate key column that has a default constraint specifying the values from a sequence object")]
        SequentialKey,

        /// <summary>
        /// Identifies a column that is a logial key constituent
        /// </summary>
        [Description("Identifies a column that is a logial key constituent")]
        LogicalKey,

        /// <summary>
        /// Identifies a surrogate key column
        /// </summary>
        [Description("Identifies a surrogate key column")]
        SurrogateKey,

        /// <summary>
        /// Value is 32-digit alphanumeric code that uniquely (within some tolerance) identifies the content of a record
        /// </summary>
        [Description("Value is 32-digit alphanumeric code that uniquely (within some tolerance) identifies the content of a record")]
        RecordHash,

        /// <summary>
        /// Value is of integral type and denotes the number of records in some context
        /// </summary>
        [Description("Value is of integral type and denotes the number of records in some context")]
        RecordCount,

        /// <summary>
        /// Identifies a column whose values contain server names
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        [Description("Identifies a column whose values contain database server names")]
        ServerName,

        /// <summary>
        /// Identifies a column that specifies database names
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        [Description("Identifies a column that specifies database names")]
        DatabaseName,

        /// <summary>
        /// Identifies a column that specifies schema names
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        [Description("Identifies a column that specifies schema names")]
        SchemaName,

        /// <summary>
        /// Identifies a column that specifies database object names
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        [Description("Identifies a column that specifies database object names")]
        DatabaseObjectName,

        /// <summary>
        /// Specifies that the role is application-defined
        /// </summary>
        [Description("Specifies that the role is application-defined")]
        ApplicationDefined,

        /// <summary>
        /// Specifies that the columns purpose in life is to be ignored
        /// </summary>
        [Description("Specifies that the columns purpose in life is to be ignored")]
        Ignored
    }


}
