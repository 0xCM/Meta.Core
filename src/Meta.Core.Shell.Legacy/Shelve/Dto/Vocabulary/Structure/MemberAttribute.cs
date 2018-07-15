//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{

    /// <summary>
    /// Defines a member attribute
    /// </summary>
    public sealed class MemberAttribute : TypeMember<MemberAttribute>, IDtoMemberAttribute
    {

        public MemberAttribute(string DeclaringType, string MemberName, string MemberType)
            : base(DeclaringType, MemberName, MemberType)
        {
        }

    }

    public sealed class MemberAttributes : TypedItemList<MemberAttributes, MemberAttribute>
    {

    }

}
