//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

namespace Meta.Core.DTO
{
    public sealed class TypeValue : TypeValue<TypeValue, DtoType>
    {
        public TypeValue()
        {

        }

        public TypeValue(ITypeValue AdaptedValue)
            : base(AdaptedValue.TypeName, AdaptedValue.ModeledValue)
        { }

        public override bool Equals(TypeValue other)
        {
            throw new NotImplementedException();
        }

        protected override int Hash()
        {
            throw new NotImplementedException();
        }
    }


    public sealed class TypeValues : TypedItemList<TypeValues, TypeValue>, ITypeValueList<TypeValue>
    {

    }
}
