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
    using System.Text;
    using System.IO;
    using System.Runtime.CompilerServices;

    using Meta.Core;
    using Meta.Core.Workflow;
    using Meta.Core.Testing;

    using Meta.Syntax;
    using Meta.Models;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.CSharp;
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.SqlTDom;
    using SqlT.Dom;

    using static ClrStructureSpec;
    using static metacore;
    using static sql;

    using sxc = SqlT.Syntax.contracts;
    using sx = SqlT.Syntax.SqlSyntax;


    [WorkflowNode]
    public class SqlGenerationTests : WorkflowNode<SqlGenTestResult>
    {

        new T Print<T>(T result)
            where T : ITestResult
        {
            Notify(result.Description);
            return result;
        }

        public SqlGenerationTests(IWorkflowContext C)
            : base(C)
        {


        }

        ISqlGenerator SqlGenerator
            => C.SqlGenerator();

        ISqlProxyBroker SyntaxBroker
            => SqlTSyntaxProxies.Instance.DefaultBroker().Require();

        SqlModelScript gen(IModel model)
            => SqlGenerator.GenerateScript(model);

        public WorkFlowed<SqlModelScript> Gen01()
        {
            var model = new SqlSequence("[S01].[Sequence01]", SqlNativeTypes.sqlint.Reference());
            var sql = SqlGenerator.GenerateScript(model);            
            return sql;           
        }


        SqlGenTestResult result(string expect, string actual, [CallerMemberName] string method = null)
            => new SqlGenTestResult(GetType().Uri().WithAppendedPathComponts(method), expect, actual);
            

        public WorkFlowed<SqlModelScript> Gen02()
        {
            var model = left(sqlvar(@"Var1"), 5);
            var script = gen(model);
            return script;
        }

        public WorkFlowed<SqlGenTestResult> SelectClause01()
        {
            var model = select(new sx.select_expression(left(L("12345648"), 5), "left_value",true));
            var script = gen(model);
            var expect = "12345";
            var actual = SyntaxBroker.SelectColumn<string>(script.ScriptText).Single();
            return  Print(result(expect, actual));
        }

    }



    public class SqlGenTestResult : TestResult<string>
    {
        public SqlGenTestResult(string TestName, string Expect, string Actual)    
            : base(TestName, Expect, Actual)
        {

        }

        public override bool Succeeded
            => equals(Expect, Actual);
    }
}