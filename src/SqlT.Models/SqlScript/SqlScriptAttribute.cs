//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;

    using SqlT.Syntax;

    /// <summary>
    /// Used to associate an arbitrary code element with an identified script
    /// </summary>
    public class SqlScriptAttribute : Attribute
    {
        readonly SqlIdentifier ScriptIdentifier;

        public SqlScriptAttribute(string identifier)
        {
            this.ScriptIdentifier = new SqlIdentifier(identifier, false);
        }

        public static Option<SqlIdentifier> GetScriptIdentifier(Type t)
            => t.GetOptionalAttribute<SqlScriptAttribute>().Map(a => a.ScriptIdentifier);
            
    }
}
