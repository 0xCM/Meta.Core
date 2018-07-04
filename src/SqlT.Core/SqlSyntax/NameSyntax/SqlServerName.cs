//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;

    public sealed class SqlServerName : SqlName<SqlServerName>, ISimpleSqlName
    {
        public const string UriPartIdentifier = "server";

        public static SqlDatabaseName operator +(SqlServerName server, SqlDatabaseName db)
            => new SqlDatabaseName(server, db.UnqualifiedName);

        public static new SqlServerName Parse(string s)
            => new SqlServerName(s);

        public static implicit operator SqlServerName(string x)
            => new SqlServerName(x);

        public static readonly SqlServerName LocalHost = new SqlServerName("localhost");

        protected override string UriComponentName
            => UriPartIdentifier;


        public SqlServerName()
            : this(string.Empty)
        { }

        public SqlServerName(string Name)
            : base(Name)
        {

        }

        public override string FullName
            => CreateFullName(false);

        public bool IsLocalHost
            => UnqualifiedName == LocalHost.UnqualifiedName;

        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


        public SqlDatabaseName MasterDatabase
            => SqlDatabaseName.Master(this);

        public SqlDatabaseName ResolvedDatabase(SqlDatabaseName dbName)
            => this + dbName;
    }


}