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

    public class SqlDocParts : TypedItemList<SqlDocParts, SqlDocPart>
    {
        public static readonly SqlDocPart Syntax = new SyntaxPart();
        public static readonly SqlDocPart Arguments = new ArgumentsPart();
        public static readonly SqlDocPart Header = new DocDescriptorPart();
        public static readonly SqlDocPart Table = new TablePart();
        public static readonly SqlDocPart TableRow = new TableRowPart();
        public static readonly SqlDocPart DocumentText = new DocTextPart();
        public static readonly SqlDocPart SectionHeading = new SectionHeadingPart();


        public static IEnumerable<P> Parts<P>()
            where P : SqlDocPart
                => (new SqlDocParts()).OfType<P>();

        public static P Part<P>()
            where P : SqlDocPart
                => Parts<P>().Single();
                

    }

}