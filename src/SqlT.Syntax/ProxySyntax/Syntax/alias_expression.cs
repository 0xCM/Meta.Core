﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;

    partial class SqlProxySyntax
    {
        public sealed class alias_expression<e, p> : proxy_expression<e, p>
             where e : ISyntaxExpression
             where p : ISqlTabularProxy, new()
        {
            public string name { get; }

            public alias_expression(e operand, string name)
                : base(operand)
            {

                this.name = ifBlank(name, $"Alias_{now().Ticks}");
            }

            public override string ToString()
                => $"{Operand} as {name}";
        }
    }

}