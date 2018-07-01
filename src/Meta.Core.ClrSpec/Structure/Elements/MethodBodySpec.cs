//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Specifies a method body
    /// </summary>
    public class MethodBodySpec : ValueObject<MethodBodySpec>
    {
        public MethodBodySpec(string Code)
        {
            this.Code = Code;
        }

        /// <summary>
        /// Source code that defines the body of the method
        /// </summary>
        public string Code { get; }

        public override string ToString()
            => Code;
    }
}