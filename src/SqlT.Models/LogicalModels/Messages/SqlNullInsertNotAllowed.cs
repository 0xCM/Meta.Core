//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;

    using static metacore;

    using SqlT.Core;
    
    public class SqlNullInsertNotAllowed : SqlServerErrorNotification
    {
        protected static readonly Regex Match = regex("Cannot insert the value NULL into column \'(?<ColumnName>(.*))\', table \'(?<TableName>(.*))\'");

        public SqlNullInsertNotAllowed()
        {

        }

        internal SqlNullInsertNotAllowed(SqlException e, SqlConnectionString cs)
            : base(e, cs)
        {
            DatabaseName = cs.DatabaseName;
            TableName = Match.TryGetGroupValue(ErrorMessage, nameof(TableName)).ValueOrDefault();
            ColumnName = Match.TryGetGroupValue(ErrorMessage, nameof(ColumnName)).ValueOrDefault();

        }

        public string DatabaseName { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }


    }
}
