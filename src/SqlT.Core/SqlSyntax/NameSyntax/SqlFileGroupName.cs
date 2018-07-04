//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;


    using SqlT.Syntax;

    public sealed class SqlFileGroupName : SqlName<SqlFileGroupName>, ISimpleSqlName
    {
        public static readonly string UriPartIdentifier = "filegroup";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlFileGroupName Parse(string s)
            => new SqlFileGroupName(s);

        public static implicit operator SqlFileGroupName(string Value)
            => new SqlFileGroupName(Value);

        public SqlFileGroupName(string Value)
            : base(Value)
        { }


        public SqlFileGroupName()
            : this(string.Empty)
        { }
                  


        public SqlFileGroupName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public override string ToString()
            => UnqualifiedName;

    }
}
