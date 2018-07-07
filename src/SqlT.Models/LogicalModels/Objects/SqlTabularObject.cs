//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    using static metacore;

    public abstract class SqlTabularObject<M> : SqlObject<M>, ISqlColumnProvider, ISqlTabularObject
        where M : SqlTabularObject<M>
    {
        protected SqlTabularObject(sxc.ISqlObjectName Name, SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null, bool IsIntrinsic = false)
                : base(Name, Documentation, Properties, IsIntrinsic)
        {

        }

        protected abstract IReadOnlyList<ISqlColumn> GetColumns();        

        IReadOnlyList<ISqlColumn> ISqlColumnProvider.Columns
            => GetColumns();

        IReadOnlyList<SqlColumnName> sxc.column_name_provider.ColumnNames
            => map(GetColumns(), c => c.Name);
    }

    public abstract class SqlTabularObject<M, N> : SqlTabularObject<M>
        where M : SqlTabularObject<M,N>
        where N : sxc.ISqlObjectName, new()
    {

        protected SqlTabularObject(
            N Name,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            bool IsIntrinsic = false
            )
            : base(Name, Documentation, Properties, IsIntrinsic)
        {
            this.Name = Name;
        }

        public N Name { get; }
    }
    
}
