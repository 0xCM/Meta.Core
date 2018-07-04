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

    using static metacore;
    using sxc = Syntax.contracts;

    /// <summary>
    /// Classifies a set of columns defined by a tabular object
    /// </summary>
    public class SqlColumnGroup
    {
        public SqlColumnGroup(sxc.tabular_name TabularName, string GroupName, SqlColumnGroupKind GroupKind, params SqlColumnName[] Columns)
        {
            this.TabularName = TabularName;
            this.GroupKind = GroupKind;
            this.GroupName = GroupName;
            this.Columns = Columns.ToList();
        }

        public SqlColumnGroup(sxc.tabular_name TabularName, SqlColumnGroupKind GroupKind, params SqlColumnName[] Columns)
        {
            this.TabularName = TabularName;
            this.GroupKind = GroupKind;
            this.GroupName = String.Empty;
            this.Columns = Columns.ToList();
        }

        public SqlColumnGroup(sxc.tabular_name TabularName, params SqlColumnName[] Columns)
        {
            this.TabularName = TabularName;
            this.GroupKind = SqlColumnGroupKind.None;
            this.GroupName = String.Empty;
            this.Columns = Columns.ToList();
        }

        public string GroupName { get; }

        public SqlColumnGroupKind GroupKind { get; }

        public sxc.tabular_name TabularName { get; }

        public IReadOnlyList<SqlColumnName> Columns { get; }

        public SqlColumnGroup Regroup(SqlColumnGroupKind DstGroup)
            => new SqlColumnGroup(TabularName, GroupName, DstGroup, Columns.ToArray());

        public override string ToString()
            =>  $"({GroupName},{GroupKind},{TabularName},{string.Join(",", Columns)})";
    }
}
