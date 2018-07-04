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

    using SqlT.Core;

    using static metacore;
    using SqlT.SqlDocs.Proxies;


    public interface ISqlDocStore 
    {
       Option<int> SyncDescriptions(IEnumerable<SqlMarkdownDocument> documents);

        Option<int> SyncTables(IEnumerable<SqlMarkdownDocument> documents);

        Option<int> SyncHeadings(IEnumerable<SqlMarkdownDocument> documents);

        Option<int> SyncSyntaxBlocks(IEnumerable<SqlMarkdownDocument> documents);

        Option<int> SyncHelpKeywords(IEnumerable<SqlMarkdownDocument> documents);
        Option<int> SyncDocumentContent(IEnumerable<SqlMarkdownDocument> documents);
        Option<int> SyncSampleScripts();
    }


}