//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypeAttribute : TypeMember<TypeAttribute>
    {
        public TypeAttribute(TypeMember MemberType)
        {
            this.MemberType = MemberType;
        }

        public TypeMember MemberType { get; }
    }


}