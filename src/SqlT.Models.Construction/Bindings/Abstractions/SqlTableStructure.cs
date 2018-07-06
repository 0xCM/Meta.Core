//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Syntax.SqlNativeTypeRefs;

    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlTable<T, S> : SqlTable<T>
       where T : SqlTable<T, S>, new()
       where S : SqlSchema<S>
    {

        protected SqlTable()
            : base(new SqlTableName(typeof(S).Name, typeof(T).Name))
        {
            this.Schema = Schema;
        }

        protected SqlTable(S Schema)
            : base(new SqlTableName(Schema.Name, typeof(T).Name))
        {
            this.Schema = Schema;
        }

        protected SqlTable(S Schema, ISimpleSqlName table_name)
            : base(new SqlTableName(Schema.Name, table_name))
        {
            this.Schema = Schema;
        }

        public S Schema { get; }

        public class Column
        {
            public static implicit operator Column(INT TypeRef)
                => new Column(TypeRef);

            public static implicit operator Column(NVARCHAR TypeRef)
                => new Column(TypeRef);

            public static implicit operator Column(VARCHAR TypeRef)
                => new Column(TypeRef);

            public static implicit operator Column(DATETIME2 TypeRef)
                => new Column(TypeRef);

            public static implicit operator Column(BIGINT TypeRef)
                => new Column(TypeRef);

            public static implicit operator Column(DATE TypeRef)
                => new Column(TypeRef);

            public Column(sxc.data_type_ref TypeRef)
            {
                this.TypeRef = TypeRef;
            }

            sxc.data_type_ref TypeRef { get; }
        }

        public class Column<C> : Column
            where C : sxc.data_type_ref
        {
            public static implicit operator Column<C>(C type_ref)
                => new Column<C>(type_ref);

            public Column(C c)
                : base(c)
            { }
        }


        public class Default<C> : SqlDefaultConstraint<T, Default<C>, C>
        {
            public Default(Expression<Func<T, C>> Column1, ISyntaxExpression Expression, SqlDefaultConstraintName DefaultConstraintName = null)
                : base(Column1, DefaultConstraintName)
            {
                this.Expression = Expression;
            }
            protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
                => rolist<ISqlConstraintColumn>();

            public ISyntaxExpression Expression { get; }
        }

        public new class PrimaryKey
        {
            public PrimaryKey(SqlPrimaryKey Definition)
            {
                this.Definition = Definition;
            }

            public SqlPrimaryKey Definition { get; }
        }

        public class PrimaryKey<C1> : SqlPrimaryKey<T, PrimaryKey<C1>, C1>
        {

            public static implicit operator PrimaryKey(PrimaryKey<C1> src)
                => new PrimaryKey(null);

            public PrimaryKey(Expression<Func<T, C1>> Column1, SqlPrimaryKeyName PrimaryKeyName = null)
                : base(Column1, PrimaryKeyName)
            {

            }

            protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
                => rolist<ISqlConstraintColumn>();
        }

        public class PrimaryKey<C1, C2> : PrimaryKey<C1>
        {

            public PrimaryKey(
                Expression<Func<T, C1>> Col1,
                Expression<Func<T, C2>> Col2,
                SqlPrimaryKeyName PrimaryKeyName = null)
                : base(Col1, PrimaryKeyName)
            {

            }

        }

        public class Index<C1> : SqlIndex<T, Index<C1>, C1>
        {
            public Index(Expression<Func<T, C1>> Col1)
                : base(Col1)
            {

            }

        }

        public class Index<C1, C2> : Index<C1>
        {
            public Index(
                Expression<Func<T, C1>> Col1,
                Expression<Func<T, C2>> Col2)
                : base(Col1)
            {
                this.Col2 = new SqlIndexColumn(Col2.GetValueMember().Name);
            }

            public SqlIndexColumn Col2 { get; }

        }

        public class Index<C1, C2, C3> : Index<C1, C2>
        {
            public Index(
                Expression<Func<T, C1>> Col1,
                Expression<Func<T, C2>> Col2,
                Expression<Func<T, C3>> Col3
                )
                : base(Col1, Col2)
            {
                this.Col3 = new SqlIndexColumn(Col3.GetValueMember().Name);
            }

            public SqlIndexColumn Col3 { get; }
        }

        public class ForeignKey
        {
            public static implicit operator ForeignKey(SqlForeignKey Definition)
                => new ForeignKey(Definition);


            public ForeignKey(SqlForeignKey Definition)
            {
                this.Definition = Definition;
            }

            public SqlForeignKey Definition { get; }
        }

        public class ForeignKey<M, TClient, TSupplier, C1, S1> : SqlForeignKey<M, TClient, TSupplier>
            where M : ForeignKey<M, TClient, TSupplier, C1, S1>
            where TClient : ISqlTable
            where TSupplier : ISqlTable

        {

            public ForeignKey(SqlForeignKeyName ForeginKeyName = null)
                : base(ForeginKeyName ?? SqlForeignKeyName.Parse(typeof(M).Name))
            {

            }
        }

        public class ForeignKey<TR1, C1, S1> : ForeignKey<ForeignKey<TR1, C1, S1>, T, TR1, C1, S1>
            where TR1 : ISqlTable
        {

            public static implicit operator ForeignKey(ForeignKey<TR1, C1, S1> fk)
                => new ForeignKey(null);

            public ForeignKey(
                Expression<Func<T, C1>> ClientCol1,
                Expression<Func<TR1, S1>> SupplierCol1,
                SqlForeignKeyName KeyName = null)

            {

            }
        }

        protected static ForeignKey<TR1, C1, S1> FK<TR1, C1, S1>(
            Expression<Func<T, C1>> ClientCol1,
            Expression<Func<TR1, S1>> SupplierCol1)
            where TR1 : ISqlTable
                => new ForeignKey<TR1, C1, S1>(ClientCol1, SupplierCol1);


        protected static PrimaryKey<C1> PK<C1>(
            Expression<Func<T, C1>> Col1)
            => new PrimaryKey<C1>(Col1);

        protected static PrimaryKey<C1, C2> PK<C1, C2>(
            Expression<Func<T, C1>> Col1,
            Expression<Func<T, C2>> Col2)
            => new PrimaryKey<C1, C2>(Col1, Col2);

        protected static Index<C1> INDEX<C1>(
            Expression<Func<T, C1>> Col1)
            => new Index<C1>(Col1);

        protected static Index<C1, C2> INDEX<C1, C2>(
            Expression<Func<T, C1>> Col1,
            Expression<Func<T, C2>> Col2)
            => new Index<C1, C2>(Col1, Col2);

        protected static Index<C1, C2, C3> INDEX<C1, C2, C3>(
            Expression<Func<T, C1>> Col1,
            Expression<Func<T, C2>> Col2,
            Expression<Func<T, C3>> Col3)
            => new Index<C1, C2, C3>(Col1, Col2, Col3);

        protected static Default<C> DEFAULT<C>(
            Expression<Func<T, C>> Col,
            ISyntaxExpression expression
            ) => new Default<C>(Col, expression);
    }

}