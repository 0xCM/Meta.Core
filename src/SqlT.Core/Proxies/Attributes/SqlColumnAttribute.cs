//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public class SqlColumnAttribute : SqlProxyAttribute
    {

        public SqlColumnAttribute()
        {

        }

        public SqlColumnAttribute(int Position, string ColumnName)
        {
            this.ColumnName = ColumnName;
            this.Position = Position;
        }

        public SqlColumnAttribute(string ColumnName, int Position)
        {
            this.ColumnName = ColumnName;
            this.Position = Position;
        }

        public string ColumnName
        {
            get { return GetFacetValue<string>(nameof(ColumnName)); }
            set { SetFacetValue(nameof(ColumnName), value); }
        }

        public int Position
        {
            get { return GetFacetValue<int>(nameof(Position)); }
            set { SetFacetValue(nameof(Position), value); }
        }

        public override SqlProxyKind ProxyKind 
            => SqlProxyKind.Column;

        public override string ToString() 
            => $"{ColumnName} (1)";
    }
}