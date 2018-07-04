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

    using Meta.Core;

    public class SqlMarkdownDocument
    {       
        public SqlMarkdownDocument(FilePath DocPath)
        {
            this.DocPath = DocPath;
            this.FileSize = DocPath.FileSize ?? -1;
            this.FileContent = DocPath.ReadAllText();
            this.Descriptor = new DocumentDescriptor { Segment = DocPath.Folder.FolderName };
        }

        public FilePath DocPath { get; }

        public long FileSize { get; }

        public string FileContent { get; }

        public string Title
            => Descriptor.Title ?? DocPath;

        public string Segment
            => Descriptor.Segment;

        public DocumentDescriptor Descriptor { get; }

        MutableList<SectionHeading> _SectionHeadings { get; }
            = MutableList.Create<SectionHeading>();

        public IEnumerable<SectionHeading> SectionHeadings
            => _SectionHeadings;

        public void AddHeading(SectionHeading heading)
            => _SectionHeadings.Add(heading);

        public Option<Date> ModifiedDate
            => Descriptor.ModifiedDate;        

        public MutableList<DocumentTable> Tables { get; } 
            = MutableList.Create<DocumentTable>();

        public MutableList<SyntaxDefinition> SyntaxBlocks { get; } 
            = MutableList.Create<SyntaxDefinition>();

        public override string ToString()
            => DocPath;
    }
}
