//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;

    partial class TypeStructures
    {
        public abstract class TableType<T> : TabularObject<T, SqlTableType, SqlTableTypeName>, ITableType
            where T : TableType<T>, new()

        {           
            protected TableType()
            {
                            
            }
                  
            public override SqlTableType CreateModel()
            {

                var columns = mapi(RepresentedColumns, (i, r) => new SqlTableTypeColumn(DefineColumn(i, r)));
                return ~ from b in new SqlTableTypeBuilder(Name, Description).WithColumns(columns)
                        select b;

            }

            public override SqlTableTypeName Name
                => new SqlTableTypeName(SchemaName, GetType().Name);
        }

        public abstract class TableType<T2, T1> : TableType<T2>
            where T1 : TableType<T1>, new()
            where T2 : TableType<T2, T1>, new()

        {
            protected override IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T1, T2>().ToReadOnlyList();

            protected TableType()
                : base()
            {

            }
        }

        public abstract class TableType<T3, T2, T1> : TableType<T3>
            where T1 : TableType<T1>, new()
            where T2 : TableType<T2>, new()
            where T3 : TableType<T3, T2, T1>, new()

        {

            protected override IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T1, T2, T3>().ToReadOnlyList();

            protected TableType()
                : base()
            {

            }
        }

        public abstract class TableType<T4, T3, T2, T1> : TableType<T4>
            where T1 : TableType<T1>, new()
            where T2 : TableType<T2>, new()
            where T3 : TableType<T3>, new()
            where T4 : TableType<T4, T3, T2, T1>, new()

        {
            protected override IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T1, T2, T3, T4>().ToReadOnlyList();

            protected TableType()
                : base()
            {

            }
        }
    }
}