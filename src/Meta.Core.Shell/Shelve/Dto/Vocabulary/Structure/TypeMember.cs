//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{

    /// <summary>
    /// A surrogate/adapter for any <see cref="TypeMember{M}"/> specialization
    /// </summary>
    public sealed class TypeMember : TypeMember<TypeMember>, IDtoTypeMember
    {

        public TypeMember(IDtoTypeMember AdaptedMember)
            : base(AdaptedMember.DeclaringType, AdaptedMember.MemberName, AdaptedMember.MemberType)
        {
        }

    }

    public sealed class TypeMembers : TypedItemList<TypeMembers, TypeMember>
    {

    }

}