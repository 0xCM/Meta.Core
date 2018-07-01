//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using static metacore;
    
    public static partial class VariableFormatters
    {
        public static readonly ISymbolicFormatter CanonicalFormatter 
            = new Canonical();

        public static readonly ISymbolicFormatter ShellFormatter
            = new ShellCommandFormatter();

        static string Format(IEnumerable<ISymbolicElement> elements, Func<ISymbolicVariable, string> RenderVariable)
        {
            var sb = new StringBuilder();
            foreach (var v in elements)
            {
                switch (v)
                {
                    case ISymbolicVariable sv:
                        sb.Append(RenderVariable(sv));
                        break;
                    default:
                        sb.Append(v.ToString());
                        break;
                }
            }

            var fmt = sb.ToString();
            return fmt;
        }
    }

}