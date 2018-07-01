//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using static metacore;

    using Meta.Models;

    /// <summary>
    /// Represents a keword, a classified character sequence with global or contextual meaning
    /// </summary>
    /// <typeparam name="k">The derived subtype</typeparam>
    public abstract class Keyword<k> : Model<k>, IKeyword
        where k : Keyword<k>
    {
        public static KeywordSequence operator +(Keyword<k> x, IKeyword y)
            => new KeywordSequence(stream(x.KeywordName, y.KeywordName));

        public static OneOf operator |(Keyword<k> x, IKeyword y)
            => new OneOf((x + y).Terms);

        public static implicit operator KeywordReference(Keyword<k> k)
            => new KeywordReference(k);

        static Keyword()
        {
            instance = ~
                from ctor in typeof(k).TryGetDefaultPrivateConstructor()
                let v = (k)ctor.Invoke(array<object>())
                select v;
        }

        protected static readonly k instance;

        public static k get()
            => instance;

        public static implicit operator string(Keyword<k> kw)
            => kw.KeywordName;

        protected Keyword(string name = null)
            => this.KeywordName = ifBlank(name, typeof(k).Name.ToLower());

        public string KeywordName { get; }

        public override string ToString()
            => KeywordName;

    }
}