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

    using Meta.Core;
    using SqlT.Core;
   
    public static class SqlListBinding
    {
        public static SqlTypedIdentifierListBinding<TTable, TIdentifier> BindTypedIdentifier
            <TTable, TIdentifier>(string ListName,
                Expression<Func<TTable, object>> identifierColumn,
                Expression<Func<TTable, object>> identifierValueColumn)
                    where TTable : class, ISqlTableProxy, new()
                        => new SqlTypedIdentifierListBinding<TTable, TIdentifier>
                        (
                            ListName,
                            identifierColumn.GetValueMemberName(),
                            identifierValueColumn.GetValueMemberName()
                        );

        public static SqlTableTypeListBinding<TTable, TType> BindTypedIdentifier
            <TTable, TType>
            (
                string ListName,
                Expression<Func<TType, object>> identifierColumn
            )
            where TTable : class, ISqlTableProxy, new()
            where TType : class, ISqlTableTypeProxy, new()
                => new SqlTableTypeListBinding<TTable, TType>
                (
                    ListName,
                    identifierColumn.GetValueMemberName()                    
                );
    }

    public abstract class SqlListBinding<T,B> : SqlProxyTypeBinding<T,B>
        where T : class, ISqlTableProxy, new()
    {

        protected SqlListBinding(string ListName, SqlColumnName IdentifierColumn)
        {
            this.ListName = ListName;
            this.IdentifierColumn = IdentifierColumn;
        }

        public string ListName { get; }

        public SqlColumnName IdentifierColumn { get; }
    }       
}