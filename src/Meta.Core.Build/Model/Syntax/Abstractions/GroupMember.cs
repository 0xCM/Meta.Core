//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using static metacore;

    public abstract class GroupMember
    {

        protected GroupMember(string ElementName, string Label, string Condition)
        {
            this.ElementName = ElementName;
            this.Condition = ifBlank(Condition, string.Empty);
            this.Label = ifBlank(Label, string.Empty);
        }

        public string ElementName { get; set; }

        public string Condition { get; set; }

        public string Label { get; set; }

        public abstract string ToXml();

    }

    public abstract class GroupMember<G,M> : GroupMember
        where G : GroupMember<G,M>
    {

        protected GroupMember(string ElementName, M ElementContent, string Label, string Condition)
            : base(ElementName ?? typeof(G).Name, Label, Condition)
        {
            this.ElementContent = ElementContent;
        }


        public M ElementContent { get; set; }

        public override string ToXml()
            => string.IsNullOrWhiteSpace(Condition)
            ? $"<{ElementName}>{ElementContent}</{ElementName}"
            : $"<{ElementName} Condition=\"{Condition}\">{ElementContent}</{ElementName}";

    }


    public abstract class GroupMember<G> : GroupMember<G,ISymbolicExpression>
        where G : GroupMember<G>
    {

        protected GroupMember(string ElementName, ISymbolicExpression ElementContent, string Label,  string Condition)
            : base(ElementName, ElementContent, Label, Condition)
        {

        }

    }
}