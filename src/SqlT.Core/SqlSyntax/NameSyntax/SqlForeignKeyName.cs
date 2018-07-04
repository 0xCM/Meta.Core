//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    /// <summary>
    /// Specifies a foreign key name
    /// </summary>
    public sealed class SqlForeignKeyName : SqlConstraintName<SqlForeignKeyName>
    {
        public static readonly string UriPartIdentifier = "fk";

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlForeignKeyName()
        { }

        protected override SqlForeignKeyName CreateFromParts(params string[] parts)
            => new SqlForeignKeyName(parts);

        SqlForeignKeyName(params string[] parts)
            : base(parts)
        { }

        public SqlForeignKeyName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlForeignKeyName(ICompositeSqlName SqlName)
            : base(SqlName)
        {

        }

        public SqlForeignKeyName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlForeignKeyName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlForeignKeyName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }




    }


}