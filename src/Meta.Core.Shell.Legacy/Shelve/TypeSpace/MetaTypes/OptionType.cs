//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Represents an Option Type relative to a <see cref="TypeSpace{S}"/>
    /// </summary>
    /// <typeparam name="S">The declaring space</typeparam>
    /// <typeparam name="X"></typeparam>
    public sealed class OptionType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<OptionType<S, X>, S>(OptionType<S, X> x)
            => new MetaType<OptionType<S, X>, S>(x.Space);

        public OptionType(S Space)
            : base(Space)
        {

        }
    }
}