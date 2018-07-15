//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    public sealed class EnumerationLiteral
    {
        public EnumerationLiteral(string DeclaringType, string LiteralName, string LiteralType)
        {
            this.DeclaringType = DeclaringType;
            this.LiteralName = LiteralName;
            this.LiteralType = LiteralType;
        }

        public string DeclaringType { get; }

        public string LiteralName { get; }

        public string LiteralType { get; }

        public override string ToString()
            => $"{DeclaringType}::{LiteralName} : {LiteralType}";
    }

    public sealed class EnumerationLiterals : TypedItemList<EnumerationLiterals, EnumerationLiteral>
    {
        public static implicit operator string(EnumerationLiterals src)
            => src.ToString();
    }

}
