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

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    using static metacore;

    public class SqlModelList<M> : IReadOnlyList<M>
        where M : IModel
    {
        readonly IReadOnlyList<M> items;

        internal SqlModelList(IEnumerable<M> items)
        {
            this.items = rolist(items);
        }

        M IReadOnlyList<M>.this[int index]
            => items[index];

        int IReadOnlyCollection<M>.Count
            => items.Count;

        IEnumerator IEnumerable.GetEnumerator()
            => items.GetEnumerator();

        IEnumerator<M> IEnumerable<M>.GetEnumerator()
            => items.GetEnumerator();
    }

    public sealed class SqlModelList : SqlModelList<IModel>
    {
        public static SqlModelList<M> From<M>(IEnumerable<M> items)
            where M : IModel
            => new SqlModelList<M>(items);

        public static SqlModelList From(IEnumerable<IModel> items)
            => new SqlModelList(items);

        internal SqlModelList(IEnumerable<IModel> items)
            : base(items)
        { }
    }
}