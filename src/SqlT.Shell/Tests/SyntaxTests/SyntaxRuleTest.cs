//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Meta.Syntax;

    using static metacore;

    public abstract class TestCase
    {
        protected TestCase(string TestName, bool Passed)
        {
            this.Passed = Passed;
            this.TestName = TestName;

        }
        /// <summary>
        /// The name of the test
        /// </summary>
        public string TestName { get; }

        /// <summary>
        /// Whether to test succeeded
        /// </summary>
        public bool Passed { get; }

    }

    public class SyntaxRuleTest : TestCase
    {

        public SyntaxRuleTest(SyntaxRule TestedRule, string Evaluation, string Expectation, bool Passed, [CallerMemberName] string  TestName = null)
            : base(TestName,Passed)
        {

            this.TestedRule = TestedRule;
            this.Evaluation = Evaluation;
            this.Expectation = Expectation;


        }

        /// <summary>
        /// The rule under test
        /// </summary>
        public SyntaxRule TestedRule { get; }

        /// <summary>
        /// The rule evaluation result
        /// </summary>
        public string Evaluation { get; }

        /// <summary>
        /// The expected evaluation
        /// </summary>
        public string Expectation { get; }


        public override string ToString()
           => Passed ?
            $"{TestName} Succes: {Evaluation}"
          : $"{TestName} Failure: {Evaluation} <> {Expectation}";
    }



}