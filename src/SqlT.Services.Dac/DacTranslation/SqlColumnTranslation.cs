//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Services;

    using static metacore;

    /// <summary>
    /// Defines operations that manipulate and project column specification information between alternate representations
    /// </summary>
    public static class SqlColumnTranslation
    {
        [SqlTBuilder]
        public static SqlDataFacets SpecifyDataFacets(this DacX.TSqlTableTypeColumn dsql)
            => GetSqlDataFacets(dsql, dsql.DataType.Single());

        [SqlTBuilder]
        public static SqlDataFacets SpecifyDataFacets(this DacX.TSqlColumn dsql)
            => GetSqlDataFacets(dsql, dsql.DataType.Single());

        [SqlTBuilder]
        public static typeref SpecifyDataTypeReference(this DacX.TSqlColumn dsql)
        {
            //The column's type will not be known, for example, if computed
            var dtSource = dsql.DataType.FirstOrDefault();
            return dtSource != null ? new typeref
            (
                SqlDataTypes.Find(dtSource.Name.SpecifyDataTypeName()),
                Facets: dsql.SpecifyDataFacets()
            ) : SqlNativeTypes.unknown.Reference();

        }

        [SqlTBuilder]
        public static typeref SpecifyDataTypeReference(this DacX.TSqlTableTypeColumn dsql)
            => new typeref
            (
                SqlDataTypes.Find(dsql.DataType.Single().Name.SpecifyDataTypeName()),
                Facets: dsql.SpecifyDataFacets()
            );


        [SqlTBuilder]
        public static IReadOnlyList<SqlTableTypeColumn> SpecifyColumns(this DacX.TSqlTableType dsql)
        {
            var sqlcols = new List<SqlTableTypeColumn>();
            var pos = 0;
            foreach (var c in dsql.Columns)
            {
                sqlcols.Add(
                    new SqlTableTypeColumn
                    (
                        Position: pos++,
                        LocalName: c.GetLocalName(),
                        DataType: null
                    ));
            }
            return sqlcols;
        }

        [SqlTBuilder]
        public static IReadOnlyList<SqlTableColumn> SpecifyColumns(this DacX.TSqlTable dsql)
        {

            var sqlcols = new List<SqlTableColumn>();
            var pos = 0;
            foreach (var c in dsql.Columns)
            {
                var simpleName = c.GetLocalName();

                var dataType = c.SpecifyDataTypeReference();
                sqlcols.Add(new SqlTableColumn(simpleName, pos++,  dataType));

            }
            return sqlcols;
        }

        [SqlTBuilder]
        static SqlDataFacets GetSqlDataFacets(dynamic source, DacX.ISqlDataType dsql)
        {

            var intrinsicType = SqlNativeTypes.TryFind(
                t => t.Name == dsql.SpecifyTypeName()).ValueOrDefault();


            bool required = not(source.Nullable);
            if (intrinsicType != null)
            {

                var length = intrinsicType.CanSpecifyLength ? (int?)source.Length : null;
                var precision = intrinsicType.CanSpecifyPrecision ? (byte?)source.Precision : null;
                var scale = intrinsicType.CanSpecifyScale ? (byte?)source.Scale : null;
                return new SqlDataFacets(required, length, precision, scale);

            }
            else
            {
                var dtr = dsql as DacX.TSqlDataTypeReference;
                if (dtr != null)
                {
                    return new SqlDataFacets
                    (
                        IsValueRequired: required,
                        MaxLength: dtr.UddtLength != 0 ? dtr.UddtLength : (int?)null,
                        NumericPrecision: dtr.UddtPrecision != 0 ? (byte)dtr.UddtPrecision : (byte?)null,
                        NumericScale: dtr.UddtScale != 0 ? (byte)dtr.UddtScale : (byte?)null
                    );
                }

                return new SqlDataFacets(required);
            }

        }

    }
}