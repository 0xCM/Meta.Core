//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Linq;
    partial class BuildSyntax
    {
        public class PropertyGroupMember :  PropertyGroupMember<PropertyGroupMember>  
        {
            

            public PropertyGroupMember(string Name, ISymbolicExpression Value, string Label, string Condition)
                : base(Name, Value, Label, Condition)
            {
                this.Value = Value;
            }

            public PropertyGroupMember(SymbolicVariable Value, string Label = null, string Condition = null)
                : base(Value, Label, Condition)
            {
                this.Value = Value;

            }


            public ISymbolicExpression Value { get; set; }

            public override string ToString()
            {
                return $"{this.ElementName} = {Value.Format()}";
            }

        }

        public sealed class PropertyGroupMembers : TypedItemList<PropertyGroupMembers, PropertyGroupMember>
        {
            public static implicit operator PropertyGroupMembers(PropertyGroupMember[] items)
                => Create(items);
        }

    }
}