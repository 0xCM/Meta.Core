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

    using V = SymbolicVariable;
    using E = ISymbolicExpression;

    public struct SymbolicVariable  : ISymbolicVariable
    {
        public delegate V VariableAggregator(V x, V y);

        public static implicit operator V(SymbolicReference Reference)
            => Define(SymbolicVariableName.Empty, Reference);

        public static SymbolicExpression operator +(V x, V y)
            => SymbolicExpression.Define(x, y);

        public static V Define(SymbolicVariableName Name, params E[] Components)
            => new V(Name, Components);

        public static V Define(SymbolicVariableName Name) 
            => new V(Name);

        SymbolicVariable(SymbolicVariableName Name)
        {
            this.VariableName = Name;
            this.Components = ReadOnlyList<E>.Empty;
        }

        SymbolicVariable(SymbolicVariableName VariableName, IEnumerable<E> Components)
        {
            this.VariableName = VariableName;
            this.Components = rolist(Components);
        }

        public IReadOnlyList<E> Components { get; }

        public SymbolicVariableName VariableName { get; }
            
        IEnumerable<E> E.Components
            => Components;

        public Option<object> ResolveValue()
            => ToString();

        public bool IsAnonymous
            => VariableName.IsEmpty;

        public V Rename(SymbolicVariableName NewName)
            => new V(NewName, Components);

        public SymbolicReference CreateReference()
            => new SymbolicReference(this);

        public override string ToString()
            => this.Format();
    }
}
