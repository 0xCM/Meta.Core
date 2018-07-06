//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Text;
    
    using SqlT.Core;

    using static SqlProxySyntax;

    
    public abstract class SqlFilter
    {
        public static SqlFilter<T> Equals<T>(Expression<Func<T, object>> ColumnSelector, CoreDataValue Value)
            where T : class, ISqlTabularProxy, new()
            => new SqlFilter<T>(ColumnSelector.ColumnName().SyntaxEqual<T>(Value.ToSqlLiteral()));
    }

    public sealed class SqlFilter<T> : ISqlFilter<T>
        where T : class, ISqlTabularProxy, new()
    {   
        public SqlFilter(params column_predicate<T>[] Predicates)
        {
            this.Predicates = Predicates.ToReadOnlyList();
        }

        public IReadOnlyList<column_predicate<T>> Predicates { get; }

        public string FormatSyntax()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Predicates.Count; i++)
            {
                var p = Predicates[i];
                var syntax = i == 0 
                    ? p.FormatSyntax() 
                    : " and " + p.FormatSyntax();
                sb.Append(syntax);
            }
            return sb.ToString();    
        }

        public override string ToString()
            => FormatSyntax();
    }
}