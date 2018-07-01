//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
namespace Meta.Core.DTO
{
    public sealed class CollectionType : DtoType<CollectionType, CollectionValue>
    {
        public CollectionType(string ItemType)
            : base($"Collection<{ItemType}>", new TypeMembers())
        {
            this.ItemType = ItemType;
        }

        public string ItemType { get; }

        public override CollectionValue ParseValue(string text)
        {
            throw new NotImplementedException();
        }

        public override string FormatValue(CollectionValue value)
        {
            throw new NotImplementedException();
        }
    }
}
