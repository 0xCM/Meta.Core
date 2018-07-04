//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    public sealed class SqlSchemaName : SqlName<SqlSchemaName>, ISimpleSqlName
    {
        public const string UriPartIdentifier = "schema";

        public static SqlSchemaName sys = new SqlSchemaName("sys");

        public static new readonly SqlSchemaName Empty = new SqlSchemaName();

        public static implicit operator SqlIdentifier(SqlSchemaName name)
            => new SqlIdentifier(name.UnquotedLocalName, name.quoted);


        public static new SqlSchemaName Parse(string s)
            => new SqlSchemaName(s);


        public static implicit operator SqlSchemaName(string LocalName)
            => new SqlSchemaName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlSchemaName()
        { }

        public SqlSchemaName(string LocalName)
            : base(LocalName)
        {

        }

        public SqlSchemaName(ICompositeSqlName SqlName)
            : base(SqlName)
        {

        }

        public override string FullName
            => CreateFullName(false);


        public bool IsSystemSchema
            => string.Compare(UnqualifiedName, sys.UnquotedLocalName, true) == 0;



        public SqlTableName WithTable(SqlTableName table)
            => new SqlTableName(this.ServerNamePart, this.DatabaseNamePart, UnqualifiedName, table.UnquotedLocalName);

        public bool IsDatabaseQualified
            => NameComponents.Count >= 2;

        public bool IsServerQualified
            => NameComponents.Count >= 3;


        public string ServerNamePart
        {
            get
            {
                var StandardPosition = 3;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return string.Empty;
            }

        }

        public string DatabaseNamePart
        {
            get
            {
                var StandardPosition = 2;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return string.Empty;
            }

        }

    }
}
