//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    partial class BuildSyntax
    {
        public sealed class LiteralString : Literal<string>
        {
            public static implicit operator LiteralString(string value)
                => new LiteralString(value);

            public static implicit operator string(LiteralString value)
                => value.ToString();

            public LiteralString(string Value, string Left = "\"", string Right = "\"")
                : base(Value, Left, Right)
            { }
        }

    }


}
