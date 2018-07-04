//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;
    using System.Linq;


    public abstract class SqlTabularDocumentation<N> : SqlObjectDocumentation<N>, ISqlTabularDocumentation<N>
        where N : SqlTabularName<N>, new()
    {
        protected readonly Dictionary<string, SqlColumnDocumentation> DocumentedColumns
            = new Dictionary<string, SqlColumnDocumentation>();

        readonly List<SqlColumnGroup> _ColumnGroups
            = new List<SqlColumnGroup>();

        protected SqlTabularDocumentation()
        {
            
        }

        protected SqlTabularDocumentation(N Name, string Label, string Description, string Identifier)
            : base(Name, Label, Description, Identifier)
        {
            

        }

        /// <summary>
        /// The columns defined by the tabular object
        /// </summary>
        public IReadOnlyList<SqlColumnDocumentation> Columns
            => DocumentedColumns.Values.OrderBy(x => x.Position).ToList();

        /// <summary>
        /// The roles, if any, played by the columns defined by the table
        /// </summary>
        public IEnumerable<SqlColumnRole> ColumnRoles
            => DocumentedColumns.Values
                    .Where(c => c.RoleType?.RoleKind != SqlColumnRoleKind.Unclassified)
                    .Select(x => new SqlColumnRole(x.Name, x.RoleType));

        public SqlColumnDocumentation this[SqlColumnName colname] 
            => DocumentedColumns.ContainsKey(colname) ? DocumentedColumns[colname] : SqlColumnDocumentation.Empty;

        public SqlColumnGroup DefineColumnGroup(string GroupName, params SqlColumnName[] columns)
        {
            var g = new SqlColumnGroup(Name, GroupName, SqlColumnGroupKind.None, columns);
            _ColumnGroups.Add(g);
            return g;
        }

        public SqlColumnGroup DefineColumnGroup(SqlColumnGroupKind GroupKind, params SqlColumnName[] columns)
        {
            var g = new SqlColumnGroup(Name, GroupKind, columns);
            _ColumnGroups.Add(g);
            return g;
        }

        public IEnumerable<SqlColumnGroup> ColumnGroups
            => _ColumnGroups;


        public override string ToString()
            => $"{Name}" + (!string.IsNullOrWhiteSpace(Description) 
            ?  $": {Description}" 
            :  string.Empty);

    }
}
