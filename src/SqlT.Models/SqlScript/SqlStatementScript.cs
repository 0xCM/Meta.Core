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
    using SqlT.Syntax;

    using static SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Represents a statement deterined by a script
    /// </summary>
    public class SqlStatementScript : statement<SqlStatementScript>, ISqlScript
    {
        public SqlStatementScript(SqlScript SqlScript, object ScriptSource, SqlSyntaxGraph SyntaxGraph)
            : base(EMPTY)
        {
            this.SqlScript = SqlScript;
            this.ScriptSource = ScriptSource;
            this.SyntaxGraph = SyntaxGraph;
        }

        public SqlStatementScript(SqlScript SqlScript, object ScriptSource)
            : base(EMPTY)
        {
            this.SqlScript = SqlScript;
            this.ScriptSource = ScriptSource;
            this.SyntaxGraph = SyntaxGraph;
        }

        public SqlStatementScript(SqlSpecScript SqlScript)
            : base(EMPTY)
        {
            this.SqlScript = SqlScript;
        }

        public Option<SqlSyntaxGraph> SyntaxGraph { get; }

        public object ScriptSource { get; }

        public ISqlScript SqlScript { get; }

        public string ScriptText
            => SqlScript.ScriptText;

        SqlScriptName ISqlScript.ScriptName
            => SqlScript.ScriptName;

        IReadOnlyList<SqlParameterName> ISqlScript.ParameterNames
            => SqlScript.ParameterNames;

        string ISqlScript.ScriptId
            => SqlScript.ScriptId;

        public override string ToString()
            => SqlScript.ToString();

    }
    
}
