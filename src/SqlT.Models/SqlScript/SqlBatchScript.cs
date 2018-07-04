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
    using System.Text;
    using SqlT.Syntax;
    using SqlT.Core;    

    public class SqlBatchScript : ISqlScript
    {
        public static implicit operator string(SqlBatchScript x)
            => x.ToString();

        public SqlBatchScript(IEnumerable<SqlBatchScriptSegment> Segments)
        {
            this.Segments = Segments.ToList();
            this.ScriptName = SqlScriptName.Empty;
        }

        public SqlBatchScript(SqlScriptName ScriptName, IEnumerable<SqlBatchScriptSegment> Segments)
        {
            this.Segments = Segments.ToList();
            this.ScriptName = ScriptName;
        }

        public SqlScriptName ScriptName { get; }

        public IReadOnlyList<SqlBatchScriptSegment> Segments { get; }

        public string ScriptText 
            => ToString();

        IReadOnlyList<SqlParameterName> ISqlScript.ParameterNames
            => new List<SqlParameterName>();

        string ISqlScript.ScriptId
            => string.Empty;

        public IEnumerable<SqlStatementScript> Statements
             => from segment in Segments
                from statement in segment.Statements
                select statement;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var segment in Segments)
            {
                sb.AppendLine(segment.ScriptText);
                sb.AppendLine("GO");
            }
            return sb.ToString();
        }
    }
}
