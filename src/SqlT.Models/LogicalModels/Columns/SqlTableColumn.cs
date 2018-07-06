//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using sxc = Syntax.contracts;


    /// <summary>
    /// Represents a column in a table
    /// </summary>

    [SqlElementType(SqlElementTypeNames.TableColumn)]
    public sealed class SqlTableColumn : SqlColumn<SqlTableColumn>
    {

        public static implicit operator SqlTableColumn(SqlColumnDefinition Definition)
            => new SqlTableColumn(Definition);
        
        /// <summary>
        /// Yields a sequence of columns conforming to the supplied proxy type
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="startpos">The ordinal position assigned to the first column which consequently determines the ordinal position assigned to subsequent columns in the sequence</param>
        /// <returns></returns>
        public static IEnumerable<SqlTableColumn> ReplicateAll<P>(int startpos = 0)
            where P : ISqlTabularProxy, new()
        {
            var colpos = startpos;
            var metadata = typeof(P).Assembly.SqlProxyMetadataIndex();
            foreach (var proxycol in metadata.Tabular<P>().Columns)
                yield return new SqlTableColumn(proxycol.DefineSqlColumn(newpos: colpos++));
        }


        /// <summary>
        /// Yields an identified sequence of columns conforming to the supplied proxy type
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="startpos">The ordinal position assigned to the first column which consequently determines the ordinal positions assigned to subsequent columns in the sequence</param>
        /// <param name="RuntimeNames">The runtime names of the columns to replicate</param>
        /// <returns></returns>
        public static IEnumerable<SqlTableColumn> ReplicateSelected<P>(int startpos = 0, params string[] RuntimeNames)
            where P : ISqlTabularProxy, new()
        {
            var colpos = startpos;
            var metadata = typeof(P).Assembly.SqlProxyMetadataIndex();
            var tableProxy =  metadata.Tabular<P>();
            return from name in RuntimeNames
                   let proxycol = tableProxy.FindColumnByRuntimeName(name)
                   select new SqlTableColumn(proxycol.DefineSqlColumn(newpos: colpos++));
        }

        public static SqlTableColumn Define<P>(int pos, string RuntimeName)
            where P : ISqlTabularProxy, new()
            => ReplicateSelected<P>(pos, RuntimeName).Single();

        public static SqlTableColumn Define<P>(int pos, string RuntimeName, string Alias)
            where P : ISqlTabularProxy, new()
            => ReplicateSelected<P>(pos, RuntimeName).Single().Rename(Alias);

        public SqlTableColumn(SqlColumnDefinition Definition)
            : base(Definition)
        {
        }

        public override SqlTableColumn Reposition(int newPosition)
            => new SqlTableColumn(Definition.Reposition(newPosition));

        public override SqlTableColumn Reparent(sxc.sql_object newParent)
            => new SqlTableColumn(Definition.Reparent(newParent));

        public override SqlTableColumn Rename(SqlColumnName newName)
            => new SqlTableColumn(Definition.Rename(newName));

        public override SqlTableColumn Retype(SqlTypeDescriptor newType)
            => new SqlTableColumn(Definition.Retype(DataTypeReference.retype(newType)));


        public SqlTableColumn
        (
            string LocalName,
            int Position,
            sxc.data_type_ref DataType,
            sxc.sql_object Parent = null,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlDefaultConstraint DefaultConstraint = null,
            string ComputationExpression = null,
            bool ComputationPersisted = false,
            SqlColumnRoleType ColumnRole = null
         ) : 
         base
         (
            LocalName,
            Position, 
            DataType, 
            Parent, 
            Documentation, 
            Properties,
            DefaultConstraint,
            ComputationExpression,
            ComputationPersisted,
            ColumnRole
         )
        {
        }

        ISqlColumn Self
            => this;


    }
}
