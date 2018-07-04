//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Vocabulary;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Consolidates access to specification builders for ease-of-use
    /// </summary>
    
    [MonadicBuilderFactoryHost]
    public static partial class SqlModelBuilders
    {
        public static Builder<B> Lift<B>(B b) 
            where B : ISqlModelBuilder => b;

        /// <summary>
        /// Intantiates a Builderic <see cref="SqlMergeStatement"/> builder
        /// </summary>
        /// <typeparam name="TSrc">The source tabular</typeparam>
        /// <typeparam name="TDst">The target table</typeparam>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlMergeStatementBuilder<TSrc, TDst>> Merge<TSrc, TDst>(string SrcAlias, string DstAlias)
            where TSrc : class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new()
                => new SqlMergeStatementBuilder<TSrc, TDst>(SrcAlias,DstAlias);

        [MonadicBuilderFactory]
        public static Builder<SqlMergeStatementBuilder<TSrc, TDst>> Merge<TSrc, TDst>(params SqlMergeColumn[] matchcols)
            where TSrc : class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new()
            => from ms in Merge<TSrc, TDst>("Src", "Dst")
               from a in ms.Automap()
               from match in ms.Match(matchcols)
               select match;

        /// <summary>
        /// Intantiates a monadic <see cref="SqlMergeStatement"/> builder
        /// </summary>
        /// <param name="SourceType">The type of the tabular proxy source</param>
        /// <param name="TargetType">The type of the tabular proxy target</param>
        /// <param name="ApplyAutomap">Whether to define column mappings automatically based on name</param>
        /// <param name="WhenNotMatchedBySourceDelete"></param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlMergeStatementBuilder> Merge(Type SourceType, Type TargetType, 
            bool ApplyAutomap = true, bool WhenNotMatchedBySourceDelete = false)
                => new SqlMergeStatementBuilder(SourceType, TargetType, ApplyAutomap,WhenNotMatchedBySourceDelete);
               
        /// <summary>
        /// Instantiates a monadic builder that constructs <see cref="SqlProcedure"/> specifications
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlProcedureBuilder> Procedure(SqlProcedureName ProcedureName)
            => new SqlProcedureBuilder(ProcedureName);

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder"/> with the intent of defining an index
        /// </summary>
        /// <param name="IndexName">The name of the index that will be constructed</param>
        /// <param name="TableName">The table on which the index will be defined</param>
        /// <param name="columns">The primary columns of the index</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder> Index(SqlIndexName IndexName, SqlTableName TableName, params SqlColumnName[] columns)
            => new SqlIndexBuilder(IndexName, TableName, columns);

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder"/> with the intent of defining a unique index
        /// </summary>
        /// <param name="IndexName">The name of the index that will be constructed</param>
        /// <param name="TableName">The table on which the index will be defined</param>
        /// <param name="columns">The primary columns of the index</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder> UniqueIndex(SqlIndexName IndexName, SqlTableName TableName, params SqlColumnName[] columns)
            => new SqlIndexBuilder(IndexName, TableName, columns).Unique();

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder"/> with the intent of defining a clustered index
        /// </summary>
        /// <param name="IndexName">The name of the index that will be constructed</param>
        /// <param name="TableName">The table on which the index will be defined</param>
        /// <param name="columns">The primary columns of the index</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder> ClusteredIndex(SqlIndexName IndexName, SqlTableName TableName, params SqlColumnName[] columns)
            => new SqlIndexBuilder(IndexName, TableName, columns).Cluster();

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder"/> with the intent of defining a clustered columnstore index
        /// </summary>
        /// <param name="IndexName">The name of the index that will be constructed</param>
        /// <param name="TableName">The table on which the index will be defined</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlColumnStoreIndexBuilder> ClusteredColumStoreIndex(SqlIndexName IndexName, SqlTableName TableName)
            => new SqlColumnStoreIndexBuilder(IndexName, TableName);

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder"/> with the intent of defining a nonclustered columnstore index
        /// </summary>
        /// <param name="IndexName">The name of the index that will be constructed</param>
        /// <param name="TableName">The table on which the index will be defined</param>
        /// <param name="columns">The primary columns of the index</param>
        /// <returns></returns>
        public static Builder<SqlColumnStoreIndexBuilder> NonClusteredColumnStoreIndex(SqlIndexName IndexName, SqlTableName TableName, params SqlColumnName[] columns)
            => new SqlColumnStoreIndexBuilder(IndexName, TableName, false, columns);

        /// <summary>
        /// Instantiates a builder that constructs <see cref="SqlIndex"/> specifications
        /// </summary>
        /// <typeparam name="P">The table to which the index applies</typeparam>
        /// <param name="IndexName">The name of the index</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> Index<P>(SqlIndexName IndexName)
            where P : ISqlTableProxy, new()
            => new SqlIndexBuilder<P>(IndexName);

        /// <summary>
        /// Creates a <see cref="SqlIndexBuilder{P}"/> initialized with 0 or more primary columns
        /// </summary>
        /// <typeparam name="P">The table to which the index applies</typeparam>
        /// <param name="selectors">The selectors that identify the primary kindex columns</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> Index<P>(params Expression<Func<P, object>>[] selectors)
            where P : ISqlTableProxy, new()
            => new SqlIndexBuilder<P>(selectors);

        /// <summary>
        /// Instantiates a <see cref="SqlIndexBuilder{P}"/> initialized with a name and 0 or more primary columns
        /// </summary>
        /// <typeparam name="P">The table to which the index applies</typeparam>
        /// <param name="IndexName">The name of the index</param>
        /// <param name="selectors">Identifies the primary index columns</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> Index<P>(SqlIndexName IndexName, params Expression<Func<P, object>>[] selectors)
            where P : ISqlTableProxy, new()
            => new SqlIndexBuilder<P>(IndexName).OnColumns(selectors);

        /// <summary>
        /// Instantiates a <see cref="SqlIndexBuilder{P}"/> that constructs a unique index
        /// </summary>
        /// <typeparam name="P">The table to which the index applies</typeparam>
        /// <param name="IndexName">The name of the index</param>
        /// <returns></returns>
        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> UniqueIndex<P>(SqlIndexName IndexName)
            where P : ISqlTableProxy, new()
            => new SqlIndexBuilder<P>(IndexName).Unique();

        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> UniqueIndex<P>(params Expression<Func<P, object>>[] selectors)
            where P : ISqlTableProxy, new()
            => new SqlIndexBuilder<P>(selectors).Unique();

        [MonadicBuilderFactory]
        public static Builder<SqlIndexBuilder<P>> UniqueIndex<P>(SqlIndexName IndexName, params Expression<Func<P, object>>[] selectors)
            where P : ISqlTableProxy, new()
                => from i in new SqlIndexBuilder<P>(selectors).Unique()
                   from c in i.OnColumns(_ => selectors)
                   select c;        

        [MonadicBuilderFactory]
        public static Builder<SqlTableTypeBuilder> TableType(SqlTableTypeName TypeName, string documenation = null)
            => new SqlTableTypeBuilder(TypeName, documenation);

        [MonadicBuilderFactory]
        public static Builder<SqlTableTypeBuilder> TableType<P>(SqlTableTypeName TypeName, string documenation = null)
            where P : ISqlTabularProxy, new()
            => new SqlTableTypeBuilder<P>(TypeName, documenation);

        [MonadicBuilderFactory]
        public static Builder<SqlTableTypeBuilder> CombinedType<H,T>(SqlTableTypeName TypeName, string documenation = null)
            where H : ISqlTabularProxy, new()
            where T : ISqlTabularProxy, new()               
            => new SqlTableTypeBuilder<H>(TypeName, documenation).WithColumns<T>();

        [MonadicBuilderFactory]
        public static Builder<SqlTableTypeBuilder> TableType(SqlTableTypeName TypeName, IEnumerable<SqlTableTypeColumn> Columns)
            => new SqlTableTypeBuilder(TypeName, Columns);

        [MonadicBuilderFactory]
        public static Builder<SqlAlterIndexBuilder> AlterIndex(SqlTableName TableName, SqlIndexName IndexName, SqlAlterIndexAction AlterAction)
            => new SqlAlterIndexBuilder(TableName, IndexName, AlterAction);

        [MonadicBuilderFactory]
        public static Builder<SqlAlterIndexBuilder> RebuildIndex(SqlTableName TableName, SqlIndexName IndexName)
            => new SqlAlterIndexBuilder(TableName, IndexName, SqlAlterIndexAction.Rebuild);

        [MonadicBuilderFactory]
        public static Builder<SqlAlterIndexBuilder> DisableIndex(SqlTableName TableName, SqlIndexName IndexName)
            => new SqlAlterIndexBuilder(TableName, IndexName, SqlAlterIndexAction.Disable);

        [MonadicBuilderFactory]
        public static Builder<SqlTableBuilder> Table(SqlTableName TableName, SqlElementDescription Description = null)
            => new SqlTableBuilder(TableName, Description);

        [MonadicBuilderFactory]
        public static Builder<SqlTableBuilder<P>> Table<P>(SqlTableName TableName, SqlElementDescription Description = null)
            where P : ISqlTabularProxy, new()
            => new SqlTableBuilder<P>(TableName, Description);

        [MonadicBuilderFactory]
        public static Builder<SqlSynonymBuilder> Synonym(SqlSynonymName SynonymName)
            => new SqlSynonymBuilder(SynonymName);

        [MonadicBuilderFactory]
        public static Builder<SqlSequence> IntSequence(SqlSequenceName name, int initialValue = 1, int increment = 1, int cacheSize = 10)
            => SqlSequenceBuilder.CreateIntSequence(name, initialValue, increment, cacheSize);

        [MonadicBuilderFactory]
        public static Builder<SqlSequence> BigIntSequence(SqlSequenceName name, long initialValue = 1, long increment = 1, int cacheSize = 10)
            => SqlSequenceBuilder.CreateBigIntSequence(name, initialValue, increment, cacheSize);

        [MonadicBuilderFactory]
        public static Builder<SqlDropSequence> DropSequence(SqlSequenceName SequenceName, bool CheckExistence = true)
            => new SqlDropSequenceBuilder(SequenceName, CheckExistence).Complete();

        [MonadicBuilderFactory]
        public static Builder<SqlDropTable> DropTable(SqlTableName TableName, bool CheckExistence = true)
            => new SqlDropTableBuilder(TableName, CheckExistence).Complete();

        [MonadicBuilderFactory]
        public static Builder<SqlTransactionBlockBuilder> TransactionBlock(params sxc.statement[] Statements)
            => new SqlTransactionBlockBuilder(Statements);

        [MonadicBuilderFactory]
        public static Builder<SqlTransactionBlockBuilder> TransactionBlock(IEnumerable<sxc.statement> Statements, SqlTransactionName TransactionName = null)
            => new SqlTransactionBlockBuilder(Statements, TransactionName);

        [MonadicBuilderFactory]
        public static Builder<SqlSelectBuilder<P>> Select<P>()
            where P : ISqlTabularProxy, new()
                => new SqlSelectBuilder<P>();

        [MonadicBuilderFactory]
        public static Builder<SqlSelectBuilder> SelectFrom(SqlTableName source, params SqlColumnName[] columns)
            => new SqlSelectBuilder(source, columns);

        [MonadicBuilderFactory]
        public static Builder<SqlSelectBuilder> SelectFrom(SqlViewName source, params SqlColumnName[] columns)
            => new SqlSelectBuilder(source, columns);

        public static SqlColumnProxySelection Selection(this SqlColumnProxyInfo c)
            => new SqlColumnProxySelection(c);
    }
}
