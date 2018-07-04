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

    using static metacore;
    using static ClrStructureSpec;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.CSharp;
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.SqlTDom;
    using SqlT.Dom;
    
    using Meta.Core;
    using Meta.Core.Workflow;


    [WorkflowNode]
    public class SyntaxTests : WorkflowNode<SyntaxTestResult>
    {

        WorkFlowed<SqlScript> script(string sql, [CallerMemberName] string caller = null)
            => SqlScript.Create($"{GetType().Name}/{caller}", sql);

        ISqlXmlSyntaxFormatter XmlSyntaxFormatter
            => C.SqlXmlSyntaxFormatter();

        ISqlDomRepository DomRepository
            => C.SqlDomRepository();


        WorkFlowed<SyntaxTestResult> SaveXmlSyntax(SyntaxTestResult result)
        {
            var saved = result.XmlSyntax.Map(xml => DomRepository.SaveXmlSyntax(stream(new SqlXmlSyntaxFormat(result.ReferenceSql, xml))));
            saved.OnNone(Notify);
            return result;
        }                

        public SyntaxTests(IWorkflowContext C)
            : base(C)
        {

                           
        }

        public WorkFlowed<SyntaxTestResult> Distinct01()
            => from sql in script("select distict Col01, Col02 from [Schema01].[Table01]")
               let xml = XmlSyntaxFormatter.FormatXmlSyntax(sql).Map(x => x.XmlSyntax)
               let result = new SyntaxTestResult(caller(), sql, xml, xml.IsSome())
               from saved in SaveXmlSyntax(result)
               select saved;

        public WorkFlowed<SyntaxTestResult> GroupBy01()
            => from sql in script("select Col01, Col02 from [Schema01].[Table01] group by Col01, Col02")
               let xml = XmlSyntaxFormatter.FormatXmlSyntax(sql).Map(x => x.XmlSyntax)
               let result = new SyntaxTestResult(caller(), sql, xml, xml.IsSome())
               from saved in SaveXmlSyntax(result)
               select saved;

        public WorkFlowed<SyntaxTestResult> OrderBy01()
            => from sql in script("select Col01, Col02 from [Schema01].[Table01] order by Col01, Col02")
               let xml = XmlSyntaxFormatter.FormatXmlSyntax(sql).Map(x => x.XmlSyntax)
               let result = new SyntaxTestResult(caller(), sql, xml, xml.IsSome())
               from saved in SaveXmlSyntax(result)
               select saved;



    }


}