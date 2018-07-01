//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    using static metacore;

    partial class BuildSyntax
    {

        public abstract class SyntaxElement
        {
            protected SyntaxElement(ElementDescriptor Descriptor, ISymbolicExpression Content = null)
            {
                this.Descriptor = Descriptor;
                this.Content = Content != null ? some(Content) : none<ISymbolicExpression>();
            }

            public ElementDescriptor Descriptor { get; }

            public string Name
                => Descriptor.Name;

            public string Label
                => Descriptor.Label;

            public int LineNumber
                => Descriptor.Line;

            public Option<ISymbolicExpression> Content { get; }

            public override string ToString()
                => ToXml();

            public virtual string ToXml()
                => concat(
                    $"<{Name} Label={quote(Label)}>", eol(), 
                        Content.Map(c => c.Format(), () => string.Empty), eol(), 
                    $"</{Name}>");               
        }

        public abstract class SyntaxElement<E> : SyntaxElement
        {

            protected SyntaxElement(ElementDescriptor Descriptor, ISymbolicExpression Content = null)
                : base(Descriptor,Content)
            {
                
            }
        }
    }


}