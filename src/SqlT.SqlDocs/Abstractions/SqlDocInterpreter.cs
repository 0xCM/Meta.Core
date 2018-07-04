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

    abstract class SqlDocInterpreter<P, C, S> : MarkdownInterpreter<S, C>
       where P : SqlDocPart
       where C : SqlDocPartContent, new()
       where S : IMarkdownObject
    {

        protected SqlDocInterpreter()
            : base(new C())
        {


        }

        protected SqlDocInterpreter(C Content)
            : base(Content)
        {


        }

    }



}