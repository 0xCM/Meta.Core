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
        class ShellCommandFormatter : ISymbolicFormatter
        {
            static string Format(IEnumerable<ISymbolicElement> elements)
                => VariableFormatters.Format(elements, v => $"%{v.VariableName}%");

            public string Format(ISymbolicVariable x)
                => Format(x.Components.Count() == 1
                    ? x.Expand()
                    : x.ExpandComponents());

            public string Format(ISymbolicExpression x)
                => Format(x.Components);
        }
    }
}