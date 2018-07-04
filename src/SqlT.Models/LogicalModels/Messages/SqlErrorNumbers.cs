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

    using Meta.Core;
    using SqlT.Core;
    
    /// <summary>
    /// Correlates a few common error messages with message numbers
    /// </summary>
    public class SqlErrorNumbers : TypedItemList<SqlErrorNumbers, SqlMessageNumber> 
    {
        public static SqlMessageNumber? Lookup(int MessageId)
            => TryFind(x => x.Value == MessageId).ValueOrDefault();              

        public static readonly SqlMessageNumber NetworkError = 53;

        //Violation of PRIMARY KEY constraint '$(PkName)'. Cannot insert duplicate key in object '$(TableSchema).$(TableName)'. The duplicate key value is (x, y, z). The statement has been terminated.
        public static readonly SqlMessageNumber PrimaryKeyViolation = 2627;
        
        //Could not find server '(DbSvr)' in sys.servers.Verify that the correct server name was specified.If necessary, execute the stored procedure sp_addlinkedserver to add the server to sys.servers.
        public static readonly int ServerNotFound = 7202;
        
        //Cannot open database "$(DbName)" requested by the login. The login failed. Login failed for user '$(Username)'.
        public static readonly int LoginFailed = 4060;
        
        //SQL Error: Invalid column name '$(ColumnName)'.
        public static readonly int InvalidColumnName = 207;
        
        //Cannot insert the value NULL into column '$(ColumnName)', table '$(TableName)'; column does not allow nulls. %ls fails.
        public static readonly int NullInsertNotAllowed = 515;
    }
}