//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{

    using Meta.Models;

    public sealed class OperatorName : SimpleName
    {
        public static OperatorName Parse(string s)
            => new OperatorName(s);

        public static implicit operator OperatorName(string x)
            => new OperatorName(x);

        public OperatorName(string Value)
            : base(Value)
        {

        }

        public OperatorName()
            : this(string.Empty)
        { }

    }
}