//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;

    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    
    partial class SqlSyntax
    {

        public sealed class contract_message_spec : Model<contract_message_spec>
        {

            public contract_message_spec(SqlMessageTypeName type_name, kwt.INITIATOR INITIATOR)
            {
                this.message_type = new contract_message_type(type_name);
                this.message_sender = INITIATOR;
            }

            public contract_message_spec(SqlMessageTypeName type_name, kwt.TARGET TARGET)
            {
                this.message_type = new contract_message_type(type_name);
                this.message_sender = TARGET;
            }

            public contract_message_spec(contract_message_type message_type, contract_message_sender message_sender)
            {
                this.message_type = message_type;
                this.message_sender = message_sender;
            }


            public contract_message_type message_type { get; }

            public contract_message_sender message_sender { get; }

            public override string ToString()
                => $"{message_type} {SENT} {BY} {message_sender}";
        }

        public sealed class contract_message_specs : SyntaxList<contract_message_specs, contract_message_spec>
        {
            public static implicit operator contract_message_specs(contract_message_spec[] items)
                => new contract_message_specs(items);

            public contract_message_specs()
            {

            }

            public contract_message_specs(params contract_message_spec[] items)
                : base(items)
            { }
        }

    }

}