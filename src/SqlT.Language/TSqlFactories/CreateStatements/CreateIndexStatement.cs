//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public static partial class TSqlFactory
    {
        public static TSql.IndexTypeKind TSqlIndexType(this SqlIndex src)
        {
            if (not(src.Clustered) && src.ColumnStore)
                return TSql.IndexTypeKind.NonClusteredColumnStore;
            else if (src.Clustered && src.ColumnStore)
                return TSql.IndexTypeKind.ClusteredColumnStore;
            else if (src.Clustered)
                return TSql.IndexTypeKind.Clustered;
            else
                return TSql.IndexTypeKind.NonClustered;                
        }

        public static IEnumerable<TSql.ColumnReferenceExpression> TSqlIncludedColumns(this SqlIndex src)
            => from c in src.IncludedColumns
               select c.TSqlColumnRef();

        public static IEnumerable<TSql.ColumnWithSortOrder> TSqlPrimaryColumns(this SqlIndex src)
            => from c in src.PrimaryColumns
               select new TSql.ColumnWithSortOrder
            {
                Column = c.TSqlColumnRef(),
                SortOrder = c.Ascending
                               ? TSql.SortOrder.Ascending
                               : TSql.SortOrder.Descending
            };

        public static TSql.IndexDefinition TSqlDefine(this SqlIndex src)
        {
            var ix = new TSql.IndexDefinition
            {
                IndexType = new TSql.IndexType { IndexTypeKind = src.TSqlIndexType() },
                Name = src.IndexName.TSqlIdentifier(),
                Unique = src.Unique

            };
            ix.Columns.AddRange(src.TSqlPrimaryColumns());
            return ix;                            
        }


        [TSqlBuilder]
        public static TSql.CreateIndexStatement TSqlCreate(this SqlIndex src)
        {
            var idxName = src.IndexName.UnqualifiedName.TSqlIdentifier(true);

            var idx = new TSql.CreateIndexStatement()
            {
                Clustered = src.Clustered,
                OnName = src.TableName.TSqlSchemaObjectName(),
                Name = idxName,
                Unique = src.Unique,                
            };
            
           
            var cols = rolist(src.TSqlPrimaryColumns());
            idx.Columns.AddRange(cols);

            var inclusions = rolist(src.TSqlIncludedColumns());
            idx.IncludeColumns.AddRange(inclusions);

            return idx;

        }

    }
}