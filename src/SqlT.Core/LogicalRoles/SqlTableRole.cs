//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Binds a Table to a role 
    /// </summary>
    public class SqlTableRole 
    {
        public SqlTableRole(SqlTableName Table, SqlTableRoleType RoleType)
        {
            this.Table = Table;
            this.RoleType = RoleType;
        }

        /// <summary>
        /// The name of the Table for which a role classification is being assigned
        /// </summary>
        public SqlTableName Table { get; }

        /// <summary>
        /// The role played by the Table
        /// </summary>
        public SqlTableRoleType RoleType { get; }

        public override string ToString()
            => $"{Table}({RoleType})";
    }
}
