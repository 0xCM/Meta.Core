//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class SqlTFactory
    {
        public static string GetSchemaQualifiedName(this TSql.MultiPartIdentifier src)
            => src.ToObjectName().SchemaQualifiedName;

        [SqlTBuilder]
        public static SqlDefaultConstraintName ConstraintName(this TSql.DefaultConstraintDefinition tsql)
            => ifNotNull(tsql.ConstraintIdentifier,
                id => new SqlDefaultConstraintName(id.Value),
                () => SqlDefaultConstraintName.Empty);

        [SqlTBuilder]
        public static SqlUniqueConstraintName ConstraintName(this TSql.UniqueConstraintDefinition tsql)
            => ifNotNull(tsql.ConstraintIdentifier,
                id => new SqlUniqueConstraintName(id.Value),
                () => SqlUniqueConstraintName.Empty);

        [SqlTBuilder]
        public static SqlPrimaryKeyName PrimaryKeyName(this TSql.ConstraintDefinition tsql)
            => ifNotNull(tsql.ConstraintIdentifier,
                id => new SqlPrimaryKeyName(id.Value),
                () => SqlPrimaryKeyName.Empty);


        [SqlTBuilder]
        public static SqlColumnName ColumnName(this TSql.ColumnReferenceExpression tsql)
            => new SqlColumnName(tsql.MultiPartIdentifier.GetLocalName());


        [SqlTBuilder]
        public static SqlTableName ToTableName(this TSql.MultiPartIdentifier tsql)
            => new SqlTableName(tsql.ToObjectName());

        public static SqlObjectName ToObjectName(this TSql.MultiPartIdentifier tsql)
        {
            var identifiers = tsql.Identifiers;
            switch (identifiers.Count)
            {
                case 1: return new SqlObjectName(identifiers[0].Value);
                case 2: return new SqlObjectName(identifiers[0].Value, identifiers[1].Value);
                case 3: return new SqlObjectName(identifiers[0].Value, identifiers[1].Value, identifiers[2].Value);
                case 4: return new SqlObjectName(identifiers[0].Value, identifiers[1].Value, identifiers[2].Value, identifiers[3].Value);
                default:
                    throw new NotSupportedException();
            }
        }

        [SqlTBuilder]
        public static SqlProcedureName ToProcedureName(this TSql.MultiPartIdentifier tsql)
            => tsql.ToObjectName().AsProcedureName();

        [SqlTBuilder]
        public static SqlSequenceName ToSequenceName(this TSql.MultiPartIdentifier tsql)
            => tsql.ToObjectName().AsSequenceName();

        [SqlTBuilder]
        public static SqlIndexName ToIndexName(this TSql.Identifier tsql)
            => new SqlIndexName(tsql.Value);

        [SqlTBuilder]
        public static SqlSchemaName ToSchemaName(this TSql.Identifier tsql)
            => new SqlSchemaName(tsql.Value);

        [SqlTBuilder]
        public static SqlVariableName ToVariableName(this TSql.Identifier tsql)
            => new SqlVariableName(tsql.Value);

        [SqlTBuilder]
        public static SqlTypeName ToTypeName(this TSql.MultiPartIdentifier tsql)
            => SqlTypeName.FromParts(tsql.Identifiers.Select(x => x.Value).ToArray());

        [SqlTBuilder]
        public static SqlDataTypeName ToDataTypeName(this TSql.MultiPartIdentifier tsql)
            => SqlDataTypeName.FromParts(tsql.Identifiers.Select(x => x.Value).ToArray());

        public static string GetLocalName(this TSql.MultiPartIdentifier src)
            => src.Identifiers.Count != 0 ? src.Identifiers.Last().Value : String.Empty;

        [SqlTBuilder]
        public static SqlFunctionName ToFunctionName(this TSql.MultiPartIdentifier tsql)
            => tsql.ToObjectName().AsFunctionName();
    }
}