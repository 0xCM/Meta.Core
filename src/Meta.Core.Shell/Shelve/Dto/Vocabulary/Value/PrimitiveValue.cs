//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

namespace Meta.Core.DTO
{
    /// <summary>
    /// Encapsulates the value of a DTO primitive
    /// </summary>
    public sealed class PrimitiveValue : TypeValue<PrimitiveValue, PrimitiveType>
    {

        public PrimitiveValue()
        {

        }

        public PrimitiveValue(string TypeName, object NativeRepresentation)
            : base(TypeName, NativeRepresentation)
        {

        }

        public override bool Equals(PrimitiveValue other)
        {
            throw new NotImplementedException();
        }

        protected override int Hash()
        {
            throw new NotImplementedException();
        }
    }
}
