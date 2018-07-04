//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    using SqlT.Services;

    public sealed class SqlDomTypeCorrelations : TypedItemList<SqlDomTypeCorrelations, SqlDomTypeCorrelation>
    {
        IReadOnlyDictionary<string, SqlDomTypeCorrelation> index;

        public static implicit operator SqlDomTypeCorrelations(SqlDomTypeCorrelation[] correlations)
            => Create(correlations);

        public SqlDomTypeCorrelations() { }

        protected override void Filled()
        {
            index = this.ToDictionary(x => x.TSqlType.Name);
        }

        public new Option<SqlDomTypeCorrelation> TryFind(string TypeName)
            => index.TryFind(TypeName);
    }

}
