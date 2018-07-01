//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Identifies a resource navigation root
    /// </summary>
    public sealed class NavigationRootIdentifier : SemanticIdentifier<NavigationRootIdentifier, string>
    {
        public static implicit operator NavigationRootIdentifier(string x)
            => new NavigationRootIdentifier(x);

        protected override NavigationRootIdentifier New(string IdentifierText)
            => new NavigationRootIdentifier(IdentifierText ?? string.Empty);


        NavigationRootIdentifier()
            : base(string.Empty)
        { }

        public NavigationRootIdentifier(string text)
            : base(text)
        {

        }

    }


}