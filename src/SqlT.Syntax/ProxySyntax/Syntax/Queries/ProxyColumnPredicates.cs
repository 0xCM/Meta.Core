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

    using Meta.Syntax;
    using SqlT.Core;

    using static sql;

    using static SqlT.Syntax.SqlProxySyntax;
    using static SqlT.Syntax.SqlSyntax;

    using sxc = contracts;
    using ops = SqlSyntax.sqlops;
    using spx = SqlProxySyntax;
    
    partial class SqlProxySytaxExtensions
    {        

        public static column_predicate<C, P> SyntaxBetween<P, C>(this SqlColumnName c, 
            scalar_value lower, scalar_value upper)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => c.SyntaxBetween<P, C>((ISyntaxExpression)lower, (ISyntaxExpression)upper);

        public static column_predicate<C, P> SyntaxBetween<P, C>(this SqlColumnName c, 
                CoreDataValue lower, CoreDataValue upper)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => c.SyntaxBetween<P, C>(new scalar_value(lower), new scalar_value(upper));

        public static column_predicate<C, P> SyntaxBetween<P, C>(this SqlColumnHandle<P, C> h, C lower, C upper)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
        {
            var _lower = ~CoreDataValue.FromObject(lower);
            var _upper = ~CoreDataValue.FromObject(upper);
            return h.ElementName.SyntaxBetween<P, C>(_lower, _upper);
        }

        public static column_predicate<C, P> SyntaxLessThan<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.LT, x));

        public static column_predicate<C, P> SyntaxLessThan<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxLessThan<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxLessThan<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxLessThan<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxGreaterThan<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : IBooleanExpression
            where P : ISqlTabularProxy
            => new column_predicate<C, P>(c, @bool(ops.GT, x));

        public static column_predicate<C, P> SyntaxGreaterThan<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxGreaterThan<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxGreaterThan<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxGreaterThan<P, C>(~CoreDataValue.FromObject(x));

        public static spx.column_predicate<P> SyntaxEqual<P>(this SqlColumnName c, ISyntaxExpression x)
            where P : ISqlTabularProxy, new()
            => new spx.column_predicate<P>(c, @bool(ops.EQ, x));

        public static column_predicate<C, P> SyntaxEqual<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.EQ, x));

        public static column_predicate<C, P> SyntaxEqual<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxEqual<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxEqual<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxEqual<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxNotEqual<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.NEQ, x));

        public static column_predicate<C, P> SyntaxNotEqual<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxNotEqual<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxNotEqual<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxNotEqual<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxLessThanOrEqual<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.LTEQ, x));

        public static column_predicate<C, P> SyntaxLessThanOrEqual<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxLessThanOrEqual<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxLessThanOrEqual<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxLessThanOrEqual<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxGreaterThanOrEqual<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.GTEQ, x));

        public static column_predicate<C, P> SyntaxGreaterThanOrEqual<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxGreaterThanOrEqual<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxGreaterThanOrEqual<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxGreaterThanOrEqual<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxNotLessThan<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.NLT, x));

        public static column_predicate<C, P> SyntaxNotLessThan<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxNotLessThan<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxNotLessThan<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxNotLessThan<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxNotGreaterThan<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
            => new column_predicate<C, P>(c, @bool(ops.NGT, x));

        public static column_predicate<C, P> SyntaxNotGreaterThan<P, C>(this SqlColumnName c, CoreDataValue x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => c.SyntaxNotGreaterThan<P, C>(x.ToSqlLiteral());

        public static column_predicate<C, P> SyntaxNotGreaterThan<P, C>(this SqlColumnHandle<P, C> h, C x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => h.ElementName.SyntaxNotGreaterThan<P, C>(~CoreDataValue.FromObject(x));

        public static column_predicate<C, P> SyntaxBetween<P, C>(this SqlColumnName c, 
                ISyntaxExpression lower, ISyntaxExpression upper)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => new column_predicate<C, P>(c, @bool(ops.BETWEEN, lower, upper));

        public static column_predicate<C, P> SyntaxOr<P, C>(this SqlColumnName c, 
            ISyntaxExpression left, ISyntaxExpression right)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => new column_predicate<C, P>(c, @bool(ops.OR, left, right));

        public static column_predicate<C, P> SyntaxOr<P, C>(this sxc.proxy_column_predicate<P> predicate, 
            Expression<Func<P, C>> selector, ISyntaxExpression right)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => selector.ColumnName().SyntaxOr<P, C>(predicate, right);

        public static column_predicate<C, P> SyntaxNot<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => new column_predicate<C, P>(c, @bool(ops.NOT, x));

        public static column_predicate<C, P> SyntaxNot<P, C>(this sxc.proxy_column_predicate<P> predicate, 
            Expression<Func<P, C>> selector, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => selector.ColumnName().SyntaxNot<P, C>(x);

        public static column_predicate<C, P> SyntaxLike<P, C>(this SqlColumnName c, ISyntaxExpression x)
            where C : column_predicate<C, P>
            where P : ISqlTabularProxy, new()
                => new column_predicate<C, P>(c, @bool(ops.LIKE, x));

        public static column_predicate<C, P> SyntaxLike<P, C>(this sxc.proxy_column_predicate<P> predicate, 
            Expression<Func<P, C>> selector, ISyntaxExpression x)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => selector.ColumnName().SyntaxLike<P, C>(x);

        public static column_predicate<C, P> SyntaxAnd<P, C>(this SqlColumnName c, 
            ISyntaxExpression left, ISyntaxExpression right)
                where P : ISqlTabularProxy, new()
                where C : column_predicate<C, P>
                => new column_predicate<C, P>(c, @bool(ops.AND, left, right));

        public static column_predicate<C, P> SyntaxAnd<P, C>(this sxc.proxy_column_predicate<P> predicate, 
            Expression<Func<P, C>> selector, ISyntaxExpression right)
                where C : column_predicate<C, P>
                where P : ISqlTabularProxy, new()
                    => selector.ColumnName().SyntaxAnd<P, C>(predicate, right);
    }

}