//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Core.SqlProxyMetadataProvider;

    using sxc = SqlT.Syntax.contracts;
    using kwt = SqlT.Syntax.SqlKeywordTypes;
    using B = SqlTableBuilder;
    using Column = SqlT.Models.SqlTableColumn;
    using G = System.Collections.Generic;

    /// <summary>
    /// Constructs <see cref="SqlTable"/> definitions
    /// </summary>
    public class SqlTableBuilder : SqlModelBuilder<B, SqlTable>
    {
        SqlTableName TableName { get; }

        MutableList<Column> Columns { get; }
            = MutableList.Create<Column>();

        MutableList<SqlIndex> Indexes { get; }
            = MutableList.Create<SqlIndex>();

        MutableList<SqlColumnStoreIndex> ColumnStoreIndexes { get; }
            = MutableList.Create<SqlColumnStoreIndex>();

        G.List<SqlColumnName> PkColumnNames
            = new G.List<SqlColumnName>();

        SqlPrimaryKeyName PkName;

        SqlFileGroupName FgName = SqlFileGroup.DefaultFileGroupName;

        int colpos = 0;

        IReadOnlySet<Link<sxc.data_type_ref>> TypeSubstitutions { get; }
            = roset<Link<sxc.data_type_ref>>();

        /// <summary>
        /// Appends a column to the table definition
        /// </summary>
        /// <param name="column">The column to add</param>
        void AddColumn(Column column)
        {

            var srcType = column.DataTypeReference;
            foreach (var sub in TypeSubstitutions)
            {
                var candidate = sub.Source;
                if (candidate.type_name == srcType.type_name
                    && candidate.precision == srcType.precision
                    && candidate.scale == srcType.scale
                    && candidate.length == srcType.length
                   )
                {
                    Columns.Add(column.Retype(new SqlTypeReference(candidate)));
                    return;
                }
            }

            Columns.Add(column);
        }

        void AddColumns(IEnumerable<Column> columns)
            => iter(columns, AddColumn);

        public SqlTableBuilder(SqlTableName TableName, IEnumerable<Link<sxc.data_type_ref>> TypeSubstitutions, SqlElementDescription Description = null)
        {
            this.TypeSubstitutions = roset(TypeSubstitutions);
            this.TableName = TableName.TrimCatalog();
            this.Description = Description;
        }

        public SqlTableBuilder(SqlTableName TableName, SqlElementDescription Description = null)
        {
            this.TableName = TableName.TrimCatalog();
            this.Description = Description;
        }

        internal SqlTableBuilder(SqlTableName TableName, IEnumerable<Column> Columns, SqlElementDescription Description = null)
        {
            this.TableName = TableName;
            AddColumns(Columns);
            this.Description = Description;
        }

        Column DefineRoleColumn(SqlColumnRoleKind columnType, int colpos)
        {
            var colname = SqlColumnRole.DefaultRoleColumnNames[columnType];
            switch (columnType)
            {
                case SqlColumnRoleKind.SystemVersion:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.rowversion.Reference(false),
                            Documentation: "Auto-generated value that identifies the record version"
                        );
                case SqlColumnRoleKind.CreateTime:
                    return new Column
                        (
                            Position: colpos,
                            LocalName: colname,
                            DataType: SqlNativeTypes.datetime2.Reference(false, scale: 3),
                            Documentation: "The time at which the record was created",
                            DefaultConstraint: new SqlDefaultConstraint
                            (
                                new SqlDefaultConstraintName($"DF_{TableName.UnqualifiedName}_{columnType}"),
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
                                new SqlDefaultConstraintName($"DF_{TableName.UnqualifiedName}_{columnType}"),
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

        Column col(SqlColumnName name)
            => Columns.Single(c => c.Name == name);

        public Builder<B> WithNamedPrimaryKey(string name, params SqlColumnName[] pkColNames)
        {
            this.PkName = new SqlPrimaryKeyName(TableName.SchemaNamePart, name);
            this.PkColumnNames = pkColNames.ToList();
            return this;
        }

        public Builder<B> WithIndex(SqlIndex Index)
        {
            Indexes.Add(Index);
            return this;
        }

        public Builder<B> WithIndex(SqlColumnStoreIndex Index)
        {
            ColumnStoreIndexes.Add(Index);
            return this;
        }

        public Builder<B> WithPrimaryKey(params SqlColumnName[] pkColNames)
        {
            if (pkColNames.Length != 0)
            {
                this.PkName = new SqlPrimaryKeyName(TableName.SchemaNamePart, $"PK_{TableName.UnqualifiedName}");
                this.PkColumnNames = pkColNames.ToList();
            }
            return this;
        }

        public Builder<B> OnFileGroup(string name)
        {
            this.FgName = name;
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.data_type_ref typeref, string docs = null)
        {
            AddColumn(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: typeref,
                    Documentation: docs

                ));
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type, bool isNullable, string docs)
        {
            AddColumn(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: type.Reference(isNullable),
                    Documentation: docs
                ));
            return this;
        }

        public Builder<B> WithComputedColumn(SqlColumnName name, string expression, bool pesisted = true)
        {
            AddColumn(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: SqlNativeTypes.sqlint.Reference(),
                    ComputationExpression: expression,
                    ComputationPersisted: pesisted)
                );
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type, bool isNullable, string documentation = null, 
            int? length = null, byte? precision = null, byte? scale = null)
                => Step(() =>        
                AddColumn(new Column
                    (
                     Position: colpos++,
                     LocalName: name,
                     DataType: type.Reference(isNullable, length, precision, scale),
                     Documentation: documentation
                    )));

        public Builder<B> WithRoleColumn(SqlColumnRoleKind columnType)
            => Step( () =>AddColumn(DefineRoleColumn(columnType, colpos++)));

        public Builder<B> WithColumns(params Column[] columns)
        {
            var startcount = this.Columns.Count;
            AddColumns(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumns(IEnumerable<Column> columns)
        {
            var startcount = this.Columns.Count;
            AddColumns(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumns(IEnumerable<SqlColumnDefinition> definitions)
        {
            var startcount = this.Columns.Count;
            var columns = map(definitions, definition => new Column(definition));
            AddColumns(map(columns, c => c.Reposition(c.Position + startcount)));
            colpos += startcount;
            return this;
        }

        public Builder<B> WithColumn(SqlColumnName name, sxc.ISqlType type, CoreDataFacets facets, string documentation = null)
            => Step(() => AddColumn(new Column
                (
                    Position: colpos++,
                    LocalName: name,
                    DataType: type.Reference(SqlDataFacets.FromCoreFacets(facets)),
                    Documentation: documentation
                )));

        public Builder<B> WithSequentialKeyColumn(SqlSequence Sequence, SqlColumnName ColumnName = null, bool pk = true)
        {
            var col = Sequence.CreateSequencedColumn(TableName, colpos++, pk, ColumnName);

            AddColumn(col);
            if (pk)
                WithPrimaryKey(col.Name);
            return this;
        }

        public Builder<B> WithSequentialKeyColumn(SqlSequenceName seqname, sxc.ISqlType SequenceType, SqlColumnName colname = null, bool pk = true)
        {
            var col = seqname.CreateSequencedColumn(SequenceType.Reference(false), TableName, colpos++, pk, colname);
            AddColumn(col);
            if (pk)
                WithPrimaryKey(col.Name);

            return this;
        }

        public Builder<B> WithColumn(CoreDataFieldDescription field)
        {
            if (!field.DataType.CanMapToSqlType())
                throw new ArgumentException($"The {field.Name} field of type {field.DataType} cannot be mapped to a SQL type");

            WithColumn
            (
                name: new SqlColumnName(field.Name),
                type: field.DataType.MapToSqlType(),
                isNullable: field.Optional,
                documentation: field.Documentation,
                length: field.DataFacets.MapValueOrDefault(x => x.MaxLength),
                precision: field.DataFacets.MapValueOrDefault(x => x.NumericPrecision),
                scale: field.DataFacets.MapValueOrDefault(x => x.NumericScale)
            );
            return this;
        }

        public Builder<B> WithColumns(IReadOnlyList<CoreDataFieldDescription> fields)
            => Step( () => fields.Iterate(f => WithColumn(f)));
                    

        public Builder<B> WithColumns<X>()
            where X : ISqlTabularProxy, new()
            => Step( () => WithColumns(Column.ReplicateAll<X>()));

        public override SqlTable Complete()
            => new SqlTable
            (
                TableName: TableName,
                Columns: Columns,
                PrimaryKey: 
                    isBlank(PkName) 
                    ? null
                    : new SqlPrimaryKey
                        (
                            PrimaryKeyName: PkName,
                            KeyColumns: PkColumnNames.Map(name => new SqlPrimaryKeyColumn(col(name)))
                        ),
                Properties: Properties,
                Documentation: Description,
                FileGroupName: FgName,
                Indexes: Indexes,
                ColumnStoreIndexes: ColumnStoreIndexes
            );
    }


    public class SqlTableBuilder<P> : B
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


        public SqlTableBuilder(SqlElementDescription Description = null)
            : base(TabularProxy.ObjectName.AsTableName(), Column.ReplicateAll<P>(), Description)
        {

        }

        public SqlTableBuilder(SqlTableName TableName, SqlElementDescription Description = null)
            : base(TableName.TrimCatalog(), Column.ReplicateAll<P>(), Description)
        {

        }
    }
}