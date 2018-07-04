//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SqlT.Core;

    using static metacore;

    using sxc = Syntax.contracts;

    public abstract class SqlConstraint<T,N> : SqlObject<T,N>, sxc.constraint<N>
        where T : SqlConstraint<T,N>
        where N : SqlConstraintName<N>, new()
    {

        protected SqlConstraint(
            N ConstraintName,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
            ) : 
            base
            (
                ConstraintName,
                Documentation: Documentation,
                Properties: Properties
            )
        {



        }


        protected abstract IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns();

        public IReadOnlyList<ISqlConstraintColumn> ConstrainedColumns
            => GetConstrainedColumns();
        

        public override string ToString()
        {
            var count = ConstrainedColumns.Count;

            var sb = new StringBuilder();
            sb.Append(ObjectName.UnqualifiedName);
            sb.Append("(");
            sb.Append(string.Join(",", 
                map(ConstrainedColumns, c => c.ConstrainedColumn.Name.UnqualifiedName).ToArray()));
            sb.Append(")");
            return sb.ToString();
        }

        public virtual bool IsIdentifying
            => false;


    }
}
