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

    using sxc = SqlT.Syntax.contracts;

    using T = SqlTableTypeColumn;

    [SqlElementType(SqlElementTypeNames.TableTypeColumn)]
    public sealed class SqlTableTypeColumn : SqlColumn<T>
    {

        /// <summary>
        /// Yields a sequence of columns conforming to the supplied proxy type
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="startpos">The ordinal position assigned to the first column which consequently determines the ordinal position assigned to subsequent columns in the sequence</param>
        /// <returns></returns>
        public static IEnumerable<T> ReplicateAll<P>(int startpos = 0)
            where P : ISqlTabularProxy, new()
        {
            var colpos = startpos;
            var metadata = typeof(P).Assembly.SqlProxyMetadataIndex();
            foreach (var proxycol in metadata.Tabular<P>().Columns)
                yield return new T(proxycol.DefineSqlColumn(newpos: colpos++));
        }

        public SqlTableTypeColumn
        (
            SqlColumnName LocalName,
            int Position,
            sxc.data_type_ref DataType,
            sxc.sql_object Parent = null,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlDefaultConstraint DefaultConstraint = null,
            SqlColumnRoleType ColumnRole = null
         ) : base
            (
                LocalName,
                Position,
                DataType, 
                Parent, 
                Documentation, 
                Properties, 
                DefaultConstraint,
                null,
                false,
                ColumnRole
             )
        {

        }

        public SqlTableTypeColumn(SqlColumnDefinition Definition)
            : base(Definition)
        { }

        public override T Rename(SqlColumnName newName)
            => new T(Definition.Rename(newName));

        public override T Reposition(int newPosition)
            => new T(Definition.Reposition(newPosition));

        public override T Reparent(sxc.sql_object newParent)
            => new T(Definition.Reparent(newParent));

        public override T Retype(SqlTypeReference newType)
            => new T(Definition.Retype(DataTypeReference.retype(newType)));

        public T ToTableColumn()
            => new T
            (
                Name,
                Position,
                DataTypeReference,
                Parent.ValueOrDefault(),
                Documentation.ValueOrDefault(),
                Properties,
                DefaultConstraint.ValueOrDefault(),
                ColumnRole: ColumnRole
            );



    }


}
