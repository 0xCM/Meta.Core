//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    partial class BuildSyntax
    {
        public sealed class ItemGroup : Group<ItemGroup>
        {

            public ItemGroup()
                : base(nameof(ItemGroup), string.Empty, string.Empty)
            {
                Members = new List<ItemGroupMember>();
            }

            public ItemGroup(IEnumerable<ItemGroupMember> Members, string Label = null, string Condition = null)
                : base(nameof(ItemGroup), Label, Condition)
            {

                this.Members = Members.ToReadOnlyList();
            }


            public IReadOnlyList<ItemGroupMember> Members { get; set; }


        }

        public sealed class ItemGroups : TypedItemList<ItemGroups, ItemGroup>
        {
            public static implicit operator ItemGroups(ItemGroup[] items)
                => Create(items);

        }

    }


}