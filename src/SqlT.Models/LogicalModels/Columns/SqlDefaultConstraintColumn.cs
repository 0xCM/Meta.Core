//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    using SqlT.Core;
    using SqlT.Syntax;

    
    [SqlElementType(SqlElementTypeNames.DefaultConstraintColumn)]
    public sealed class SqlDefaultConstraintColumn : SqlConstraintColumn<SqlDefaultConstraintColumn>
    {

        public SqlDefaultConstraintColumn(ISqlColumn ConstrainedColumn)
            : base(ConstrainedColumn)
        { }


    }

}
