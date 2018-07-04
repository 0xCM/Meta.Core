//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public class SqlIndexIncludeColumnAttribute : SqlProxyAttribute
    {
        public SqlIndexIncludeColumnAttribute()
        {

        }

        public SqlIndexIncludeColumnAttribute(string ColumnName, int KeyPosition)
        {
            this.ColumnName = ColumnName;
            this.ColumnPosition = KeyPosition;
        }

        /// <summary>
        /// The name of the column
        /// </summary>
        public string ColumnName
        {
            get { return GetFacetValue<string>(nameof(ColumnName)); }
            set { SetFacetValue(nameof(ColumnName), value); }
        }

        /// <summary>
        /// The relative position of the column in the include list
        /// </summary>
        public int ColumnPosition
        {
            get { return GetFacetValue<int>(nameof(ColumnPosition)); }
            set { SetFacetValue(nameof(ColumnPosition), value); }
        }

        public override SqlProxyKind ProxyKind
            => SqlProxyKind.IndexIncludeColumn;

        public override string ToString()
            => ColumnName;

    }
}