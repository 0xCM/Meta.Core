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
    /// Specifies a function name
    /// </summary>
    public sealed class SqlFunctionName : SqlObjectName<SqlFunctionName>
    {
        public const string UriPartIdentifier = "functions";

        public static implicit operator SqlFunctionName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlFunctionName()
        { }

        protected override SqlFunctionName CreateFromParts(params string[] parts)
            => new SqlFunctionName(Quoted, parts);

        SqlFunctionName(bool Quoted, params string[] parts)
            : base(Quoted, parts)
        { }

        public SqlFunctionName(string LocalName, bool quoted = false)
            : base(quoted, LocalName)
        {

        }

        public SqlFunctionName(ICompositeSqlName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        { }

        public SqlFunctionName(SqlSchemaName SchemaName, string LocalName, bool quoted = false)
            : base(SchemaName, LocalName, quoted)
        { }

        public SqlFunctionName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = false)
            : base(DatabaseName, SchemaName, LocalName, quoted)
        { }

        public SqlFunctionName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = false)
            : base(ServerName, DatabaseName, SchemaName, LocalName, quoted)
        { }


        public SqlFunctionName(sxc.ISqlObjectName ObjectName, bool quoted = false)
            : base(ObjectName.ServerNamePart, ObjectName.DatabaseNamePart, ObjectName.SchemaNamePart, ObjectName.UnqualifiedName, quoted)
        { }



    }
}
