//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomMethods : TypedItemList<CustomMethods, ClrCustomMemberIdentifier>
    {
        public static readonly ClrCustomMemberIdentifier GetItemArray = new ClrCustomMemberIdentifier(nameof(GetItemArray));
        public static readonly ClrCustomMemberIdentifier SetItemArray = new ClrCustomMemberIdentifier(nameof(SetItemArray));
    }

}