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
    using Markdig.Syntax.Inlines;
    using Markdig.Helpers;
    using Markdig.Extensions.Tables;
    

    using static metacore;


    sealed class HeaderInterpreter : BlockInterpreter<DocDescriptorPart, DocumentDescriptor>
    {

        static string trim(string content)
            => metacore.trim(content, '\"');

        string AttributeName { get; set; }
            = string.Empty;

        IList<string> AttributeValue { get; set; }
            = new List<string>();




        void InterpretSyntax(HtmlEntityInline syntax)
        {
            AttributeValue.Add(syntax.Transcoded.ToString());
        }


        void InterpretSyntax(LiteralInline syntax)
        {
            var content = trim(syntax.Content.ToString());
            if (isBlank(content))
                return;

            if (content.Contains(':'))
            {
                var parts = split(content, ':');
                if(parts.Count >= 1)
                    AttributeName = trim(parts[0]);
                if(parts.Count >= 2)
                    AttributeValue.Add(trim(parts[1]));
                if (parts.Count >= 3)
                    AttributeValue.Add(trim(parts[2]));

            }
            else
            {
                if (isNotBlank(AttributeName))
                    AttributeValue.Add(content);
            }
        }


        IEnumerable<string> FilterHelpKeywords(IEnumerable<string> Candidiates)
            => from c in Candidiates
               where not(c.EndsWith("_TSQL"))
               && c != "_"
               select c;
               


        void InterpretSyntax(ContainerInline syntax)
            => iter(syntax, Interpret);

        void InterpretSyntax(LineBreakInline syntax)
        {
            if (isNotBlank(AttributeName) && AttributeValue.Count != 0)
            {
                if (equals(AttributeName, DocDescriptorPart.AttributeNames.keywords))
                    iter(FilterHelpKeywords(AttributeValue), kw => Content.AddHelpKeyword(kw));
                else
                {
                    var attribValue = string.Join(" ", AttributeValue);
                    Content.AddAttribute(AttributeName, attribValue);
                }
            }
            AttributeName = string.Empty;
            AttributeValue = new List<string>();

        }

        void InterpretSyntax(PipeTableDelimiterInline syntax)
            => iter(syntax, Interpret);


        void InterpretSyntax(ParagraphBlock syntax)
        {
            if (syntax.Inline != null)
                Interpret(syntax.Inline);
        }

        void InterpretSyntax(ListItemBlock syntax)
        {
            foreach (var item in syntax)
                Interpret(item);
        }

        void InterpretSyntax(ThematicBreakBlock syntax)
        {
            
        }


        void Interpret(IMarkdownObject syntax)
        {
            InterpretSyntax((dynamic)syntax);
        }

        public HeaderInterpreter(DocumentDescriptor Value)
            : base(Value)
        { }


        public override void DefineContent(IMarkdownObject syntax)
        {
            Interpret(syntax);

        }
    }


}