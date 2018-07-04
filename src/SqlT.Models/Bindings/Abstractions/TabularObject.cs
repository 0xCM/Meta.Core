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
    using System.ComponentModel;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;
 
    partial class TypeStructures
    {

        static IEnumerable<ColumnRepresentative> ColumnRepresentatives<T>()
            where T : ITabularObject, new()
            => from r in stream(new T())
               from c in ClrClass.Get<T>().PublicInstanceProperties
               where c.PropertyType.Realizes<sxc.data_type_ref>()
               select new ColumnRepresentative(r, c);

        static IEnumerable<ColumnRepresentative> ColumnRepresentatives<T2,T1>()
            where T1 : ITabularObject, new()
            where T2 : ITabularObject, new()
            => 
                from c in stream(
                    ColumnRepresentatives<T2>(),
                    ColumnRepresentatives<T1>()
                )

               select c;

        static IEnumerable<ColumnRepresentative> ColumnRepresentatives<T3, T2, T1>()
            where T1 : ITabularObject, new()
            where T2 : ITabularObject, new()
            where T3 : ITabularObject, new()
            => from c in stream(
                    ColumnRepresentatives<T3>(),
                    ColumnRepresentatives<T2,T1>()
                )                                    
               
               select c;

        static IEnumerable<ColumnRepresentative> ColumnRepresentatives<T4, T3, T2, T1>()
            where T1 : ITabularObject, new()
            where T2 : ITabularObject, new()
            where T3 : ITabularObject, new()
            where T4 : ITabularObject, new()
            => from c in stream(
                    ColumnRepresentatives<T4>(),
                    ColumnRepresentatives<T3, T2, T1>()
                )
               select c;

        public abstract class TabularObject<T, M, N> : ObjectStructure<T, M, N>, ITabularObject<N>
            where N : sxc.ISqlObjectName
            where T : TabularObject<T,M, N>, new()
            where M : ISqlTabularObject
        {
            protected TabularObject()
            {
                
            }

            protected virtual IReadOnlyList<ColumnRepresentative> RepresentedColumns
                => ColumnRepresentatives<T>().ToReadOnlyList();


            protected SqlColumnDefinition DefineColumn(int Position, ColumnRepresentative Representative, SqlDefaultConstraint @default = null)
                => new SqlColumnDefinition(
                    Position: Position,
                    Name: Representative.ColumnName,
                    DataType: Representative.GetValue<sxc.data_type_ref>(),
                    Default: @default,
                    Documentation: Representative.Description
                    );
        }


        public abstract class TabularObject<T, M> : TabularObject<T, M, sxc.tabular_name>
            where T : TabularObject<T, M>, new()
            where M : ISqlTabularObject
        {

            protected TabularObject()
            {

            }

        }


    }


}