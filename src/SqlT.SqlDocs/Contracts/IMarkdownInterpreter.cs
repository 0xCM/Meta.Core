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
    using static metacore;

    using Markdig.Syntax;

    public interface IMarkdownInterpreter
    {
        void DefineContent(IMarkdownObject Syntax);
    }

    public interface IMarkdownInterpreter<S, C> : IMarkdownInterpreter
       where S : IMarkdownObject
       where C : new()
    {
        void DefineContent(S Syntax);
    }

}