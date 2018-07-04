//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{


    public sealed class SqlPackageIdentifier : SemanticIdentifier<SqlPackageIdentifier, string>
    {
        public static implicit operator SqlPackageIdentifier(string text)
            => new SqlPackageIdentifier(text);

        protected override SqlPackageIdentifier New(string text)
            => new SqlPackageIdentifier(text);

        SqlPackageIdentifier()
            : base(string.Empty)
        { }


        SqlPackageIdentifier(string value)
            : base(value)
        { }
    }
}