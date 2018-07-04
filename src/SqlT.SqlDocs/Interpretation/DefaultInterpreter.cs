//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Markdig;
    using Markdig.Extensions.Tables;
    using Markdig.Syntax;
    using Markdig.Syntax.Inlines;
    using Markdig.Extensions.AutoIdentifiers;
    using Markdig.Helpers;
   


    sealed class DefaultInterpreter : SqlDocInterpreter<DocTextPart, DocumentText, IMarkdownObject>
    {

        public override void DefineContent(IMarkdownObject Syntax)
        {            
            
        }
    }


}