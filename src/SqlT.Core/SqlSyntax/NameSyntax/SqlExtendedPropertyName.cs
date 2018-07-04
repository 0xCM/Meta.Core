//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using N = SqlExtendedPropertyName;

    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    public sealed class SqlExtendedPropertyName : SqlName<N>, ISimpleSqlName
    {
        public static readonly string UriPartIdentifier = "xprop";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new N Parse(string Identifier)
            => new N(Identifier);

        public static N FromParts(string Identifier)
            => new N(Identifier);


        public static implicit operator N(string Identifier)
            => Parse(Identifier);


        public SqlExtendedPropertyName()
            : this(string.Empty)
        {

        }

        public SqlExtendedPropertyName(string Identifier)
            : base(Identifier)
        {

        }



        public override string FullName
            => CreateFullName(false);
    }
}
