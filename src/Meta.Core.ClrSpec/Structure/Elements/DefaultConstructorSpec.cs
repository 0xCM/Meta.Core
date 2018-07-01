//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes a type's default constructor
    /// </summary>
    public class DefaultConstructorSpec : ConstructorSpec
    {
        public DefaultConstructorSpec(ClrClassName DeclaringTypeName, 
            ClrAccessKind? AccessLevel = null)
                : base(DeclaringTypeName, AccessLevel)
        {

        }
    }
}