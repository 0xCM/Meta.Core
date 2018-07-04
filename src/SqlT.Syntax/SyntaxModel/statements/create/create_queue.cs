//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;
    using Meta.Models;

    using SqlT.Core;

    using static metacore;

    partial class SqlSyntax
    {

        public sealed class create_queue : create_statement<create_queue, SqlQueueName>
        {
            public create_queue(SqlQueueName element_name, queue_status status = null, queue_retention retention = null)
                : base(QUEUE, element_name)
            {
                this.retention = retention;
                this.status = status;
            }

            public ModelOption<queue_status> status { get; }

            public ModelOption<queue_retention> retention { get; }


            public override string ToString()
                => $"{CREATE} {QUEUE} {element_name}";
        }

        public sealed class create_queues : SyntaxList<create_queues, create_queue>
        {

            public static implicit operator create_queues(create_queue[] items)
                => new create_queues(items);

            public create_queues()
            { }

            public create_queues(params create_queue[] items)
                : base(items)
            { }
        }
    }
}