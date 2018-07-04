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

    public class SqlServerErrorNotification : SqlErrorNotification
    {


        public SqlServerErrorNotification()
        {

        }

        internal SqlServerErrorNotification(SqlException e, SqlConnectionString cs = null)
            : base(e, cs)
        {
            SqlErrorNumber = e.Number;
            ServerName = e.Server;
            ErrorMessage = e.Message;
            Severity = (SqlSeverityLevel)e.Class;
            HResultCode = e.HResult;
            Procedure = e.Procedure;
            ProcedureLineNumber = e.LineNumber;
        }


        public int SqlErrorNumber { get; set; }

        public string ServerName { get; set; }

        public int HResultCode { get; set; }

        public SqlSeverityLevel Severity { get; set; }

        public string Procedure { get; set; }

        public int ProcedureLineNumber { get; set; }

        public override string MessageDetail
            => $"SQL Error: {ErrorMessage}";
    }
}
