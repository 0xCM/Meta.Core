//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using SqlT.Core;
    using static metacore;

    public abstract class SqlScriptResources<T> : IEnumerable<SqlParameterizedScript>
        where T : SqlScriptResources<T>
    {
        static IReadOnlyDictionary<string, SqlParameterizedScript> Scripts
            = AssemblyResourceProvider.Get(typeof(T).Assembly)
                .TextResources(".sql")
                .Select(x => (x.Name, new SqlParameterizedScript(x.Name, x.Text)))
                .ToReadOnlyDictionary();

        public Option<SqlParameterizedScript> TryFind(string name)
            => Scripts.TryFind(name);

        public Option<SqlScript> TryResolve(SqlScriptName name, object parameters)
            => TryFind(name).MapValueOrDefault(s => new SqlScript(s.ScriptName, s.Prepare(parameters)));

        public IEnumerator<SqlParameterizedScript> GetEnumerator()
            => Scripts.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}