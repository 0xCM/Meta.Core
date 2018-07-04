//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;


    public interface ISqlTabularDocumentation : ISqlObjectDocumentation
    {
        /// <summary>
        /// The roles, if any, played by the columns defined by the table
        /// </summary>
        IEnumerable<SqlColumnRole> ColumnRoles { get; }

        /// <summary>
        /// The columns defined by the tabular object
        /// </summary>
        IReadOnlyList<SqlColumnDocumentation> Columns { get; }

    }

    public interface ISqlTabularDocumentation<N> : ISqlTabularDocumentation, ISqlObjectDocumentation<N>
        where N : SqlTabularName<N>, new()
    { }
}
