//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Represents an Interface type relative to a <see cref="TypeSpace{S}"/>
    /// </summary>
    /// <typeparam name="S">The declaring space</typeparam>
    /// <typeparam name="X"></typeparam>
    public sealed class InterfaceType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<InterfaceType<S, X>, S>(InterfaceType<S, X> x)
            => new MetaType<InterfaceType<S, X>, S>(x.Space);

        public InterfaceType(S Space)
            : base(Space)
        {

        }
    }
}