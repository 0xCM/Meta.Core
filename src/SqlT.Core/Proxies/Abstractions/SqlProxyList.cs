//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    
    public class SqlProxyList<P> : IReadOnlyList<P>
        where P : ISqlProxy
    {
        readonly IReadOnlyList<P> items;

        public static implicit operator SqlProxyList<P>(P[] items)
            => new SqlProxyList<P>(items);

        public SqlProxyList()
        {
            this.items = new List<P>();
        }

        public SqlProxyList(IEnumerable<P> items, string delimiter = ",")
        {
            this.items = items.ToList();
            this.delimiter = delimiter;
        }

        public SqlProxyList(IEnumerable<P> src, Func<ISqlProxy, P> f)
        {
            items = src.Select(item => f(item)).ToSqlProxyList();
        }


        IEnumerator<P> IEnumerable<P>.GetEnumerator()
            => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => items.GetEnumerator();
        public string delimiter { get; }

        public int Count
            => items.Count;


        public P this[int index] 
            => items[index];

        public override string ToString()
            => string.Join(delimiter, items.ToArray());
    }

    public class SqlProxyList<L, P> : SqlProxyList<P>
        where P : ISqlProxy
        where L : SqlProxyList<L, P>, new()
    {
        public static readonly L empty = new L();

        protected SqlProxyList()
        { }


        protected SqlProxyList(IEnumerable<P> items, string delimiter = ",")
            : base(items, delimiter)
        {

        }

    }
    public static class SqlProxyList
    {
        public static SqlProxyList<Y> ToSqlProxyList<X, Y>(IEnumerable<X> src, Func<X, Y> f)
            where X : ISqlProxy
            where Y : ISqlProxy
            => new SqlProxyList<Y>(src.Select(item => f(item)));

        public static SqlProxyList<P> ToSqlProxyList<P>(this IEnumerable<P> items)
            where P : ISqlProxy  => new SqlProxyList<P>(items);
    }

}
