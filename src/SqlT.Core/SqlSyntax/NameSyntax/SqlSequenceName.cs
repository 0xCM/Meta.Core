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
    /// Specifies a sequence name
    /// </summary>
    public sealed class SqlSequenceName : SqlObjectName<SqlSequenceName>, sxc.sequence_name
    {
        public static readonly string UriPartIdentifier = "sequence";

        public static new SqlSequenceName Parse(string s)
            => SqlObjectName<SqlSequenceName>.Parse(s);

        public static implicit operator SqlSequenceName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlSequenceName()
        { }

        protected override SqlSequenceName CreateFromParts(params string[] parts)
            => new SqlSequenceName(parts);

        SqlSequenceName(params string[] parts)
            : base(parts)
        { }

        public SqlSequenceName(string UnqualifiedName)
            : base(UnqualifiedName)
        {

        }

        public SqlSequenceName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        {

        }          


        public SqlSequenceName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlSequenceName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        {

        }


        public SqlSequenceName(ICompositeSqlName SqlName, bool Quoted = true)
            : base(SqlName,Quoted)
        {

        }


    }
}
