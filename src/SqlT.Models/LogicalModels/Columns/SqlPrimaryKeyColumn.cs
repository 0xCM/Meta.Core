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
    /// Characterizes a primary key column
    /// </summary>
    [SqlElementType(SqlElementTypeNames.PrimaryKeyColumn)]
    public sealed class SqlPrimaryKeyColumn : SqlConstraintColumn<SqlPrimaryKeyColumn>
    {

        public SqlPrimaryKeyColumn(ISqlColumn ConstrainedColumn)
            : base(ConstrainedColumn)
        { }


    }

}
