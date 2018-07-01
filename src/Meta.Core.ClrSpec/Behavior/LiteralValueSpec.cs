//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

public static partial class ClrBehaviorSpec
{

    public sealed class LiteralValueSpec : ExpressionSpec<LiteralValueSpec>
    {
        public static implicit operator CoreDataValue(LiteralValueSpec x) 
            => x.LiteralValue;
        
        public static implicit operator LiteralValueSpec(CoreDataValue x) 
            => new LiteralValueSpec(x);

        public readonly CoreDataValue LiteralValue;

        public LiteralValueSpec(CoreDataValue LiteralValue)
        {
            if (isNull(LiteralValue))
                throw new System.ArgumentNullException();

            this.LiteralValue = LiteralValue;
        }

        public override string ToString()
            => LiteralValue.ToString();
    }


}


