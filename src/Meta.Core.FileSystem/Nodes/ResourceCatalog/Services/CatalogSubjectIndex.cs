//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using System.Collections;

    using static metacore;

    public class CatalogSubjectIndex : IReadOnlyDictionary<Type, CatalogSubject>
    {
        public static CatalogSubjectIndex Create(IEnumerable<CatalogSubject> areas)
            => new CatalogSubjectIndex(areas);

        IReadOnlyDictionary<Type, CatalogSubject> index;

        public CatalogSubjectIndex(IEnumerable<CatalogSubject> src)
        {
            index = src.ToDictionary(x => x.GetType());
        }

        public CatalogSubject this[Type key]
            => index[key];

        public IEnumerable<Type> Keys
            => index.Keys;

        public IEnumerable<CatalogSubject> Values
            => index.Values;

        public int Count
            => index.Count;

        public bool ContainsKey(Type key)
        {
            return index.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<Type, CatalogSubject>> GetEnumerator()
        {
            return index.GetEnumerator();
        }

        public bool TryGetValue(Type key, out CatalogSubject value)
        {
            return index.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return index.GetEnumerator();
        }
    }



}