//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Meta.Core.DTO
{
    public sealed class CollectionValue : TypeValue<CollectionValue, CollectionType>
    {
        public CollectionValue()
        { }


        public CollectionValue(string TypeName, TypeValues Items)
            : base(TypeName, Items)
        {

        }

        public CollectionValue(string TypeName, IEnumerable<TypeValue> Items)
            : this(TypeName, TypeValues.Create(Items))
        {

        }


        public TypeValues Items
            => (TypeValues)base.ModeledValue;

        public override bool Equals(CollectionValue other)
            => Items.Equals(other);

        protected override int Hash()
        {
            throw new NotImplementedException();
        }
    }
}
