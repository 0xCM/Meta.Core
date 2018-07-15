//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System.Collections.Generic;


    public interface IDtoType : IDtoValueParser, IDtoValueFormatter
    {
        /// <summary>
        /// The name of the type which must be unique within the scope of the model
        /// </summary>
        string TypeName { get; }


        /// <summary>
        /// Defines the <see cref="IDtoTypeMember"/> members declared on the type
        /// </summary>
        IEnumerable<IDtoTypeMember> Members { get; }
    }

    public interface IDtoType<T> : IDtoType
        where T : IDtoType
    {

    }

    public interface IDtoType<T, V> : IDtoType, IDtoValueParser<V>, IDtoValueFormatter<V>
        where T : IDtoType
        where V : ITypeValue
    {

    }

}
