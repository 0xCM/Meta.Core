//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using SqlT.Syntax;

    public sealed class SqlSynonymName : SqlObjectName<SqlSynonymName>
    {
        public static readonly string UriPartIdentifier = "synonym";

        public static new SqlSynonymName Parse(string s)
            => SqlObjectName<SqlSynonymName>.Parse(s);

        public static implicit operator SqlSynonymName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        /// <summary>
        /// For the pleasure of the JSON serializer
        /// </summary>
        public SqlSynonymName()
        { }

        protected override SqlSynonymName CreateFromParts(params string[] parts)
            => new SqlSynonymName(parts);

        SqlSynonymName(params string[] parts)
            : base(true, parts)
        { }

        SqlSynonymName(bool quoted, params string[] parts)
            : base(quoted, parts)
        { }

        public SqlSynonymName(SqlIdentifier LocalName)
            : base(LocalName)
        {

        }

        public SqlSynonymName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlSynonymName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlSynonymName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        {

        }

        public SqlSynonymName(ICompositeSqlName SqlName, bool Quoted = true)
            : base(SqlName, Quoted)
        {

        }
    }
}
