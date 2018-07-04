//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    using System.Collections.Concurrent;

    using SqlT.Core;
    using SqlT.Models;


    public class SqlDtoServices : ApplicationService<SqlDtoServices, ISqlDtoServices>, ISqlDtoServices
    {
        static ConcurrentDictionary<Type, ReadOnlyList<SqlColumnProperty>> ColumnIndex { get; }
            = new ConcurrentDictionary<Type, ReadOnlyList<SqlColumnProperty>>();

        static ReadOnlyList<SqlColumnProperty> ColumnProperties(Type DtoType)
        {
            return ColumnIndex.GetOrAdd(DtoType, t =>                            
                mapi(ClrType.Get(t).PublicInstanceProperties, (i,p) => new SqlColumnProperty(new SqlColumnIdentifier(p.Name, i), p))                
            );
        }

        static ReadOnlyList<SqlColumnProperty> ColumnProperties<T>()
            => ColumnProperties(typeof(T));


        static object[] GetDataRow(ReadOnlyList<SqlColumnProperty> columns, object item)
        {
            var row = new object[columns.Count];
            for (int i = 0; i < columns.Count; i++)
                row[i] = columns[i].Property.GetValue(item);
            return row;
        }

        static object FillDto(object dto, ReadOnlyList<SqlColumnProperty> columns, object[] row)
        {
            for (var i = 0; i < columns.Count; i++)
                columns[i].Property.SetValue(dto, row[i]);
            return dto;
        }

        static T FillDto<T>(T dto, ReadOnlyList<SqlColumnProperty> columns, object[] row)
        {
            for (var i = 0; i < columns.Count; i++)
                columns[i].Property.SetValue(dto, row[i]);
            return dto;
        }

        static object GetDto(Type DtoType, ReadOnlyList<SqlColumnProperty> columns, object[] row)
            => FillDto(Activator.CreateInstance(DtoType), columns, row);

        static T GetDto<T>(ReadOnlyList<SqlColumnProperty> columns, object[] row)
            where T : new()
            => FillDto(new T(), columns, row);

        public ISqlDataFrame ToFrame(Type DtoType, IEnumerable<object> items, bool PLL = false)
        {
            var columns = ColumnProperties(DtoType);
            var rows = map(items, item => GetDataRow(columns, item), PLL);
            return new SqlDataFrame(rolist(columns.Select(x => x.Column)), rows);
        }

        public ISqlDataFrame ToFrame<T>(IEnumerable<T> items, bool PLL = false)
            => ToFrame(typeof(T), items.Cast<object>(), PLL);

        public IEnumerable<object> FromFrame(Type DtoType, ISqlDataFrame frame, bool PLL)
        {
            var columns = ColumnProperties(DtoType);

            if (PLL)
                foreach (var row in frame.Rows.AsParallel())
                    yield return GetDto(DtoType, columns, row);
            else
                foreach (var row in frame.Rows)
                    yield return GetDto(DtoType, columns, row);

        }

        public IEnumerable<T> FromFrame<T>(ISqlDataFrame frame, bool PLL)
            where T : new()
        {
            var columns = ColumnProperties<T>();

            if(PLL)
                foreach (var row in frame.Rows.AsParallel())
                    yield return GetDto<T>(columns, row);
            else
                foreach (var row in frame.Rows)
                    yield return GetDto<T>(columns, row);
                                             
        }


    }



}