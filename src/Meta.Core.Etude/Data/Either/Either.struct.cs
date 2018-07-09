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

    /// <summary>
    /// A value that realizes exactly one of two alternatives, 
    /// named "left" and "right"
    /// </summary>
    /// <typeparam name="L">The type of the left alternative</typeparam>
    /// <typeparam name="R">The type of the right alternative</typeparam>
    public readonly struct Either<L, R> : IEither<L,R>, IEquatable<Either<L, R>>
    {
        public static implicit operator Either<L,R>(L left)
            => new Either<L, R>(left);

        public static implicit operator Either<L, R>(R right)
            => new Either<L, R>(right);

        public static bool operator ==(Either<L, R> x, Either<L, R> y)
            => x.Equals(y);

        public static bool operator !=(Either<L, R> x, Either<L, R> y)
            => not(x.Equals(y));

        /// <summary>
        /// Constructs a left-valued alternative
        /// </summary>
        /// <param name="left">The alternative value</param>
        public Either(L left)
        {
            this.Left = left;
            this.Selected = Case.Left;
            this.Right = default;
        }

        /// <summary>
        /// Constructs a right-valued alternative
        /// </summary>
        /// <param name="right">The alternative value</param>
        public Either(R right)
        {
            this.Right = right;
            this.Selected = Case.Right;
            this.Left = default;
        }

        enum Case { Left, Right }


        /// <summary>
        /// Tracks the chosen alternative
        /// </summary>
        Case Selected { get; }

        /// <summary>
        /// Specifies the left alternative
        /// </summary>
        public L Left { get; }

        /// <summary>
        /// Specivies the right alternative
        /// </summary>
        public R Right { get; }

        /// <summary>
        /// Indicates whether the left alternative is specified
        /// </summary>
        public bool IsLeft
            => Selected == Case.Left;

        /// <summary>
        /// Indicates whether the right alternative is specified
        /// </summary>
        public bool IsRight
            => Selected == Case.Right;

        public Cardinality Cardinality => throw new NotImplementedException();

        /// <summary>
        /// Invokes an action if the alternative is left-valued
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Either<L, R> OnLeft(Action<L> action)
        {
            if (Selected == Case.Left)
                action(Left);
            return this;
        }
    
        /// <summary>
        /// Invokes an action if the alternative is right values
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Either<L, R> OnRight(Action<R> action)
        {
            if (Selected == Case.Right)
                action(Right);
            return this;
        }

        /// <summary>
        /// Invokes exactly one of two alternative actions
        /// </summary>
        /// <param name="left">The action to invoke when the altenative is left-valued</param>
        /// <param name="right">The action to invoke when the altenative is right-valued</param>
        public void OnValue(Action<L> left, Action<R> right)
            => OnLeft(left).OnRight(right);

        /// <summary>
        /// Applies exactly one of two transformations
        /// </summary>
        /// <typeparam name="Y">The type of the output value</typeparam>
        /// <param name="ifLeft">The transformation to invoke when the alternative is left-valued</param>
        /// <param name="ifRight">The transformation to invoke when the alternative is right-valued</param>
        /// <returns></returns>
        public Y Apply<Y>(Func<L, Y> ifLeft, Func<R, Y> ifRight)
            => IsLeft ? ifLeft(Left) : ifRight(Right);

        /// <summary>
        /// Adjudicates structural equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Either<L, R> other)
        {
            if (IsLeft && other.IsLeft)
                return Equals(Left, other.Left);
            else if (IsRight && other.IsRight)
                return Equals(Right, other.Right);
            else
                return false;
        }

        public override string ToString()
            => Apply(left => $"Left({left})",
                        right => $"Right({right})");

        public override int GetHashCode()
            => IsLeft ? Left.GetHashCode() 
                : Right.GetHashCode();

        public override bool Equals(object obj)
            => obj is Either<L, R> 
            ? Equals((Either<L, R>)obj) : false;

        Seq<L> LContained()
            => IsLeft ? Seq.singleton(Left) : Seq.zero<L>();

        Seq<R> RContained()
            => IsRight ? Seq.singleton(Right) : Seq.zero<R>();
    }
}