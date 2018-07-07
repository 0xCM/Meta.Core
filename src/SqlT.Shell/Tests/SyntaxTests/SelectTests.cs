//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Tests
{
    using System;
    using System.Linq;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Services;

    using Meta.Core;
    using Meta.Core.Workflow;
    
    [WorkflowNode]
    public class SelectTests : SyntaxTestHost<SyntaxTestResult>

    {

        public SelectTests(IWorkflowContext C)
            : base(C)
        {

            TestCases = GetTestCases();
            
        }

        int Counter = 0;
            

        public Lst<SqlStatementScript> TestCases { get; }


        Seq<SqlStatementScript> GetTestCases()
            => SqlParser.ParseStatements(Script()).OnNone(Notify).Items();

        WorkFlowed<SyntaxTestResult> DefineTest(string sql)
        {
            var flow = from script in wf.value(sql)
                       let xml = XmlSyntaxFormatter.FormatXmlSyntax(sql).Map(x => x.XmlSyntax)
                       let result = new SyntaxTestResult($"{GetType().Name}{++Counter}", sql, xml, xml.IsSome())
                       from saved in SaveXmlSyntax(result)
                       select saved;
            return flow;
        }

        public WorkFlowed<SyntaxTestResult> OverTest()
            => DefineTest("SELECT  SalesYTD = ROW_NUMBER() OVER(PARTITION BY TerritoryName ORDER BY SalesYTD DESC) FROM Sales.vSalesPerson");

        public WorkFlowed<SyntaxTestResult> ExecTest()
            => DefineTest("exec [mySchema].[myProc] @Param1, @Param2, @Param3");


        WorkFlowed<SyntaxTestResult> DefineTest(SqlStatementScript Script)
            => from sql in wf.value(Script)
               let xml = XmlSyntaxFormatter.FormatXmlSyntax(sql.ScriptText).Map(x => x.XmlSyntax)
               let result = new SyntaxTestResult($"{nameof(SelectTests)}{++Counter}", sql.ScriptText, xml, xml.IsSome())
               from saved in SaveXmlSyntax(result)
               select saved;


        public Lst<WorkFlowed<SyntaxTestResult>> DefineTests()
           => from script in TestCases
              select DefineTest(script);
    }
}
