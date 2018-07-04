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

    using Markdig;
    using Markdig.Syntax;

    using Meta.Core;

    using static metacore;


    public interface ISqlDocsNavigator : INodeService
    {
        NodeFolderPath RootFolder { get; }

        IEnumerable<NodeFilePath> MarkdownDocuments { get; }
        IEnumerable<NodeFilePath> SampleScripts { get; }


    }


}