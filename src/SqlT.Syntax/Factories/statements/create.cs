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
    using System.Linq.Expressions;
    using System.Reflection;
    
    using SqlT.Core;
    
    using static metacore;
    using static SqlSyntax;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using kpt = SqlKeyPhraseTypes;    

    partial class sql
    {
        public static create_index create(kwt.INDEX INDEX, SqlIndexName name,
            kwt.ON ON, table_or_view_name parent_object, column_list columns)
            => new create_index(name, parent_object, columns);

        public static create_schema create(kwt.SCHEMA SCHEMA, SqlSchemaName name)
            => new create_schema(name);

        public static create_synonym create(kwt.SYNONYM SYNONYM, SqlSynonymName synonym_name, kwt.FOR FOR, object_name referent_name)
            => new create_synonym(synonym_name, referent_name);


        public static create_contract create(kwt.CONTRACT CONTRACT, SqlBrokerContractName name,
            params contract_message_spec[] message_specs)
                => new create_contract(name, message_specs);

        public static create_message_type create(kpt.MESSAGETYPE MESSAGETYPE, SqlMessageTypeName name)
            => new create_message_type(name);

        public static augmentation<create_message_type> create(kpt.MESSAGETYPE MESSAGETYPE, SqlMessageTypeName name, string description)
            => create(MESSAGETYPE, name).augment(
                xprop(MESSAGETYPE, name, SqlPropertyNames.Documentation, description));

        public static create_message_types message_types(params create_message_type[] items)
            => items;

        public static create_service create(kwt.SERVICE SERVICE, SqlBrokerServiceName service_name,
            kwt.ON ON, SqlQueueName queue_name, params SqlBrokerContractName[] contract_names)
                => new create_service(service_name, queue_name, contract_names);

        public static create_queue create(kwt.QUEUE QUEUE, SqlQueueName name)
            => new create_queue(name);

        public static create_queue create(kwt.QUEUE QUEUE, SqlQueueName name, kwt.WITH WITH, kwt.STATUS STATUS, kwt.ON ON)
            => new create_queue(name, status: new queue_status(ON));

        public static create_queue create(kwt.QUEUE QUEUE, SqlQueueName name, kwt.WITH WITH, kwt.STATUS STATUS, kwt.OFF OFF)
            => new create_queue(name, status: new queue_status(OFF));

        public static create_queue create(kwt.QUEUE QUEUE, SqlQueueName name, kwt.WITH WITH, kwt.RETENTION RETENTION, kwt.ON ON)
            => new create_queue(name, retention: new queue_retention(ON));

        public static create_queue create(kwt.QUEUE QUEUE, SqlQueueName name, kwt.WITH WITH, kwt.RETENTION RETENTION, kwt.OFF OFF)
            => new create_queue(name, retention: new queue_retention(OFF));


    }

}