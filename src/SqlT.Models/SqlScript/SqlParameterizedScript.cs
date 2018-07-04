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
    using System.Diagnostics;
    using System.Reflection;

    using static metacore;

    using SqlT.Core;

    /// <summary>
    /// Defines and identifies a SQL script that has 0 or more parameters
    /// </summary>
    public class SqlParameterizedScript : SqlScript<SqlParameterizedScript>, ISqlScript
    {
        public static implicit operator SqlScript(SqlParameterizedScript s)
            => new SqlScript(s.Body);

        public static implicit operator string(SqlParameterizedScript s)
            => s?.Body ?? String.Empty;

        static IReadOnlyList<SqlParameterName> ExtractParameters(Script script)
            => map(script.GetParameterNames(false).Where(p => !p.StartsWith("var_")), 
                    x => new SqlParameterName(x));

        public SqlParameterizedScript(SqlScriptName Name, Script Body)
            : base(Name, null, Body.Body, ExtractParameters(Body))
            => this.Body = Body;

        public SqlParameterizedScript(SqlScriptName Name, Script Body, IEnumerable<SqlParameterName> Parameters)
            : base(Name, null, Body.Body, Parameters) => this.Body = Body;

        public SqlParameterizedScript Identify(SqlScriptName Identifier)
            => new SqlParameterizedScript(Identifier, Body, ParameterNames);

        public Script Body { get; }
        
        string ISqlScript.ScriptText
            => Body;

        public override string ToString() 
            => Body;

        public string Prepare(object parameters) 
            => Body.SpecifyParametersWithObject(parameters);
    }


}
