//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    using static ClrStructureSpec;
    using static metacore;

    partial class SyntaxBuilders
    {
        public static SyntaxTrivia ToComment(this string text)
            => Comment($"//{text}");

        public static SyntaxTrivia StartDocComment(string type)
            => Comment($"/// <{type}>");

        public static SyntaxTrivia EndDocComment(string type)
            => Comment($"/// </{type}>");

        public static SyntaxTriviaList ToCommentLine(this string text)
            => TriviaList(text.ToComment(), CarriageReturnLineFeed);

        public static SyntaxTriviaList ToComments(this CodeDocumentationSpec doc)
            => doc.Text.ToCommentLine();

        public static SyntaxTriviaList ToComments(this ElementDescription doc)
        {

            if(isBlank(doc.Text))
            {
                return TriviaList();
            }
            else
            {
                var trivia = new List<SyntaxTrivia>();
                trivia.Add(StartDocComment("summary"));
                trivia.Add(CarriageReturnLineFeed);

                using (var reader = new StringReader(doc.Text))
                {
                    var line = reader.ReadLine();
                    while(line != null)
                    {
                        trivia.Add(Comment("/// " + line));
                        trivia.Add(CarriageReturnLineFeed);
                        line = reader.ReadLine();
                    }
                }

                trivia.Add(CarriageReturnLineFeed);
                trivia.Add(EndDocComment("summary"));
                trivia.Add(CarriageReturnLineFeed);
                return TriviaList(trivia.ToArray());
            }            
        }

        public static SyntaxTriviaList ToComments(this CodeFilePreamble doc) 
            => TriviaList(
                map(doc.Lines, line => array(line.ToComment(), CarriageReturnLineFeed)).Reduce()
                );

        public static S WithComments<S>(this S syntax, IClrElementSpec spec)
            where S : MemberDeclarationSyntax
                => spec.Documentation ? syntax.WithLeadingTrivia(spec.Documentation.ValueOrDefault().BuildComments()) : syntax;

        public static CompilationUnitSyntax WithComments(this CompilationUnitSyntax syntax, CodeFileSpec spec)
            => spec.Preamble 
            ? syntax.WithLeadingTrivia(spec.Preamble.ValueOrDefault().BuildComments()) 
            : syntax;

        public static NamespaceDeclarationSyntax WithComments(this NamespaceDeclarationSyntax syntax, NamespaceSpec spec)
            => spec.Documentation.Map(d => syntax.WithLeadingTrivia(d.BuildComments()),() => syntax);

        public static SyntaxTriviaList BuildComments(this CodeDocumentationSpec x)
            => ToComments((dynamic)x);

    }
}
