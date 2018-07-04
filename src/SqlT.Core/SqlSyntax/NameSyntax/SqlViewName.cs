//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using SqlT.Syntax;

    public sealed class SqlViewName : SqlTabularName<SqlViewName>, sxc.tabular_name
    {
        public const string UriPartIdentifier = "view";

        public static new SqlViewName Parse(string s)
            => FromParts(Componetize(s));

        public static SqlViewName FromParts(params string[] parts)
            => new SqlViewName(true, parts);

        public static implicit operator SqlViewName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlViewName()
        { }

        protected override SqlViewName CreateFromParts(params string[] parts)
            => new SqlViewName(true, parts);

        SqlViewName(bool quoted, params string[] parts)
            : base(quoted, parts)
        { }

        public SqlViewName(SqlIdentifier UnqualifiedName)
            : base(UnqualifiedName)
        {

        }

        public SqlViewName(SqlSchemaName SchemaName, string UnqualifiedName)
            : base(SchemaName, UnqualifiedName)
        {

        }

        public SqlViewName(string DatabaseNamePart, SqlSchemaName SchemaName, string UnqualifiedName)
            : base(DatabaseNamePart, SchemaName, UnqualifiedName)
        { }

        public SqlViewName(SqlDatabaseName DatabaseName, SqlViewName ViewName)
            : base(DatabaseName.ServerNamePart, DatabaseName.UnqualifiedName, ViewName.SchemaNamePart, ViewName.UnqualifiedName)
        { }


        public SqlViewName(string ServerNamePart, string DatabaseNamePart, string SchemaNamePart, string UnqualifiedName)
            : base(ServerNamePart, DatabaseNamePart, SchemaNamePart, UnqualifiedName)
        { }

        public SqlViewName(ICompositeSqlName ObjectName, bool quoted = true)
            : base(ObjectName, true)
        { }

        public SqlViewName Rename(string NewName)
            => new SqlViewName(ServerNamePart, DatabaseNamePart, SchemaName, NewName);

    }
}
