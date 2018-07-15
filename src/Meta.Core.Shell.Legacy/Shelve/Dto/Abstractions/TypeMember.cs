//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    public abstract class TypeMember<M> : IDtoTypeMember
        where M : TypeMember<M>
    {

        public TypeMember(string DeclaringType, string MemberName, string MemberType)
        {
            this.DeclaringType = DeclaringType;
            this.MemberName = MemberName;
            this.MemberType = MemberType;
        }

        public string DeclaringType { get; }

        public string MemberName { get; }

        public string MemberType { get; }


        public override string ToString()
            => $"{DeclaringType}::{MemberName} : {MemberType}";


    }


}
