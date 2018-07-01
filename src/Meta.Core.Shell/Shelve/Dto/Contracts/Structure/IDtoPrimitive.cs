//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    /// <summary>
    /// Designates a DTO primitive, a DTO type that is indecomposible within the context of the model.
    /// As such, it has no associations with other non-primitive types (but may be associated
    /// with other primitive types)
    /// </summary>
    public interface IDtoPrimitive : IDtoType
    {

    }
}
