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

    using Markdig;
    using Markdig.Extensions.Tables;
    using Markdig.Syntax;
    using Markdig.Syntax.Inlines;
    using Markdig.Extensions.AutoIdentifiers;
    using Markdig.Helpers;

    using static metacore;


    class InterpretationController : ApplicationComponent
    {

        IMarkdownInterpreter CurrentInterpreter { get; set; }

        IMarkdownInterpreter DefaultInterpreter { get; }


        public InterpretationController(IApplicationContext C, FilePath DocPath)
            : base(C)
        {
        
            this.Interpretation = new SqlMarkdownDocument(DocPath);            
            this.DefaultInterpreter = new DefaultInterpreter();
            this.CurrentInterpreter = DefaultInterpreter;
        }

        public InterpretationController(IApplicationContext C, SqlMarkdownDocument Document)
            : base(C)
        {

            this.Interpretation = Document;
            this.DefaultInterpreter = new DefaultInterpreter();
            this.CurrentInterpreter = DefaultInterpreter;
        }

        public InterpretationController(IApplicationContext C, RepositoryFile File)
            : base(C)
        {

            this.Interpretation = new SqlMarkdownDocument(File.AbsolutePath);
            this.DefaultInterpreter = new DefaultInterpreter();
            this.CurrentInterpreter = DefaultInterpreter;
        }

        bool ExpectSyntaxBlock = false;
        bool ExpectArgumentBlock = false;
        int ThematicBreakCount = 0;
        
     
        public SqlMarkdownDocument Interpretation { get; } 
            

        static string JoinLines(IEnumerable<StringLine> lines)
            => trim(string.Join(eol(), lines.ToArray()));


        IMarkdownInterpreter SelectInterpreter(FencedCodeBlock block)
        {
            if (ExpectSyntaxBlock)
            {                
                var text = JoinLines(block.Lines.Lines);
                Interpretation.SyntaxBlocks.Add(new SyntaxDefinition(text, block.Line));
                ExpectSyntaxBlock = false;
            }
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(Table syntax)
        {
            var content = new DocumentTable();
            Interpretation.Tables.Add(content);
            return new TableInterpreter(content);
        }

        IMarkdownInterpreter SelectInterpreter(LiteralInline syntax)
        {
            var text = syntax.Content.ToString();

            return CurrentInterpreter;
        }

        
        IMarkdownInterpreter SelectInterpreter(ThematicBreakBlock syntax)
        {        
            ThematicBreakCount++;

            if (ThematicBreakCount == 1)
                return new HeaderInterpreter(Interpretation.Descriptor);
            else if (ThematicBreakCount == 2)
                return DefaultInterpreter;
            else
                return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(ContainerInline syntax)
        {
            foreach (var item in syntax)
                ApplyCurrent(item);

            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(ParagraphBlock syntax)
        {
            if (syntax.Inline != null)
                ApplyCurrent(syntax.Inline);

            return CurrentInterpreter;

        }

        IMarkdownInterpreter SelectInterpreter(ListItemBlock syntax)
        {
            foreach (var item in syntax)
                ApplyCurrent(item);
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(ListBlock syntax)
        {
            foreach (var item in syntax)
                ApplyCurrent(item);
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(HeadingBlock syntax)
        {
            var headerText = ifNotNull(syntax.Inline, 
                il =>  trim(string.Join(" ", il.Select(x => x.ToString()))),
                    () => string.Empty);

            if (isNotBlank(headerText))
                Interpretation.AddHeading(new SectionHeading(headerText, syntax.Line, syntax.Level));

            if (isNotBlank(headerText) && syntax.Level == 2)
            {               
                ExpectSyntaxBlock = headerText == "Syntax";
                ExpectArgumentBlock = headerText == "Arguments";
            }
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(LinkInline syntax)
        {
            
            return CurrentInterpreter;

        }

        IMarkdownInterpreter SelectInterpreter(LineBreakInline syntax)
        {
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(HeadingLinkReferenceDefinition syntax)
        {
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(LinkReferenceDefinitionGroup syntax)
        {
            foreach (var item in syntax)
                ApplyCurrent(item);

            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(LinkReferenceDefinition syntax)
        {
            return CurrentInterpreter;
        }

        IMarkdownInterpreter SelectInterpreter(object o)
        {
            return CurrentInterpreter;
        }

        IMarkdownInterpreter NextInterpreter(IMarkdownObject syntax)
                => SelectInterpreter((dynamic)syntax);

        void ApplyCurrent(IMarkdownObject syntax)
        {
            try
            {
                CurrentInterpreter.DefineContent(syntax);
            }
            catch(Exception e)
            {
                Notify(error(e));
            }
        }


        public void Interpret(IMarkdownObject syntax)
        {
            CurrentInterpreter = NextInterpreter(syntax);
            CurrentInterpreter.DefineContent(syntax);
        }

    }


}
