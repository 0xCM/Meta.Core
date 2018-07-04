//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using X = SqlProxyProfileIdentifier;
    using I = System.String;

    public sealed class SqlProxyProfileIdentifier : SemanticIdentifier<X, I>
    {
        public static implicit operator X(I x)
            => new X(x);

        protected override X New(I IdentifierText)
            => new X(IdentifierText);

        public RelativePath Location
            => RelativePath.Parse(IdentifierText);

        SqlProxyProfileIdentifier(I text)
            : base(text)
        {

        }
    }

}