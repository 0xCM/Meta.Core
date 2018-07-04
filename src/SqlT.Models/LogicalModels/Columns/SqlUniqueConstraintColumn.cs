//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Syntax;

    /// <summary>
    /// Characterizes a unique constraint column
    /// </summary>
    [SqlElementType(SqlElementTypeNames.UniqueConstraintColumn)]
    public sealed class SqlUniqueConstraintColumn : SqlConstraintColumn<SqlUniqueConstraintColumn>
    {

        public SqlUniqueConstraintColumn(ISqlColumn ConstrainedColumn)
            : base(ConstrainedColumn)
        { }

    }

}
