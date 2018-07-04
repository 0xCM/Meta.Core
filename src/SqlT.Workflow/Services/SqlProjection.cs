//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using System.Linq;

    using SqlT.Core;


    

    public class SqlProjection<TSrc, TDst> : ISqlProjection<TSrc, TDst>
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()

    {
        SqlInjector<TSrc, TDst> F;
        SqlSequenceInjector<TSrc, TDst> G;

        public SqlProjection(SqlInjector<TSrc, TDst> F)
        {
            this.F = F;
        }

        public SqlProjection(SqlSequenceInjector<TSrc, TDst> G)
        {
            this.G = G;
        }

        public IEnumerable<TDst> Push(IEnumerable<TSrc> src)
            => F != null ? from item in src select F(item) : G(src);

        IEnumerable<ISqlTabularProxy> ISqlProjection.Push(IEnumerable<ISqlTabularProxy> src)
            => F != null
            ? from TSrc item in src select F(item) as ISqlTabularProxy
            : from ISqlTabularProxy item in G(src.Cast<TSrc>()) select item;
    }


}
