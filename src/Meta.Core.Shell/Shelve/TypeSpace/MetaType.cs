//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{

    public sealed class MetaType<M, S>
        where M : IMetaType<S>
        where S : ITypeSpace<S>
    {

        public MetaType(S Space)
        {

            this.Space = Space;
        }

        public S Space { get; }

    }
 
}