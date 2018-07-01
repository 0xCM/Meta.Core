//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    public sealed class RecordType<S, X> : MetaBase<S, X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<RecordType<S, X>, S>(RecordType<S, X> x)
            => new MetaType<RecordType<S, X>, S>(x.Space);

        public RecordType(S Space)
            : base(Space)
        {
        }
    }

}