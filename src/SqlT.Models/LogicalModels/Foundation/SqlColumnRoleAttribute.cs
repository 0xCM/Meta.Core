//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Reflection;

    using SqlT.Core;

    /// <summary>
    /// Applied to an element to associate it with a <see cref="SqlColumnRoleKind"/>
    /// </summary>
    public class SqlColumnRoleAttribute : Attribute
    {
        public static SqlColumnRoleKind? GetMemberRole(MemberInfo m)
            => m.HasAttribute<SqlColumnRoleAttribute>() 
            ? m.GetCustomAttribute<SqlColumnRoleAttribute>().RoleType 
            :  (SqlColumnRoleKind?)null;

        public SqlColumnRoleAttribute(SqlColumnRoleKind RoleType)
        {
            this.RoleType = RoleType;
        }

        public SqlColumnRoleKind RoleType { get; }

        public override string ToString()
            => RoleType.ToString();

    }
}
