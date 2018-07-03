//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;
    using static express;

    using G = ChoiceGrammar;

    /// <summary>
    /// Defines the choice concept: A choice is an identified value
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class Choice<V> : IEquatable<Choice<V>>
    {
        public static Option<Choice<V>> Parse(string text)
            => from parseMethod in ClrType.Get<V>().ParseMethod
               from  p in func<string, V>(parseMethod)
               let parts = text.Bifurcate(G.Entails)
               let identity = parts.Left.Bifurcate(G.OfType)
               from value in Try(() => p(parts.Right))
               select new Choice<V>(identity, p(parts.Right));

        public Choice(ChoiceIdentity Identity, V Value)
        {
            this.Identity = Identity;
            this.Value = Value;
        }

        /// <summary>
        /// Identifies the choice
        /// </summary>
        public ChoiceIdentity Identity { get; }

        /// <summary>
        /// The value entailed by the choice
        /// </summary>
        public V Value { get; }

        public bool Equals(Choice<V> other)
        {
            if (isNull(other))
                return false;

            var sameIdentity = Identity == other.Identity;
            var sameValue = Equals(Value, other.Value);

            return sameIdentity && sameValue;                          
        }

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public override bool Equals(object obj)
            => obj is Choice<V>  ? Equals((Choice<V>)obj) : false;

        public override string ToString()
            => $"{Identity} {G.Entails} {Value}";
    }
}