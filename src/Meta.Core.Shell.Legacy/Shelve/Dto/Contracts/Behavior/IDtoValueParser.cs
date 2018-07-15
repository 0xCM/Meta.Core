//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    public interface IDtoValueParser
    {
        /// <summary>
        /// Transforms a value of the type into a textual representation
        /// </summary>
        /// <param name="text">A textual representation of a type value</param>
        /// <returns></returns>
        object ParseValue(string text);
    }

    public interface IDtoValueParser<V> : IDtoValueParser
        where V : ITypeValue
    {
        new V ParseValue(string text);
    }

}
