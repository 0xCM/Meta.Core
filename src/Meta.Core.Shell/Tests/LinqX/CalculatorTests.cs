//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;    
    using System.Linq;

    using Meta.Core.Workflow;

    using static metacore;
    using static operators;
        
    public interface ICalculatorTestCase
    {
        string Operator { get; }

        object X { get; }

        object Y { get; }


        Option<object> ComputedValue { get; }

        object ExpectedValue { get; }

    }
    public class CalculatorTestCase<T> : ICalculatorTestCase
    {
        public CalculatorTestCase(T X, T Y, string Operator, T ExpectedValue, T ComputedValue = default)
        {
            this.X = X;
            this.Y = Y;
            this.Operator = Operator;
            this.ComputedValue = ComputedValue;
            this.ExpectedValue = ExpectedValue;
        }

        public T X { get; }

        public T Y { get; }

        public string Operator { get; }

        public T ExpectedValue { get; }

        public Option<T> ComputedValue { get; }

        object ICalculatorTestCase.X
            => X;

        object ICalculatorTestCase.Y
            => Y;

        Option<object> ICalculatorTestCase.ComputedValue
            => ComputedValue;

        object ICalculatorTestCase.ExpectedValue
            => ExpectedValue;

        public bool Succeeded
            => Object.Equals(ExpectedValue, ComputedValue.ValueOrDefault());
    }

    [WorkflowNode]
    public class CalculatorTests : TestWorkflow<Lst<ICalculatorTestCase>>
    {

        static ICalculatorTestCase test<T>(string op, T x, T y, T expect, T actual)
            => new CalculatorTestCase<T>(x, y, op, expect, actual);

        public CalculatorTests(IWorkflowContext C)
            : base(C)
        {

        }

        public WorkFlowed<Lst<ICalculatorTestCase>> Add()
        {
            var t1 = test("+", 3,4, 3+4, add(3, 4));
            var t2 = test("+", 3.14m, 4.14m, 3.14m + 4.14m, add(3.14m, 4.14m));

            var integers = range(50, 500000);
            var decimals = range(1.0m, 100.0m);
            var doubles = range(1.0, 250000.0);

            return list(t1, t2);

        }


    }


}