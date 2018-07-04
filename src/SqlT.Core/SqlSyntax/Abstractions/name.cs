//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;
    using sxc = contracts;
    
    public abstract class name<n1, n2> : cdu<IName, n1, n2>, IName
        where n1 : IName
        where n2 : IName
    {
        public name(n1 n1)
            : base(n1)
        {
            this.referent_type = string.Empty;
        }

        public name(n2 n2)
            : base(n2)
        {

        }

        public string referent_type { get; }

        public string text
            => (selected_value as ISqlIdentifier).IdentifierText;

        public bool quoted
            => (selected_value as ISqlIdentifier).Quoted;

        public bool IsEmpty
            => string.IsNullOrWhiteSpace(text);

        public override string ToString()
            => text;


    }


}