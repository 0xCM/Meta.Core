//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;

    [SqlElementType(SqlElementTypeNames.Queue)]
    public sealed class SqlQueue : SqlObject<SqlQueue,SqlQueueName>
    {

        public SqlQueue
        (
            SqlQueueName QueueName,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null
         )
            : base
            (
                  QueueName,
                  Properties: Properties,
                  Documentation: Documentation
            )
        {
        }

    }

    public sealed class SqlQueues : SyntaxList<SqlQueues, SqlQueue>
    {
        public static implicit operator SqlQueues(SqlQueue[] MessageTypes)
            => new SqlQueues(MessageTypes);

        public SqlQueues()
        { }

        public SqlQueues(SqlQueue[] MessageTypes)
            : base(MessageTypes)
        { }
    }
}
