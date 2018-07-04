//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    
    public sealed class SqlPrimaryKeyName : SqlConstraintName<SqlPrimaryKeyName>
    {
        public static readonly string UriPartIdentifier = "pk";

        public static implicit operator SqlPrimaryKeyName(string s)
            => new SqlPrimaryKeyName(Componetize(s));

        public static implicit operator SqlPrimaryKeyName(SqlObjectName src)
            => new SqlPrimaryKeyName((sxc.ISqlObjectName)src);

        public static implicit operator SqlObjectName(SqlPrimaryKeyName src)
            => new SqlObjectName((sxc.ISqlObjectName)src);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlPrimaryKeyName()
        { }

        protected override SqlPrimaryKeyName CreateFromParts(params string[] parts)
            => new SqlPrimaryKeyName(parts);

        SqlPrimaryKeyName(params string[] parts)
            : base(parts)
        { }

        public SqlPrimaryKeyName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlPrimaryKeyName(ICompositeSqlName SqlName, bool quoted =false)
            : base(SqlName, quoted)
        {

        }

        public SqlPrimaryKeyName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlPrimaryKeyName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlPrimaryKeyName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }


        public SqlPrimaryKeyName(sxc.ISqlObjectName ObjectName)
            : base(ObjectName.ServerNamePart, ObjectName.DatabaseNamePart, ObjectName.SchemaNamePart, ObjectName.UnqualifiedName)
        { }


    }
}