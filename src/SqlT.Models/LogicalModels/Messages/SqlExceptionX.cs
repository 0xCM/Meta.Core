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

    public static class SqlExceptionX
    {
        static Dictionary<SqlMessageNumber, Func<SqlException, SqlConnectionString, SqlErrorNotification>> NF { get; }
            = new Dictionary<SqlMessageNumber, Func<SqlException, SqlConnectionString, SqlErrorNotification>>
            {
                {SqlErrorNumbers.NetworkError, (SqlException e,  SqlConnectionString cs) =>  new SqlNetworkError(e,cs)},
                {SqlErrorNumbers.PrimaryKeyViolation, (SqlException e,  SqlConnectionString cs) =>  new SqlConstraintViolation(e,cs)},
                {SqlErrorNumbers.ServerNotFound, (SqlException e,  SqlConnectionString cs) =>  new SqlServerNotFound(e,cs)},
                {SqlErrorNumbers.LoginFailed, (SqlException e,  SqlConnectionString cs) =>  new SqlLoginFailed(e,cs)},
                {SqlErrorNumbers.InvalidColumnName, (SqlException e,  SqlConnectionString cs) =>  new SqlInvalidColumnName(e,cs)},
                {SqlErrorNumbers.NullInsertNotAllowed, (SqlException e,  SqlConnectionString cs) =>  new SqlNullInsertNotAllowed(e,cs)},


            };

        public static SqlErrorNotification CreateSqlErrorNotification(this SqlException e, SqlConnectionString cs)
        {
            var number = SqlErrorNumbers.Lookup(e.Number);
            if (not(number.HasValue))
                return new SqlServerErrorNotification(e);
            else
                return NF[number.Value](e, cs);

        }

        public static SqlErrorNotification CreateErrorNotification(this Exception e, SqlConnectionString cs = null)
        {
            if ((e as InvalidOperationException)?.ToString().Contains("The timeout period elapsed prior to obtaining a connection from the pool") ?? false)
                return new SqlConnectionPoolTimedOut(e as InvalidOperationException, cs ?? SqlConnectionString.Empty);
            else
                return new SqlErrorNotification(e);
        }

    }


}
