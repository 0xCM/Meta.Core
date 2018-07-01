//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    using static metacore;


    /// <summary>
    /// Base type for Elements that can directly appear under the top Project node
    /// </summary>
    public abstract class ProjectElement
    {
        protected ProjectElement(string ElementName, string Label, string Condition = null, int? Position = null)
        {

            this.ElementName = ElementName;
            this.Label = Label;
            this.Condition = ifNull(Condition, () => string.Empty);
            this.Position = ifNullValue(Position, 0);

        }

        public string ElementName { get; set; }

        public string Label { get; set; }

        public string Condition { get; set; }

        public int Position { get; set; }

        protected virtual string FormatContent()
            => string.Empty;

        public override string ToString()
            => ToXml();

        public virtual string ToXml()                    
            => concat(
                $"<{ElementName} Label={quote(Label)}>", eol(), 
                    FormatContent(), eol(), 
                $"</{ElementName}>"
            );
            
        

    }

    public abstract class ProjectElement<T> : ProjectElement
        where T : ProjectElement<T>
    {

        protected ProjectElement(string ElementName, string Label, string Condition = null, int? Position = null)
            : base(ElementName, Label, Condition,Position)
        { }


    }
}