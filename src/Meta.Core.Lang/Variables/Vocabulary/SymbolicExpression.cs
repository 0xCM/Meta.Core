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

    using static metacore;

    using X = SymbolicExpression;
    using E = ISymbolicExpression;

    public struct SymbolicExpression : E
    {
        public static X Define(params E[] Components)
                => new X(Components);

        public static X operator +(X x1, X x2)
            => new X(x1.Components.Concat(x2.Components));

        public SymbolicExpression(IEnumerable<E> Components)
            => this.Components = rolist(Components);

        public IReadOnlyList<E> Components { get; }

        IEnumerable<E> E.Components
            => Components;

        public override string ToString()
            => this.Format();

        public SymbolicVariable ToVariable(SymbolicVariableName Name)
            => SymbolicVariable.Define(Name, Components.ToArray());
    }
}