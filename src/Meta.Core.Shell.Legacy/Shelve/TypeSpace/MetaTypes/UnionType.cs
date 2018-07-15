//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{    
    public sealed class UnionType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<UnionType<S, X>, S>(UnionType<S, X> x)
            => new MetaType<UnionType<S, X>, S>(x.Space);

        public UnionType(S Space)
            : base(Space)
        {
            
        }
    }
}