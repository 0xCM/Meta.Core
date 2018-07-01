//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;   
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using Meta.Models;

    public sealed class KeyPhrase : Model<KeyPhrase>, IKeyphrase
    {

        public static KeyPhrase create(IEnumerable<IKeyword> keywords)
            => new KeyPhrase(keywords);

        public static KeyPhrase create(params IKeyword[] keywords)
            => new KeyPhrase(keywords);

        public static KeyPhrase operator +(KeyPhrase x, IKeyword y)
            => create(x.keywords + y);

        public static KeyPhrase operator +(IKeyword x, KeyPhrase y)
            => create(x + y.keywords);

        public static implicit operator string(KeyPhrase kp)
            => kp.ToString();

        public static implicit operator KeyPhrase(IKeyword[] keywords)
            => create(keywords);

        public static implicit operator KeyPhrase(SyntaxList<IKeyword> keywords)
            => create(keywords);

        public KeyPhrase(IEnumerable<IKeyword> keywords)
            => keywords = new SyntaxList<IKeyword>(keywords);

        public SyntaxList<IKeyword> keywords { get; }

        IModelList<IKeyword> IKeyphrase.keywords
            => keywords;

        public override string ToString()
            => isNotNull(keywords) ? string.Join(" ", keywords) : string.Empty;
    }


    public abstract class keyphrase<k1, k2> : Model<keyphrase<k1, k1>>, IKeyphrase
        where k1 : IKeyword
        where k2 : IKeyword
    {

        public keyphrase(k1 kw1, k2 kw2)
        {
            this.kw1 = kw1;
            this.kw2 = kw2;
        }

        public IModelList<IKeyword> keywords
            => new SyntaxList<IKeyword>(stream<IKeyword>(kw1, kw2));

        protected k1 kw1 { get; }
        protected k2 kw2 { get; }

        public override string ToString()
            => string.Join(" ", kw1, kw2);
    }

    public abstract class keyphrase<k1, k2, k3> : Model<keyphrase<k1, k1, k3>>, IKeyphrase
        where k1 : IKeyword
        where k2 : IKeyword
        where k3 : IKeyword
    {

        public keyphrase(k1 kw1, k2 kw2, k3 kw3)
        {
            this.kw1 = kw1;
            this.kw2 = kw2;
            this.kw3 = kw3;

        }

        public IModelList<IKeyword> keywords
            => new SyntaxList<IKeyword>(stream<IKeyword>(kw1, kw2));

        protected k1 kw1 { get; }

        protected k2 kw2 { get; }

        protected k3 kw3 { get; }

        public override string ToString()
            => string.Join(" ", kw1, kw2, kw3);
    }


}