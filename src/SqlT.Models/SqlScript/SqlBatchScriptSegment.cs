//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Syntax;
    using SqlT.Models;
    using sx = SqlT.Syntax.SqlSyntax;


    public class SqlBatchScriptSegment : ISqlScript
    {

        public SqlBatchScriptSegment(SqlScript SegmentScript, IEnumerable<SqlStatementScript> statements,  int? StartLine = null, int? EndLine = null)
        {
            this.SegmentScript = SegmentScript;
            this.StartLine = StartLine;
            this.EndLine = EndLine;
            this.Statements = statements.ToReadOnlyList();
        }

        public SqlScript SegmentScript { get; }

        public ReadOnlyList<SqlStatementScript> Statements { get; }

        public int? StartLine { get; }


        public int? EndLine { get; }

        public string ScriptText
            => SegmentScript.ScriptText;

        public SqlScriptName ScriptName
            => SegmentScript.ScriptName;

        public IReadOnlyList<SqlParameterName> ParameterNames
            => SegmentScript.ParameterNames;

        public string ScriptId
            => SegmentScript.ScriptId;

        public override string ToString()
            => SegmentScript.ScriptText;
    }


}