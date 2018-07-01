//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Represents an Intersection Type relative to a <see cref="TypeSpace{S}"/>
    /// </summary>
    /// <typeparam name="S">The declaring space</typeparam>
    /// <typeparam name="X"></typeparam>
    public sealed class IntersectionType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<IntersectionType<S, X>, S>(IntersectionType<S, X> x)
            => new MetaType<IntersectionType<S, X>, S>(x.Space);

        public IntersectionType(S Space)
            : base(Space)
        {

        }
    }
}