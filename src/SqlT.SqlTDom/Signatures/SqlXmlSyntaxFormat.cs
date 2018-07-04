//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;


    public class SqlXmlSyntaxFormat
    {
        public SqlXmlSyntaxFormat(SqlScript SourceScript, string XmlSyntax)
        {
            this.SourceScript = SourceScript;
            this.XmlSyntax = XmlSyntax;
        }

        public SqlScript SourceScript { get; }

        public string XmlSyntax { get; }

        public override string ToString()
            => XmlSyntax;
    }


}