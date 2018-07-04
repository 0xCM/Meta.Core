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

    class SqlDocsServices : ApplicationService<SqlDocsServices, ISqlDocs>, ISqlDocs
    {
        MarkdownPipeline Pipeline { get; }

        public SqlDocsServices(IApplicationContext C)
            : base(C)
        {
            Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

        }

        SqlMarkdownDocument InterpretDocumentContent(FilePath DocPath)
        {
            var doc = new SqlMarkdownDocument(DocPath);
            var interpreter = new InterpretationController(C, doc);
            
            var blocks = Markdown.Parse(doc.FileContent, Pipeline).ToList();
            iteri(blocks, (i,block) 
                => interpreter.Interpret(block));
            return interpreter.Interpretation;

        }

        SqlMarkdownDocument InterpretDocumentContent(RepositoryFile File)
        {
            var doc = new SqlMarkdownDocument(File.AbsolutePath);            
            var blocks = Markdown.Parse(doc.FileContent, Pipeline).ToList();
            var interpreter = new InterpretationController(C, File);
            iteri(blocks, (i, block)
                => interpreter.Interpret(block));
            return interpreter.Interpretation;

        }

        public Option<SqlMarkdownDocument> ParseDocument(RepositoryFile SrcFile)
            => Try(SrcFile, InterpretDocumentContent)
                    .OnNone(Notify);


        public Option<SqlMarkdownDocument> ParseDocument(FilePath SrcFile)
            =>  Try(SrcFile, InterpretDocumentContent)
                    .OnNone(Notify);
                
               
        
    }

}

