//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
    public static class MemberAssociationSetBuilder
    {
        public static MemberAssociationSetBuilder<S, T> Build<S, T>()
            => new MemberAssociationSetBuilder<S, T>();
    }

    public class MemberAssociationSetBuilder<S, T>
    {
        public static implicit operator MemberAssociationSet<S, T>(MemberAssociationSetBuilder<S, T> builder)
            => builder.Complete();

        MutableSet<MemberAssociation> Associations { get; } 
            = new MutableSet<MemberAssociation>();


        public MemberAssociationSetBuilder<S, T> Associate(Expression<Func<S, object>> s, Expression<Func<T, object>> t)
        {
            Associations.Add(MemberAssociation.Associate(s, t));
            return this;
        }

        public MemberAssociationSetBuilder<S, T> Associate(params
            (Expression<Func<S, object>> SourceMember, Expression<Func<T, object>> TargetMember)[] pairs)
        {
            foreach (var association in pairs.Select(p => MemberAssociation.Associate(p.SourceMember, p.TargetMember)))
                Associations.Add(association);
            return this;
        }

        public MemberAssociationSet<S, T> Complete()
            => new MemberAssociationSet<S, T>(Associations);


    }

}