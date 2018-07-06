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

    partial class SqlSyntax
    {
        public sealed class contract_message_sender : du<kwt.INITIATOR, kwt.TARGET, kwt.DEFAULT>
        {
            public static implicit operator contract_message_sender(kwt.INITIATOR x)
                => new contract_message_sender(x);

            public static implicit operator contract_message_sender(kwt.TARGET x)
                => new contract_message_sender(x);

            public static implicit operator contract_message_sender(kwt.DEFAULT x)
                => new contract_message_sender(x);

            public contract_message_sender(kwt.INITIATOR x)
                : base(x)
            {

            }

            public contract_message_sender(kwt.TARGET x)
                : base(x)
            {

            }

            public contract_message_sender(kwt.DEFAULT x)
                : base(x)
            {

            }

        }
    }


}