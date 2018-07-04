//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Specifies a unique constraint name
    /// </summary>
    public sealed class SqlUniqueConstraintName : SqlConstraintName<SqlUniqueConstraintName>
    {
        public const string UriPartIdentifier = "uq";

        public static SqlUniqueConstraintName FromParts(params string[] parts)
            => new SqlUniqueConstraintName(parts);

        public static new SqlUniqueConstraintName Parse(string s)
            => FromParts(Componetize(s));

        protected override string UriComponentName
            => UriPartIdentifier;


        /// <summary>
        /// For the pleasure of the JSON serializer
        /// </summary>
        public SqlUniqueConstraintName()
        { }

        protected override SqlUniqueConstraintName CreateFromParts(params string[] parts)
            => new SqlUniqueConstraintName(parts);

        SqlUniqueConstraintName(params string[] parts)
            : base(parts)
        { }

        public SqlUniqueConstraintName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlUniqueConstraintName(SqlSchemaName SchemaName, string LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlUniqueConstraintName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(DatabaseName, SchemaName, LocalName)
        { }

        public SqlUniqueConstraintName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }


        public SqlUniqueConstraintName(sxc.ISqlObjectName ObjectName)
            : base(ObjectName.ServerNamePart, ObjectName.DatabaseNamePart, ObjectName.SchemaNamePart, ObjectName.UnqualifiedName)
        { }


 
    }


}