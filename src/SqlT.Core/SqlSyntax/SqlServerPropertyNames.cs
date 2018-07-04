//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax    
{
    using SqlT.Core;
    /// <summary>
    /// See https://docs.microsoft.com/en-us/sql/t-sql/functions/serverproperty-transact-sql
    /// Defines the properties whose values can be accessed via the SERVERPROPERTY intrinsic function
    /// </summary>
    public class SqlServerPropertyNames : TypedItemList<SqlServerPropertyNames, SqlServerPropertyName>
    {
        /// <summary>
        /// Version of the Microsoft.NET Framework common language runtime (CLR) that was used while building the instance of SQL Server
        /// </summary>
        public static readonly SqlServerPropertyName BuildClrVersion 
            = "BuildClrVersion";

        /// <summary>
        /// Name of the default collation for the server
        /// </summary>
        public static readonly SqlServerPropertyName Collation 
            = "Collation";

        /// <summary>
        /// ID of the SQL Server collation
        /// </summary>
        public static readonly SqlServerPropertyName CollationID 
            = "CollationId";

        /// <summary>
        /// Windows comparison style of the collation
        /// </summary>
        public static readonly SqlServerPropertyName ComparisonStyle 
            = "ComparisonStyle";

        /// <summary>
        /// NetBIOS name of the local computer on which the instance of SQL Server is currently running
        /// </summary>
        public static readonly SqlServerPropertyName ComputerNamePhysicalNetBIOS 
            = "ComputerNamePhysicalNetBIOS";

        /// <summary>
        /// Installed product edition of the instance of SQL Server
        /// </summary>
        public static readonly SqlServerPropertyName Edition 
            = "Edition";

        /// <summary>
        /// Installed product edition ID of the instance of SQL Server
        /// </summary>
        public static readonly SqlServerPropertyName EditionID 
            = "EditionID";

        /// <summary>
        /// Version of the instance of SQL Server, in the form of 'major.minor.build.revision'.
        /// </summary>
        public static readonly SqlServerPropertyName ProductVersion 
            = "ProductVersion";

        /// <summary>
        /// Name of the default path to the instance data files
        /// </summary>
        public static readonly SqlServerPropertyName InstanceDefaultDataPath 
            = "InstanceDefaultDataPath";

        /// <summary>
        /// Name of the default path to the instance log files
        /// </summary>
        public static readonly SqlServerPropertyName InstanceDefaultLogPath 
            = "InstanceDefaultLogPath";

        /// <summary>
        /// The major version number, e.g. 13
        /// </summary>
        public static readonly SqlServerPropertyName ProductMajorVersion 
            = "ProductMajorVersion";

        /// <summary>
        /// The minor version number, e.g. 5
        /// </summary>
        public static readonly SqlServerPropertyName ProductMinorVersion 
            = "ProductMinorVersion";

    }
}
