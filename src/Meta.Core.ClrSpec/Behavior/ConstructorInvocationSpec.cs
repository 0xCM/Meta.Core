//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;

using static metacore;

public static partial class ClrBehaviorSpec
{
    /// <summary>
    /// Characterizes a constructor invocation
    /// </summary>
    public class ConstructorInvocationSpec : ExpressionSpec<ConstructorInvocationSpec>
    {
        public ConstructorInvocationSpec(ClrTypeReference TypeReference, params MethodArgumentValueSpec[] Arguments)
        {
            this.TypeReference = TypeReference;
            this.Arguments = rolist(Arguments);
        }

        public ClrTypeReference TypeReference { get; }

        public IReadOnlyList<MethodArgumentValueSpec> Arguments { get; }

    }

}