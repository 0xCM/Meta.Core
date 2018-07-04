//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Testing
{
    using System;
    using System.Reflection;

    using static metacore;

    public interface ITestResult
    {
        /// <summary>
        /// Specifies the test name
        /// </summary>
        string TestName { get; }

        /// <summary>
        /// Specifies the invariant
        /// </summary>
        object Expect { get; }

        /// <summary>
        /// Specifies the computation result
        /// </summary>
        object Actual { get; }

        /// <summary>
        /// Specifies whether result of the computation satisfied the invariant
        /// </summary>
        bool Succeeded { get; }

        /// <summary>
        /// Describes the outcome of the test
        /// </summary>
        IApplicationMessage Description { get; }
    }

    public interface ITestResult<T> : ITestResult
    {

        new T Expect { get; }

        new T Actual { get; }

    }

    
    public class TestResult<T> : ITestResult<T>
    {
        public static TestResult<T> Define(string TestName, T Expect, T Actual)
            => new TestResult<T>(TestName, Actual, Expect);

        public TestResult(string TestName, T Expect, T Actual)
        {
            this.TestName = TestName;
            this.Expect = Expect;
            this.Actual = Actual;
        }

        public string TestName { get; }

        public T Expect { get; }

        public T Actual { get; }

        public virtual bool Succeeded
            => object.Equals(Expect, Actual);

        object ITestResult.Expect
            => Expect;

        object ITestResult.Actual
            => Actual;

        public IApplicationMessage Description
            => Succeeded
            ? inform($"{TestName} succeeded") :
              error($"{TestName} failed: {Expect} <> {Actual}");

        public override string ToString()
            => Description.Format(false);

    }

}