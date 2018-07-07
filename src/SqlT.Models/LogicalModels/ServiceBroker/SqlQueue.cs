//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
