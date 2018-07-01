//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public static partial class ClrBehaviorSpec
{

    /// <summary>
    /// Base type for expression specifiers
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class ExpressionSpec<T> : ValueObject<T>, IClrExpressionSpec
        where T : ExpressionSpec<T>
    {

    }


}


