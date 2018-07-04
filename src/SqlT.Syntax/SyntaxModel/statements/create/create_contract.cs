//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    partial class SqlSyntax
    {
        public sealed class create_contract : create_statement<create_contract, SqlBrokerContractName>
        {
            public static implicit operator SqlBrokerContractName(create_contract x) 
                => x.element_name;

            public create_contract(SqlBrokerContractName element_name,
                contract_message_specs message_specs,
                contract_auth auth = null)
                : base(CONTRACT, element_name)
            {
                this.message_specs = message_specs;
                this.auth = auth;
            }

            public contract_message_specs message_specs { get; }

            public ModelOption<contract_auth> auth { get; }

            public override string ToString()
                => $"{CREATE} {CONTRACT} {element_name} ({message_specs})";
        }

        public sealed class create_contracts : SyntaxList<create_contracts, create_contract>
        {
            public static implicit operator create_contracts(create_contract[] items)
                => new create_contracts(items);

            public create_contracts()
            { }

            public create_contracts(params create_contract[] items)
                : base(items)
            { }
        }    
    }
}