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
    using static metacore;


    
    public class IfElse<X>
    {
        public IfElse(Func<X,bool> Predicate)
            => this.Predicate = Predicate;

        public Func<X,bool> Predicate { get; }

        public WorkFlowed<Y> Evaulate<Y>(X x, Func<X, Y> @true, Func<X, Y> @false)
            => Predicate(x) ? @true(x) : @false(x);
    }

    public abstract class LogicalOperator
    {

    }

    public class And<X>
    {
       
        public And(params Func<X, bool>[] Predicates)            
            => this.Predicates = Predicates;

        public ReadOnlyList<Func<X, bool>> Predicates { get; }

    }

    public class And<X,Y>
    {
        public And(Func<X,bool> P1, Func<Y,bool> P2)
        {
            this.P1 = P1;
            this.P2 = P2;
        }

        public Func<X,bool> P1 { get; }

        public Func<Y,bool> P2 { get; }

        
    }


    public class Switch<A1,A2,A3,X,Y>
    {
        public Switch(Func<A1,Func<X,Y>> F1, Func<A2, Func<X, Y>> F2)
        {
            this.F1 = F1;
            this.F2 = F2;
        }
        
        public Func<A1, Func<X, Y>> F1 { get; }

        public Func<A2, Func<X, Y>> F2 { get; }

        public Func<X, Y> Evaluate(A1 value)
            => F1(value);

        public Func<X, Y> Evaluate(A2 value)
            => F2(value);

    }








}