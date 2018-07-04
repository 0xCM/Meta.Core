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
    using SqlT.Services;

    using Config = SqlT.SqlDocs.Proxies.Configuration;
    using FX = CommonFileExtensions;
        
    using static metacore;


    class SqlDocsNavigator : NodeService<SqlDocsNavigator,ISqlDocsNavigator>, ISqlDocsNavigator
    {

        IFileRepository FileRepository { get; }
        

        public SqlDocsNavigator(INodeContext C)
            : base(C)
        {

            var config = C.SqlDocsConfig();
            this.FileRepository = new FileRepository(C,
                   RootLocation: new NodeFolderPath(Host, config.RepositoryLocation) + FolderName.Parse("docs"),
                   SupportedExtensions: roitems(FX.Markdown, FX.Sql),
                   TopFolderNames: split(config.SelectedSections, ';').Select(FolderName.Parse)
                   );


        }

        public NodeFolderPath RootFolder
            => FileRepository.RootLocation;

        public IEnumerable<NodeFilePath> MarkdownDocuments
            => FileRepository.Navigator.Files.Where(f => f.Extension == FX.Markdown);

        public IEnumerable<NodeFilePath> SampleScripts
            => FileRepository.Navigator.Files.Where(f => f.Extension == FX.Sql);


    }


}