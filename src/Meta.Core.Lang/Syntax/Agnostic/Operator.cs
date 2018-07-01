//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;

    using static metacore;
    
    public abstract class Operator<r> : Model<r>, IOperator
        where r : Operator<r>
    {

        protected static readonly r instance;

        static Operator()
        {
            instance = ~
                from ctor in typeof(r).TryGetDefaultPrivateConstructor()
                let v = (r)ctor.Invoke(array<object>())
                select v;
        }

        public static r get()
            => instance;

        public static implicit operator string(Operator<r> op)
            => op.Symbol;

        protected Operator(OperatorName name, string symbol = null)
        {
            this.Name = name;
            this.Symbol = symbol ?? name.Identifier;
        }

        public OperatorName Name { get; }

        public string Symbol { get; }

        public override string ToString()
            => Symbol;
    }

    public abstract class Operator<r,v> : Operator<r>
        where r : Operator<r,v>
    {
        public static implicit operator string(Operator<r,v> op)
            => op.Symbol;

        protected Operator(OperatorName name, string symbol = null)
            : base(name, symbol)
        {
        }
    }

    public interface IBooleanOperator : IOperator { }

    public interface IBitwiseOperator : IOperator { }

    public interface ILogicalOperator : IBooleanOperator
    {
        IKeyword Designator { get; }
    }

    public interface IBinaryOperator : IOperator { }

    public interface IAssignmentOperator : IOperator { }

    public interface IArithmeticOperator : IBinaryOperator { }

    public interface IComparisonOperator : IBinaryOperator, IBooleanOperator { }

    public interface ITernaryOperator : IOperator { }

    public interface IUnaryOperator : IOperator { }

}