//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class MemberPredicate
    {
        public static IMemberPredicate Define(IOperator Operator, MemberInfo Member)
        {
            var OP = Operator.GetType();
            var typedef = typeof(MemberPredicate<>).GetGenericTypeDefinition();
            var type = typedef.MakeGenericType(OP);
            var predicate = Activator.CreateInstance(type, Operator, Member) as IMemberPredicate;
            return predicate;
        }
    }

    /// <summary>
    /// Represents an operation that evaluates a member aspect and returns a boolean result
    /// </summary>
    /// <typeparam name="OP">The type of operator that when applied carries out the evaluation represented by the predicate</typeparam>
    public class MemberPredicate<OP> : PredicateApplication<OP, MemberInfo>, IMemberPredicate
        where OP : Operator<OP>
    {

        public MemberPredicate(OP Operator, MemberInfo Member)
            : base(Operator)
        {
            this.Member = Member;
        }

        public MemberInfo Member { get; }

        protected override IReadOnlyList<object> Operands
            => new object[] { Member };

        MemberInfo IMemberPredicate.Member
            => Member;


        public override string ToString()
            => $"{Operator}({Member.Name})";

    }
}
