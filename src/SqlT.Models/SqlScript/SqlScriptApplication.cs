//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Encapsulates a collection of scripts that have been applied to one or more databases
    /// </summary>
    public class SqlScriptApplication : ValueObject<SqlScriptApplication>
    {
        public SqlScriptApplication(IEnumerable<Option<ISqlModelScript>> AppliedScripts)
        {
            this.AppliedScripts = AppliedScripts.ToReadOnlyList();
        }

        public ReadOnlyList<Option<ISqlModelScript>> AppliedScripts { get; }
    }

}