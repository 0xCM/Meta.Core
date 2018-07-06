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
    using System.Linq.Expressions;

    using SqlT.Core;
    using SqlT.Types;

    public sealed class SqlTypedIdentifierListBinding<TTable, TIdentifier> : SqlListBinding<TTable, TIdentifier>
       where TTable : class, ISqlTableProxy, new()

    {
        public SqlTypedIdentifierListBinding(string ListName, SqlColumnName IdentifierColumn, SqlColumnName TypedIdentifierValueColumn)
            : base(ListName, IdentifierColumn)
        {
            this.TypedIdentifierValueColumn = TypedIdentifierValueColumn;
        }

        public SqlColumnName TypedIdentifierValueColumn { get; }

    }
}