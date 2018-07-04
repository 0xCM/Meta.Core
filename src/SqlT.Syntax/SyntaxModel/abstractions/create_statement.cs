//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using Meta.Models;
    using Meta.Syntax;
    using static SqlSyntax;

    public abstract class create_statement<s,n> : statement<s>, sxc.create_statement
        where s : create_statement<s,n>
        where n : IName
    {
        protected create_statement(IKeyphrase element_designator, n element_name)
            : base(CREATE)
        {
            this.element_designator = element_designator;
            this.element_name = element_name;
                
        }

        protected create_statement(IKeyword element_designator, n element_name)
            : this(KeyPhrase.create(element_designator), element_name)
        {

        }

        public n element_name { get; }

        public IKeyphrase element_designator { get; }
           
        public override string ToString()
            => $"{statement_designator}";

    }

}