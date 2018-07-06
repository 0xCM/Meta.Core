//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Models;
    using Meta.Syntax;

    partial class SqlSyntax
    {
        public sealed class if_else : Model<if_else>
        {    
            public if_else(IBooleanExpression test_condition, statement_or_block if_part, statement_or_block else_part = null)
            {
                this.test_condition = test_condition;
                this.if_part = if_part;
                this.else_part = else_part;
            }

            public IBooleanExpression test_condition { get; }

            public statement_or_block if_part { get; }


            public ModelOption<statement_or_block> else_part { get; }

            public override string ToString()
                => else_part.map(
                    @else => $"{IF}({test_condition}){if_part}{@else}", 
                    () => $"{IF}({test_condition}){if_part})"
                    );
        }
    }
}