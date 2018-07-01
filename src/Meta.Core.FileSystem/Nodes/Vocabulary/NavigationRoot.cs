//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{


    /// <summary>
    /// Represents the origin of a hierarchical resource navigator
    /// </summary>
    public abstract class NavigationRoot : INavigationRoot
    {
        protected NavigationRoot(NavigationRootIdentifier RootIdentifier, object Value)
        {
            this.RootIdentifier = RootIdentifier;
            this.Value = Value;
        }
        public NavigationRootIdentifier RootIdentifier { get; }

        object Value { get; }

        object INavigationRoot.Value
            => Value;
        public override string ToString()
            => $"{RootIdentifier} ~ {Value}";

    }

    public abstract class NavigationRoot<V> : NavigationRoot, INavigationRoot<V>        
    {
       protected NavigationRoot(NavigationRootIdentifier RootIdentifier, V Value)
            : base(RootIdentifier, Value)
        {
        }

        public V Value
            => (V)(this as INavigationRoot).Value;


    }



}