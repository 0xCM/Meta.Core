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

    using SqlT.Core;
    using SqlT.Services;
    using SqlT.SqlDocs.Proxies;

    using static metacore;


    class SqlDocStore : NodeService<SqlDocStore, ISqlDocStore>, ISqlDocStore
    {

        ISqlDocsNavigator Navigator { get; }

        ISqlProxyBroker SqlDocsBroker { get; }
        

        public SqlDocStore(INodeContext C)
            : base(C)
        {
            Navigator = C.SqlDocsNavigator();
            SqlDocsBroker = C.SqlDocsBroker();

        }

        MarkdownFileInfo DescribeFile(SqlMarkdownDocument s, string Segment)
            => new MarkdownFileInfo
                         (
                             SegmentName: Segment,
                             FileLocation: s.DocPath.RelativeTo(Navigator.RootFolder),
                             DocumentTitle: s.Title,
                             ModifiedDate: s.ModifiedDate.Map(v => (Date?)v, () => null),
                             FileSize: s.FileSize
                         );

        public Option<int> SyncSyntaxBlocks(IEnumerable<SqlMarkdownDocument> documents)
        {
            var syntaxBlocks = list(from d in documents
                                    from s in d.SyntaxBlocks
                                    select new SqlSyntaxBlock
                                    (
                                        SegmentName: d.Segment,
                                        DocumentTitle: d.Title,
                                        SyntaxPosition: s.LineNumber,
                                        SyntaxContent: s.Text
                                    ));

            return SqlDocsBroker.Call(new SyncSyntaxBlocks(syntaxBlocks));
        }

        public Option<int> SyncHeadings(IEnumerable<SqlMarkdownDocument> documents)
        {
            var headings = list(from d in documents
                                from s in d.SectionHeadings
                                select (d.Title, s));

            return 0;
        }

        public Option<int> SyncHelpKeywords(IEnumerable<SqlMarkdownDocument> documents)
        {
            var keywords = (from d in documents
                                from kw in d.Descriptor.HelpKeywords
                                    select new MarkdownHelpKeyword
                                    (
                                        SegmentName: d.Segment, 
                                        DocumentTitle: d.Title,
                                         Keyword: kw
                                    )).Distinct().ToList();

            return SqlDocsBroker.Call(new SyncMarkdownHelpKeywords(keywords));
        }

        public Option<int> SyncTables(IEnumerable<SqlMarkdownDocument> documents)
        {
            var tables = rolist(from d in documents
                              from t in d.Tables
                              select t.ToRowset(d.Segment, d.Title));

            return SqlDocsBroker.Call(new SyncMarkdownTables
                (tables.Select(x => x.Table), 
                tables.SelectMany(x => x.Rows))
                );
        }

        public Option<int> SyncDescriptions(IEnumerable<SqlMarkdownDocument> documents)
        {

            var root = Navigator.RootFolder;
            var calls = from d in documents
                        group d by d.DocPath.Folder.FolderName into segments
                        let descriptions = map(segments, s => DescribeFile(s, segments.Key))
                        select new SyncMarkdownFiles(segments.Key, descriptions);
            var results = map(calls, c => SqlDocsBroker.Exec(c).OnNone(Notify));
            return results.FirstOrDefault();
                                                                                    
        }

        public Option<int> SyncSampleScripts()
             => (from result in map(
                 from loaded in Navigator.SampleScripts.Select(f => f.LoadTextFile()).Split().Right
                    group loaded by loaded.SegmentName into segments
                    let call = new SyncSampleScripts(segments.Key, segments.ToReadOnlyList())
                    select call, call => SqlDocsBroker.Exec(call))
                 select result).Condense();
                   
                
                
        

        public Option<int> SyncDocumentContent(IEnumerable<SqlMarkdownDocument> documents)
        {
            var calls = from doc in documents
                          group doc by doc.DocPath.Folder.FolderName into segments
                          let descriptions = map(segments, s => (s,DescribeFile(s, segments.Key)))
                          let contents = map(descriptions, d => new MarkdownFileContent
                            (
                              SegmentName: segments.Key,
                              FileLocation: d.Item2.FileLocation,
                              DocumentTitle: d.Item2.DocumentTitle,
                              ModifiedDate: d.Item2.ModifiedDate,
                              FileSize: d.Item2.FileSize,
                              FileContent: d.s.FileContent                              
                            ))
                          select new SyncMarkdownFileContent(segments.Key, contents);
            var results = map(calls, c => SqlDocsBroker.Call(c));
            return results.FirstOrDefault();
        }
    }
}