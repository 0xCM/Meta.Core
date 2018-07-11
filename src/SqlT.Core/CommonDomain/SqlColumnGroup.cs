//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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

        /// <summary>
        /// The name of the grouping
        /// </summary>
        public string GroupName { get; }

        /// <summary>
        /// The group classification
        /// </summary>
        public SqlColumnGroupKind GroupKind { get; }

        /// <summary>
        /// The column-defining object
        /// </summary>
        public sxc.tabular_name TabularName { get; }

        /// <summary>
        /// The columns included in the group
        /// </summary>
        public IReadOnlyList<SqlColumnName> Columns { get; }

        /// <summary>
        /// Replaces the group's classification
        /// </summary>
        /// <param name="DstGroup">The new classification</param>
        /// <returns></returns>
        public SqlColumnGroup Regroup(SqlColumnGroupKind DstGroup)
            => new SqlColumnGroup(TabularName, GroupName, DstGroup, Columns.ToArray());

        public override string ToString()
            =>  $"({GroupName},{GroupKind},{TabularName},{string.Join(",", Columns)})";
    }
}
