//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Text;
    using SqlT.Core;

    using static metacore;

    public static class SqlScriptExtensions
    {
        public static SqlScript CreateBatchScript(this IEnumerable<ISqlScript> scripts)
        {
            var sb = new StringBuilder();
            iter(scripts, script =>
            {
                sb.AppendLine(script.ScriptText);
                sb.AppendLine("GO");
                sb.AppendLine();
            });
            return sb.ToString();
        }
    }
}
