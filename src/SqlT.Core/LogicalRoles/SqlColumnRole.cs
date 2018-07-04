//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    

    /// <summary>
    /// Binds a column to a role 
    /// </summary>
    public class SqlColumnRole 
    {
        public static ISet<SqlColumnRoleKind> AuditRoleTypes
            = new HashSet<SqlColumnRoleKind>(new[]
            {
                SqlColumnRoleKind.CreateTime,
                SqlColumnRoleKind.CreateUser,
                SqlColumnRoleKind.UpdateTime,
                SqlColumnRoleKind.UpdateUser
            });

        public static readonly IReadOnlyDictionary<SqlColumnRoleKind, SqlColumnName> DefaultRoleColumnNames 
            = new Dictionary<SqlColumnRoleKind, SqlColumnName>
        {
            [SqlColumnRoleKind.SystemVersion] = "DbVersion",
            [SqlColumnRoleKind.CreateTime] = "DbCreateTime",
            [SqlColumnRoleKind.UpdateTime] = "DbUpdateTime",
            [SqlColumnRoleKind.CreateUser] = "DbCreateUser",
            [SqlColumnRoleKind.UpdateUser] = "DbUpdateUser",
        };

        public static SqlColumnName GetDefaultNameForRole(SqlColumnRoleKind Role)
            => DefaultRoleColumnNames[Role];
        
        public SqlColumnRole(SqlColumnName Column, SqlColumnRoleType RoleType)
        {
            if (RoleType == null)
                throw new ArgumentNullException();

            this.Column = Column;
            this.RoleType = RoleType;
        }

        /// <summary>
        /// The name of the column for which a role classification is being assigned
        /// </summary>
        public SqlColumnName Column { get; }

        /// <summary>
        /// The role played by the column
        /// </summary>
        public SqlColumnRoleType RoleType { get; }

        public SqlColumnRoleKind RoleKind
            => RoleType.RoleKind;

        public override string ToString()
            => $"{Column}({RoleType})";
    }
}
