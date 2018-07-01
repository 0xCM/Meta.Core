//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System.Collections.Generic;


    partial class BuildSyntax
    {
        public sealed class PropertyGroup : Group<PropertyGroup>
        {

            public PropertyGroup()
                : base(nameof(PropertyGroup), string.Empty, string.Empty)
            {
                Properties = new PropertyGroupMembers();
            }

            public PropertyGroup(IEnumerable<PropertyGroupMember> Properties, string Label = null, string Condition = null)
                : base(nameof(PropertyGroup), Label, Condition)
            {
                this.Properties = PropertyGroupMembers.Create(Properties);
            }

            public PropertyGroupMembers Properties { get; set; }

        }

        public sealed class PropertyGroups : TypedItemList<PropertyGroups, PropertyGroup>
        {
            public static implicit operator PropertyGroups(PropertyGroup[] items)
                => Create(items);

        }


    }
}
