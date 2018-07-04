//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;
    using System.Collections.Generic;

    public interface ISqlScript
    {
        /// <summary>
        /// Uniquely identifies the script within some context
        /// </summary>
        string ScriptId { get; }

        /// <summary>
        /// The actual text of the script
        /// </summary>
        string ScriptText { get; }
            
        SqlScriptName ScriptName { get; }

        IReadOnlyList<SqlParameterName> ParameterNames { get; }

    }


}
