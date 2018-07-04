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

    using SqlT.Core;

    public sealed class SqlQualifiedScript : SqlScript<SqlQualifiedScript>
    {

        public SqlQualifiedScript(SqlServerName ServerName, string DatabaseName, SqlScript Script)
            : base(Script.ScriptName, Script.ScriptText)
        {
            this.DatabaseName = new SqlDatabaseName(ServerName, DatabaseName);
        }

        public SqlQualifiedScript(SqlDatabaseName DatabaseName, SqlScript Script)
            : base(Script.ScriptName, Script.ScriptText)
        {
            this.DatabaseName = DatabaseName;
        }

        public SqlDatabaseName DatabaseName { get; }

    }





}
