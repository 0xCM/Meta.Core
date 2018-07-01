﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    partial class BuildSyntax
    {

        public sealed class ItemGroupMember : ItemGroupMember<ItemGroupMember>
        {
            public static implicit operator string(ItemGroupMember v)
                => v.ToString();


            public ItemGroupMember()
                : base(string.Empty, null, string.Empty, string.Empty)
            {
            }

            public ItemGroupMember(string ElementName, ISymbolicExpression ElementContent, string Label, string Condition)
                : base(ElementName, ElementContent, Label, Condition)
            {
            }


            public ItemGroupMember Rename(string NewName)
                => new ItemGroupMember(NewName, ElementContent, string.Empty, Condition);

        }

    }


}