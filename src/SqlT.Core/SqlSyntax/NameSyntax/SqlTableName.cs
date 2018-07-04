//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    using sxc = Syntax.contracts;

    using SqlT.Syntax;

    /// <summary>
    /// Specifies a table name
    /// </summary>
    public sealed class SqlTableName : SqlTabularName<SqlTableName>
    {
        public const string UriPartIdentifier = "table";

        public static SqlTableName Placeholder
            => new SqlTableName("@ServerName", "@DatabaseName", "@SchemaName", "@TableName");

        public static new SqlTableName Parse(string s)
            => new SqlTableName(true, Componetize(s));

        public static implicit operator SqlTableName(string s)
            => Parse(s);

        public static implicit operator SqlObjectName(SqlTableName src)
            => new SqlObjectName((sxc.ISqlObjectName)src);


        public static SqlTableName operator + (SqlDatabaseName database, SqlTableName table)
            => new SqlTableName(database, table);

        public static SqlTableName operator +(SqlServerName server, SqlTableName table)
            => new SqlTableName(new SqlDatabaseName(server, table.DatabaseNamePart), table);



        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlTableName()
        { }

        protected override SqlTableName CreateFromParts(params string[] parts)
            => new SqlTableName(true, parts);

        SqlTableName(bool quoted, params string[] parts)
            : base(quoted, parts)
        { }

        public SqlTableName(SqlIdentifier LocalName)
            : base(LocalName)
        {

        }

        public SqlTableName(SqlIdentifier SchemaName, SqlIdentifier LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlTableName(SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, SchemaName, LocalName)
        {

        }

        public SqlTableName(SqlSchemaName SchemaName, ISimpleSqlName UnqualifiedName, bool quoted = true)
            : base(quoted, SchemaName, UnqualifiedName.Identifier.IdentifierText)
        {

        }

        public SqlTableName(SqlDatabaseName DatabaseName, SqlTableName TableName, bool quoted = true)
            : base(quoted, DatabaseName, DatabaseName, TableName.SchemaName, TableName)
        { }

        public SqlTableName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted)
            : base(quoted, DatabaseName.ServerName, DatabaseName, SchemaName, LocalName)
        { }

        public SqlTableName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName)
            : base(ServerName, DatabaseName, SchemaName, LocalName)
        { }


        public SqlTableName(ICompositeSqlName SqlName, bool quoted = true)
            : base(SqlName, quoted)
        {

        }


        public SqlTableName Rename(string NewName)
            => new SqlTableName(ServerNamePart, DatabaseNamePart, SchemaName, NewName);

        public override SqlTableName OnDatabase(SqlDatabaseName DatabaseName)
            => new SqlTableName(
                DatabaseName.ServerName,
                DatabaseName.UnqualifiedName,
                SchemaNamePart,
                UnqualifiedName
                );


    }
}
