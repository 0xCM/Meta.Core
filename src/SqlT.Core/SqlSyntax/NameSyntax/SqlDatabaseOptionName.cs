//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using sxc = SqlT.Syntax.contracts;

    using N = SqlDatabaseOptionName;

    using SqlT.Syntax;

    public sealed class SqlDatabaseOptionName : SqlName<N>
    {
        public static readonly string UriPartIdentifier = "dboption";

        public new static N Parse(string s)
            => new N(Componetize(s));

        public static implicit operator N(string LocalName)
            => new N(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlDatabaseOptionName()
            : this(string.Empty)
        {

        }

        public SqlDatabaseOptionName(params string[] components)
            : base(components)
        {

        }


        public override string FullName
            => CreateFullName(false);


        public override bool Equals(object other)
        {
            if (!IsComparable(other))
                return false;
            var left = this as N;
            var right = other as N;
            return string.Compare(left.UnqualifiedName, right.UnqualifiedName, true) == 0;
        }

        public override int GetHashCode()
            => typeof(N).GetHashCode()
            & UnqualifiedName.GetHashCode();

    }


}