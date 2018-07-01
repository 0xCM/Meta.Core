//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

namespace Meta.Core.DTO
{
    /// <summary>
    /// Defines the structural contract to which members defined on a DTO type must adhere
    /// </summary>
    public interface IDtoTypeMember
    {
        string DeclaringType { get; }

        /// <summary>
        /// The name of the member, unique within the scope of the declaring type
        /// </summary>
        string MemberName { get; }

        /// <summary>
        /// The name of the type, unique within the scope of the model
        /// </summary>
        string MemberType { get; }

    }


}
