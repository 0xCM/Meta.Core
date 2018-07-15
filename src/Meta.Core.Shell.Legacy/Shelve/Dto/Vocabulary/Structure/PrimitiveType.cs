//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
namespace Meta.Core.DTO
{
    public sealed class PrimitiveType : PrimitiveType<PrimitiveType, PrimitiveValue>
    {

        public PrimitiveType(IDtoPrimitive AdaptedType)
            : base(AdaptedType.TypeName)
        {


        }

        public override PrimitiveValue ParseValue(string text)
        {
            throw new NotImplementedException();
        }

        public override string FormatValue(PrimitiveValue value)
        {
            throw new NotImplementedException();
        }
    }
}
