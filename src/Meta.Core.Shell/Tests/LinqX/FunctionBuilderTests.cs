//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    
    using Meta.Core.Test;
    using Meta.Core.Workflow;

    using static metacore;
    using static express;


    [WorkflowNode]                            
    public class FunctionBuilderTests : TestWorkflow<FunctionBuilderTests.TestResult>
    {
        public class TestResult
        {

        }
        
        public WorkFlowed<TestResult> Iconify()
        {
            //var data = http.get(uri("http://json.schemastore.org/tsconfig"));

            var content = files.folder(@"C:\Dev\Areas\Labs\NodeExec");
            var icon = FilePath.Parse(@"C:\Dev\Assets\icons\Selected\Annotate_Disabled.ico");
            var result = files.iconify(content, icon, "New Tooltip").OnNone(Notify);
            var linkPath = CommonFolders.DevTemp + FolderName.Parse("Test2");
            files.link(linkPath, content)
                    .OnNone(Notify)
                    .OnSome(link => files.iconify(link.Link, icon));
            return new TestResult();
        }


        public FunctionBuilderTests(IWorkflowContext C)
            : base(C)
        {

           
        }

        public enum Choices
        {
            ChoiceA,
            ChoiceB,
            ChoiceC
        }

        public WorkFlowed<TestResult> Test()
        {
            var choice = Choices.ChoiceA;
            var result = Selection<Choices, string>(choice)
                        .When(Choices.ChoiceA, () => "Choice A")
                        .When(Choices.ChoiceB, () => "Choice B")
                        .When(Choices.ChoiceC, () => "Choice C")
                        .Eval();
            return new TestResult();

        }

        public WorkFlowed<TestResult> Test2()
        {
            var value = Guid.NewGuid();
            var result = TypeSwitch<string>(value)
                         .When<Guid>(g => g.ToString())
                         .When<int>(g => g.ToString())
                         .Eval();

            return new TestResult();

        }

        int Method1(int k)
        {
            return k + 5;
        }


        public WorkFlowed<TestResult> Test1()
        {
            var m1 = ClrClass.Get<FunctionBuilderTests>().DeclaredInstanceMethods.Single(m => m.Name == nameof(Method1));
            var result = m1.Func<int, int>(this)(10);

            var f = funcx(() => 5);
            var g = funcx(() => 20);
            var eq = f.Equal(g).Compile()();
            
            
            return new TestResult();

        }

    }
}


