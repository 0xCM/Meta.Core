//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    /// <summary>
    /// Characterizes a linked server
    /// </summary>
    [SqlElementType(SqlElementTypeNames.LinkedServer)]
    public sealed class SqlLinkedServer : SqlElement<SqlLinkedServer>, ISqlElement
    {
        public readonly SqlServerName ServerName;
        public readonly Option<string> DataSource;
        public readonly Option<string> Provider;
        public readonly Option<SqlUser> RemoteUser;
        public readonly Option<string> ProviderString;
        public readonly Option<SqlName> Catalog;
        public readonly Option<string> ServerProduct;

        public SqlLinkedServer
            (
                SqlServerName ServerName, 
                SqlUser RemoteUser, 
                SqlElementDescription Documentation = null, 
                IEnumerable<SqlPropertyAttachment> Properties = null
            )
            : base(ServerName, Documentation, Properties)
        {
            this.ServerName = ServerName;
            this.ServerProduct = "SQL Server";
            this.RemoteUser = RemoteUser;
        }

        public SqlLinkedServer
        (
            SqlServerName ServerName,
            string ServerProduct = "",
            string DataSource = null,
            string Provider = null,
            string ProviderString = null,
            SqlUser RemoteUser = null,
            SqlName Catalog = null
        ) : base(ServerName)
        {
            this.ServerName = ServerName;
            this.DataSource = DataSource;
            this.RemoteUser = RemoteUser;
            this.Provider = Provider;
            this.ProviderString = ProviderString;
            this.ServerProduct = ServerProduct;
            this.Catalog = Catalog;
        }


    }


}
