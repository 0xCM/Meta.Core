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
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Core.SqlProxyMetadataProvider;

    using sxc = SqlT.Syntax.contracts;
    using B = SqlTableTypeBuilder;
    using Column = SqlTableTypeColumn;

    /// <summary>
    /// Implements builder pattern for constructing <see cref="SqlTableType"/> objects
    /// </summary>
    public class SqlTableTypeBuilder : SqlModelBuilder<SqlTableType>
    {
        SqlTableTypeName TypeName { get; }

        SqlElementDescription Documentation { get; }

        MutableList<Column> Columns { get; }
            = MutableList.Create<Column>();

        MutableList<SqlPropertyAttachment> Properties { get; }
            = MutableList.Create<SqlPropertyAttachment>();

        int colpos = 0;

        Column DefineTypeColumn(CoreDataFieldDescription field, int position = 0)
        {
            if (!field.DataType.CanMapToSqlType())
                throw new ArgumentException($"The {field.Name} field of type {field.DataType} cannot be mapped to a SQL type");

            var type = field.DataType.MapToSqlType();
            var length = field.DataFacets.MapValueOrDefault(x => x.MaxLength);
            var precision = field.DataFacets.MapValueOrDefault(x => x.NumericPrecision);
            var scale = field.DataFacets.MapValueOrDefault(x => x.NumericScale);
            return new Column(
                    Position: position,
                    LocalName: field.Name,
                    DataType: type.Reference(field.Optional, length, precision, scale),
                    Documentation: field.Documentation
                );
        }

        Column DefineRoleColumn(SqlColumnRoleKind columnType, int colpos)
        {
            var colname = SqlColumnRole.DefaultRoleColumnNames[columnType];
            switch (columnType)
            {

                case SqlColumnRoleKind.CreateTime:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.datetime2.Reference(false, scale: 3),
                            Documentation: "The time at which the record was created",
                            DefaultConstraint: new SqlDefaultConstraint
                            (
                                new SqlDefaultConstraintName($"DF_{TypeName.UnqualifiedName}_{columnType}"),
                                $"(sysdatetime())"
                            )
                        );
                case SqlColumnRoleKind.CreateUser:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.nvarchar.Reference(false, length: 75),
                            Documentation: "The user that created the record",
                            DefaultConstraint: new SqlDefaultConstraint
                            (
                                new SqlDefaultConstraintName($"DF_{TypeName.UnqualifiedName}_{columnType}"),
                                $"(SUSER_NAME())"
                            )
                        );

                case SqlColumnRoleKind.UpdateTime:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.datetime2.Reference(true, scale: 7),
                            Documentation: "The time at which the record was updated"
                        );
                case SqlColumnRoleKind.UpdateUser:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.nvarchar.Reference(true, length: 75),
                            Documentation: "The user that last updated the record"
                        );

                default:
                    throw new NotImplementedException($"The {columnType} column type is not recognized");
            }
        }


        Column GetRequiredColumn(SqlColumnName name) 
            => Columns.Single(c => c.Name == name);

        

        internal SqlTableTypeBuilder(SqlTableTypeName TypeName, string documentation)
        {
            this.TypeName = TypeName.TrimCatalog();
            this.Documentation = documentation;
        }


        internal SqlTableTypeBuilder(SqlTableTypeName TableName, IEnumerable<Column> Columns)
        {
            this.TypeName = TableName;
            this.Columns.AddRange(Columns);
        }
               
        public Builder<B> WithColumn(SqlColumnName name, sxc.data_type_ref typeref, string documentation = null)
        {
            Columns.Add(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: typeref,
                    Documentation: documentation

                ));
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type, bool isNullable, string documentation = null)
        {
            Columns.Add(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: type.Reference(isNullable),
                    Documentation: documentation
                ));
            return this;
        }


        Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type,
                bool isNullable, string documentation = null, 
                int? length = null, byte? precision = null, byte? scale = null)
        {
            Columns.Add(new Column
                (
                 Position: colpos++,
                 LocalName: name,
                 DataType: type.Reference(isNullable, length, precision, scale),
                 Documentation: documentation
                ));
            return this;
        }

        public Builder<B> WithRoleColumn(SqlColumnRoleKind columnType)
        {
            Columns.Add(DefineRoleColumn(columnType, colpos++));
                return this;
        }

        public Builder<B> WithColumns(params Column[] columns)
        {
            var startcount = this.Columns.Count;
            this.Columns.AddRange(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumns(IEnumerable<Column> columns)
        {
            var startcount = this.Columns.Count;
            this.Columns.AddRange(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumns(IEnumerable<SqlColumnDefinition> definitions)
        {
            var startcount = this.Columns.Count;
            var columns = map(definitions, definition => new Column(definition));
            this.Columns.AddRange(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type, CoreDataFacets facets, string documentation = null)
        {
            Columns.Add(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: type.Reference(SqlDataFacets.FromCoreFacets(facets)),
                    Documentation : documentation
                ));
            return this;
        }


        public Builder<B> WithColumn(CoreDataFieldDescription field)
        {
            Columns.Add(DefineTypeColumn(field,colpos++));
            return this;
        }
        

        public Builder<B> WithColumns(IReadOnlyList<CoreDataFieldDescription> fields)
        {

            fields.Iterate(f => WithColumn(f));
            return this;
        }

        public Builder<B> WithColumns<X>()
            where X : ISqlTabularProxy, new()
        {

            WithColumns(Column.ReplicateAll<X>());
            return this;
        }


        public override SqlTableType Complete() 
            => new SqlTableType (
                TypeName: new SqlTableTypeName(TypeName),
                Columns: Columns,
                PrimaryKey: null,
                Properties: Properties,
                Documentation: Documentation
            );
    }

    public class SqlTableTypeBuilder<P> : B
        where P : ISqlTabularProxy, new()
    {
        static Lazy<SqlTabularProxyInfo> _ProxyInfo
            = defer(() => ProxyMetadata<P>().Tabular<P>());

        static SqlTabularProxyInfo TabularProxy
            => _ProxyInfo.Value;

        public static IEnumerable<SqlColumnProxyInfo> GetColumns(IEnumerable<Expression<Func<P, object>>> selectors)
            => from selector in selectors
               let property = selector.GetProperty()
               select TabularProxy.Columns.Single(c => c.ClrElement as PropertyInfo == property);


        public SqlTableTypeBuilder()
            : base(TabularProxy.ObjectName.AsTableTypeName(), Column.ReplicateAll<P>())
        {

        }


        public SqlTableTypeBuilder(SqlTableTypeName TypeName, string Documentation)
            : base(TypeName.TrimCatalog(), Documentation)
        {

        }

    }
}
