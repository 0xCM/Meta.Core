//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    partial class BuildSyntax
    {
        public abstract class Literal
        {
            protected Literal(object Data, string Left = null, string Right = null)
            {
                this.Data = Data;
                this.Left = Left ?? string.Empty;
                this.Right = Right ?? string.Empty;
            }

            protected object Data { get; }
            protected string Left { get; }
            protected string Right { get; }

            public override string ToString()
                => $"{Left}{Data}{Right}";
        }

        public abstract class Literal<V> : Literal
        {
            protected Literal(V Value, string Left = null, string Right = null)
                : base(Value, Left, Right)
            { }

            public V Value
                => (V)Data;
        }



    }
}
