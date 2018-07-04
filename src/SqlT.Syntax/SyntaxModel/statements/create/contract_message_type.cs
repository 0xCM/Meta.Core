//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using Meta.Models;
    using SqlT.Core;

    using kwt = SqlKeywordTypes;
    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class contract_message_type : du<SqlMessageTypeName, kwt.DEFAULT>
        {
            public static implicit operator contract_message_type(SqlMessageTypeName x)
                => new contract_message_type(x);

            public static implicit operator contract_message_type(kwt.DEFAULT x)
                => new contract_message_type(x);

            public contract_message_type(SqlMessageTypeName x)
                : base(x)
            {

            }

            public contract_message_type(kwt.DEFAULT x)
                : base(x)
            {

            }

        }
    }


}