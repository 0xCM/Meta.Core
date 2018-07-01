//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    
    using static metacore;

    using G = ChoiceGrammar;

    /// <summary>
    /// A choice is identified by a classifier and a named instance of that classifier.
    /// This type encodes that precept and the structural isomorphism between
    /// this identification and 2-tuples 
    /// </summary>
    public readonly struct ChoiceIdentity : IEquatable<ChoiceIdentity>
    {
        /// <summary>
        /// The canonical 0
        /// </summary>
        public static ChoiceIdentity None
            = new ChoiceIdentity(string.Empty, string.Empty);

        static bool Eq(ChoiceIdentity x, ChoiceIdentity y)
        {
            var sameLabel = equals(x.Label, y.Label);
            var sameClass = equals(x.Class, y.Class);
            return sameLabel && sameClass;
        }

        public static bool operator ==(ChoiceIdentity x, ChoiceIdentity y)
            => x.Equals(y);

        public static bool operator !=(ChoiceIdentity x, ChoiceIdentity y)
            => not(x.Equals(y));

        public static ChoiceIdentity Parse(string Identity)
            => Identity.Bifurcate(G.OfType);

        public static implicit operator ChoiceIdentity((string Label, string Class) x)
            => new ChoiceIdentity(x);

        public static implicit operator (string Label, string Class) (ChoiceIdentity x)
            => (x.Class, x.Label);

        public static ChoiceIdentity Identify((string Label, string Class) x)
            => x;

        public ChoiceIdentity((string Label, string Class) x)
        {
            this.Label = x.Label;
            this.Class = x.Class;
        }

        public ChoiceIdentity(string Label, string Class)
        {
            this.Label = Label;
            this.Class = Class;
        }

        /// <summary>
        /// The name of the classifier instance
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// The name of the classifier
        /// </summary>
        public string Class { get; }

        public bool Equals(ChoiceIdentity other)
            => Eq(this, other);

        public override bool Equals(object obj)
            => ifType((obj, this), v => Eq(v.left, v.right), _ => false);

        public override int GetHashCode()
            => ToString().GetHashCode();

        public override string ToString()
            => $"{Label} {G.OfType} {Class}";
    }

}