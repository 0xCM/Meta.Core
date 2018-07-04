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

    using SqlT.Core;

    using static metacore;

    /// <summary>
    /// An indexed collection of <see cref="SqlParameterizedScript"/> elements
    /// </summary>
    public class SqlScriptCollection : IEnumerable<SqlParameterizedScript>
    {
        public static SqlScriptCollection Define(params SqlParameterizedScript[] scripts)
            => new SqlScriptCollection(scripts);

        public static implicit operator SqlScriptCollection(SqlParameterizedScript[] scripts)
            => Define(scripts);

        public SqlScriptCollection(IEnumerable<SqlParameterizedScript> scripts)
            => Index = scripts.ToDictionary(x => x.ScriptName);

        IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript> Index { get; }
     
        public IEnumerable<SqlParameterizedScript> Scripts
            => Index.Values;

        public IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript> GetIndex()
           => Index;

        public Option<SqlParameterizedScript> TryFind(SqlScriptName name)
            => Index.TryFind(name);

        public IEnumerator<SqlParameterizedScript> GetEnumerator()
            => Scripts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Scripts.GetEnumerator();
    }

}