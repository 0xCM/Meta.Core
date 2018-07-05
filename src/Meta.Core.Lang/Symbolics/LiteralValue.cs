//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Syntax;

    using static metacore;

    public struct LiteralValue<V> : IGrammarExpression
    {
        public static implicit operator LiteralValue(LiteralValue<V> Literal)
            => new LiteralValue(Literal);

        public LiteralValue(V Value)
        {
            this.Value = Value;
            this.IsEmpty = false;
        }

        public V Value { get; }

        public bool IsEmpty { get; }

        Lst<IToken> IGrammarExpression.Tokens
            => list<IToken>(Token.Define(string.Empty, Value));
        
        public override string ToString()
            => $"{Value}";
    }

    public readonly struct LiteralValue
    {
        public static LiteralValue<V> Define<V>(V Value)
            => new LiteralValue<V>(Value);

        public LiteralValue(object Value)
        {
            this.Value = Value;
            this.IsEmpty = isNull(Value);
        }

        public object Value { get; }


        public bool IsEmpty { get; }

        public override string ToString()
            => toString(Value);

    }



}