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
    using Markdig.Extensions.Tables;
    using Markdig.Syntax.Inlines;

    sealed class TableInterpreter : SqlDocInterpreter<TablePart, DocumentTable, Table>
    {
        public TableInterpreter(DocumentTable Content)
            : base(Content)
        { }


        public override void DefineContent(Table syntax)
        {
            Content.TablePosition = syntax.Line;
            var rowidx = 0;
            foreach (var row in syntax)
            {
                rowidx++;
                var colidx = 0;
                foreach (var cell in row.Descendants().OfType<TableCell>())
                {
                    colidx++;

                    var value = string.Empty;
                    foreach (var inline in cell.Descendants().OfType<LiteralInline>())
                        value += inline.Content.ToString();

                   Content[rowidx, colidx] = value;
                }
            }
            
        }
    }


}