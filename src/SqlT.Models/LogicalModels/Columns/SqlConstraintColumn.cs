//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{       
    /// <summary>
    /// Specifies a column referenced by a constraint
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlConstraintColumn<T> : SqlElement<T>, ISqlConstraintColumn
        where T : SqlConstraintColumn<T>
    {
        protected SqlConstraintColumn(ISqlColumn ConstrainedColumn)
            : base(ConstrainedColumn.Name)
        {
            this.ConstrainedColumn = ConstrainedColumn;
        }

        public ISqlColumn ConstrainedColumn { get; }

        public override string ToString()
            => ConstrainedColumn.ToString();
    }
}
