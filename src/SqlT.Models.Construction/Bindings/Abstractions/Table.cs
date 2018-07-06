//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlT.Syntax.sql;

    using sx = SqlT.Syntax.SqlSyntax;

    partial class TypeStructures
    {       
        public abstract class Table<T> : TabularObject<T, SqlTable, SqlTableName>, ITable
            where T : Table<T>, new()

        {
            protected Table()
            {

            }            

            protected virtual IEnumerable<ClrProperty> PrimaryKeyColumns
                => stream<ClrProperty>();

            protected SqlDefaultConstraint DefaultSequenceConstraint(Expression<Func<T, object>> Column, SqlSequenceName Sequence)
            {
                var col = SqlColumnName.Parse(Column.GetMember().Name);
                var name = SqlDefaultConstraint.ConventionalName(this.Name, Column.GetMember().Name);
                var expr = Sequence.NextValueFor().FormatSyntax();
                return new SqlDefaultConstraint(name, expr, col);
            }

            protected SqlDefaultConstraint DefaultTimestampContraint(Expression<Func<T, object>> Column)
            {
                var col = SqlColumnName.Parse(Column.GetMember().Name);
                var name = SqlDefaultConstraint.ConventionalName(this.Name, Column.GetMember().Name);
                var expr = getdate().FormatSyntax();
                return new SqlDefaultConstraint(name, expr, col);
            }

            protected SqlDefaultConstraint DefaultLiteralConstraint(Expression<Func<T, object>> Column, sx.scalar_value value)
            {
                var col = SqlColumnName.Parse(Column.GetMember().Name);
                var name = SqlDefaultConstraint.ConventionalName(this.Name, Column.GetMember().Name);
                var expr = value.FormatSyntax();
                return new SqlDefaultConstraint(name, expr, col);
            }


            public virtual IEnumerable<SqlDefaultConstraint> DefaultConstraints { get; }
                = stream<SqlDefaultConstraint>();

            public override SqlTable CreateModel()
            {
                var defaults = DefaultConstraints.ToDictionary(c => c.ConstrainedColumnName);                
                var columns = mapi(ColumnRepresentatives<T>(), (i, r) 
                        => new SqlTableColumn(DefineColumn(i, r, defaults.TryFind(r.ColumnName).ValueOrDefault())));
                return ~ from b in new SqlTableBuilder(Name, Description).WithColumns(columns)
                              from pk in b.WithPrimaryKey(PrimaryKeyColumns.Select(x => new SqlColumnName(x.Name)).ToArray())                              
                              select b.Complete();                
            }

            public override SqlTableName Name
                => new SqlTableName(SchemaName, GetType().Name);

        }

        public abstract class Table<T2, T1> : Table<T2>
            where T1 : TabularObject<T1, SqlTable>, new()
            where T2 : Table<T2, T1>, new()

        {
            protected override IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T1, T2>().ToReadOnlyList();

            protected Table()
                : base()
            {

            }
        }

        public abstract class SqlTemporalTable<T, S> : SqlTable<T, S>
            where T : SqlTemporalTable<T, S>, new()
            where S : SqlSchema<S>
        {

            protected SqlTemporalTable(S Schema)
                : base(Schema)
            {

            }

        }

        public abstract class Table<T3, T2, T1> : Table<T3>
            where T1 : TabularObject<T1,SqlTable>, new()
            where T2 : TabularObject<T2, SqlTable>, new()
            where T3 : Table<T3, T2, T1>, new()

        {
            protected override IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T1,T2,T3>().ToReadOnlyList();

            protected Table()
                : base()
            {

            }
        }

    }


}