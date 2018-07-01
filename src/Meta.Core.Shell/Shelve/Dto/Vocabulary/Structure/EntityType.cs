//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System;

    public sealed class EntityType : DtoType<EntityType, EntityValue>
    {
        public EntityType(string TypeName, TypeMembers Members)
            : base(TypeName, Members)
        {
            
        }



        public override EntityValue ParseValue(string text)
        {
            throw new NotImplementedException();
        }

        public override string FormatValue(EntityValue value)
        {
            throw new NotImplementedException();
        }
    }
}
