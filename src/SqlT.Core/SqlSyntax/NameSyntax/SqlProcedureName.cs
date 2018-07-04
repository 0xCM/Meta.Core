//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;
    
    public sealed class SqlProcedureName : SqlObjectName<SqlProcedureName>
    {
        public const string UriPartIdentifier = "procedure";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlProcedureName Parse(string s)
            => SqlObjectName<SqlProcedureName>.Parse(s);

        public static implicit operator SqlProcedureName(string s)
            => Parse(s);

        public SqlProcedureName()
        {

        }

        protected override SqlProcedureName CreateFromParts(params string[] parts)
            => new SqlProcedureName(parts);

        SqlProcedureName(params string[] parts)
            : base(parts)
        { }

        public SqlProcedureName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlProcedureName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlProcedureName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlProcedureName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        {

        }

        public SqlProcedureName(ICompositeSqlName SqlName, bool Quoted = true)
            : base(SqlName,Quoted)
        {

        }

        public override SqlProcedureName OnDatabase(SqlDatabaseName DatabaseName)
            => new SqlProcedureName(
                DatabaseName.ServerName,
                DatabaseName,
                SchemaName,
                UnqualifiedName
                );
    }
}
