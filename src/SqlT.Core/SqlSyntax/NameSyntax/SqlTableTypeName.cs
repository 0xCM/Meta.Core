//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using SqlT.Syntax;

    /// <summary>
    /// Specifies a table type name
    /// </summary>
    public class SqlTableTypeName : SqlTypeName<SqlTableTypeName>, sxc.tabular_name
    {
        public const string UriPartIdentifier = "tabletype";

        public static new SqlTableTypeName Parse(string s)
            => new SqlTableTypeName(Componetize(s));

        public static SqlTableTypeName FromParts(params string[] parts)
            => new SqlTableTypeName(parts);


        public static implicit operator SqlTableTypeName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlTableTypeName()

        { }

        protected override SqlTableTypeName CreateFromParts(params string[] parts)
            => FromParts(parts);

        SqlTableTypeName(params string[] parts)
            : base(parts)
        { }


        public SqlTableTypeName(ICompositeSqlName SqlName, bool quoted = true)
            : base(SqlName, quoted)
        {

        }

        public SqlTableTypeName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlTableTypeName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }


        public SqlTableTypeName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        {

        }

    }


}