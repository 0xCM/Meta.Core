//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Represents the concept of a column role - which classifies the purpose of the
    /// column within the context it is defined
    /// </summary>
    public sealed class SqlColumnRoleType : IEquatable<SqlColumnRoleType>
    {

        public static bool operator == (SqlColumnRoleType x, SqlColumnRoleType y)
            => x.Equals(y);

        public static bool operator != (SqlColumnRoleType x, SqlColumnRoleType y)
            => !x.Equals(y);

        public SqlColumnRoleType(string RoleName, SqlColumnRoleKind RoleKind)
        {
            this.RoleName = RoleName;
            this.RoleKind = RoleKind;
        }

        public SqlColumnRoleType(SqlColumnRoleKind RoleKind)
        {
            this.RoleName = RoleKind.ToString();
            this.RoleKind = RoleKind;
        }

        public string RoleName { get; }

        public SqlColumnRoleKind RoleKind { get; }

        public override string ToString()
            => RoleName;

        public override bool Equals(object obj)
            => obj is SqlColumnRoleType && Equals((SqlColumnRoleType)obj);

        public bool Equals(SqlColumnRoleType other)
            => ((object)other) != null
            && this.RoleKind == other.RoleKind
            && this.RoleName == other.RoleName;

        public override int GetHashCode()
            => RoleName.GetHashCode();
    }


}
