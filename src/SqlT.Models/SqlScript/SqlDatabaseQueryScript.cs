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

    using static metacore;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Specifies a query that is potentially parametrized by a potentially server-qualified database name
    /// </summary>
    public sealed class SqlDatabaseQueryScript : SqlScript<SqlDatabaseQueryScript>, ISqlObjectQueryScript, ISqlDatabaseQueryScript
    {
        public const string ServerParameterName = "@ServerName";
        public const string DatabaseParameterName = "@DatabaseName";

        static IEnumerable<SqlParameterValue> CalcParameterValues(SqlDatabaseName SourceDatabase)
        {
            if (SourceDatabase.IsServerQualified)
                yield return new SqlParameterValue(ServerParameterName, SourceDatabase.ServerName.UnqualifiedName);

            if (!SourceDatabase.IsEmpty())
                yield return new SqlParameterValue(DatabaseParameterName, SourceDatabase.UnqualifiedName);
        }

        public SqlDatabaseQueryScript(SqlScriptName ScriptName, string ScriptText, SqlDatabaseName SourceDatabase)
            : base(ScriptName, ScriptText)
        {
            this.SourceDatabase = SourceDatabase;
            this.ParameterValues = rolist(CalcParameterValues(SourceDatabase));
        }

        public SqlDatabaseQueryScript(SqlScript Script, SqlDatabaseName SourceDatabase)
            : this(Script.ScriptName, Script.ScriptText, SourceDatabase) { }

        public SqlDatabaseName SourceDatabase { get; }

        public ReadOnlyList<SqlParameterValue> ParameterValues { get; }

        Option<SqlDatabaseName> ISqlObjectQueryScript.SourceDatabase
            => SourceDatabase;

        Option<sxc.ISqlObjectName> ISqlObjectQueryScript.SourceObject
            => none<sxc.ISqlObjectName>();

        public override string ToString()
            => $"From {SourceDatabase}: {ScriptText}";
    }
}
