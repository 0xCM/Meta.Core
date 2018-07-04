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


    public sealed class DocumentText : SqlDocPartContent<DocumentText, DocTextPart>
    {
        IList<string> segments { get; }
            = new List<string>();

        public DocumentText()
            : this(string.Empty)
        {

        }


        public DocumentText(string Text)
            : base(Text)
        { }


        public void AddSegment(string segment)
            => segments.Add(segment);

        public IEnumerable<string> Segments
            => segments;

    }

}