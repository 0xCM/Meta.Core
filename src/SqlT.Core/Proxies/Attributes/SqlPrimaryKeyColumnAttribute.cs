//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlPrimaryKeyColumnAttribute : SqlProxyAttribute
    {
        public SqlPrimaryKeyColumnAttribute()
        {

        }

        public SqlPrimaryKeyColumnAttribute(string ReferencedColumnName, int ReferencedColumnPosition)
        {
            this.ReferencedColumnName = ReferencedColumnName;
            this.ReferencedColumnPosition = ReferencedColumnPosition;
        }

        public SqlPrimaryKeyColumnAttribute(string ReferencedColumnName, int ReferencedColumnPosition, int KeyColumnPosition)
        {
            this.ReferencedColumnName = ReferencedColumnName;
            this.ReferencedColumnPosition = ReferencedColumnPosition;
            this.KeyColumnPosition = KeyColumnPosition;            
        }

        /// <summary>
        /// The name of the column being included in the primary key
        /// </summary>
        public string ReferencedColumnName
        {
            get { return GetFacetValue<string>(nameof(ReferencedColumnName)); }
            set { SetFacetValue(nameof(ReferencedColumnName), value); }
        }

        /// <summary>
        /// The ordinal postion of the column in the table on which the key is defined
        /// </summary>
        public int ReferencedColumnPosition
        {
            get { return GetFacetValue<int>(nameof(ReferencedColumnPosition)); }
            set { SetFacetValue(nameof(ReferencedColumnPosition), value); }
        }

        /// <summary>
        /// The position of the column relative to other primary key column
        /// </summary>
        public int KeyColumnPosition
        {
            get { return GetFacetValue<int>(nameof(KeyColumnPosition)); }
            set { SetFacetValue(nameof(KeyColumnPosition), value); }
        }

        public override SqlProxyKind ProxyKind
            => SqlProxyKind.PrimaryKeyColumn;

        public override string ToString() 
            => ReferencedColumnName;

    }
}