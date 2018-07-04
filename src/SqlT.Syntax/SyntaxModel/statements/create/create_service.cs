//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class create_service : create_statement<create_service, SqlBrokerServiceName>
        {

            public create_service(SqlBrokerServiceName element_name, SqlQueueName queue_name, params SqlBrokerContractName[] contract_names)
                : base(SERVICE, element_name)
            {
                this.queue_name = queue_name;
                this.contract_names = contract_names;
            }


            public SqlQueueName queue_name { get; }

            public SyntaxList<SqlBrokerContractName> contract_names { get; }


            public override string ToString()
                => $"{CREATE} {SERVICE} {element_name} on {queue_name} ({string.Join(",", contract_names)})";

        }

        public sealed class create_services : SyntaxList<create_services, create_service>
        {
            public static implicit operator create_services(create_service[] items)
                => new create_services(items);

            public create_services()
            { }

            public create_services(params create_service[] items)
                : base(items)
            { }

        }
    }



}
