//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;

    public static class SqlColumnRoleExtensions
    {

        public static bool IsAuditRole(this SqlColumnRoleKind x)
            => SqlColumnRole.AuditRoleTypes.Contains(x);

        public static bool IsVersionRole(this SqlColumnRoleKind x)
            => x == SqlColumnRoleKind.SystemVersion;

        public static SqlColumnName RoleColumnName(this SqlTabularProxyInfo p, SqlColumnRoleType role)
            => p.FindColumnWithRole(role)?.ColumnName ?? SqlColumnName.Empty;

    }
}
