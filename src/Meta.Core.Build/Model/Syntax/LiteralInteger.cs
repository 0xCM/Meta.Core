//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    partial class BuildSyntax
    {
        sealed class LiteralInteger : Literal<int>
        {
            public static implicit operator LiteralInteger(int x)
                => new LiteralInteger(x);

            public static implicit operator string(LiteralInteger x)
                => x.ToString();

            public LiteralInteger(int Value)
                : base(Value) { }


        }

    }


}
