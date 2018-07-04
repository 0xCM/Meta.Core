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
    using System.Text;

    using static metacore;



    public sealed class SyntaxDefinition : SqlDocPartContent<SyntaxDefinition, SyntaxPart>
    {
        public SyntaxDefinition()
            : base(string.Empty)
        {


        }

        public SyntaxDefinition(string Text, int LineNumber)
            : base(Text, LineNumber)
        {
            
        }



        public override string ToString()
            => Text;



    }
}