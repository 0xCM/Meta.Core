//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Tests
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Meta.Core;
    using Meta.Core.Workflow;
    using Meta.Core.Testing;

    using SqlT.CSharp;
    using static metacore;
    using static sql;

    public class CsGenTestResult : TestResult<string>
    {
        public CsGenTestResult(string TestName, string Expect, string Actual)
            : base(TestName, Expect, Actual)
        {

        }

        public override bool Succeeded
            => equals(Expect, Actual);
    }


    [WorkflowNode]
    public class CsGenerationTests : WorkflowNode<CsGenTestResult>
    {
        CsGenTestResult result(string expect, string actual, [CallerMemberName] string method = null)
            => new CsGenTestResult(GetType().Uri().WithAppendedPathComponts(method), expect, actual);


        ICSharpSnippetGenerator Snippets { get; }

        public CsGenerationTests(IWorkflowContext C)
            : base(C)
        {
            this.Snippets = C.CSharpSnippetGenerator();   
        }


        public WorkFlowed<CsGenTestResult> Test01()
        {
            var spec = typespec.subclass("A", "B");
            var code = Snippets.GenerateClass(spec);


            return result("", "");
        }

        public WorkFlowed<CsGenTestResult> Test02()
        {
            var spec = typespec.subclose("A", "B", "X1", "X2");
            var code = Snippets.GenerateClass(spec);


            return result("", "");
        }




        static Func<Option<A>,Option<B>> F<A,B>(Func<A,B> f)
        {
            Func<Option<A>, Option<B>> F = x => x.Map(a =>  f(a));
            return F;
        }



        public WorkFlowed<CsGenTestResult> Test03()
        {
            var spec = typespec.poco("MyPoco", ("PropA", "string"), ("PropB", "int"));
            var code = Snippets.GenerateClass(spec);


            return result("", "");
        }

    }

}