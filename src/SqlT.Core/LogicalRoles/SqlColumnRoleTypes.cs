//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// List of recognized/generally-applicable column roles
    /// </summary>
    /// <remarks>
    /// Application-specific roles can be specified by using the <see cref="SqlColumnRoleKind.ApplicationDefined"/> role kind
    /// when defining the application-specific <see cref="SqlColumnRoleType"/>
    /// </remarks>
    public class SqlColumnRoleTypes : TypedItemList<SqlColumnRoleTypes, SqlColumnRoleType>
    {
        /// <summary>
        /// Specifies the absence of a role assignment
        /// </summary>
        public static readonly SqlColumnRoleType UnclassifiedRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.Unclassified);

        /// <summary>
        /// Applied to a column to denote that it specifies a system version number that 
        /// uniquely identifies a row of data in a database
        /// </summary>
        public static readonly SqlColumnRoleType SystemVersionRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.SystemVersion);

        /// <summary>
        /// Applied to a column to denote that it specifies the time at which a record has been created
        /// </summary>
        public static readonly SqlColumnRoleType CreateTimeRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.CreateTime);

        /// <summary>
        /// Applied to a column to denote that it specifies the user that created a recored
        /// </summary>
        public static readonly SqlColumnRoleType CreateUserRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.CreateUser);

        /// <summary>
        /// Applied to a column to denote that it specifies the user the time at which the record was last updated
        /// </summary>
        public static readonly SqlColumnRoleType UpdateTimeRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.UpdateTime);

        /// <summary>
        /// Applied to a column to denote that it specifies the user that last updated a recored
        /// </summary>
        public static readonly SqlColumnRoleType UpdateUserRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.UpdateUser);

        /// <summary>
        /// Applied to a column to denote that it specifies an intregal value that specifies, relative
        /// to some fixed constant; the time at which the record was created or last updated
        /// </summary>
        public static readonly SqlColumnRoleType ChangeMarkerRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.ChangeMarker);

        /// <summary>
        /// Specifies that the column is a surrogate key and which has a default constraint specifying the 
        /// next value of the sequence
        /// </summary>
        public static readonly SqlColumnRoleType SequentialKeyRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.SequentialKey);

        /// <summary>
        /// Identifies on or more columns that comprise a logial key
        /// </summary>
        public static readonly SqlColumnRoleType LogicalKeyRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.LogicalKey);

        /// <summary>
        /// Specifies that the column is a surrogate key
        /// </summary>
        public static readonly SqlColumnRoleType SurrogateKeyRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.SurrogateKey);


        /// <summary>
        /// Value is 32-digit alphanumeric code that uniquely (within some tolerance) identifies the content of a record
        /// </summary>
        public static readonly SqlColumnRoleType RecordHashRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.RecordHash);

        /// <summary>
        /// Value is of type int and denotes the count of something
        /// </summary>
        public static readonly SqlColumnRoleType CountRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.RecordCount);

        /// <summary>
        /// Value specifies the name of a database server
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlColumnRoleType ServerNameRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.ServerName);

        /// <summary>
        /// Value specifies the non-qualified name of a database
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlColumnRoleType DatabaseNameRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.DatabaseName);

        /// <summary>
        /// Value specifies the non-qualified name of a database schema
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlColumnRoleType SchemaNameRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.SchemaName);

        /// <summary>
        /// Value specifies the non-qualified name of a database object 
        /// </summary>
        /// <remarks>
        /// Conforming values are always of data type sysname or nvarchar(128)
        /// </remarks>
        public static readonly SqlColumnRoleType ObjectNameRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.DatabaseObjectName);

        /// <summary>
        /// Specifies that the role is application-defined
        /// </summary>
        public static readonly SqlColumnRoleType ApplicationRole 
            = new SqlColumnRoleType(SqlColumnRoleKind.ApplicationDefined);

        /// <summary>
        /// Specifies that the purpose of the column is to be ignored
        /// </summary>
        public static readonly SqlColumnRoleType Ignored 
            = new SqlColumnRoleType(SqlColumnRoleKind.Ignored);

        /// <summary>
        /// Looks up the role type based on the <see cref="SqlColumnRoleKind"/> enumeration
        /// </summary>
        /// <param name="RoleKind"></param>
        /// <returns></returns>
        public static SqlColumnRoleType FromKind(SqlColumnRoleKind RoleKind)
            => (new SqlColumnRoleTypes()).Single(x => x.RoleKind == RoleKind);
    }
}
