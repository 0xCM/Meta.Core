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

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Base type for tabular documentation sets
    /// </summary>
    public abstract class SqlTabularProxyInfo : SqlObjectProxyInfo
    {

        public SqlTabularProxyInfo
        (
            SqlProxyKind ProxyKind, 
            Type RuntimeType, 
            sxc.tabular_name TabularName, 
            IReadOnlyList<SqlColumnProxyInfo> Columns,
            ISqlTabularDocumentation Documentation = null            
        ) : base(ProxyKind, RuntimeType, TabularName, Documentation)
        {
            this.ObjectName = TabularName;
            this.Columns = Columns.OrderBy(x => x.Position).ToList();
        }

        /// <summary>
        /// Specifies the name of the represented SQL object
        /// </summary>
        public new sxc.tabular_name ObjectName { get; }

        /// <summary>
        /// Specifies the column representatives
        /// </summary>
        public IReadOnlyList<SqlColumnProxyInfo> Columns { get; private set; }

        /// <summary>
        /// Specifies the representing proxy type
        /// </summary>
        public override Type RuntimeType 
            => ClrElement as Type;

        /// <summary>
        /// Specifies the SQL object documentation
        /// </summary>
        public new ISqlTabularDocumentation Documentation
            => base.Documentation as ISqlTabularDocumentation;

        /// <summary>
        /// Retrieves a column identified by the name of its proxy representative
        /// </summary>
        /// <param name="RuntimeName">The representative name</param>
        /// <returns></returns>
        public SqlColumnProxyInfo FindColumnByRuntimeName(string RuntimeName)
            => Columns.FirstOrDefault(c => c.RuntimeName == RuntimeName);

        /// <summary>
        /// Retrieves a column identified by its name
        /// </summary>
        /// <param name="ColumnName">The name of the column</param>
        /// <returns></returns>
        public SqlColumnProxyInfo FindColumnByColumnName(SqlColumnName ColumnName)
            => Columns.FirstOrDefault(x => x.ColumnName == ColumnName);

        /// <summary>
        /// Attempts to find a column identified by its name
        /// </summary>
        /// <param name="ColumnName">The name of the column</param>
        /// <returns></returns>
        public Option<SqlColumnProxyInfo> TryFindColumnByColumnName(SqlColumnName ColumnName)
            => Columns.FirstOrDefault(c => c.ColumnName == ColumnName);          

        /// <summary>
        /// Retrieves a column identified by its name
        /// </summary>
        /// <param name="Position">The name of the column</param>
        /// <returns></returns>
        public SqlColumnProxyInfo FindColumnByPosition(int Position)
            => Columns.FirstOrDefault(x => x.Position == Position);

        /// <summary>
        /// Finds exactly one column corresponding to a specified role or throws an exception
        /// if no column has such a role
        /// </summary>
        /// <param name="RoleType">The type of role to match</param>
        /// <returns></returns>
        public SqlColumnProxyInfo FindColumnWithRole(SqlColumnRoleType RoleType)
            => Columns.FirstOrDefault(c => c.Role != null && c.Role.RoleType == RoleType);

        /// <summary>
        /// Determines whether the table has any columns with a specified role
        /// </summary>
        /// <param name="RoleType">The type of role to match</param>
        /// <returns></returns>
        public bool HasColumnWithRole(SqlColumnRoleType RoleType)
            => Columns.Any(c => c.Role != null && c.Role.RoleType == RoleType);

        /// <summary>
        /// Attempts to find a column with a specified role
        /// </summary>
        /// <param name="RoleType">The type of role to match</param>
        /// <returns></returns>
        public Option<SqlColumnProxyInfo> TryFindColumnWithRole(SqlColumnRoleType RoleType)
            => HasColumnWithRole(RoleType)
            ? Columns.FirstOrDefault(c => c.Role?.RoleType == RoleType)
            : null;
                
        /// <summary>
        /// Determines whether a column is playing a given role
        /// </summary>
        /// <param name="ColumnName">The name of the column</param>
        /// <param name="RoleType">The type of role to match</param>
        /// <returns></returns>
        public bool IsColumnInRole(SqlColumnName ColumnName, SqlColumnRoleType RoleType)
            => TryFindColumnByColumnName(ColumnName).MapValueOrDefault(c => c.Role?.RoleType == RoleType);
           
        /// <summary>
        /// Filters columns based on role assignment
        /// </summary>
        /// <param name="RoleType">The role on which to filter</param>
        /// <returns></returns>
        public IEnumerable<SqlColumnProxyInfo> FindColumnsWithRole(SqlColumnRoleType RoleType = null)
        {
            foreach(var col in Columns)
                if (RoleType == null)
                    if (col.Documentation.RoleType?.RoleKind != SqlColumnRoleKind.Unclassified)
                        yield return col;
                else
                    if (col.Documentation.RoleType == RoleType)
                        yield return col;
        }
    }
}