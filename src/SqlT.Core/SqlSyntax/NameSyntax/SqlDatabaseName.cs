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
    /// Specifies a database name
    /// </summary>
    public sealed class SqlDatabaseName : SqlName<SqlDatabaseName>
    {
        public const string UriPartIdentifier = "database";

        public static SqlDatabaseName Master(SqlServerName ServerName = null)
            => new SqlDatabaseName(ServerName ?? SqlServerName.Empty, "master");

        public static SqlDatabaseName Msdb(SqlServerName ServerName = null)
            => new SqlDatabaseName(ServerName ?? SqlServerName.Empty, "msdb");


        public static new readonly SqlDatabaseName Empty = new SqlDatabaseName();


        public static new SqlDatabaseName Parse(string s)
            => new SqlDatabaseName(Componetize(s));

        public static implicit operator SqlDatabaseName(string Name)
            =>  Name.EnclosedBy('[', ']') ? Parse(Name) : new SqlDatabaseName(Name);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlDatabaseName()
            : base(false, string.Empty, string.Empty)
        {

        }

        public SqlDatabaseName(ICompositeSqlName SqlName)
            : base(SqlName)
        {

        }

        public SqlDatabaseName(bool quoted, params string[] components)
            : base(quoted, components)
        {

        }


        public SqlDatabaseName(params string[] components)
            : base(components)
        {

        }

        public SqlDatabaseName(SqlServerName ServerName, string CatalogName)
           : base(ServerName, CatalogName)
        {

        }
                     
        public string ServerNamePart
            => NameComponents.Count == 2 ? NameComponents[0] : string.Empty;

        /// <summary>
        /// The name of the server on which the database is hosted, if applicable
        /// </summary>
        public SqlServerName ServerName
            => ServerNamePart;

        public override string FullName
            => CreateFullName(false);

        public bool IsServerQualified
            => NameComponents.Count > 1;        

        public SqlDatabaseName HostedBy(SqlServerName ServerName)
            => new SqlDatabaseName(ServerName, UnqualifiedName);

        public SqlDatabaseName TrimServer()             
            => new SqlDatabaseName(UnqualifiedName);

        public SqlTableName ResolvedTable(SqlTableName src)
            => src.OnDatabase(this);
        public SqlDatabaseName Shadow()
            => new SqlDatabaseName(ServerNamePart, $"{UnqualifiedName}.Shadow");

    }


}