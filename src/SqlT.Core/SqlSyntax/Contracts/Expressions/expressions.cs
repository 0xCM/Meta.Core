//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;

    public static partial class contracts
    {
        public interface named_expression : ISyntaxExpression
        {
            IName name { get; }
        }

        public interface numeric_expression : ISyntaxExpression { }

        public interface scalar_expression : ISyntaxExpression { }

        public interface literal_value : scalar_expression
        {
            object value { get; }

        }

        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/data-types/constants-transact-sql
        /// </summary>
        /// <typeparam name="v">The literal type</typeparam>
        public interface literal_value<v> : literal_value, scalar_expression
        {
            new v value { get; }
        }

        public interface comparison_expression : IBinaryExpression, IBooleanExpression
        {
            IComparisonOperator op { get; }
        }


        public interface column_ref : scalar_expression, IModelReference<SqlColumnName> { }

        public interface value_expression : ISyntaxExpression { }
                     
    }
}

