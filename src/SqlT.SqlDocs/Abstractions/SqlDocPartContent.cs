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

    public abstract class SqlDocPartContent
    {
        protected SqlDocPartContent(SqlDocPart DocPart,  string Text, int LineNumber)
        {
            this.DocPart = DocPart;
            this.Text = Text;
            this.LineNumber = LineNumber;
        }

        public SqlDocPart DocPart { get; }

        public string Text { get; }

        public int LineNumber { get; }

        public override string ToString()
            => Text;
    }

    public abstract class SqlDocPartContent<C,P> : SqlDocPartContent
        where C : SqlDocPartContent<C,P>, new()
        where P : SqlDocPart
    {

        protected SqlDocPartContent(string Text, int LineNumber = 0)
            : base(SqlDocParts.Part<P>(), Text, LineNumber)
        { }
    }

    

}
