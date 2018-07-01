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

    partial class VariableFormatters
    {

        public static string Format(this ISymbolicExpression x)
            => CanonicalFormatter.Format(x);

        class Canonical : ISymbolicFormatter
        {                
            public string Format(ISymbolicExpression x)
            {
                var sb = new StringBuilder();
                switch (x)
                {
                    case ISymbolicLiteral l:
                        sb.Append($"{l}");
                        break;
                    case ISymbolicReference r:
                        sb.Append($"$({r.Referent.VariableName})");
                        break;
                    
                    case ISymbolicVariable v:
                        if (not(v.IsAnonymous) && v.Components.Count() == 0)
                            sb.Append($"$({v.VariableName})");
                        else
                            iter(v.Components, c => sb.Append($"{Format(c)}"));
                        break;
                    default:
                        iter(x.Components, c => sb.Append($"{Format(c)}"));
                        break;
                }
                return sb.ToString();
            }
        }
    }

}