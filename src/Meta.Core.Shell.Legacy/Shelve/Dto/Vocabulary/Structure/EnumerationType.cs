//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System;
    using static metacore;

    public sealed class EnumerationType : PrimitiveType<EnumerationType, EnumerationValue>
    {
        public EnumerationType(string TypeName, string LiteralTypeName, EnumerationLiterals DeclaredLiterals)
            : base(TypeName)
        {
            this.LiteralTypeName = LiteralTypeName;
            this.DeclaredLiterals = DeclaredLiterals;
        }


        public string LiteralTypeName { get; }


        public EnumerationLiterals DeclaredLiterals { get; }

        public override EnumerationValue ParseValue(string text)
        {
            throw new NotImplementedException();
        }

        public override string FormatValue(EnumerationValue value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
            => $"{TypeName}{embrace(DeclaredLiterals)}";
    }

    public sealed class EnumerationTypes : TypedItemList<EnumerationTypes, EnumerationType>
    {

    }

}
