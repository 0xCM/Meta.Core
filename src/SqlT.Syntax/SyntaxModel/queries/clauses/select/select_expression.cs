//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;

    using static metacore;

    partial class SqlSyntax
    {
        /// <summary>
        /// Represents an item in a select list
        /// </summary>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/queries/select-clause-transact-sql
        /// </remarks>
        public class select_expression : SyntaxExpression<select_expression>
        {
            
            public select_expression(SyntaxExpression value, SimpleSqlName? alias = null, bool alias_assignment = false)
            {
                this.expression = value;
                this.alias = alias.HasValue ? ModelOption.some(alias.Value) : ModelOption.none<SimpleSqlName>();
                this.alias_assignment = alias_assignment;
            }

            public select_expression(ISyntaxExpression value, SimpleSqlName? alias = null, bool alias_assignment = false)
            {
                this.expression = new SyntaxExpression(value);
                this.alias = alias.HasValue ? ModelOption.some(alias.Value) : ModelOption.none<SimpleSqlName>();
                this.alias_assignment = alias_assignment;
            }

            public SyntaxExpression expression { get; }

            public ModelOption<SimpleSqlName> alias { get; }

            public bool alias_assignment { get; }

            public override string ToString()
                => alias.map(a 
                        => alias_assignment 
                        ? $"{alias} = {expression}" 
                        : $"{alias} as {expression}", 
                    () => $"{expression}");
        }
    }

}