//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    /// <summary>
    /// Primitive types are those types for which instantiated values cannot be decomposed 
    /// within the context of the model
    /// </summary>
    public abstract class PrimitiveType<T, V> : DtoType<T, V>
        where T : PrimitiveType<T, V>
        where V : ITypeValue
    {
        protected PrimitiveType(string TypeName)
            : base(TypeName, new TypeMembers())
        {

        }

    }
}
