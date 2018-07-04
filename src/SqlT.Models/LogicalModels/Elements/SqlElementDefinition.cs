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

    using SqlT.Core;
    using SqlT.Syntax;


    using static metacore;


    public abstract class SqlElementDefinition<M, N> : SqlModelDefinition<M>
        where M : SqlElementDefinition<M, N>, new()
        where N : SqlName<N>, new()
    {
        protected SqlElementDefinition()
        {

        }

        protected SqlElementDefinition(N Name = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            bool IsIntrinsic = false
            ) : base(IsIntrinsic)
        {

            this.Name = Name ?? new N();
            this.Documentation = ifNull(Documentation, () => SqlElementDescription.Empty);
            this.Properties = Properties?.ToList() ?? new List<SqlPropertyAttachment>();
        }

        public N Name { get; set; }

        public Option<SqlElementDescription> Documentation { get; set; }

        public List<SqlPropertyAttachment> Properties { get; set; }
    }
}