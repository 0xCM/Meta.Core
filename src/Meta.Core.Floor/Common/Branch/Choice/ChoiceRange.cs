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

    using G = ChoiceGrammar;

    public class ChoiceRange<V> : IEquatable<ChoiceRange<V>>
        where V : IComparable
    {
        public ChoiceRange(ChoiceIdentity identity, (V Min, V Max) Range)
        {
            this.Identity = identity;
            this.Min = Range.Min;
            this.Max = Range.Max;
        }

        /// <summary>
        /// Identifies the range
        /// </summary>
        public ChoiceIdentity Identity { get; }

        /// <summary>
        /// The minimum available value
        /// </summary>
        public V Min { get; }

        /// <summary>
        /// The maximum available value
        /// </summary>
        public V Max { get; }

        public override string ToString()
            => $"{Identity} {G.Between} {Min} and {Max}";

        public override int GetHashCode()
            => Min.GetHashCode() & Max.GetHashCode();

        public bool Equals(ChoiceRange<V> other)
            => isNull(other)
            ? false : Identity == other.Identity
            && Equals(Min, other.Min)
            && Equals(Max, other.Max);
    }


}