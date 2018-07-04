//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using SqlT.Syntax;

    public class SqlDataTypeName : SqlTypeName<SqlDataTypeName>
    {
        public const string UriPartIdentifier = "datatype";

        public static new SqlDataTypeName Parse(string s)
            => new SqlDataTypeName(Componetize(s));

        public static SqlDataTypeName FromParts(params string[] parts)
            => new SqlDataTypeName(parts);


        public static implicit operator SqlDataTypeName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlDataTypeName()

        { }

        protected override SqlDataTypeName CreateFromParts(params string[] parts)
            => FromParts(parts);

        SqlDataTypeName(params string[] parts)
            : base(parts)
        { }


        public SqlDataTypeName(ICompositeSqlName SqlName, bool quoted = true)
            : base(SqlName, quoted)
        {

        }

        public SqlDataTypeName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlDataTypeName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }


        public SqlDataTypeName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        {

        }

    }


}