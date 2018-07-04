//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;

    using static metacore;
    using static SqlProxyMetadataProvider;

    using D = SqlTableDocumentation;
    using N = SqlTableName;

    /// <summary>
    /// Produces a <see cref="D"/> value as specified by the builder operations
    /// </summary>
    public class SqlTableDocumentationBuilder<T> 
        : SqlObjectDocumentationBuilder<SqlTableDocumentationBuilder<T>, T, D, N>, ISqlTableDocumentationBuilder
            where T : ISqlTableProxy, new()
    {
        public static implicit operator SqlTableProxyDocumentation(SqlTableDocumentationBuilder<T> builder)
            => builder.Documentation;

        public static implicit operator D(SqlTableDocumentationBuilder<T> builder)
            => builder.Documentation.Documentation;

        static SqlTableProxyInfo TableProxy = ProxyMetadata<T>().Table<T>();

        public SqlTableDocumentationBuilder(string Label, string Description, string Identifier)
            : base(new D(TableProxy.ObjectName, Label, Description, Identifier))
        {
                    
        }

        public SqlTableDocumentationBuilder<T> WithColumn<C>(Expression<Func<T, C>> selector, 
            string Label, string Descripion, string SampleValues = null)
        {
            var member = selector.GetMember().Name;
            var column = TableProxy.Columns.FirstOrDefault(c => c.RuntimeName == member);
            if (column == null)
                throw new ArgumentException($"No column corresponding to {member} could be found");

            ElementDocumentation.DocumentColumn(new SqlColumnDocumentation(column.ColumnName, Label, Descripion)
            {
                Position = column.Position,
                ValueRequired = column.SqlType.IsNullable ?? true,
                DataTypeName = column.SqlType.TypeName,
            });

            return this;
        }

        public SqlTableDocumentationBuilder<T> WithColumns(params SqlColumnDocumentation[] columns)
        {
            ElementDocumentation.DocumentColumns(columns);
            return this;
        }

        public SqlTableDocumentationBuilder<T> WithColumnGroup(string GroupName, 
            params SqlColumnName[] Columns)
        {
            ElementDocumentation.DefineColumnGroup(GroupName, Columns);
            return this;
        }

        public SqlTableDocumentationBuilder<T> WithColumnGroup(SqlColumnGroupKind GroupKind, 
            params SqlColumnName[] Columns)
        {
            ElementDocumentation.DefineColumnGroup(GroupKind, Columns);
            return this;
        }

        /// <summary>
        /// Classifies an index as a natural key
        /// </summary>
        /// <typeparam name="U">The index type</typeparam>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithNaturalKey<U>()
            where U : SqlIndexProxy<T>, new()

        {
            var idxProxy = TableProxy.Indexes.Single(x => x.RuntimeType == typeof(U));
            var idxCols = array(idxProxy.IndexColumns.OrderBy(x => x.IndexColumnPosition).Select(x => x.ColumnName));
            ElementDocumentation.DefineColumnGroup(SqlColumnGroupKind.NaturalKey, idxCols);
            return this;
        }

        /// <summary>
        /// Defines a named column group
        /// </summary>
        /// <param name="GroupName">The group name</param>
        /// <param name="selection">The columns included by the group</param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithColumnGroup(string GroupName, 
            params Expression<Func<T,object>>[] selection)
        {
            var names = selection.Select(c => new SqlColumnName(c.SelectedPropertyName())).ToArray();
            return WithColumnGroup(GroupName, names);            
        }

        /// <summary>
        /// Defines a classified column group
        /// </summary>
        /// <param name="GroupKind">The group classification</param>
        /// <param name="selection">The columns included by the group</param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithColumnGroup(SqlColumnGroupKind GroupKind, 
            params Expression<Func<T, object>>[] selection)
        {
            var names = selection.Select(c => new SqlColumnName(c.SelectedPropertyName())).ToArray();
            return WithColumnGroup(GroupKind, names);
        }

        /// <summary>
        /// Describes a column that plays a specific infrastructure role
        /// </summary>
        /// <typeparam name="C">The member type</typeparam>
        /// <param name="selector">Selects the column to describe</param>
        /// <param name="RoleType">Specifies the column's role</param>
        /// <param name="Label"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithColumn<C>(Expression<Func<T, C>> selector, 
            SqlColumnRoleType RoleType, string Label = null, string Description = null, string Identifier = null)            
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            ElementDocumentation.DocumentColumn(new SqlColumnDocumentation(column.ColumnName, RoleType)
            {
                Label = Label ?? column.ColumnName,
                Description = Description ?? String.Empty,                
                Position = column.Position,
                ValueRequired = column.SqlType.IsNullable ?? true,
                DataTypeName = column.SqlType.TypeName,
                Identifier = Identifier ?? column.ColumnName
            });

            return this;
        }

        public SqlTableDocumentationBuilder<T> WithColumn(SqlColumnRole ColumnRole, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByColumnName(ColumnRole.Column);
            ElementDocumentation.DocumentColumn(new SqlColumnDocumentation(column.ColumnName, ColumnRole.RoleType)
            {
                Label = Label ?? column.ColumnName,
                Description = Description ?? String.Empty,
                Position = column.Position,
                ValueRequired = column.SqlType.IsNullable ?? true,
                DataTypeName = column.SqlType.TypeName,
                Identifier = Identifier ?? column.ColumnName

            });
            return this;
        }

        public SqlTableDocumentationBuilder<T> WithCreateTimeColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.CreateTimeRole),
                Label: Label ?? "Create Time",
                Description: Description ?? "The time at which the record was created"
                );                
        }

        public SqlTableDocumentationBuilder<T> WithCreateUserColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.CreateUserRole),
                Label: Label ?? "Creator",
                Description: Description ?? "Identifies the user that created the record"
                );
        }

        public SqlTableDocumentationBuilder<T> WithUpdateTimeColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.UpdateTimeRole),
                Label: Label ?? "Last Update Time",
                Description: Description ?? "The time at which the record was was last updated"
                );
        }

        public SqlTableDocumentationBuilder<T> WithUpdateUserColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.UpdateUserRole),
                Label: Label ?? "Modifier",
                Description: Description ?? "Identifies the user that last updated the record"
                );
        }

        public SqlTableDocumentationBuilder<T> WithSystemVersionColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.SystemVersionRole),
                Label: Label ?? "Last Update Time",
                Description: Description ?? "The record version number as assigned by the system"
                );
        }

        public SqlTableDocumentationBuilder<T> WithSequentalSurrogateColumn<C>(Expression<Func<T, C>> selector, 
            string Label = null, string Description = null, string Identifier = null)
        {
            var column = TableProxy.FindColumnByRuntimeName(selector.GetMember().Name);
            return WithColumn(
                ColumnRole: new SqlColumnRole(column.ColumnName, SqlColumnRoleTypes.SequentialKeyRole),
                Label: Label ?? "Record Sequence Number",
                Description: Description ?? "A value taken from a strictly increasing sequence that uniquely identifies the record in the table"
                );
        }

        public SqlTableDocumentationBuilder<T> IdentifyAs(string TableIdentifier)
        {
            ElementDocumentation.Identifier = TableIdentifier;
            return this;
        }

        public SqlTableDocumentationBuilder<T> WithIgnoredColumns(params Expression<Func<T, object>>[] selectors)
        {
            var docs = from column in selectors.Select(s => TableProxy.FindColumnByRuntimeName(s.GetValueMember().Name))
                        select new SqlColumnDocumentation(column.ColumnName, SqlColumnRoleTypes.Ignored);
            ElementDocumentation.DocumentColumns(docs.ToArray());
            return this;
        }

        /// <summary>
        /// Documents a column
        /// </summary>
        /// <typeparam name="C">The column's property type</typeparam>
        /// <param name="selector">Identifies the column to be documented</param>
        /// <param name="column">Documents the column</param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithColumn<C>(Expression<Func<T, C>> selector, 
            SqlColumnDocumentation column)
        {
            ElementDocumentation.DocumentColumn(column);
            return this;
        }

        /// <summary>
        /// Classifies the table as a reference table
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="dataInModelDb"></param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> IsReferenceTable(bool defaultValue = true, bool dataInModelDb = false)
        {
            ElementDocumentation.IsReferenceTable = defaultValue;
            ElementDocumentation.ReferenceDataInModel = dataInModelDb;
            return this;
        }

        /// <summary>
        /// Documents a relationship 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="Description"></param>
        /// <param name="TCol1"></param>
        /// <param name="SCol1"></param>
        /// <returns></returns>
        public SqlTableDocumentationBuilder<T> WithRelation<S>(
            string Description, 
            Expression<Func<T, object>> TCol1, 
            Expression<Func<S, object>> SCol1
            )
        {
            //TODO: complete
            return this;
        }

        /// <summary>
        /// Specifies the constructed documentation
        /// </summary>
        public SqlTableProxyDocumentation Documentation
            => new SqlTableProxyDocumentation(TableProxy, ElementDocumentation);

        /// <summary>
        /// Specifies the name of the table being documented
        /// </summary>
        public string TableName
            => ElementDocumentation.Name;
    }
}