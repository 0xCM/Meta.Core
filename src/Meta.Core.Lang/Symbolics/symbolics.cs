namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    
    public static class symbolics
    {
        /// <summary>
        /// Constructs a named <see cref="SymbolicVariable"/> with no component value
        /// </summary>
        /// <param name="name">The name of the resulting variable</param>
        /// <returns></returns>
        public static SymbolicVariable symbolic(SymbolicVariableName name)
            => SymbolicVariable.Define(name);

        /// <summary>
        /// Constructs a named <see cref="SymbolicVariable"/> value from a component sequence
        /// </summary>
        /// <param name="name">The name of the resulting variable </param>
        /// <param name="components">The components that determine the value of the variable</param>
        /// <returns></returns>
        public static SymbolicVariable symbolic(SymbolicVariableName name, params ISymbolicExpression[] components)
            => SymbolicVariable.Define(name, components);

        /// <summary>
        /// Constructs an anonymous <see cref="SymbolicVariable"/> value from a component sequence
        /// </summary>
        /// <param name="components">The components that determine the value of the variable</param>
        /// <returns></returns>
        public static SymbolicVariable symbolic(params ISymbolicExpression[] components)
            => SymbolicVariable.Define(SymbolicVariableName.Empty, components);

        /// <summary>
        /// Defines a <see cref="SymbolicLiteral{V}"/> value
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SymbolicLiteral<V> symbolicValue<V>(V value)
            => SymbolicLiteral.Define<V>(value);

        /// <summary>
        /// Defines a literal value
        /// </summary>
        /// <typeparam name="V">The literal value type</typeparam>
        /// <param name="value">The literal value</param>
        /// <returns></returns>
        public static LiteralValue<V> literal<V>(V value)
            => LiteralValue.Define(value);

        /// <summary>
        /// Defines an untyped variable
        /// </summary>
        /// <param name="name">The variable name</param>
        /// <param name="ComponentValues">The components that comprise the value</param>
        /// <returns></returns>
        public static Variable var(VariableName name, params IGrammarExpression[] ComponentValues)
            => new Variable(name, ComponentValues);

        /// <summary>
        /// Defines a typed varible
        /// </summary>
        /// <typeparam name="V">The variable value type</typeparam>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The value of the variable</param>
        /// <returns></returns>
        public static Variable var<V>(VariableName name, V value)
            => new Variable(name, literal(value));

        /// <summary>
        /// Defines a reference to a variables
        /// </summary>
        /// <param name="v">The variable to reference</param>
        /// <returns></returns>
        public static VariableReference @ref(Variable v)
            => v.CreateReference();

    }
}
