//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using static metacore;

    using System;
    using System.Text.RegularExpressions;

    using System.Data.SqlClient;

    public class SqlInvalidColumnName : SqlServerErrorNotification
    {
        protected static readonly Regex ColumnNameMatch = regex(@"Invalid column name \'(?<ColumnName>(.*))\'");

        public SqlInvalidColumnName()
        {

        }

        internal SqlInvalidColumnName(SqlException e, SqlConnectionString cs)
            : base(e, cs)
        {
            ColumnName = ColumnNameMatch.TryGetGroupValue(ErrorMessage, nameof(ColumnName)).ValueOrDefault();
            DatabaseName = cs.DatabaseName;
        }

        public string ColumnName { get; set; }

        public string DatabaseName { get; set; }
    }
}
