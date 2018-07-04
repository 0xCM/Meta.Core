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

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;
    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;


    public class SqlScriptIndex : ISqlScriptIndex
    {
        readonly IReadOnlyDictionary<IName, ReadOnlyList<ISqlElementSpecScript>> nameLookup;

        public SqlScriptIndex(IEnumerable<ISqlElementSpecScript> scripts)
        {
            nameLookup = scripts.GroupBy(x => x.ElementName).ToDictionary(x => x.Key, y => y.Map(z => z));
        }

        public IEnumerable<ISqlElementSpecScript> All 
            => nameLookup.Values.SelectMany(x => x);


        public ISqlElementSpecScript FindByName(IName name) 
            =>  nameLookup[name].Single();


    }
}
