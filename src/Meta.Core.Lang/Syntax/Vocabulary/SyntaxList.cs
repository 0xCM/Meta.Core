//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;

    using static metacore;

    public static class SyntaxList
    {

        public static SyntaxList<m> create<m>(IEnumerable<m> src)
            where m : IModel
                => new SyntaxList<m>(src);


        public static SyntaxList<t> create<s, t>(IEnumerable<s> src, Func<s, t> f)
            where s : IModel
            where t : IModel
                => new SyntaxList<t>(src.Select(item => f(item)));

    }

    public class SyntaxList<m> : Model<SyntaxList<m>>, IModelList<m>, IEnumerable<m>
        where m : IModel
    {

        public static new readonly SyntaxList<m> empty = new SyntaxList<m>();

        public static implicit operator SyntaxList<m>(m[] items)
            => new SyntaxList<m>(items);

        public static SyntaxList<m> operator +(SyntaxList<m> x, m y)
            => new SyntaxList<m>(array(x, y));

        public static SyntaxList<m> operator +(m x, SyntaxList<m> y)
            => new SyntaxList<m>(array(x, y.ToArray()));

        protected readonly List<m> _items;


        public SyntaxList()
        {
            _items = new List<m>();
            delimiter = ",";
        }


        public SyntaxList(IEnumerable<m> items, string delimiter = null)
        {
            _items = new List<m>(items);
            this.delimiter = delimiter ?? ",";
        }

        public SyntaxList(IEnumerable<IModel> src, Func<IModel, m> f)
            : this()
        {
            _items = new List<m>(src.Select(item => f(item)));
        }

        public SyntaxList<m> prepend(params m[] items)
            => new SyntaxList<m>(items.Concat(_items));

        public SyntaxList<m> append(params m[] items)
            => new SyntaxList<m>(_items.Concat(items));

        public IReadOnlyList<m> items
            => _items;

        public IEnumerator<m> GetEnumerator()
            => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public string delimiter { get; }

        public override bool IsEmpty
            => _items.Count == 0;

        public override string ToString()
            => string.Join(delimiter, _items.ToArray());

        IModelList<m> IModelList<m>.append(params m[] items)
            => append(items);

        IModelList<m> IModelList<m>.prepend(params m[] items)
            => prepend(items);
    }

    public abstract class SyntaxList<L, m> : SyntaxList<m>
        where m : IModel
        where L : SyntaxList<L, m>, new()
    {
        public static L define(params m[] items)
        {
            var l = new L();
            l._items.AddRange(items);
            return l;
        }

        protected SyntaxList()
        { }


        protected SyntaxList(IEnumerable<m> items, string delimiter = null)
            : base(items, delimiter)
        {

        }


        public static new readonly L empty = new L();


    }


}