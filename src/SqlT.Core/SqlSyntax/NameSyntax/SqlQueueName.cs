//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using SqlT.Syntax;
    using sxc = Syntax.contracts;
    
    public class SqlQueueName : SqlObjectName<SqlQueueName>
    {
        public static readonly string UriPartIdentifier = "queue";

        public static new SqlQueueName Parse(string s)
            => new SqlQueueName(Componetize(s));

        public static SqlQueueName FromParts(params string[] parts)
            => new SqlQueueName(parts);


        public static implicit operator SqlQueueName(string s)
            => Parse(s);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlQueueName()
        { }


        protected override SqlQueueName CreateFromParts(params string[] parts)
            => FromParts(parts);

        SqlQueueName(params string[] parts)
            : base(true, parts)
        { }


        public SqlQueueName(ICompositeSqlName SqlName, bool quoted = true)
            : base(SqlName, quoted)
        {

        }



        public SqlQueueName(
            SqlServerName ServerNamePart,
            SqlDatabaseName DatabaseNamePart,
            SqlSchemaName SchemaNamePart,
            string UnqualifiedName)
            : base(ServerNamePart, DatabaseNamePart, SchemaNamePart, UnqualifiedName)
        {

        }




    }


}