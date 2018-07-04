//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SqlT.Core;

    public sealed class SqlColumnInterval<T> 
        where T : struct, IComparable
    {

        public SqlColumnInterval(SqlColumnName ColumnName, T Min, T Max, bool MinInclusive = true, bool MaxInclusive = true)
        {
            this.ColumnName = ColumnName;
            this.Min = Min;
            this.Max = Max;
            this.MinInclusive = MinInclusive;
            this.MaxInclusive = MaxInclusive;

        }

        public SqlColumnName ColumnName { get; }

        public bool MinInclusive { get; }

        public bool MaxInclusive { get; }

        public T Min { get; }

        public T Max { get; }

        public bool IsClosed
            => MinInclusive && MaxInclusive;

    }
}
