//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using SqlT.Models;
    using SqlT.Core;
    using System;

    using sx = SqlT.Syntax.SqlSyntax;


    public class SelectCountByGroupingColumn : SelectFromTabular<SelectCountByGroupingColumn, SqlTabularName>
    {

        public SelectCountByGroupingColumn(SqlTabularName TabularName, SqlColumnName GroupingColumn)
            : base(TabularName)
        {
            this.GroupingColumm = GroupingColumm;
        }
        

        public SqlColumnName GroupingColumm { get; }


        public override SqlSelectStatement Render()
        {
            var s = new sx.column_ref(GroupingColumm);


            throw new NotImplementedException();
        }

    }

    

}
