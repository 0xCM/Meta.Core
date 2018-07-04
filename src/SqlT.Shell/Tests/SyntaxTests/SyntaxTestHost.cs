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
    using System.Reflection;

    using Meta.Core;
    using Meta.Core.Workflow;

    public abstract class SyntaxTestHost<T> : WorkflowNode<T>
    {
        protected IReadOnlyDictionary<SqlScriptName,SqlParameterizedScript> ScriptIndex { get; }

        public SyntaxTestHost(IWorkflowContext C)
            : base(C)
        {

            ScriptIndex = Assembly.GetExecutingAssembly().LoadSqlResources().ToDictionary(x => x.ScriptName);
        }

        protected ISqlXmlSyntaxFormatter XmlSyntaxFormatter
            => C.SqlXmlSyntaxFormatter();

        protected ISqlDomRepository DomRepository
            => C.SqlDomRepository();

        protected ISqlParser SqlParser
            => C.SqlParser();


        protected WorkFlowed<SqlScript> script(string sql, [CallerMemberName] string caller = null)
            => SqlScript.Create($"{GetType().Name}/{caller}", sql);

        protected WorkFlowed<SyntaxTestResult> SaveXmlSyntax(SyntaxTestResult result)
        {
            var saved = result.XmlSyntax.Map(xml => DomRepository.SaveXmlSyntax(stream(new SqlXmlSyntaxFormat(result.ReferenceSql, xml))));
            saved.OnNone(Notify);
            return result;

        }

        protected SqlParameterizedScript Script(SqlScriptName Name)
            => ScriptIndex[Name];

        protected SqlParameterizedScript Script(Type t = null)
            => Script((t ?? GetType()).Name);
    }
}