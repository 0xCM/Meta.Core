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
    using SqlT.Core;
   
    using static metacore;
    using sxc = SqlT.Syntax.contracts;
    using static SqlT.Core.SqlProxyMetadataProvider;

    /// <summary>
    /// Implements builder pattern that facilitates merge statement construction
    /// </summary>
    public sealed class SqlMergeStatementBuilder : SqlModelBuilder<SqlMergeStatement>
    {

        readonly Dictionary<string, SqlMergeColumn> ColumnMappings = new Dictionary<string, SqlMergeColumn>();

        Type SourceType { get; }

        SqlTableTypeName SourceTypeName { get; }

        SqlVariableName SourceName { get; set; }

        Type TargetType { get; }
                 
        string SourceAlias { get; set; }

        sxc.tabular_name TargetName { get; set; }

        string TargetAlias { get; set; }

        bool HoldLock { get; set; }

        bool WhenNotMatchedBySourceDelete { get; set; }

        public SqlMergeStatementBuilder(Type SourceType, Type TargetType, bool ApplyAutomap = true,bool WhenNotMatchedBySourceDelete = false)
        {

            this.SourceType = SourceType;
            this.SourceName = new SqlVariableName("Records");
            this.SourceTypeName = PXM.TableTypeName(SourceType);
            this.SourceAlias = SourceAlias ?? "Src";
            this.WhenNotMatchedBySourceDelete = WhenNotMatchedBySourceDelete;
            this.TargetType = TargetType;
            this.TargetName = PXM.TabularName(TargetType);
            this.TargetAlias = TargetAlias ?? "Dst";
            this.HoldLock = true;
            if (ApplyAutomap)
                this.Automap();
        }        

        public Builder<SqlMergeStatementBuilder> Automap()
        {
            var srccols = PXM.Tabular(SourceType).Columns.ToDictionary(x => x.RuntimeName);
            var dstcols = PXM.Tabular(TargetType).Columns.ToDictionary(x => x.RuntimeName);
            foreach (var dstcol in dstcols)
            {
                srccols.TryFind(dstcol.Key).OnSome(srccol =>
                    ColumnMappings[srccol.RuntimeName] = (new SqlMergeColumn(srccol.Selection(), dstcol.Value.Selection())));
            }

            return this;
        }

        public override SqlMergeStatement Complete()
        {
            return new SqlMergeStatement(
                SourceName,
                SourceAlias,
                TargetName,
                TargetAlias,
                HoldLock,
                WhenNotMatchedBySourceDelete,
                ColumnMappings.Values.ToArray()
                );
        }

        public Builder<SqlMergeStatementBuilder> Match(params SqlMergeColumn[] mappings)
        {
            iter(mappings, mapping => ColumnMappings[mapping.SourceColumn.RuntimeName] = mapping);
            return this;
        }

        public Builder<SqlMergeStatementBuilder> Map(ClrPropertyName SrcProp, ClrPropertyName DstProp, bool match = false)
        {
            var srcCol = PXM.Column(SourceType, SrcProp);
            var dstCol = PXM.Column(TargetType, DstProp);
            ColumnMappings[srcCol.RuntimeName] = (new SqlMergeColumn(srcCol.Selection(), dstCol.Selection(), match));
            return this;
        }


    }

    /// <summary>
    /// Impelements builder idiom for <see cref="SqlMergeStatement"/> items
    /// </summary>
    /// <typeparam name="TSrc">The proxy type that represents the characteristics of the source data</typeparam>
    /// <typeparam name="TDst">The proxy type that represents the characteristics of the target table</typeparam>
    public sealed class SqlMergeStatementBuilder<TSrc,TDst> : SqlModelBuilder<SqlMergeStatement>
        where TSrc : class, ISqlTabularProxy,new()
        where TDst : class, ISqlTabularProxy,new()
    {

        readonly Dictionary<string, SqlMergeColumn> ColumnMappings = new Dictionary<string, SqlMergeColumn>();

        SqlName SourceName { get; }

        string SourceAlias { get; }

        sxc.tabular_name TargetName { get; }

        string TargetAlias { get; }

        bool HoldLock { get; }

        bool WhenNotMatchedBySourceDelete { get; set; }

        public SqlMergeStatementBuilder(string SourceAlias = null, string TargetAlias = null)
        {
            
            this.SourceName = new SqlVariableName("Records");
            this.SourceAlias = SourceAlias ?? "Src";
            this.TargetName = ProxyMetadata<TDst>().Tabular<TDst>().ObjectName;
            this.TargetAlias = TargetAlias ?? "Dst";
            this.HoldLock = true;
        }     

        public Builder<SqlMergeStatementBuilder<TSrc, TDst>> Automap()
        {
            var srccols = PXM.Tabular<TSrc>().Columns.ToDictionary(x => x.RuntimeName);
            var dstcols = PXM.Tabular<TDst>().Columns.ToDictionary(x => x.RuntimeName);
            foreach (var dstcol in dstcols)
            {
                srccols.TryFind(dstcol.Key).OnSome(srccol => 
                    ColumnMappings[srccol.RuntimeName] = (new SqlMergeColumn(srccol.Selection(), dstcol.Value.Selection())));
            }

            return this;
        }

        
        public Builder<SqlMergeStatementBuilder<TSrc,TDst>> Map<K>(Expression<Func<TSrc,K>> src, Expression<Func<TDst, K>> dst, bool match = false)
        {            
            var srcCol = PXM.Column<TSrc>(src.GetValueMember().Name);
            var dstCol = PXM.Column<TDst>(dst.GetValueMember().Name);
            ColumnMappings[srcCol.RuntimeName] = (new SqlMergeColumn(srcCol.Selection(), dstCol.Selection(), match));
            return this;
        }

        public Builder<SqlMergeStatementBuilder<TSrc, TDst>> Match<K>(Expression<Func<TSrc, K>> src, Expression<Func<TDst, K>> dst)
            => Map(src, dst, true);

        public Builder<SqlMergeStatementBuilder<TSrc, TDst>> Match(params SqlMergeColumn[] mappings)
        {
            iter(mappings, mapping => ColumnMappings[mapping.SourceColumn.RuntimeName] = mapping);
            return this;
        }

        public override SqlMergeStatement Complete()
        {
            return new SqlMergeStatement(
                SourceName, 
                SourceAlias, 
                TargetName, 
                TargetAlias, 
                HoldLock,
                WhenNotMatchedBySourceDelete,
                ColumnMappings.Values.ToArray()
                );
        }

    }
}
