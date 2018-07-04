//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;
    using static SqlSyntax;

    using sxc = contracts;
    using kwt = SqlT.Syntax.SqlKeywordTypes;

    public static partial class SqlSyntaxExtensions
    {

        public static shrinkdatabase Shrink(this ISqlDatabaseHandle database)
            => new shrinkdatabase(database.DatabaseName);

        public static SqlSynonym Clone(this SqlSynonym x,
            SqlSynonymName SynonymName = null,
            sxc.ISqlObjectName Referent = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null)
                => new SqlSynonym
                (
                    SynonymName ?? x.SynonymName,
                    Referent ?? x.Referent,
                    Properties ?? x.Properties,
                    Documentation ?? x.Documentation.ValueOrDefault()
                );

        public static SqlSynonym For(this SqlSynonym x, sxc.ISqlObjectName ReferentName)
            => x.Clone(Referent: ReferentName);

        public static sxc.statement AsStatement(this sxc.function_call call)
            => new statement_adapter(call);

        public static IEnumerable<SqlColumnName> Names(this IEnumerable<ISqlColumn> columns)
            => columns.Select(c => c.Name);

        public static SqlColumnDefinition FindByRole(this IEnumerable<SqlColumnDefinition> columns,
            SqlColumnRoleKind RoleKind) => columns.Single(c => c.ColumnRole?.RoleKind == RoleKind);

        public static Option<SqlColumnDefinition> TryFindByRole(this IEnumerable<SqlColumnDefinition> columns,
            SqlColumnRoleKind RoleKind) => columns.SingleOrDefault(c => c.ColumnRole?.RoleKind == RoleKind);

        public static SqlColumnDefinition ApplyNameConventions(this SqlColumnDefinition src)
             => new SqlColumnDefinition
            (
               Position: src.Position,
               Name: src.Name,
               DataType: src.DataType,
               Parent: src.Parent.ValueOrDefault(),
               Documentation: src.Documentation.ValueOrDefault(),
               Properties: src.Properties,
               Default: src.Default.MapValueOrDefault(x
                   => x.Rename(
                        SqlDefaultConstraint.ConventionalName(
                            src.Parent.MapValueOrDefault(z => z.ObjectName)
                            ?? new SqlObjectName(Guid.NewGuid().ToString("N")), src.Name))),
               ComputationExpression: src.ComputationExpression.ValueOrDefault(null),
               ComputationPersisted: src.ComputationPersisted,
               ColumnRole: src.ColumnRole
            );

        /// <summary>
        /// Clones the column while assigning it a new parent
        /// </summary>
        /// <param name="newParent">The new parent to which the column will belong</param>
        /// <returns></returns>
        public static SqlColumnDefinition Reparent(this SqlColumnDefinition src, ISqlObject newParent)
            => new SqlColumnDefinition
            (
               Position: src.Position,
               Name: src.Name,
               DataType: src.DataType,
               Parent: newParent,
               Documentation: src.Documentation.ValueOrDefault(),
               Properties: src.Properties,
               Default: src.Default.ValueOrDefault(),
               ComputationExpression: src.ComputationExpression.ValueOrDefault(null),
               ComputationPersisted: src.ComputationPersisted,
               ColumnRole: src.ColumnRole
            );

        public static SqlTypeDescriptor TypeDescriptor(this SqlColumnDefinition src)
            => new SqlTypeDescriptor(src.DataType);

        /// <summary>
        /// Replicates the source column while changing, if necessary, the column
        /// data type reference to NOT NULL
        /// </summary>
        /// <param name="src">The column subject to transformation</param>
        /// <returns></returns>
        public static SqlColumnDefinition NotNull(this SqlColumnDefinition src)
            => src.Retype(src.DataType.retype
                (
                    src.TypeDescriptor().Transform
                    (d => new SqlTypeDescriptor
                        (
                            TypeName: d.TypeName,
                            IsNullable: false,
                            Length: d.Length,
                            Precision: d.Precision,
                            Scale: d.Scale
                        )
                    )
                ));

        /// <summary>
        /// Replicates the source columns while changing, if necessary, the column
        /// data type reference to NOT NULL
        /// </summary>
        /// <param name="src">The column subject to transformation</param>
        /// <returns></returns>
        public static IEnumerable<SqlColumnDefinition> NotNull(this IEnumerable<SqlColumnDefinition> src)
            => src.Select(NotNull);

        /// <summary>
        /// Clones the column while assigning it a new <see cref="sxc.data_type_ref"/>
        /// </summary>
        /// <param name="src">The column subject to transformation</param>
        /// <param name="DataType">The data type of the modified column</param>
        /// <returns></returns>
        public static SqlColumnDefinition Retype(this SqlColumnDefinition src, sxc.data_type_ref DataType)
            => new SqlColumnDefinition
            (
               Position: src.Position,
               Name: src.Name,
               DataType: DataType,
               Parent: src.Parent.ValueOrDefault(),
               Documentation: src.Documentation.ValueOrDefault(),
               Properties: src.Properties,
               Default: src.Default.ValueOrDefault(),
               ComputationExpression: src.ComputationExpression.ValueOrDefault(null),
               ComputationPersisted: src.ComputationPersisted,
               ColumnRole: src.ColumnRole
            );

        /// <summary>
        /// Clones the column while assigning it a new position
        /// </summary>
        /// <param name="src">The column subject to transformation</param>
        /// <param name="Position">The new position the column will occupy</param>
        /// <returns></returns>
        public static SqlColumnDefinition Reposition(this SqlColumnDefinition src, int Position)
            => new SqlColumnDefinition
            (
               Position: Position,
               Name: src.Name,
               DataType: src.DataType,
               Parent: src.Parent.ValueOrDefault(),
               Documentation: src.Documentation.ValueOrDefault(),
               Properties: src.Properties,
               Default: src.Default.ValueOrDefault(),
               ComputationExpression: src.ComputationExpression.ValueOrDefault(null),
               ComputationPersisted: src.ComputationPersisted,
               ColumnRole: src.ColumnRole
            );

        /// <summary>
        /// Clones the column while assigning it a new name
        /// </summary>
        /// <param name="src">The column subject to transformation</param>
        /// <param name="Name">The column's new name</param>
        /// <returns></returns>
        public static SqlColumnDefinition Rename(this SqlColumnDefinition src, SqlColumnName Name)
            => new SqlColumnDefinition
            (
               Position: src.Position,
               Name: Name,
               DataType: src.DataType,
               Parent: src.Parent.ValueOrDefault(),
               Documentation: src.Documentation.ValueOrDefault(),
               Properties: src.Properties,
               Default: src.Default.ValueOrDefault(),
               ComputationExpression: src.ComputationExpression.ValueOrDefault(null),
               ComputationPersisted: src.ComputationPersisted,
               ColumnRole: src.ColumnRole

            );

        /// <summary>
        /// Produces a <see cref="SqlTableColumn"/> according to the information supplied by a <see cref="SqlColumnProxyInfo"/> instance
        /// </summary>
        /// <param name="proxyInfo">The column proxy metadata</param>
        /// <param name="newpos">An alternate position for the column, if desired</param>
        /// <returns></returns>
        public static SqlColumnDefinition DefineSqlColumn(this SqlColumnProxyInfo proxyInfo, string newname = null,
            int? newpos = null, SqlColumnRoleType ColumnRole = null)
        {
            var sqlType = proxyInfo.SqlType;

            var _coltype = SqlNativeTypes.TryFind(p => p.Name == sqlType.TypeName);
            if (!_coltype)
                _coltype = SqlNativeTypes.TryFind(p => p.Name == sqlType.BaseTypeName);

            if (!_coltype)
                throw new Exception($"Could not find primitive of type {sqlType.TypeName} or {sqlType.BaseTypeName}");

            var colType = ~_coltype;


            var colPos = newpos ?? proxyInfo.Position;
            var colName = newname ?? proxyInfo.ColumnName;
            var role = ColumnRole ?? proxyInfo.Documentation.RoleType;
            var typeRef = colType.Reference(sqlType.IsNullable ?? false, sqlType.Length, sqlType.Precision, sqlType.Scale);
            return new SqlColumnDefinition(colPos, colName, typeRef, ColumnRole: role);
        }

        static SqlTableColumn CreateSequentialKeyColumn(
            SqlSequenceName SequenceName,
            sxc.data_type_ref SequenceType,
            SqlTableName TableName,
            int Position,
            SqlColumnRoleType ColumnRole,
            SqlColumnName ColumnName = null)
            => new SqlTableColumn
                (
                    Position: Position,
                    LocalName: ColumnName ?? "RecordKey",
                    DataType: SequenceType,
                    Documentation: "Surrogate key for the record",
                    DefaultConstraint: new SqlDefaultConstraint
                    (
                        SqlDefaultConstraint.ConventionalName(TableName, ColumnName ?? "Key"),
                        $"(next value for {SequenceName})"
                    ),
                    ColumnRole: ColumnRole

                ).Definition;

        public static SqlTableColumn CreateSequencedColumn(
            this SqlSequence Sequence,
            SqlTableName TableName,
            int Position = -1,
            bool IsPrimaryKey = true,
            SqlColumnName ColumnName = null)
                => CreateSequentialKeyColumn(
                    Sequence.ObjectName,
                    Sequence.SequenceDataType,
                    TableName,
                    Position,
                    IsPrimaryKey ? SqlColumnRoleTypes.SequentialKeyRole : SqlColumnRoleTypes.UnclassifiedRole,
                    ColumnName);

        public static SqlTableColumn CreateSequencedColumn(this SqlSequenceName SequenceName,
            sxc.data_type_ref SequenceType, SqlTableName TableName, int Position = -1,
                bool IsPrimaryKey = true, SqlColumnName ColumnName = null)
                    => CreateSequentialKeyColumn(SequenceName, SequenceType, TableName, Position,  
                        IsPrimaryKey 
                        ? SqlColumnRoleTypes.SequentialKeyRole 
                        : SqlColumnRoleTypes.UnclassifiedRole,
                        ColumnName);

        public static SqlProcedureName ConventialTruncateProcName(this SqlTableName table)
            => new SqlProcedureName($"Truncate{table.UnqualifiedName}").WithSchema(table.SchemaName);

        public static SqlRoutineParameter Declare(this SqlParameterName name, sxc.data_type_ref type, kwt.OUT OUT)
           => new SqlRoutineParameter(name, type, IsOutput: true);

        public static SqlRoutineParameter Declare(this SqlParameterName name, sxc.data_type_ref type, kwt.READONLY READONLY)
            => new SqlRoutineParameter(name, type, IsReadOnly: true);

        public static SqlVariableDeclaration Declare<V>(this SqlVariableName name, typeref type, V value)
             where V : ISyntaxExpression
                 => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type, CoreDataValue value)
                => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type, string value)
                => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type, int value)
                => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type, Date value)
                => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type, DateTime value)
                => new SqlVariableDeclaration(name, type, new SqlVariableInitializer(type, value));

        public static SqlVariableDeclaration Declare(this SqlVariableName name, typeref type)
                => new SqlVariableDeclaration(name, type);

        public static SqlTableTypeRef Reference(this SqlTableTypeName tt)
            => new SqlTableTypeRef(tt);

        public static typeref<T> Reference<T>(this T type, bool nullable)
            where T : sxc.ISqlType
                => new typeref<T>(type, nullable);

        public static typeref<T> Reference<T>(this T type, bool nullable, int length)
            where T : sxc.ISqlType
                => new typeref<T>(type, nullable, length);

        public static typeref<T> Reference<T>(this T type, bool nullable, byte? precision, byte? scale)
            where T : sxc.ISqlType
                => new typeref<T>(type, nullable, precision: precision, scale: scale);

        public static typeref<T> Reference<T>(this T type, bool isNullable = false, int? length = null,
                byte? precision = null, byte? scale = null)
                    where T : sxc.ISqlType
                        => new typeref<T>(type, isNullable, maxlen: length, precision: precision, scale: scale);

        public static typeref<T> Reference<T>(this T type, bool nullable, byte? scale)
            where T : sxc.ISqlType
            => new typeref<T>(type, nullable, precision: null, scale: scale);

        public static typeref<T> Reference<T>(this T type, SqlDataFacets facets)
            where T : sxc.ISqlType
            => new typeref<T>(ReferencedType: type, Facets: facets);
    }

}