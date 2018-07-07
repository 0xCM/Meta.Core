//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
