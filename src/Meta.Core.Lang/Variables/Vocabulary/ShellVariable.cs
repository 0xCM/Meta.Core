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

    using V = ShellVariable;
    using E = ISymbolicExpression;

    public struct ShellVariable : ISymbolicVariable
    {
        public delegate V VariableAggregator(V x, V y);

        public static V operator + (V x, V y)
            => x.Aggregator(x, y);

        public static V Collapse(V x, V y)
            => new V(x.VariableName, x.Expand().Concat(y.Expand()));


        public static V Define(SymbolicVariableName Name, params E[] Components)
            => new V(Name, Components);

        VariableAggregator Aggregator { get; }

        public ISymbolicFormatter DefaultFormatter { get; }

        IReadOnlyList<E> Components { get; }


        ShellVariable(SymbolicVariableName VariableName, IEnumerable<E> Components)
        {
            this.VariableName = VariableName;
            this.Components = rolist(Components);
            this.Aggregator = Collapse;
            this.DefaultFormatter = VariableFormatters.ShellFormatter;
        }

        public SymbolicVariableName VariableName { get; }

        IEnumerable<E> E.Components
            => Components;
        public bool IsEmpty
            => Components.Count == 0;

        public bool IsAnonymous
            => VariableName.IsEmpty;

        public string Format()
            => DefaultFormatter.Format(this);

        public string Format(ISymbolicFormatter Formatter)
            => Formatter?.Format(this) ?? this.DefaultFormatter.Format(this);

        public override string ToString()
            => Format(DefaultFormatter);

        public SymbolicReference CreateReference()
            => new SymbolicReference(this);

        public Option<object> ResolveValue()            
            => ToString();
    }


}
