//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class statement : statement<statement>
        {

            public statement(sxc.statement adaptee)
                : base(adaptee.statement_designator)
            {
                this.adaptee = adaptee;

            }

            public sxc.statement adaptee { get; }

            public override string ToString()
                => adaptee.ToString();

        }
    }

}