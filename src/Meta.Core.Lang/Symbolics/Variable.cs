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

    /// <summary>
    /// Represents a variable with an optional name and/or values
    /// </summary>
    public struct Variable : IVariable
    {
        public static Variable operator + (Variable x, Variable y)
            => new Variable(VariableName.Empty, 
                    x.ComponentValues.Concat(y.ComponentValues));

        public Variable(VariableName Name, params IGrammarExpression[] ComponentValues)
        {
            this.Name = Name;
            this.ComponentValues = ComponentValues.ToReadOnlyList();
        }

        public Variable(VariableName Name, IEnumerable<IGrammarExpression> ComponentValues)               
        {
            this.Name = Name;
            this.ComponentValues = rolist(ComponentValues);
        }

        public VariableName Name { get; }

        public IReadOnlyList<IGrammarExpression> ComponentValues { get; }

        public bool IsAnonymous
            => Name.IsEmpty;

        public Variable Rename(VariableName NewName)
            => new Variable(NewName, ComponentValues);

        public VariableReference CreateReference()
            => new VariableReference(this);

        public override string ToString()
            => concat($"{Name}",
                    ":=", join(string.Empty, ComponentValues.ToArray()));
    }
}