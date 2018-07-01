//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public abstract class PromptSyntaxList<B, T> : IReadOnlyList<T>, IEquatable<B>
        where B : PromptSyntaxList<B, T>, new()
    {
        public static readonly B Empty = new B();

        public static B operator +(PromptSyntaxList<B, T> x, PromptSyntaxList<B, T> y)
            => Create(x.Concat(y).ToArray());

        protected string Delimiter;



        public static B Create(IEnumerable<T> items, string Delimiter = null)
            => new B().Initialize(items, Delimiter);


        protected virtual void Filled() { }

        B Initialize(IEnumerable<T> items, string Delimiter)
        {
            this.Items = new List<T>(items);
            this.Delimiter = Delimiter ?? ",";
            Filled();
            return (B)this;
        }


        protected PromptSyntaxList()
        {
            this.Delimiter = ",";
        }

        protected PromptSyntaxList(string Delimiter)
        {
            this.Items = new List<T>();
            this.Delimiter = Delimiter ?? ",";
        }

        protected PromptSyntaxList(char Delimiter)
            : this(Delimiter.ToString())
        {
        }
        public IReadOnlyList<T> Items { get; private set; }

        public T this[int index]
            => Items[index];


        public int Count
            => Items.Count;

        public IEnumerator<T> GetEnumerator()
            => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
            => string.Join(Delimiter, this.Items);

        public bool Equals(B other)
        {
            if (other is null)
                return false;

            if (other.Count != this.Count)
                return false;

            return !(this.Zip(other,
                (x, y) => (x: x, y: y))
                .Any(
                    pair
                        => !(pair.x).Equals(pair.y))
                        );
        }

        public override int GetHashCode()
            => this.Sum(x => x.GetHashCode());

        public override bool Equals(object obj)
            => Equals(obj as B);

    }
}