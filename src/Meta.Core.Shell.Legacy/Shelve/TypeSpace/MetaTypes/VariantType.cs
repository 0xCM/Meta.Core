//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{   
    public sealed class VariantType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<VariantType<S, X>, S>(VariantType<S, X> x)
            => new MetaType<VariantType<S, X>, S>(x.Space);

        public VariantType(S Space)
            : base(Space)
        {

        }
    }
}