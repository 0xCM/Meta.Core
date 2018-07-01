//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

namespace Meta.Core.DTO
{

    public sealed class EntityValue : TypeValue<EntityValue, EntityType>
    {

        public EntityValue()
        {

        }

        public EntityValue(string TypeName, MemberValues MemberValues)
            : base(TypeName,MemberValues)
        {

        }
        /// <summary>
        /// The name of the entity
        /// </summary>
        /// <remarks>
        /// The name is intended to distinguish the entity among other entities irrespective
        /// of value semantics. It is analagous to an object reference to a boxed instance of
        /// a CLR value type
        /// </remarks>
        public string EntityName { get; set; }


        public MemberValues MemberValues
            => ModeledValue as MemberValues;

        public override bool Equals(EntityValue other)
        {
            if (other is null || other.TypeName != this.TypeName)
                return false;            

            return MemberValues.Equals(other.MemberValues);
        }

        protected override int Hash()
            => EntityName.GetHashCode() 
            +  MemberValues.GetHashCode();


    }
}
