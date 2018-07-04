//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;


    [SqlElementType(SqlElementTypeNames.View)]
    public sealed class SqlView : SqlObject<SqlView>
    {
        public readonly SqlQueryScript DefiningQuery;

        public SqlView
        (
            SqlObjectName ObjectName,
            SqlQueryScript DefiningQuery,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null
         )
            : base
            (
                  ObjectName : ObjectName, 
                  Properties : Properties,
                  Documentation : Documentation
            )
        {
            this.DefiningQuery = DefiningQuery;
        }

    }
}
