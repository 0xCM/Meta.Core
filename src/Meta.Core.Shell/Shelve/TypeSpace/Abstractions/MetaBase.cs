//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Base types for Metaclasses 
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="X"></typeparam>
    public abstract class MetaBase<S, X> : IMetaType<S, X>
        where S : ITypeSpace<S>
    {
        protected MetaBase(S Space)
        {
            this.Space = Space;
        }

        public S Space { get; }

        public override string ToString()
            => $"{Space.Name}:{typeof(X).Name}";
    }

}