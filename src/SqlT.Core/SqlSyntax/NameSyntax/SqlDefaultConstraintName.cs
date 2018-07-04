//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public sealed class SqlDefaultConstraintName : SqlConstraintName<SqlDefaultConstraintName>
    {

        public static readonly string UriPartIdentifier = "df";

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlDefaultConstraintName()
        { }

        protected override SqlDefaultConstraintName CreateFromParts(params string[] parts)
            => new SqlDefaultConstraintName(parts);

        SqlDefaultConstraintName(params string[] parts)
            : base(parts)
        { }

        public SqlDefaultConstraintName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlDefaultConstraintName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlDefaultConstraintName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlDefaultConstraintName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }


        public SqlDefaultConstraintName(sxc.ISqlObjectName ObjectName)
            : base(ObjectName.ServerNamePart, ObjectName.DatabaseNamePart, ObjectName.SchemaNamePart, ObjectName.UnqualifiedName)
        { }

 
    }


}