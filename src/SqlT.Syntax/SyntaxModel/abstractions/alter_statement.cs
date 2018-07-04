//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;
    using static SqlSyntax;
    using Meta.Syntax;

    public abstract class alter_statement<s> : statement<s>, sxc.alter_statement
        where s : alter_statement<s>
    {
        protected alter_statement(IKeyword element_designator)
            : base(ALTER)
        {
            this.element_designator = element_designator;
        }

        public IKeyword element_designator { get; }

        public override string ToString()
            => $"{statement_designator} {element_designator}";

    }
 
}