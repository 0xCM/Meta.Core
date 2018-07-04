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


  
    abstract class BlockInterpreter<P,C> : MarkdownInterpreter<IMarkdownObject, C>
        where P : SqlDocPart
        where C : SqlDocPartContent, new()
    {

        protected BlockInterpreter()
            : this(new C())
        {
        }

        protected BlockInterpreter(C Content)
            : base(Content)
        {
        }

        protected void InterpretSyntax(object syntax)
        { }
    }


}