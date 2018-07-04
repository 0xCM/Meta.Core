//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    /// <summary>
    /// Lists the recognized contracts to which values can adhere
    /// </summary>
    public class SqlValueContracts : HostedFieldList<SqlValueContract, SqlValueContracts>
    {

        /// <summary>
        /// Value is not restricted to a particular domain beyond its underlying data type
        /// </summary>
        public static readonly SqlValueContract Unrestricted = new SqlValueContract(nameof(Unrestricted));

        /// <summary>
        /// Value specifies time at which something was created
        /// </summary>
        public static readonly SqlValueContract CreateTimestamp = new SqlValueContract(nameof(CreateTimestamp));

        /// <summary>
        /// Value identifies the user responsible for creating something
        /// </summary>
        public static readonly SqlValueContract Creator = new SqlValueContract(nameof(Creator));

        /// <summary>
        /// Value identifies the time at which something was updated
        /// </summary>
        public static readonly SqlValueContract UpdateTimestamp = new SqlValueContract(nameof(UpdateTimestamp));

        /// <summary>
        /// Value identifies the user responsible for changing the state of something
        /// </summary>
        public static readonly SqlValueContract Editor = new SqlValueContract(nameof(Editor));

        /// <summary>
        /// Value uniquely identifies a row of data in a database
        /// </summary>
        public static readonly SqlValueContract DbRowVersion = new SqlValueContract(nameof(DbRowVersion));

        /// <summary>
        /// Value is (or is part of) a surrogate key
        /// </summary>
        public static readonly SqlValueContract SurrogateKey = new SqlValueContract(nameof(SurrogateKey));

        /// <summary>
        /// Value is (or is part of) a logical key that has meanin within the context of a domain
        /// </summary>
        public static readonly SqlValueContract LogicalKey = new SqlValueContract(nameof(LogicalKey));

        /// <summary>
        /// Value is 32-digit alphanumeric code that uniquely (within some tolerance) identifies the content of a record
        /// </summary>
        public static readonly SqlValueContract RecordHash = new SqlValueContract(nameof(RecordHash));

        /// <summary>
        /// Value specifies the name of a server (as recorded in the sys.servers table)
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlValueContract ServerName = new SqlValueContract(nameof(ServerName));

        /// <summary>
        /// Value specifies the name of a database
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlValueContract DatabaseName = new SqlValueContract(nameof(DatabaseName));

        /// <summary>
        /// Value specifies the name of a schema
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlValueContract SchemaName = new SqlValueContract(nameof(SchemaName));

        /// <summary>
        /// Value specifies the non-qualified name of a table 
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlValueContract TableName = new SqlValueContract(nameof(TableName));

    }
}
