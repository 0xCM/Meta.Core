//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Modules;
    using static minicore;

    /// <summary>
    /// Defines a collection of <see cref="MemberAssociation"/> values directed 
    /// from <typeparamref name="S"/> to <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    public sealed class MemberAssociationSet<S, T> : IEnumerable<MemberAssociation>
    {
        IReadOnlySet<MemberAssociation> Associations { get; }

        public MemberAssociationSet(IEnumerable<MemberAssociation> associations)
            => Associations = roset(associations);

        public IEnumerator<MemberAssociation> GetEnumerator()
            => Associations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Associations.GetEnumerator();
    }



}