//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using static metacore;

    using System;
    using System.Linq;

    using Meta.Syntax;
    using Meta.Core;
    using Meta.Core.Modules;

    using G = System.Collections.Generic;

    partial class Grammar
    {
        public struct Expression<E> : IGrammarExpression
        {

            public static implicit operator Expression(Expression<E> x)
                => new Expression(x);

            public Expression(G.IEnumerable<IToken> Tokens)
            {
                this.Tokens = Lst.make(Tokens);
                this.IsEmpty = this.Tokens.Count == 0;
            }

            public Lst<IToken> Tokens { get; }

            public bool IsEmpty { get; }

            public override string ToString()
                => join(string.Empty, Tokens.Stream());
        }

        public struct Expression : IGrammarExpression
        {
            public static Expression<E> Define<E>(G.IEnumerable<IToken> Tokens)
                => new Expression<E>(Tokens);
           

            public Expression(IGrammarExpression Source)
            {
                this.Tokens = Source.Tokens;
                this.IsEmpty = Source.Tokens.Count == 0;
            }

            public bool IsEmpty { get; }

            public Lst<IToken> Tokens { get; }

            public override string ToString()
                => string.Join(string.Empty, Tokens.Stream());
        }
    }

}