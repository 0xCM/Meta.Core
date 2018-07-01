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
    using System.Text;

    using static metacore;

    public static class SymbolicLiteral
    {
        public static SymbolicLiteral<V> Define<V>(V Value)
            => new SymbolicLiteral<V>(Value);
    }

    public struct SymbolicLiteral<V> : ISymbolicLiteral<V>
    {
        public static implicit operator SymbolicLiteral<V>(V Value)
            => SymbolicLiteral.Define(Value);

        public SymbolicLiteral(V Value)
        {
            this.Value = Value;
        }

        public V Value { get; }

        public bool IsEmpty
           => false;

        public IEnumerable<ISymbolicExpression> Components
            => stream<ISymbolicExpression>();

        object ISymbolicLiteral.Value
            => Value;

        public string Format()
            => toString(Value);

        public override string ToString()
            => toString(Value);
    }




}