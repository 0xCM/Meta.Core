//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlIndexColumnAttribute : SqlProxyAttribute
    {
        public SqlIndexColumnAttribute()
        {

        }

        public SqlIndexColumnAttribute(string ReferencedColumnName, int ReferencedColumnPosition)
        {
            this.ReferencedColumnName = ReferencedColumnName;
            this.ReferencedColumnPosition = ReferencedColumnPosition;
        }

        public SqlIndexColumnAttribute(string ReferencedColumnName, int ReferencedColumnPosition, int IndexColumnPosition)
        {
            this.ReferencedColumnName = ReferencedColumnName;
            this.ReferencedColumnPosition = ReferencedColumnPosition;
            this.IndexColumnPosition = IndexColumnPosition;
        }


        /// <summary>
        /// The name of the column
        /// </summary>
        public string ReferencedColumnName
        {
            get { return GetFacetValue<string>(nameof(ReferencedColumnName)); }
            set { SetFacetValue(nameof(ReferencedColumnName), value); }
        }

        /// <summary>
        /// The position of the column in the table
        /// </summary>
        public int ReferencedColumnPosition
        {
            get { return GetFacetValue<int>(nameof(ReferencedColumnPosition)); }
            set { SetFacetValue(nameof(ReferencedColumnPosition), value); }
        }

        /// <summary>
        /// The position of the column in the index relative to other columns in the index
        /// </summary>
        public int IndexColumnPosition
        {
            get { return GetFacetValue<int>(nameof(IndexColumnPosition)); }
            set { SetFacetValue(nameof(IndexColumnPosition), value); }
        }

        public override SqlProxyKind ProxyKind
            => SqlProxyKind.IndexColumn;

        public override string ToString() 
            => ReferencedColumnName;

    }
}