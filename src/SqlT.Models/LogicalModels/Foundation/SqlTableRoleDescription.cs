//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Encapsualtes table/column role information
    /// </summary>
    public sealed class SqlTableRoleDescription : ValueObject<SqlTableRoleDescription>
    {
        public SqlTableRoleDescription(SqlTableName TableName, IEnumerable<SqlColumnRoleType> ColumnRoles)
        {
            this.TableName = TableName;
            this.ColumnRoles = ColumnRoles.ToList();

        }

        /// <summary>
        /// The name of the table for which role information is being provided
        /// </summary>
        public SqlTableName TableName { get; }

        public IReadOnlyList<SqlColumnRoleType> ColumnRoles { get; }

        public override string ToString()
            => $"{TableName}: {ColumnRoles}";
    }
}
