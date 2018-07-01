//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using static minicore;

    /// <summary>
    /// Defines a directed association between two value members
    /// </summary>
    public class MemberAssociation
    {
        public static MemberAssociation<S, T> Associate<S, T>(Expression<Func<S, object>> s, Expression<Func<T, object>> t)
            => new MemberAssociation<S, T>(s.GetValueMember(), t.GetValueMember());

        public MemberAssociation(ValueMember s, ValueMember t)
        {
            SourceMember = s;
            TargetMember = t;
        }

        /// <summary>
        /// The supplier member
        /// </summary>
        public ValueMember SourceMember { get; }

        /// <summary>
        /// The client member
        /// </summary>
        public ValueMember TargetMember { get; }

        public override string ToString()
            => concat($"{(Domain: SourceMember.ValueType.Name, Range: TargetMember.ValueType.Name)}",
                    "=>", $"{(SourceMember.Name, Range: TargetMember.Name)}");
    }

    /// <summary>
    /// Defines a directed association between two value members defined by two respective types
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    public sealed class MemberAssociation<X, Y> : MemberAssociation
    {

        public MemberAssociation(ValueMember s, ValueMember t)
            : base(s, t)
        {
        }
    }
}