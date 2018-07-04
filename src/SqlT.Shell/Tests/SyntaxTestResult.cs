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

    using SqlT.Core;
    using SqlT.Dom;

    public class SyntaxTestResult
    {

        public SyntaxTestResult(string TestName, SqlScript ReferenceSql, Option<string> XmlSyntax,  bool Succeeded)
        {
            this.TestName = TestName;
            this.ReferenceSql = ReferenceSql.IsNamed ? ReferenceSql : ReferenceSql.Rename(TestName);
            this.Succeeded = Succeeded;
            this.XmlSyntax = XmlSyntax;
        }

        public string TestName { get; }

        public SqlScript ReferenceSql { get; }

        public Option<string> XmlSyntax { get; }

        public bool Succeeded { get; }

        const string SuccessLabel = "Succeeded";

        const string FailureLabel = "Failed";

        public override string ToString()
            => $"{TestName}: {(Succeeded ? SuccessLabel : FailureLabel)}";

    }



}