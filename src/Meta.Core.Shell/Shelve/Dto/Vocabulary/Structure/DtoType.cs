//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System.Linq;

    public sealed class DtoType : DtoType<DtoType>
    {

        public DtoType(IDtoType AdaptedType)
            : base(AdaptedType.TypeName, TypeMembers.Create(AdaptedType.Members.Select(m => new TypeMember(m))))
        {

        }

    }

    public sealed class DtoTypes : TypedItemList<DtoTypes, DtoType>
    {


    }


}
