//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Syntax;

    
    public sealed class SqlParameterName : SqlName<SqlParameterName>
    {

        public const string UriPartIdentifier = "parameter";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlParameterName Parse(string s)
            => new SqlParameterName(s);

        public static implicit operator SqlParameterName(string Value)
            => new SqlParameterName(Value);

        public SqlParameterName()
            : this(string.Empty)

        {

        }

        public SqlParameterName(IName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        {


        }

        public SqlParameterName(ICompositeSqlName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        {


        }

        public SqlParameterName(string Value)
            : base(Value.StartsWith("@") ? Value : $"@{Value}")
        { }

        public override string ToString()
            => UnqualifiedName;

        public string UnadornedName
            => UnqualifiedName.Replace("@", string.Empty);

    }
}
