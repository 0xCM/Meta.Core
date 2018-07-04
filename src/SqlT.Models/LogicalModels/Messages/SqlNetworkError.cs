//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Data.SqlClient;

    using SqlT.Core;

    using static metacore;

    /// <summary>
    /// Notification raised when encountering error number 53 as a <see cref="SqlException"/>
    /// This is not an error described in sys.messages so it is considered a client exception.
    /// Partial exception message is:             
    /// A network-related or instance-specific error occurred while establishing a connection to SQL Server
    /// </summary>
    public class SqlNetworkError : SqlClientErrorNotification
    {

        public SqlNetworkError()
        {

        }

        public SqlNetworkError(Exception e, SqlConnectionString cs)
            : base(e,cs)
        {
            ServerName = cs.ServerName;
            DatabaseName = cs.DatabaseName;
        }



        
        public string ServerName { get; set; }

        
        public string DatabaseName { get; set; }


        public override string MessageDetail =>
            $"A network error prevented establishing a connection to: {Connector}";
    }
}
