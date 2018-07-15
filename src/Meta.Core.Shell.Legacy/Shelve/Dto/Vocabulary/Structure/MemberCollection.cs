//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    public sealed class MemberCollection : TypeMember<TypeMember>, IDtoMemberCollection
    {

        public MemberCollection(string DeclaringEntity, string MemberName, string CollectionType, string ItemType)
            : base(DeclaringEntity, MemberName, CollectionType)
        {

            this.ItemType = ItemType;
        }

        public string ItemType { get; }

    }

    public sealed class MemberCollections : TypedItemList<MemberCollections, MemberCollection>
    {

    }

}
