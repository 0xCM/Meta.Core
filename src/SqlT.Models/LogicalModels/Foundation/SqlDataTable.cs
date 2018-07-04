//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;


    public abstract class SqlDataTable<R> : SqlModel<SqlDataTable<R>>, ISqlDataTable
        where R : SqlDataTable<R>
    {


        protected SqlDataTable()
        {
            this.Columns = rolist<ISqlColumn>();
        }

        protected SqlDataTable(IEnumerable<ISqlColumn> columns)
        {
            this.Columns = rolist(columns);
        }


        public virtual IReadOnlyList<ISqlColumn> Columns { get; }

        public IReadOnlyList<SqlColumnName> ColumnNames
            => map(Columns, c => c.Name);


        
    }

}