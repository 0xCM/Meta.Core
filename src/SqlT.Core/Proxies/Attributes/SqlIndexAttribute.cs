//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Applied to an index proxy to identify and describe it
    /// </summary>
    public class SqlIndexAttribute : SqlProxyAttribute
    {

        public SqlIndexAttribute(string ParentSchema, string ParentName, string IndexName, bool IsUnique)
        {
            this.ParentSchema = ParentSchema;
            this.ParentName = ParentName;
            this.IndexName = IndexName;
            this.IsUnique = IsUnique;
        }

        public override SqlProxyKind ProxyKind
            => SqlProxyKind.Index;

        /// <summary>
        /// The name of the schema in which the indexed table lives
        /// </summary>
        public string ParentSchema
        {
            get { return GetFacetValue<string>(nameof(ParentSchema)); }
            set { SetFacetValue(nameof(ParentSchema), value); }
        }
        
        /// <summary>
        /// The name of the table on which the index is defined
        /// </summary>
        public string ParentName
        {
            get { return GetFacetValue<string>(nameof(ParentName)); }
            set { SetFacetValue(nameof(ParentName), value); }
        }

        /// <summary>
        /// The name of the index
        /// </summary>
        public string IndexName
        {
            get { return GetFacetValue<string>(nameof(IndexName)); }
            set { SetFacetValue(nameof(IndexName), value); }
        }

        /// <summary>
        /// Specifies whether the index is unique
        /// </summary>
        public bool IsUnique
        {
            get { return GetFacetValue<bool>(nameof(IsUnique)); }
            set { SetFacetValue(nameof(IsUnique), value); }
        }

        public SqlTableName TableName
            => new SqlTableName(ParentSchema, ParentName);
    }
}