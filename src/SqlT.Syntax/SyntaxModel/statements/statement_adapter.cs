//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static SqlSyntax;

    using Meta.Models;
    using SqlT.Core;


    partial class SqlSyntax
    {

        public class statement_adapter : statement<statement_adapter>
        {

            public statement_adapter(IModel subject)
                : base(EMPTY)
            {
                this.subect = subject;
            }

            public IModel subect { get; }


        }

 
    }
}