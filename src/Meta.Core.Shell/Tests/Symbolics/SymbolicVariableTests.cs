//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core.Workflow;

    using static metacore;


    [WorkflowNode]
    class SymbolicVariableTests  : TestWorkflow<int>
    {
        public SymbolicVariableTests(IWorkflowContext C)
            : base(C)
        {

        }

        public WorkFlowed<int> Test1()
        {
            var x = SymbolicVariable.Define("DevRoot");
            var y = SymbolicVariable.Define("DevAreaRoot");
            var z = x + y;
            var value = z.Evaluate(EnvironmentVariableResolver.Default, CanonicalValueAggregator.GetDefault<string>());
            return 0;
        }

        public WorkFlowed<int> Test2()
        {
            var x = ShellVariable.Define("DevRoot");
            var y = ShellVariable.Define("DevAreaRoot");
            var z = x + y;
            var value = z.Evaluate<string>(EnvironmentVariableResolver.Default, CanonicalValueAggregator.GetDefault<string>());
            return 0;
        }

        public WorkFlowed<int> Test3()
        {

            var var1 = SymbolicVariable.Define("Var1");
            var var2 = SymbolicVariable.Define("Var2");
            var var3 = var1 + var2;
            Notify(inform($"v3= {var3}"));
            return 0;

        }

        public WorkFlowed<int> Test4()
        {
            var var1 = symbolics.var("Var1", 6);
            var var2 = symbolics.var("Var2", "7");
            var var3 = var1 + var2;
            var text = var3.ToString();
            return 0;
        }

        public WorkFlowed<int> Test5()
        {
            var var1 = symbolics.var("Var1", "$(ABC)");
            var var2 = symbolics.var("Var2", "$(DEF)");
            var var3 = (var1 + var2).Rename("Var3");
            var text = var3.ToString();
            return 0;
        }


    }

}