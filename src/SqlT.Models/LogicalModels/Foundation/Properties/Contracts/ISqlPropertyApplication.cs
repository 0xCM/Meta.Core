//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    using SqlT.Core;
    using SqlT.SqlSystem;


    public interface ISqlPropertyApplication
    {
        ISqlCustomProperty Property { get; }

        IExtensibleElement Element { get; }
    }

    public interface ISqlPropertyApplication<out P, out V, out E> : ISqlPropertyApplication
        where P : ISqlCustomProperty<V>
        where E : IExtensibleElement
    {
        new P Property { get; }

        new E Element { get; }
    }

}