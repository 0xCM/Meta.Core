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
    
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using B = SqlIndexBuilder;
    using static SqlModelBuilders;

    using static metacore;

    public static partial class SqlBuilderExtensions
    {
        public static SqlMessageDefinition DefineMessage(this SqlMessageIdentity msgid, SqlSeverityLevel severity,
            string msg, bool with_log = false)
                => new SqlMessageDefinition(msgid, msg, severity, with_log);

        public static string ConventionalPrefix(this SqlIndexType IndexType, bool IsUnique = false)
        {
            switch (IndexType)
            {
                case SqlIndexType.ClusteredColumnStore:
                    return "CCIX";
                case SqlIndexType.NonclusteredColumnStore:
                    return "NCIX";
                case SqlIndexType.Heap:
                case SqlIndexType.Clustered:
                case SqlIndexType.Nonclustered:
                case SqlIndexType.XML:
                case SqlIndexType.NonclusteredHash:
                case SqlIndexType.Spatial:
                default:
                    return IsUnique ? "UQIX" : "IX";
            }
        }

        const string Separator = "_";

        public static SqlIndexName ConventionalIndexName(this SqlTableName TableName, SqlIndexType IndexType, bool IsUnique = false)
            => new SqlIndexName(
                IndexType.ConventionalPrefix(IsUnique) +
                Separator +
                TableName.UnqualifiedName
                );

        public static SqlIndexName ConventionalIndexName(this SqlTableName TableName, SqlIndexType IndexType, SqlColumnName ColumnName, bool IsUnique = false)
            => new SqlIndexName(
                IndexType.ConventionalPrefix(IsUnique) +
                Separator +
                TableName.UnqualifiedName +
                Separator +
                ColumnName.UnqualifiedName
                );

        public static SqlIndexName ConventionalIndexName(this SqlTableName TableName, SqlIndexType IndexType, string Suffix, bool IsUnique = false)
            => new SqlIndexName(
                IndexType.ConventionalPrefix(IsUnique)
                + Separator
                + TableName.UnqualifiedName
                + (string.IsNullOrWhiteSpace(Suffix) ? string.Empty : Separator + Suffix)
                );

        public static B BuildIndexOn(this SqlTable table, SqlIndexName IndexName, params SqlTableColumn[] columns)
            => ~Index(IndexName, table.Name, array(columns.Names()));

        public static B BuildIndexOn(this SqlTable table, params SqlTableColumn[] columns)
            => ~Index($"IX_{table.LocalName}", table.Name, array(columns.Names()));
    }
}