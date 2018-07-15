//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Represents a Primitive Type relative to a <see cref="TypeSpace{S}"/>
    /// </summary>
    /// <typeparam name="S">The defining space</typeparam>
    /// <typeparam name="X"></typeparam>
    public sealed class PrimitiveType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<PrimitiveType<S, X>, S>(PrimitiveType<S, X> x)
            => new MetaType<PrimitiveType<S, X>, S>(x.Space);

        public PrimitiveType(S Space)
            : base(Space)
        {
        }        
    }
}