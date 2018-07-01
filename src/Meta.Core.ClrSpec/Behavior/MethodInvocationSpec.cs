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
    /// Characterizes a method invocation expression
    /// </summary>
    public class MethodInvocationSpec : ExpressionSpec<MethodInvocationSpec>
    {

        public MethodInvocationSpec(IClrElementName DeclaringTypeName, ClrMethodName MethodName, 
                bool IsStatic, params MethodArgumentValueSpec[] ArgumentValues
            )
        {
            this.TypeName = DeclaringTypeName;
            this.MethodName = MethodName;
            this.IsStatic = IsStatic;
            this.ArgumentValues = rovalues(ArgumentValues);
        }

        public IClrElementName TypeName { get; }

        public ClrMethodName MethodName { get; }

        public bool IsStatic { get; }

        public IReadOnlyList<MethodArgumentValueSpec> ArgumentValues { get; }

    }

    
}
